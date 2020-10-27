using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp2.Data;
using WebApp2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private IUserService users;

        public UserLoginController(IUserService userService)
        {
            users = userService;
        }

        // GET: api/<UserLoginController>
        [HttpGet]
        public async Task<ActionResult<User>> LogInUser([FromQuery] string userName, [FromQuery] string pass)
        {
            User user;
            try
            {
                user = users.ValidateUser(userName, pass);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<UserLoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserLoginController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserLoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserLoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
