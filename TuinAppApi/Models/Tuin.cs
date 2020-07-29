using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace TuinAppApi.Models
{
    public class Tuin
    {
        #region Properties
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        public DateTime dateAdded { get; set; }
        public ICollection<Plant> Planten { get; private set; }
        #endregion

        #region Constructors
        public Tuin()
        {
            Planten = new List<Plant>();
            dateAdded = DateTime.Now;
        }

        public Tuin(string naam) : this()
        {
            Naam = naam;
        }
        #endregion

        #region Methods
        public void AddPlant(Plant plant)
        {
            Planten.Add(plant);
        }

        public Plant GetPlant(int id)
        {
            return Planten.SingleOrDefault(i => i.Id == id);
        } 
        #endregion
    }
}
