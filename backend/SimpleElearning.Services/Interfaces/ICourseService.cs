using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SimpleELearning.Entities.Models;

namespace SimpleElearning.Services.Interfaces
{
    public interface ICourseService
    {   
        int Create(Course entity);
        int Update(Course entity);
        int Delete(Course entity);
        Course GetById(long id);
    }
}