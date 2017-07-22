using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleElearning.Services.Interfaces
{
    public interface IEntityService<TEntity> where TEntity : class
    {   
        int Create(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        TEntity GetById(long id);
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties);
    }
}