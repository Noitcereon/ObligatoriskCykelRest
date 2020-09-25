using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CykelRest.Managers;
using Microsoft.AspNetCore.Mvc;

namespace CykelRest.Controllers
{
    [ApiController]
    [Route("api/cykler/")]
    public class BicyclesController : ControllerBase
    {
        private BicycleManager _manager = new BicycleManager();

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
    }
}
