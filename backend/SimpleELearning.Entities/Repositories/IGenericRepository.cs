namespace SimpleELearning.Entities.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity GetById(long id);
        TEntity Add(TEntity entity);
        TEntity Edit(TEntity entityToUpdate);
        void Delete(TEntity entityToDelete);
    }
}
