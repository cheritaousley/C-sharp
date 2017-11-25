using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    public class CallingCardController : Controller
    {
        [HttpGetAttribute]
        [HttpGet]
        [Route("display/{First Name}/{Last Name}/{Age}/{Favorite Color}")]
        //or
        // [Route("/")]
        public JsonResult Display(string fname, string lname, string age, string color) 
        {
            var AnonObject = new{
                 fname = "Cherita",
                 lname = "Ousley",
                 age = "26",
                 color = "purple",
            };
    
            // return Json(AnonObject);
            return Json($"First Name: {AnonObject.fname} Last Name: {AnonObject.lname}  Age: {AnonObject.age} Favorite color: {AnonObject.color}");

        }
        // [HttpPost]
        // [Route("template/{First Name}/{Last Name}/{Age}/{Favorite Color}")]
        // public IActionResult Method(string name)
        // {
        //     //Method body
        // }
    }
}
