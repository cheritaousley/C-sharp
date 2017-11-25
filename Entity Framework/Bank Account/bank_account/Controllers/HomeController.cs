using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//adding Entity Framework//
using Microsoft.EntityFrameworkCore;
using bank_account.Models;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity; //for hashing password

namespace bank_account.Controllers
{
    public class HomeController : Controller
    {
        private BankContext _context;
        private readonly DbConnector _dbConnector;
        public HomeController(BankContext context, DbConnector connect)
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
        public IActionResult create(RegisterViewModel reguser)  //this will hold what the user enters
        {
           User NewUser = new User   //new user is the package semdimg to the database//this is what is being sent by to the database
            {
                first_name = reguser.first_name,
                last_name = reguser.last_name,
                username = reguser.username,
                age = reguser.age,
                email = reguser.email,
                password = reguser.password
            };
            if (TryValidateModel(NewUser))
            {
                if(NewUser.password == reguser.confirm_password)
                {
                    PasswordHasher<RegisterViewModel> Hasher = new PasswordHasher<RegisterViewModel>();
                    NewUser.password = Hasher.HashPassword(reguser, NewUser.password);
                    _context.user.Add(NewUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetString("loggedUser",reguser.first_name);
                }
                return RedirectToAction("Success");
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                System.Console.WriteLine("=============================");
                System.Console.WriteLine(ViewBag.errors);
                System.Console.WriteLine("=============================");
                
            }
            ViewBag.login_user = reguser.first_name;
            return View("Index");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModel loguser)//this is saying look for an input from a form named "Email", so either change this name or change the form
        {
            var login_user = _context.user.SingleOrDefault(user => user.email == loguser.loginEmail);
            if(login_user != null)
            {
                PasswordHasher<LoginViewModel> Hasher = new PasswordHasher<LoginViewModel>();
                if (Hasher.VerifyHashedPassword(loguser, login_user.password, loguser.loginPassword) != 0 )
                {
                    HttpContext.Session.SetString("loggedEmail", loguser.loginEmail);
                    HttpContext.Session.SetString("loggedUser", login_user.first_name);
                }
                else
                {
                    ViewBag.fail = "User does not exist";
                    return View("logUser");
                }
            }
            else{
                ViewBag.fail = "Fields cannot be blank!";
            }
            ViewBag.login_user = login_user.first_name;
            return View("Success");
            // if(login_user.email == loguser.loginEmail)
            // {
            //     return View("Success");
            // }
    
        }

        [HttpGet]
        [Route("logUser")]
        public IActionResult LogUser(LoginViewModel loguser)
        {
            return View("LogUser");
        }

        [HttpGet]
        [Route("account")]
        public IActionResult Success()
        {
            // List<User> AllUsers = _context.user.ToList();
            // List<Transaction> AllTransactions = _context.transactions.ToList();
            // ViewBag.users = AllUsers;
            // ViewBag.transactions = AllTransactions;
            ViewBag.login_user = HttpContext.Session.GetString("loggedUser"); //remember view bags does not exist over redirects! so must call on that session (using Get) when i am ready to view that variable
            return View("Success");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
