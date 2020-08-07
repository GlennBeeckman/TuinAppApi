using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuinAppApi.Models;

namespace TuinAppApi.Data.Repositories
{
    public class TuinRepository : ITuinenRepository
    {

        private readonly TuinDbContext _context;
        private readonly DbSet<Tuin> _tuinen;

        public TuinRepository(TuinDbContext dbContext)
        {
            _context = dbContext;
            _tuinen = dbContext.Tuinen;
        }

        public IEnumerable<Tuin> GetAll()
        {
            return _tuinen.Include(t => t.Planten).ToList();
        }

        public Tuin GetBy(int id)
        {
            return _tuinen.Include(t => t.Planten).SingleOrDefault(t => t.Id == id);
        }

        public bool TryGetTuin(int id, out Tuin tuin)
        {
            tuin = _context.Tuinen.Include(t => t.Planten).FirstOrDefault(t => t.Id == id);
            return tuin != null;
        }

        public void Add(Tuin tuin)
        {
            _tuinen.Add(tuin);
        }

        public void Update(Tuin tuin)
        {
            _context.Update(tuin);
        }

        public void Delete(Tuin tuin)
        {
            _tuinen.Remove(tuin);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Tuin> GetBy(string naam = null)
        {
            var tuinen = _tuinen.Include(t => t.Planten).AsQueryable();
            if(!string.IsNullOrEmpty(naam))
            {
                tuinen = tuinen.Where(t => t.Naam.IndexOf(naam) >= 0);
            }
            return tuinen.OrderBy(t => t.Naam).ToList();
        }
    }
}
