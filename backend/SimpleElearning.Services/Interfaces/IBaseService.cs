using System.Collections.Generic;
using SimpleELearning.Entities.Models;

namespace SimpleElearning.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {   
        IEnumerable<TEntity> GetAll();
    }
}