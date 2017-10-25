using Microsoft.EntityFrameworkCore;
using SimpleELearning.Entities.Interface;
using SimpleELearning.Entities.Models;

namespace SimpleELearning.Entities.Repositories
{
  public class CourseRepository : GenericRepository<Course>, ICourseRepository
  {
    public CourseRepository(DbContext context) : base(context)
    {
    }
  }
}
