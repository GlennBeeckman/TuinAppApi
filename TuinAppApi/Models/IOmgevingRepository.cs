using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuinAppApi.Models
{
    public interface IOmgevingRepository
    {
        IEnumerable<Omgeving> GetAll();
        Omgeving GetBy(int id);
        IEnumerable<Foto> GetFoto();
        IEnumerable<Temperatuur> GetTemperaturen();
        IEnumerable<Luchtdruk> GetLuchtdrukken();
        void AddFoto(Foto foto);
        void AddTemperatuur(Temperatuur temperatuur);
        void AddLuchtdruk(Luchtdruk luchtdruk);
        void SaveChanges();
    }
}
