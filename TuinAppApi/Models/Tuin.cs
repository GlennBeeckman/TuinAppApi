using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace TuinAppApi.Models
{
    public class Tuin
    {
        #region Properties
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime dateAdded { get; set; }
        public ICollection<Plant> Planten { get; set; }
        #endregion

        public Tuin()
        {
            Planten = new List<Plant>();
            dateAdded = DateTime.Now;
        }

        public Tuin(string naam): this()
        {
            Naam = naam;
        }

        public void AddPlant(Plant plant)
        {
            Planten.Add(plant);
        }

        public Plant GetPlant(int id)
        {
           return Planten.SingleOrDefault(i => i.Id == id);
        }
    }
}
