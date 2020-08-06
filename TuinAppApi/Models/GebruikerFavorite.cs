using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuinAppApi.Models
{
    public class GebruikerFavorite
    {
        public int GebruikerId { get; set; }
        public int TuinId { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public Tuin Tuin { get; set; }
    }
}
