using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuinAppApi.Data
{
    public class TuinDbInitializer
    {
        private readonly TuinDbContext _dbContext;

        public TuinDbInitializer(TuinDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void InitializeData()
        {
            Console.WriteLine("Db being deleted");
            _dbContext.Database.EnsureDeleted();
            Console.WriteLine("Db deleted, creating new db");
            if(_dbContext.Database.EnsureCreated())
            {
                //seeding via tuinDbContext
            }
        }
    }
}
