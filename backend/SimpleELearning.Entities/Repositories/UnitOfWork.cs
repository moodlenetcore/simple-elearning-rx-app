using System;
using System.Collections.Generic;
using System.Linq;
using SimpleELearning.Entities.Models;
using SimpleELearning.Entities.Interface;
using Microsoft.EntityFrameworkCore;

namespace SimpleELearning.Entities.Repositories
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext simpleELearningContext)
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
