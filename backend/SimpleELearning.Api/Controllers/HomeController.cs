using Microsoft.AspNetCore.Mvc;

namespace SimpleELearning.Api.Controllers
{
    public class HomeController : BaseController
    {
        // GET swagger
        [HttpGet]
        public IActionResult Index()
        {
            return Redirect("./swagger");
        }
    }
}
