using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuinAppApi.Models;

namespace TuinAppApi.Data.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private readonly TuinDbContext _context;
        private readonly DbSet<Gebruiker> _gebruikers;

        public GebruikerRepository(TuinDbContext dbContext)
        {
            _context = dbContext;
            _gebruikers = dbContext.Gebruikers;
        }
        public void Add(Gebruiker gebruiker)
        {
            _gebruikers.Add(gebruiker);
        }

        public Gebruiker GetBy(string email)
        {
            return _gebruikers.Include(g => g.Favorites).ThenInclude(f => f.Tuin).ThenInclude(t => t.Planten).SingleOrDefault(g => g.Email == email);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
