using System;
using System.Collections.Generic;
using System.Linq;
using SimpleElearning.Services.Interfaces;
using SimpleELearning.Entities.Models;
using SimpleELearning.Entities.Repositories;

namespace SimpleElearning.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _userRepository = unitOfWork.GetRepository<User>();
        }

        public override int Create(User user)
        {
            user.Id = Guid.NewGuid();
            _userRepository.Insert(user);
            return _unitOfWork.Commit();
        }

        public override int Delete(User user)
        {
            _userRepository.Delete(user);
            return _unitOfWork.Commit();
        }

        public override User GetById(Guid id)
        {
            return _userRepository.Get(s => s.Id == id).FirstOrDefault();
        }

        public override int Update(User user)
        {
            _userRepository.Update(user);
            return _unitOfWork.Commit();
        }

        public override IEnumerable<User> GetAll()
        {
          return _userRepository.GetAll();
        }
    }
}
