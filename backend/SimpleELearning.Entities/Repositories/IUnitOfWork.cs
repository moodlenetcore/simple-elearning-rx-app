namespace SimpleELearning.Entities.Repositories
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        int Commit();
    }
}
