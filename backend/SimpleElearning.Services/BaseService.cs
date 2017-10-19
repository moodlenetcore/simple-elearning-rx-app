using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SimpleELearning.Entities.Models;
using SimpleELearning.Entities.Repositories;
using SimpleElearning.Services.Interfaces;

namespace SimpleElearning.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public abstract IEnumerable<TEntity> GetAll();

        public abstract int Create(TEntity entity);

        public abstract int Delete(TEntity entity);

        public abstract TEntity GetById(Guid id);

        public abstract int  Update(TEntity entity);
  }
}
