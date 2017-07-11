namespace SimpleELearning.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SimpleELearning.Entities.Repositories;

    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
