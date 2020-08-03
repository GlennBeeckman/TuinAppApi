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
        public string Url { get; set; }

        public Foto(DateTime datum, string url)
        {
            this.Datum = datum;
            this.Url = url;
        }
    }
}
