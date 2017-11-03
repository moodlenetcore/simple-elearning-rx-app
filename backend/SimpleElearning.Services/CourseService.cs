using System;
using System.Collections.Generic;
using System.Linq;
using SimpleElearning.Services.Interfaces;
using SimpleELearning.Entities.Models;
using SimpleELearning.Entities.Repositories;
using SimpleELearning.Entities.Interface;

namespace SimpleElearning.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(IUnitOfWork unitOfWork, ICourseRepository courseRepository) : base(unitOfWork, courseRepository)
        {
            _courseRepository = courseRepository;
        }
    }
}
