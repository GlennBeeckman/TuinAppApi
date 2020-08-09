using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TuinAppApi.DTO
{
    public class PlantDTO
    {
        [Required]
        public string Naam { get; set; }
        public int DagenTotOogst { get; set; }
        public string DatumGeplant { get; set; }
    }
}
