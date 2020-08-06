using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using TuinAppApi.DTO;
using TuinAppApi.Models;

namespace TuinAppApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class TuinenController : ControllerBase
    {
        private readonly ITuinenRepository _tuinRepository;

        public TuinenController(ITuinenRepository context)
        {
            this._tuinRepository = context;
        }


        //GET: api/Tuinen
        /// <summary>
        /// Geeft alle tuinen op alfabetische volgorde
        /// </summary>
        /// <returns>een array (list) van alle tuinen </returns>
        [HttpGet]
        public IEnumerable<Tuin> GetTuinen()
        {
            return _tuinRepository.GetAll().OrderBy(t => t.Naam);
        }

        /// <summary>
        /// Geeft tuin met een bepaald id terug
        /// </summary>
        /// <param name="id">id van de tuin</param>
        /// <returns>tuin met opgegeven id of notFoundError</returns>
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

        /// <summary>
        /// voegt nieuwe tuin toe aan lijst
        /// </summary>
        /// <param name="tuin">nieuwe tuin</param>
        /// <returns>de nieuwe tuin</returns>
        [HttpPost]
        public ActionResult<Tuin> PostTuin(TuinDTO tuin)
        {

            Tuin tuinOmToeTeVoegen = new Tuin()
            {
                Naam = tuin.Naam,
                dateAdded = DateTime.Now               
            };

            foreach (var i in tuin.Planten)
            {
                Plant plant = new Plant(i.Naam, i.DatumGeplant, i.DagenTotOogst);
                tuinOmToeTeVoegen.AddPlant(plant);
            }

            _tuinRepository.Add(tuinOmToeTeVoegen);
            _tuinRepository.SaveChanges();

            return CreatedAtAction(nameof(GetTuin), new { id = tuinOmToeTeVoegen.Id }, tuinOmToeTeVoegen);
        }

        /// <summary>
        /// Past opgegeven tuin aan
        /// </summary>
        /// <param name="id">id van de tuin die aangepast dient te worden</param>
        /// <param name="tuin">de aangepaste tuin</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutTuin(int id, Tuin tuin)
        {
            if (id != tuin.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) //throws 404?
            {
                return BadRequest();
            }

            _tuinRepository.Update(tuin);
            _tuinRepository.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// verwijdert een tuin
        /// </summary>
        /// <param name="id">id van de tuin die verwijdert dient te worden</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteTuin(int id)
        {
            Tuin tuin = _tuinRepository.GetBy(id);
            if (tuin == null)
            {
                return NotFound();
            }

            _tuinRepository.Delete(tuin);
            _tuinRepository.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// geeft een plant van een tuin
        /// </summary>
        /// <param name="id">id van de tuin</param>
        /// <param name="plantId">id van de plant</param>
        [HttpGet("{id}/planten/{plantId}")]
        public ActionResult<Plant> GetPlant(int id, int plantId)
        {
            if(!_tuinRepository.TryGetTuin(id, out var tuin))
            {
                return NotFound();
            }

            Plant plant = tuin.GetPlant(plantId);
            if(plant == null)
            {
                return NotFound();
            }

            return plant;
        }

        /// <summary>
        /// voegt een plant toe aan een tuin
        /// </summary>
        /// <param name="id">id van de tuin</param>
        /// <param name="plant">de plant die toegevoegd wordt</param>
        /// <returns></returns>
        [HttpPost("{id}/planten")]
        public ActionResult<Plant> PostPlant(int id, PlantDTO plant)
        {
            if(!_tuinRepository.TryGetTuin(id, out var tuin))
            {
                return NotFound();
            }

            var PlantToCreate = new Plant(plant.Naam, plant.DatumGeplant, plant.DagenTotOogst);
            tuin.AddPlant(PlantToCreate);
            _tuinRepository.SaveChanges();
            return CreatedAtAction("GetPlant", new { id = tuin.Id, plantId = PlantToCreate.Id }, PlantToCreate);
        }
    }
}
