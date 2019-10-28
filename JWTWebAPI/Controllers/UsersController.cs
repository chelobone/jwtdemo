using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTWebAPI.Entities;
using JWTWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Post([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam);

            if (user == null)
            {
                if (user.Id == 0)
                    return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(user);
        }


        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
