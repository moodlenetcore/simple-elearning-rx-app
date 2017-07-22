namespace SimpleELearning.Entities.Repositories
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        int Commit();
    }
}
