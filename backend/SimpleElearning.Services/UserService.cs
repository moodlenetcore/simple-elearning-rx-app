using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SimpleElearning.Services.Interfaces;
using SimpleELearning.Entities.Models;
using SimpleELearning.Entities.Repositories;

namespace SimpleElearning.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _userRepository = unitOfWork.GetRepository<User>();
        }

        public int Create(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _userRepository.Add(entity);
            return _unitOfWork.Commit();
        }

        public int Delete(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _userRepository.Delete(entity);
            return _unitOfWork.Commit();
        }

        public IEnumerable<User> Get(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, params Expression<Func<User, object>>[] includeProperties)
        {
            return _userRepository.Get(filter, orderBy, includeProperties);
        }

        public User GetById(long id)
        {
            return _userRepository.GetById(id);
        }

        public int Update(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _userRepository.Edit(entity);
            return _unitOfWork.Commit();
        }
    }
}