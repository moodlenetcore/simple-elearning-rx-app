using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SimpleELearning.Entities.Models;
using SimpleELearning.Entities.Interface;
using SimpleELearning.Entities.Repositories;
using SimpleElearning.Services.Interfaces;

namespace SimpleElearning.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _repository;
        public BaseService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual int Create(TEntity entity)
        {
            if(entity == null)
                throw new ArgumentNullException("Entity");

            _repository.Insert(entity);
            return _unitOfWork.Commit();
        }

        public virtual int Delete(TEntity entity)
        {
            if(entity == null)
                  throw new ArgumentNullException("Entity");

            _repository.Delete(entity);
            return _unitOfWork.Commit();
        }

        public virtual TEntity GetById(Guid id)
        {
          if(id == Guid.Empty)
                throw new ArgumentNullException("id");
            return _repository.Get(x => x.Id == id).FirstOrDefault();
        }

        public virtual int  Update(TEntity entity)
        {
            if(entity == null)
                  throw new ArgumentNullException("Entity");

            _repository.Update(entity);
            return _unitOfWork.Commit();
        }
  }
}
