using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Time_Display.Controllers
{
    public class TimedisplayController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");
    
        } 
    }
}