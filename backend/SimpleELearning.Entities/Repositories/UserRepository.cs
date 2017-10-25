using Microsoft.EntityFrameworkCore;
using SimpleELearning.Entities.Models;
using SimpleELearning.Entities.Interface;

namespace SimpleELearning.Entities.Repositories
{
  public class UserRepository : GenericRepository<User>, IUserRepository
  {
    public UserRepository(DbContext context) : base(context)
    {
    }
  }
}
