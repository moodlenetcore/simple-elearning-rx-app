namespace SimpleELearning.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System;
    using SimpleELearning.Entities.Repositories;
    using SimpleELearning.Entities.Models;
    using SimpleElearning.Services.Interfaces;

    [Produces("application/json")]
    [Route("api/users")]
    public class UsersController : BaseController
    {
        private readonly IUserService _userservice;

        public UsersController(IUserService userservice)
        {
            _userservice = userservice;

            if (_userservice.Get().Count() == 0)
            {
                _userservice.Create(new User {Id = 1, Username = "Tan", Password = "12345"});
            }
        }

        // GET api/users
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userservice.Get().ToList());
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var user = _userservice.Get(s => s.Id == id).FirstOrDefault();

            if (user == null) return NotFound();

            return Ok(user);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (user == null) return BadRequest();

            if (_userservice.Create(user) > 0)
                return CreatedAtAction("Get", new { id = user.Id });

            return BadRequest(new { message = "Failed to create user" });

        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, User user)
        {
            if (user.Id != id) return BadRequest();

            var existingUser = _userservice.Get(s => s.Id == id).FirstOrDefault();
            if (existingUser == null) return NotFound();

            existingUser.Id = user.Id;
            existingUser.Username = user.Username;
            existingUser.Password = user.Password;

            if (_userservice.Update(existingUser) > 0)
                return NoContent();

            return BadRequest(new { message = "Failed to update user" });
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var existingUser = _userservice.Get(s => s.Id == id).FirstOrDefault();
            if (existingUser == null) return NotFound();

            if (_userservice.Delete(existingUser) > 0)
                return NoContent();

            return BadRequest(new { message = "Failed to delete user" });
        }

    }
}
