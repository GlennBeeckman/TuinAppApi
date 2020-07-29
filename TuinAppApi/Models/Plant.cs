using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace TuinAppApi.Models
{
    public class Plant
    {
        #region Properties
        public int Id { get; set; }
        public string Naam { get; set; }
        public int DagenTotOogst { get; set; }
        public DateTime DatumGeplant { get; set; }
        #endregion

        public Plant(string naam, int dagenTotOogst, DateTime datumGeplant)
        {
            this.Naam = naam;
            this.DagenTotOogst = dagenTotOogst;
            this.DatumGeplant = datumGeplant;
        }

    }
}
