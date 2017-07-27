using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SimpleELearning.Entities.Models;
using SimpleELearning.Entities.Repositories;
using SimpleElearning.Services.Interfaces;

namespace SimpleElearning.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _unitOfWork.GetRepository<TEntity>().GetAll();
        }
    }
}
