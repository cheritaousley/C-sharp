using System;
using System.Collections.Generic;
using users_app.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using users_app.Factory; //Need to include reference to new Factory 

namespace users_app.Controllers
{
    public class HomeController : Controller
    {
        private const string LOGGED_IN_USER = "xyz123"; // what does this mean?

        // We started with the DB connector...
        private readonly DbConnector _dbConnector;
        // Now we've moved onto factories...
        private readonly TrailItemFactory _trailItemFactory;
        private readonly UserFactory _userFactory;
       
        //     //Instantiate a UserFactory object that is immutable (READONLY)
        //     //This establishes the initial DB connection for us.
        
        public HomeController(DbConnector connector, TrailItemFactory wif, UserFactory uf)
        {
            _trailItemFactory = wif;
            _userFactory = uf;
            _dbConnector = connector;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginRegViewModel loginVM)
        {
            User user = _userFactory.GetUserByEmail(loginVM.loginVM.loginEmail);
            if (user != null)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();

                if (0 != Hasher.VerifyHashedPassword(user, user.password, loginVM.loginVM.loginPassword))
                {
                    //Handle success
                    HttpContext.Session.SetString(LOGGED_IN_USER, user.first_name);
                }
            }
            ViewBag.loggedUser_name = user.first_name;
            ViewBag.loggedUser_email = user.email;
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("register")]  //or create user route
        public IActionResult Register(LoginRegViewModel regVM)
        {
            RegisterViewModel registerVM = regVM.registerVM;

            if (TryValidateModel(registerVM))
            {
                if (registerVM.password == registerVM.confirm_password)
                {
                    PasswordHasher<RegisterViewModel> Hasher = new PasswordHasher<RegisterViewModel>();
                    registerVM.password = Hasher.HashPassword(registerVM, registerVM.password);
                    _userFactory.Register(regVM.registerVM);
                    HttpContext.Session.SetString(LOGGED_IN_USER, regVM.registerVM.first_name);
                }
            }

            return RedirectToAction("Success");
        }
        [HttpPost]
        [Route("create")]
        public IActionResult CreateProduct(TrailItem newItem)
        {
            if (TryValidateModel(newItem))
            {
                _trailItemFactory.Add(newItem);
                return RedirectToAction("Success");
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                return View("CreateProduct");
            }
        }
        [HttpGet]
        [Route("success")] //successfully added a product
        public IActionResult Success()
        {

            IEnumerable<TrailItem> factoryResult = _trailItemFactory.FindAll();
            ViewBag.menuItems = factoryResult;

            return View("Success");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}