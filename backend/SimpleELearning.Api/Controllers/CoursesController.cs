namespace SimpleELearning.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System;
    using SimpleELearning.Entities.Repositories;
    using SimpleELearning.Entities.Models;

    [Produces("application/json")]
    [Route("api/courses")]
    public class CoursesController : BaseController
    {
        private readonly IRepository<Course> _courseRepository;

        public CoursesController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _courseRepository = unitOfWork.GetRepository<Course>();
        }

        // GET api/courses
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_courseRepository.Get().ToList());
        }

        // GET api/courses/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var course = _courseRepository.Get(s => s.Id == id).FirstOrDefault();

            if (course == null) return NotFound();

            return Ok(course);
        }

        // POST api/courses
        [HttpPost]
        public IActionResult Post(Course course)
        {
            if (course == null) return BadRequest();

            course.Id = Guid.NewGuid();
            _courseRepository.Insert(course);

            if (_unitOfWork.Commit() > 0)
                return CreatedAtAction("Get", new { id = course.Id });

            return BadRequest(new { message = "Failed to create course" });

        }

        // PUT api/courses/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Course course)
        {
            if (id == null || course.Id != id) return BadRequest();

            var existingCourse = _courseRepository.Get(s => s.Id == id).FirstOrDefault();
            if (existingCourse == null) return NotFound();

            existingCourse.CourseCategoryId = course.CourseCategoryId;
            existingCourse.FullName = course.FullName;
            existingCourse.ShortName = course.ShortName;
            existingCourse.Summary = course.Summary;
            existingCourse.StartDate = course.StartDate;
            existingCourse.EndDate = course.EndDate;

            if (_unitOfWork.Commit() > 0)
                return NoContent();

            return BadRequest(new { message = "Failed to update course" });
        }

        // DELETE api/courses/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existingCourse = _courseRepository.Get(s => s.Id == id).FirstOrDefault();
            if (existingCourse == null) return NotFound();

            _courseRepository.Delete(existingCourse);
            if (_unitOfWork.Commit() > 0)
                return NoContent();

            return BadRequest(new { message = "Failed to delete course" });
        }

    }
}
