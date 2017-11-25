using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//adding Entity Framework//
using Microsoft.EntityFrameworkCore;
using restaurant.Models;
using System.Linq;

namespace restaurant.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantContext _context;
        private readonly DbConnector _dbConnector;
        public HomeController(RestaurantContext context, DbConnector connect)
        {
            _context = context;
            _dbConnector = connect;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult create(AddReviewViewModel model)  //we must pass in the model or object here and give it a name. We are accepting a addreviewviewmodel and calling it model
        {
            Review NewReview = new Review
            {
                Reviewer_Name = model.Reviewer_Name,
                Restaurant_Name = model.Restaurant_Name,
                Description =model.Description,
                Date = model.Date,
                Stars = model.Stars
            };
            if (TryValidateModel(NewReview))
            {
                _context.reviews.Add(NewReview);
                _context.SaveChanges();
                return View("Success");
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                System.Console.WriteLine("=============================");
                System.Console.WriteLine(ViewBag.errors);
                System.Console.WriteLine("=============================");
                
            }
            return View("Index");
        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult Success()
        {
            List<Review> AllReviews = _context.reviews.ToList();
            ViewBag.reviews = AllReviews;
            return View("Success");
        }
    }
}
