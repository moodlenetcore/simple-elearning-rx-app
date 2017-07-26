using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SimpleElearning.Services.Interfaces;
using SimpleELearning.Entities.Models;
using SimpleELearning.Entities.Repositories;

namespace SimpleElearning.Services
{
    public class CourseService : BaseService, ICourseService
    {
        private readonly IGenericRepository<Course> _courseRepository;
        public CourseService(IGenericRepository<Course> courseRepository) : base()
        {
            _courseRepository = courseRepository;
        }

        public int Create(Course courseEntity)
        {
            var course =  new Course
            {
                
            }
        }

        public int Delete(Course courseEntity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _courseRepository.Delete(entity);
            return _unitOfWork.Commit();
        }

        public Course GetById(long id)
        {
            var course = _courseRepository.GetById(id);
            if (course != null)
            {
                return course;
            }
            return null;
        }

        public int Update(Course courseEntity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _courseRepository.Edit(entity);
            return _unitOfWork.Commit();
        }
    }
}