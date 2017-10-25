using System;
using System.Linq;
using System.Collections.Generic;
using SimpleElearning.Services.Interfaces;
using SimpleELearning.Entities.Models;
using SimpleELearning.Entities.Repositories;
using SimpleELearning.Entities.Interface;

namespace SimpleElearning.Services
{
    public class CourseCategoriesService : BaseService<CourseCategory>, ICourseCategoriesService
    {
        private readonly ICourseCategoryRepository _courseCategoriesRepository;
        public CourseCategoriesService(IUnitOfWork unitOfWork, ICourseCategoryRepository courseCategoriesRepository) : base(unitOfWork, courseCategoriesRepository)
        {
            _courseCategoriesRepository = courseCategoriesRepository;
        }
    }
}
