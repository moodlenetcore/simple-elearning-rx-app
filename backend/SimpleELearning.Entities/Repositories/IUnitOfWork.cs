using System;
using SimpleELearning.Entities.Models;

namespace SimpleELearning.Entities.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        int Commit();
    }
}