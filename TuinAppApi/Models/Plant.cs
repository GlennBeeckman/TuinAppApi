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
        public string Familie { get; set; }
        public DateTime DatumGeplant { get; set; }
        public string WikiLink { get; set; }
        public string FotoUrl { get; set; }
        #endregion

        public Plant(string naam, string familie, DateTime datumGeplant, string wikiLink, string fotoUrl)
        {
            this.Naam = naam;
            this.Familie = familie;
            this.DatumGeplant = datumGeplant;
            this.WikiLink = wikiLink;
            this.FotoUrl = fotoUrl;
        }



    }
}
