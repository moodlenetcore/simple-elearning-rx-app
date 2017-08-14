using System;
using SimpleELearning.Entities.Models;

namespace SimpleElearning.Services.Interfaces
{
    public interface IUserService : IBaseService<User>
    {   
        int Create(User user);
        int Update(User user);
        int Delete(User user);
        User GetById(Guid id);
    }
}