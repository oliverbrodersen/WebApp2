using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNPAssignment1.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllFamiliesController : ControllerBase
    {
        // GET: api/<AllFamiliesController>

        private IFamilyService familyService;


        public AllFamiliesController(IFamilyService familyService)
        {
            this.familyService = familyService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamilies()
        {
            try
            {
                IList<Family> families = await familyService.GetFamiliesAsync();
                return Ok(families);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<AllFamiliesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AllFamiliesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AllFamiliesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AllFamiliesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
