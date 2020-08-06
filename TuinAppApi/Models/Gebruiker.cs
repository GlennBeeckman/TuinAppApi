using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuinAppApi.Models
{
    public class Gebruiker
    {
        public int GebruikerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<GebruikerFavorite> Favorites { get; set; }
        public IEnumerable<Tuin> FavoriteTuinen => Favorites.Select(f => f.Tuin);

        public Gebruiker()
        {
            this.Favorites = new List<GebruikerFavorite>();
        }

        public void AddFavoriteTuin(Tuin tuin)
        {
            Favorites.Add(new GebruikerFavorite() { TuinId = tuin.Id, GebruikerId = GebruikerId, Tuin = tuin, Gebruiker = this });
        }
    }
}
