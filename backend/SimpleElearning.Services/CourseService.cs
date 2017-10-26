using System;
using System.Collections.Generic;
using System.Linq;
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

        public override int Create(Course course)
        {
            course.Id = Guid.NewGuid();
            _courseRepository.Insert(course);
            return _unitOfWork.Commit();
        }

        public override int Delete(Course course)
        {
            _courseRepository.Delete(course);
            return _unitOfWork.Commit();
        }

        public override Course GetById(Guid id)
        {
            return _courseRepository.Get(s => s.Id == id).FirstOrDefault();
        }

        public override int Update(Course course)
        {
            _courseRepository.Update(course);
            return _unitOfWork.Commit();
        }

        public override IEnumerable<Course> GetAll()
        {
          return _courseRepository.GetAll();
        }
    }
}
