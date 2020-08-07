using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuinAppApi.Models
{
    public interface ITuinenRepository
    {
        Tuin GetBy(int id);
        bool TryGetTuin(int id, out Tuin tuin);
        IEnumerable<Tuin> GetAll();
        IEnumerable<Tuin> GetBy(string naam = null);
        void Add(Tuin tuin);
        void Delete(Tuin tuin);
        void Update(Tuin tuin);
        void SaveChanges();
    }
}
