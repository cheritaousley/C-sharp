using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using users_app.Models;
using Newtonsoft.Json;

namespace users_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;

        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        [Route("create")]
        public IActionResult create(string first_name, string last_name, int age, string email, string password, string confirm_password) //pulling information from the form
        {
            User NewUser = new User(first_name, last_name, age, email, password, confirm_password);
            string strNewUser = JsonConvert.SerializeObject(NewUser);  //changing object NewUser to a string via serial
            HttpContext.Session.SetString("UserKey", strNewUser); //storing now string NewUser into session
            
            if(TryValidateModel(NewUser))
            {
                // TempData["userCreated"] = JsonConvert.SerializeObject(ModelState.Values);
                // Console.WriteLine("-----------------------------------------------");
                // Console.WriteLine(TempData["userCreated"]);
                // Console.WriteLine("-----------------------------------------------");
                string query = $"INSERT INTO User(first_name, last_name, age, email, password) VALUES('{first_name}','{last_name}','{age}','{email}', '{password}')";
                _dbConnector.Execute(query);
                ViewBag.userCreated =first_name;
                return View("success");   //Should always redirect in post route, and you can only use tempData to store info in btw routes
            }
            else
            {
                ViewBag.errors = ModelState.Values;
            }
                return View("Index");           //why arent we redirecting again? To keep form entries filled AND present errors
        }
        [HttpGet]
        [Route("success")]
        public IActionResult success(string first_name, string last_name, int age, string email, string password, string confirm_password) //this is pulling from the form
        {
            // string userInfo = TempData["userCreated"].ToString();   //why is this needed when it is already converted to a string in line 40?
            // User NewUser = JsonConvert.DeserializeObject<User>(userInfo);
            // ViewBag.NewUser = NewUser;
            // ViewBag.NewUser = TempData["userCreated"];
            return View("success");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult login(string email, string password, int id) 
        {
            string selectquery = $"SELECT * from User where email = '{email}'"; //creating the query as a string
            List<Dictionary<string, object>> result = _dbConnector.Query(selectquery); //executing the query and stored in 'result' as a list of dictionaries
            var user = result[0]; 
            if((string) user["password"] == password)
            {
                HttpContext.Session.SetInt32("logUser", id);
                Console.WriteLine("-----------------------------------------------");
                System.Console.WriteLine(email);
                Console.WriteLine("-----------------------------------------------");
                ViewBag.logUser = email;
                return View("success");
            }
            else
            {
                ViewBag.fail = "User does not exist";
                return View("Index");
            }
        }
    }
}
