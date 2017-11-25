using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Dojo_Survey.Controllers
{
    public class DojoSurveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.SurveyRes = "Hello World";
            return View("index");

        }
        [HttpPost]
        [Route("success")]   //the slash is not needed here, just name the method
        public IActionResult success(string first_name, string last_name, string location, string favorite_language)
        {
            ViewBag.SurveyRes = "Your survey has been submitted successfully!";  //in order to render this information we have to call on these view bags in the views cshtml
            ViewBag.fname = first_name;
            ViewBag.lname = last_name;
            ViewBag.location = location;
            ViewBag.language = favorite_language;
            return View("success");

        }
        // [HttpGet]
        // [Route("/contact")]
        // public IActionResult Contact()
        // {
        //     return View("contact");

        // }
    }
}