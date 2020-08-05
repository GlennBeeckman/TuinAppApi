using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TuinAppApi.DTO
{
    public class OmgevingDTO
    {
        public IList<FotoDTO> Fotos { get; set; }
        public IList<TemperatuurDTO> Temperaturen { get; set; }
        public IList<LuchtdrukDTO> Luchtdrukken { get; set; }
    }
}
