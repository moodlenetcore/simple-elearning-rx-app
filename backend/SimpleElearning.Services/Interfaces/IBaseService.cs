using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SimpleELearning.Entities.Models;

namespace SimpleElearning.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {   
        IEnumerable<TEntity> GetAll();
    }
}