using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuinAppApi.Models
{
    public class Luchtdruk
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public float Waarde { get; set; }

        public Luchtdruk(DateTime datum, float waarde)
        {
            this.Datum = datum;
            this.Waarde = waarde;
        }
    }
}
