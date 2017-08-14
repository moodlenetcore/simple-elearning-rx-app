using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using SimpleELearning.Entities.Models;
using SimpleElearning.Services.Interfaces;

namespace SimpleELearning.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/users
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.GetAll().ToList());
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = _userService.GetById(id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (user == null) 
                return BadRequest();

            if (_userService.Create(user) > 0)
                return CreatedAtAction("Get", new { id = user.Id });

            return BadRequest(new { message = "Failed to create user" });

        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, User user)
        {
            if (id == null || user.Id != id) return BadRequest();

            var existingUser = _userService.GetById(id);
            if (existingUser == null) return NotFound();

            existingUser.Username = user.Username;
            existingUser.Password = user.Password;

            if (_userService.Update(existingUser) > 0)
                return NoContent();

            return BadRequest(new { message = "Failed to update user" });
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existingUser = _userService.GetById(id);
            if (existingUser == null) return NotFound();

            if (_userService.Delete(existingUser) > 0)
                return NoContent();

            return BadRequest(new { message = "Failed to delete user" });
        }

    }
}
