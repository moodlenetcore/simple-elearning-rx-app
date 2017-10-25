using System;
using System.Collections.Generic;
using System.Linq;
using SimpleElearning.Services.Interfaces;
using SimpleELearning.Entities.Models;
using SimpleELearning.Entities.Repositories;
using SimpleELearning.Entities.Interface;

namespace SimpleElearning.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository) : base(unitOfWork, userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
