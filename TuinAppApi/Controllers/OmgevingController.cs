using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuinAppApi.Models;

namespace TuinAppApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OmgevingController: ControllerBase
    {
        private readonly IOmgevingRepository _omgevingRepository;

        public OmgevingController(IOmgevingRepository context)
        {
            this._omgevingRepository = context;
        }

        //GET: api/Omgevingen
        /// <summary>
        /// Geeft alle omgevingen op volgorde van id
        /// </summary>
        /// <returns>een array (list) van alle omgevingen </returns>
        [HttpGet]
        public IEnumerable<Omgeving> GetOmgevingen()
        {
            return _omgevingRepository.GetAll().OrderBy(o => o.Id);
        }

        /// <summary>
        /// Geeft omgeving met een bepaald id terug
        /// </summary>
        /// <param name="id">id van de omgeving</param>
        /// <returns>tuin met opgegeven id of notFoundError</returns>
        [HttpGet("{id}")]
        public ActionResult<Omgeving> GetOmgeving(int id)
        {
            Omgeving omgeving = _omgevingRepository.GetBy(id);
            if (omgeving == null)
            {
                return NotFound();
            }
            return omgeving;
        }
    }
}
