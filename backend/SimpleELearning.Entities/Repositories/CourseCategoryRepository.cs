using Microsoft.EntityFrameworkCore;
using SimpleELearning.Entities.Interface;
using SimpleELearning.Entities.Models;

namespace SimpleELearning.Entities.Repositories
{
  public class CourseCategoryRepository : GenericRepository<CourseCategory>, ICourseCategoryRepository
  {
    public CourseCategoryRepository(DbContext context) : base(context)
    {
    }
  }
}
