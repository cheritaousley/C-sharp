using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using form_app.Models;
using Newtonsoft.Json;
// using DbConnection;

namespace form_app.Controllers
{
    public class UsersController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("ErrorsPresent") != null){
                string errorsHere = HttpContext.Session.GetString("ErrorsPresent");
                var desErrors = JsonConvert.DeserializeObject<Dictionary<string, Object>>(errorsHere);               //want to deserialize it back to an object, where the first thing is a key and the second is an object
                // string errorsHere = TempData["errorsHere"].ToString();
                // var desErrors = JsonConvert.DeserializeObject<errorsHere> (TempData["errorsHere"].ToString);
                ViewBag.errors = desErrors;
            }
            else{
                ViewBag.errors = null;
            }
            return View("Index");
        }
        [HttpPost]
        [Route("create")]
        public IActionResult create(string first_name, string last_name, int age, string email, string password) //this is pulling from the form
        {
            User NewUser = new User(first_name, last_name, age, email, password);
            string strNewUser = JsonConvert.SerializeObject(NewUser);  //serial changes it to astring...
            HttpContext.Session.SetString("UserKey", strNewUser); //now we have to store strNewUser in session--must have key and value
            bool resultsValid = TryValidateModel(NewUser);
            if(!resultsValid)
            {
                ViewBag.errors = ModelState.Values;
                // TempData["errorsHere"] = JsonConvert.SerializeObject(ModelState.Values);
                string errorsHere = JsonConvert.SerializeObject(ModelState.Values);
                HttpContext.Session.SetString("ErrorsPresent", errorsHere);
                return View("Index");           //we should always redirectToaction in a post route. You cannot use viewbag in redirect routes..We use TempData
                // return RedirectToAction("Index");
            }

            ViewBag.createdUser = NewUser;      //ViewBag only exist when you're rendering a view.
            return View("success");
        }
        [HttpGet]
        [Route("success")]
        public IActionResult success(string first_name, string last_name, int age, string email, string password) //this is pulling from the form
        {
            User NewUser = new User(first_name, last_name, age, email, password);
            ViewBag.showUser = NewUser;
            // ViewBag.FirstName = NewUser.first_name;
            // ViewBag.LastName = NewUser.last_name;
            // ViewBag.Aged = NewUser.Age;
            // ViewBag.email = NewUser.Email;
            // ViewBag.password = NewUser.Password;
            return View("success");
        }
    }
}
