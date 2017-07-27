namespace SimpleELearning.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System;
    using SimpleELearning.Entities.Repositories;
    using SimpleELearning.Entities.Models;
    using SimpleElearning.Services.Interfaces;

    [Produces("application/json")]
    [Route("api/courses")]
    public class CoursesController : BaseController
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET api/courses
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_courseService.GetAll().ToList());
        }

        // GET api/courses/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var course = _courseService.GetById(id);

            if (course == null) return NotFound();

            return Ok(course);
        }

        // POST api/courses
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (course == null) 
                return BadRequest();

            if (_courseService.Create(course) > 0)
                return CreatedAtAction("Get", new { id = course.Id });

            return BadRequest(new { message = "Failed to create course" });

        }

        // PUT api/courses/5
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Course course)
        {
            if (id == null || course.Id != id) return BadRequest();

            var existingCourse = _courseService.GetById(id);
            if (existingCourse == null) return NotFound();

            existingCourse.CourseCategoryId = course.CourseCategoryId;
            existingCourse.FullName = course.FullName;
            existingCourse.ShortName = course.ShortName;
            existingCourse.Summary = course.Summary;
            existingCourse.StartDate = course.StartDate;
            existingCourse.EndDate = course.EndDate;

            if (_courseService.Update(existingCourse) > 0)
                return NoContent();

            return BadRequest(new { message = "Failed to update course" });
        }

        // DELETE api/courses/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existingCourse = _courseService.GetById(id);
            if (existingCourse == null) return NotFound();

            if (_courseService.Delete(existingCourse) > 0)
                return NoContent();

            return BadRequest(new { message = "Failed to delete course" });
        }

    }
}
