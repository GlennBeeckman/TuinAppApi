using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace TuinAppApi.Models
{
    public class Foto
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public float Waarde { get; set; }

        public Foto(DateTime datum, float waarde)
        {
            this.Datum = datum;
            this.Waarde = waarde;
        }
    }
}
