namespace SimpleElearning.Services
{
  using System;
  using System.Collections.Generic;
  using System.Text;
    using SimpleELearning.Entities.Repositories;

    public class BaseService
  {
    protected readonly IUnitOfWork _unitOfWork;
      public BaseService(IUnitOfWork unitOfWork)
      {
          _unitOfWork = unitOfWork;
      }
  }
}
