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
            Console.Write("Omgeving being deleted");
            _dbContext.Database.EnsureDeleted();
            Console.Write("omgeving deletes, being created");
            if(_dbContext.Database.EnsureCreated())
            {
                //seeden geburt in omgevingDbContext
            }
        }
    }
}
