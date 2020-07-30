using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TuinAppApi.Models;

namespace TuinAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuinenController : ControllerBase
    {
        private readonly ITuinenRepository _tuinRepository;

        public TuinenController(ITuinenRepository context)
        {
            this._tuinRepository = context;
        }
         //GET: api/Tuinen
        [HttpGet]
        public IEnumerable<Tuin> GetTuinen()
        {
            return _tuinRepository.GetAll().OrderBy(t => t.Naam);
        }

        [HttpGet("{id}")]
        public ActionResult<Tuin> GetTuin(int id)
        {
            Tuin tuin = _tuinRepository.GetBy(id);
            if (tuin == null)
            {
                return NotFound();
            }
            return tuin;
        }
    }
}
