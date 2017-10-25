using System;
using System.Collections.Generic;
using System.Linq;
using SimpleELearning.Entities.Models;
using SimpleELearning.Entities.Interface;

namespace SimpleELearning.Entities.Repositories
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly SimpleELearningContext _context;

        public UnitOfWork(SimpleELearningContext simpleELearningContext)
        {
            _context = simpleELearningContext;
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
