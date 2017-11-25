using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Dojodachi.Controllers
{
    public class dojodachiController : Controller
    {
        public class Dachi
        {
            public int fullness;
            public int happiness;
            public int energy;
            public int meals;
            public bool alive;
            public bool happy; 
            public bool win; 
            public Dachi()
            {
                fullness = 20;
                happiness = 20;
                energy = 50;
                meals = 3;
            }
        }
        public static Dachi dojodachi;
        public static Random rnd = new Random();
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // int? count = HttpContext.Session.GetInt32("count");
            if (dojodachi == null) //checking to see if session exists
            {
                dojodachi = new Dachi;       //if session doesn't exist, set it to 1
            }
            else
            {
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
