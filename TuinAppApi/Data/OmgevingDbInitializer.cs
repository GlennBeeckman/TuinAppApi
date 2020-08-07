using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuinAppApi.Models;

namespace TuinAppApi.Data
{
    public class OmgevingDbInitializer
    {
        private readonly OmgevingDbContext _dbContext;

        public OmgevingDbInitializer(OmgevingDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void InitializeData()
        {
            Console.WriteLine("Omgeving being deleted");
            _dbContext.Database.EnsureDeleted();
            Console.WriteLine("Creating omgeving");
            if(_dbContext.Database.EnsureCreated())
            {
                Console.WriteLine("Omgeving created");
                Console.WriteLine();
                //seeden geburt in omgevingDbContext
            }
        }
    }
}
