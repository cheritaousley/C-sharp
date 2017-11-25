using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");

        }
        [HttpGet]
        [Route("/projects")]
        public IActionResult Projects()
        {
            return View("projects");

        }
        [HttpGet]
        [Route("/contact")]
        public IActionResult Contact()
        {
            return View("contact");

        }
    }
}