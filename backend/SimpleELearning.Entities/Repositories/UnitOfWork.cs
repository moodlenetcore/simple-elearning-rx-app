using System;
using System.Collections.Generic;
using System.Linq;
using SimpleELearning.Entities.Models;

namespace SimpleELearning.Entities.Repositories
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly SimpleELearningContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(SimpleELearningContext simpleELearningContext)
        {
            _context = simpleELearningContext;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null)
                _repositories = new Dictionary<Type, object>();

            if (_repositories.Keys.Contains(typeof(TEntity)))
                return _repositories[typeof(TEntity)] as IGenericRepository<TEntity>;

            var repository = new GenericRepository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }

        public int Commit()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch
            {
                return -1;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
