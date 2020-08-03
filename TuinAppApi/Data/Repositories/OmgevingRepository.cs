using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuinAppApi.Models;

namespace TuinAppApi.Data.Repositories
{
    public class OmgevingRepository : IOmgevingRepository
    {
        private readonly OmgevingDbContext _context;
        private readonly DbSet<Omgeving> _omgevingen;

        public OmgevingRepository(OmgevingDbContext dbContext)
        {
            _context = dbContext;
            _omgevingen = dbContext.Omgevingen;
        }

        public void AddFoto(Foto foto)
        {
            _omgevingen.Include(o => o.Fotos).Where(o => o.Id == 1).FirstOrDefault().Fotos.Add(foto);
        }

        public void AddLuchtdruk(Luchtdruk luchtdruk)
        {
            _omgevingen.Include(o => o.Luchtdrukken).Where(o => o.Id == 1).FirstOrDefault().Luchtdrukken.Add(luchtdruk);
        }

        public void AddTemperatuur(Temperatuur temperatuur)
        {
            _omgevingen.Include(o => o.Temperaturen).Where(o => o.Id == 1).FirstOrDefault().Temperaturen.Add(temperatuur);
        }

        public IEnumerable<Omgeving> GetAll()
        {
            return _omgevingen.Include(o => o.Fotos).Include(o => o.Temperaturen).Include(o => o.Luchtdrukken).ToList();
        }

        public IEnumerable<Temperatuur> GetTemperaturen()
        {
            return _omgevingen.Include(o => o.Temperaturen).Where(o => o.Id == 1).FirstOrDefault().Temperaturen.ToList();
        }

        public IEnumerable<Foto> GetFoto()
        {
            return _omgevingen.Include(o => o.Fotos).Where(o => o.Id == 1).FirstOrDefault().Fotos.ToList();
        }

        public IEnumerable<Luchtdruk> GetLuchtdrukken()
        {
            return _omgevingen.Include(o => o.Luchtdrukken).Where(o => o.Id == 1).FirstOrDefault().Luchtdrukken.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Omgeving GetBy(int id)
        {
            return _omgevingen.Include(o => o.Fotos).Include(o => o.Temperaturen).Include(o => o.Luchtdrukken).Where(o => o.Id == id).SingleOrDefault();
        }
    }
}
