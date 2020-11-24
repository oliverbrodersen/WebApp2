using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp2.Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebApp2.Data;

namespace WebApp2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private IFamilyService familyService;

        public FamilyController(IFamilyService familyService)
        {
            this.familyService = familyService;
        }

        [HttpGet]
        public async Task<ActionResult<Family>> GetFamily([FromQuery] string streetName, [FromQuery] int houseNumber)
        {
            try
            {
                Family family = await familyService.GetFamilyAsync(streetName, houseNumber);
                
                return Ok(family);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Family>> AddFamily([FromBody] Family family)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try {
                Family added = await familyService.AddFamilyAsync(family);
                return Created($"/{added.StreetName+added.HouseNumber}",added); // return newly added to-do, to get the auto generated id
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteFamily([FromQuery] string streetName, [FromQuery] int houseNumber) {
            try {
                await familyService.RemoveFamilyAsync(streetName,houseNumber);
                return Ok();
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}