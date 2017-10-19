using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimpleElearning.Services.Interfaces;
using SimpleELearning.Entities.Models;

namespace SimpleELearning.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/courseCategories")]
    public class CourseCategoriesController : BaseController
    {
        private readonly ICourseCategoriesService _courseCategoriesService;
        public CourseCategoriesController(ICourseCategoriesService courseCategoriesService)
        {
            _courseCategoriesService = courseCategoriesService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_courseCategoriesService.GetAll().ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var courseCategory = _courseCategoriesService.GetById(id);
            
            if(courseCategory == null) return NotFound();

            return Ok(courseCategory);
        }

        [HttpPost]
        public IActionResult Create(CourseCategory courseCategory)
        {
            if(courseCategory == null) return BadRequest();

            if(_courseCategoriesService.Create(courseCategory) > 0)
            {
                return CreatedAtAction("Get", new {id = courseCategory.Id});
            }

            return BadRequest(new {message = "Cannot create courseCategory"});
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, CourseCategory courseCategory)
        {
            if(id == null || id != courseCategory.Id) return BadRequest();

            var existingCourseCategory = _courseCategoriesService.GetById(id);
            if(existingCourseCategory == null) return NotFound();

            existingCourseCategory.Name = courseCategory.Name;
            existingCourseCategory.Description = courseCategory.Description;
            existingCourseCategory.ParentId = courseCategory.ParentId;

            if(_courseCategoriesService.Update(existingCourseCategory) > 0)
                return NoContent();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existingCourseCategory = _courseCategoriesService.GetById(id);
            if(existingCourseCategory == null) return NotFound();

            if(_courseCategoriesService.Delete(existingCourseCategory) > 0)
                return NoContent();

            return BadRequest(new {message = "Cannot delete courseCategory"});
        }
    }
}
