using Microsoft.AspNetCore.Mvc;

namespace SimpleELearning.Api.Controllers
{
    public class HomeController : BaseController
    {
        // GET api/courses
        [HttpGet]
        public IActionResult Index()
        {
            return Redirect("./swagger");
        }
    }
}
