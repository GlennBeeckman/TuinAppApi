using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TuinAppApi.Models
{
    public class Omgeving
    {
        public ICollection<Foto> Fotos { get; set; }
        public ICollection<Temperatuur> Temperaturen { get; set; }
        public ICollection<Luchtdruk> Luchtdrukken { get; set; }
        public int Id { get; internal set; }

        public Omgeving()
        {
            Fotos = new List<Foto>();
            Temperaturen = new List<Temperatuur>();
            Luchtdrukken = new List<Luchtdruk>();
        }
    }
}
