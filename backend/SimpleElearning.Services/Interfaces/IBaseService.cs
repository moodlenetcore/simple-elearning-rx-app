using System;
using System.Collections.Generic;
using SimpleELearning.Entities.Models;

namespace SimpleElearning.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {   
        IEnumerable<TEntity> GetAll();
        int Create(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        TEntity GetById(Guid id);
    }
}
