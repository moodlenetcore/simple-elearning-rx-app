using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SimpleElearning.Services.Interfaces;
using SimpleELearning.Entities.Repositories;

namespace SimpleElearning.Services
{
    public class EntityService<TEntity> : BaseService, IEntityService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        public EntityService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _genericRepository = unitOfWork.GetRepository<TEntity>();
        }

        public int Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _genericRepository.Add(entity);
            return _unitOfWork.Commit();
        }

        public int Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _genericRepository.Delete(entity);
            return _unitOfWork.Commit();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _genericRepository.Get(filter, orderBy, includeProperties);
        }

        public TEntity GetById(long id)
        {
            return _genericRepository.GetById(id);
        }

        public int Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _genericRepository.Edit(entity);
            return _unitOfWork.Commit();
        }
    }
}