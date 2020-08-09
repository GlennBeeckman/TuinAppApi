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
            Console.WriteLine("Removing existing sensors and data from garden.");
            _dbContext.Database.EnsureDeleted();
            Console.WriteLine("Installing new sensors...");
            if(_dbContext.Database.EnsureCreated())
            {
                Console.WriteLine("Sensors installed and ready to use.");
                Console.WriteLine();
                //seeden geburt in omgevingDbContext
            }
        }
    }
}
