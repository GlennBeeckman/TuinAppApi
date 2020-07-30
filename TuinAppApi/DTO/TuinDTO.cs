using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TuinAppApi.DTO
{
    public class TuinDTO
    {
        [Required]
        public string Naam { get; set; }
        public IList<PlantDTO> Planten { get; set; }
    }
}
