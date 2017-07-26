using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SimpleElearning.Services.Interfaces;
using SimpleELearning.Entities.Models;
using SimpleELearning.Entities.Repositories;

namespace SimpleElearning.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        private readonly IGenericRepository<Course> _courseRepository;
        public CourseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _courseRepository = unitOfWork.GetRepository<Course>();
        }

        public int Create(Course course)
        {
            course.Id = Guid.NewGuid();
            _courseRepository.Insert(course);
            return _unitOfWork.Commit();
        }

        public int Delete(Course course)
        {
            _courseRepository.Delete(course);
            return _unitOfWork.Commit();
        }

        public Course GetById(Guid id)
        {
            return _courseRepository.Get(s => s.Id == id).FirstOrDefault();
        }

        public int Update(Course course)
        {
            _courseRepository.Update(course);
            return _unitOfWork.Commit();
        }
    }
}