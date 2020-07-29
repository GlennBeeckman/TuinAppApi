using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuinAppApi.Models
{
    interface ITuinenRepository
    {
        Tuin GetBy(int id);
        bool TryGetTuin(int id, out Tuin tuin);
        IEnumerable<Tuin> GetAll();
        IEnumerable<Tuin> GetBy(string name);
        void Add(Tuin tuin);
        void Delete(Tuin tuin);
        void Update(Tuin tuin);
        void SaveChanges();
    }
}
