using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SimpleELearning.Entities.Models;

namespace SimpleElearning.Services.Interfaces
{
    public interface IUserService
    {   
        int Create(User entity);
        int Update(User entity);
        int Delete(User entity);
        User GetById(long id);
        IEnumerable<User> Get(
            Expression<Func<User, bool>> filter = null,
            Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null,
            params Expression<Func<User, object>>[] includeProperties);
    }
}