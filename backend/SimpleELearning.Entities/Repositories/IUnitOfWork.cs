using System;
using SimpleELearning.Entities.Models;
using SimpleELearning.Entities.Interface;

namespace SimpleELearning.Entities.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
