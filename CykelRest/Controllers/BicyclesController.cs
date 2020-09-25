using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CykelRest.Managers;
using Microsoft.AspNetCore.Mvc;
using ObligatoryClassLibrary;

namespace CykelRest.Controllers
{
    [ApiController]
    [Route("api/cykler/")]
    public class BicyclesController : ControllerBase
    {
        private readonly BicycleManager _manager = new BicycleManager();

        [HttpGet]
        public IActionResult GetAll()
        {
            if (_manager.GetAll().Count > 0)
            {
                return Ok(_manager.GetAll());
            }

            return NotFound("Ingen cykler fundet.");
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            if (_manager.GetOne(id) != null)
            {
                return Ok(_manager.GetOne(id));
            }

            return NotFound($"Kunne ikke finde en cykel med id {id}");
        }

        public IActionResult Post(Cykel newBicycle)
        {
            if (newBicycle != null)
            {
                return Ok(_manager.Post(newBicycle));
            }

            return BadRequest("Bad request during Post.");
        }

        public IActionResult Put(int id, Cykel updatedBicycle)
        {
            if (GetOne(id) != null)
            {
                return Ok(_manager.Put(id, updatedBicycle));
            }

            return NotFound($"Kunne ikke finde en cykel at opdatere med id {id}");
        }

        public IActionResult Delete(int id)
        {
            if (_manager.GetOne(id) != null)
            {
                return Ok(Delete(id));
            }

            return NotFound($"Kan ikke slette en cykel som ikke findes (id: {id})");
        }
    }
}
