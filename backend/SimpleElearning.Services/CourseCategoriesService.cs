using System;
using System.Linq;
using System.Collections.Generic;
using SimpleElearning.Services.Interfaces;
using SimpleELearning.Entities.Models;
using SimpleELearning.Entities.Repositories;

namespace SimpleElearning.Services
{
    public class CourseCategoriesService : BaseService<CourseCategory>, ICourseCategoriesService
    {
        private readonly IGenericRepository<CourseCategory> _courseCategoriesRepository;
        public CourseCategoriesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _courseCategoriesRepository = unitOfWork.GetRepository<CourseCategory>();
        }

        public override int Create(CourseCategory courseCategory)
        {
            courseCategory.Id = Guid.NewGuid();
            _courseCategoriesRepository.Insert(courseCategory);
            return _unitOfWork.Commit();
        }

        public override int Delete(CourseCategory courseCategory)
        {
            _courseCategoriesRepository.Delete(courseCategory);
            return _unitOfWork.Commit();
        }

        public override IEnumerable<CourseCategory> GetAll()
        {
            return _courseCategoriesRepository.GetAll();
        }

        public override CourseCategory GetById(Guid id)
        {
            return _courseCategoriesRepository.Get(c => c.Id == id).FirstOrDefault();
        }

        public override int Update(CourseCategory courseCategory)
        {
            _courseCategoriesRepository.Update(courseCategory);
            return _unitOfWork.Commit();
        }
    }
}