using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace Random_Passcode.Controllers
{
    public class RandompwController : Controller
    {
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // int? count = HttpContext.Session.GetInt32("count");
            if (HttpContext.Session.GetInt32("count") == null) //checking to see if session exists
            {
                HttpContext.Session.SetInt32("count", 1);       //if session doesn't exist, set it to 1
            }
            else{
                HttpContext.Session.SetInt32("count", ((int)HttpContext.Session.GetInt32("count") + 1)); //if the session exists, increment by 1
            }
            
            string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            string builder = "";
            Random random = new Random();
            
            for (int i = 0; i < 15; i++)
            {
                builder += chars[random.Next(0, chars.Length)];
            }

            // var count = HttpContext.Session.GetInt32("Count");
            // if(count == null)
            // {
            //     count = 0;
            // }

            ViewBag.count = HttpContext.Session.GetInt32("count");
            ViewBag.random_passcode = builder;
            return View("index");

        }
        [HttpGet]
        [Route("clear")]
        public IActionResult clear()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }
    }
}
