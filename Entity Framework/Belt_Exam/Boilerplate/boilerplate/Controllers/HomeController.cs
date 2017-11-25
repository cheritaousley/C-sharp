using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//adding Entity Framework//
using Microsoft.EntityFrameworkCore;
using boilerplate.Models;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity; //for hashing password

namespace boilerplate.Controllers
{
    public class HomeController : Controller
    {
        private BoilerplateContext _context;
        public HomeController(BoilerplateContext context)
        {
            _context = context;
        }

        // GET: /Home Page/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        //=======================Register User=====================//
        [HttpPost]
        [Route("register")]
        public IActionResult create(RegisterViewModel reguser)  //this will hold what the user enters
        {
            User NewUser = new User   //new user is the package sendimg to the database//this is what is being sent by to the database
            {
                first_name = reguser.first_name,
                last_name = reguser.last_name,
                username = reguser.username,
                age = reguser.age,
                email = reguser.email,
                password = reguser.password,
                description =reguser.description
            };
            if (TryValidateModel(NewUser))
            {
                if (NewUser.password == reguser.confirm_password)
                {
                    PasswordHasher<RegisterViewModel> Hasher = new PasswordHasher<RegisterViewModel>();
                    NewUser.password = Hasher.HashPassword(reguser, NewUser.password);
                    _context.user.Add(NewUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("loggedUserID", NewUser.UserId);//be sure to use th enew object just created to grab the Id, the view model doesnt have the id
                    
                    // HttpContext.Session.SetString("loggedUser", reguser.first_name);
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
        //=======================Post route for Logging in User=====================//
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModel loguser)//this is saying look for an input from a form named "Email", so either change this name or change the form
        {
            User login_user = _context.user.SingleOrDefault(user => user.email == loguser.loginEmail);
            if (login_user != null)
            {
                PasswordHasher<LoginViewModel> Hasher = new PasswordHasher<LoginViewModel>();
                if (Hasher.VerifyHashedPassword(loguser, login_user.password, loguser.loginPassword) != 0)
                {
                    HttpContext.Session.SetInt32("loggedUserID", login_user.UserId);
            
                    HttpContext.Session.SetString("loggedUser", login_user.first_name);
                }
                else
                {
                    ViewBag.fail = "User does not exist";
                    return View("logUser");
                }
            }
            else
            {
                ViewBag.fail = "Fields cannot be blank!";
            }
            // int? userID = HttpContext.Session.GetInt32("loggedUserID");
            // User currentUser = _context.user.Where(u => u.UserId == userID).FirstOrDefault();
            // ViewBag.CurrentUser = currentUser;
            // ViewBag.login_user = login_user.first_name;
            return RedirectToAction("Success");

        }
        //=======================Display form to login User=====================//
        [HttpGet]
        [Route("logUser")]
        public IActionResult LogUser(LoginViewModel loguser)
        {
            return View("LogUser");
        }
        //=======================Displays all "things", Users included=====================//
        [HttpGet]
        [Route("success")]
        public IActionResult Success(int LeftId)
        {
            int? userID = HttpContext.Session.GetInt32("loggedUserID"); //two step process on how to get the user object out of session using the userID
            User currentUser = _context.user.Where(u => u.UserId == userID).FirstOrDefault();

            // ViewBag.userRight = currentUser.Right.ToList();
            List<Connection> invitations = _context.connections.Include(p => p.Left).Where(a => a.RightId == userID).Where(s => s.Status == false).ToList();
            List<Connection> friends = _context.connections.Include(p => p.Left).Where(s => s.Status== true).Where(u => u.RightId == userID).ToList();
        
            ViewBag.invitations = invitations; //all the users who have sent invites, awaitng acceptance
            ViewBag.friends = friends; //all the users that were accepted by the logged in user
            ViewBag.CurrentUser = currentUser; 

            return View("Success");
        }

        [HttpGet]
        [Route("users")]
        public IActionResult UsersToConnect()
        {
            int? login_user = HttpContext.Session.GetInt32("loggedUserID");
            List<User> excluding_user = _context.user.Where(u => u.UserId != login_user).ToList();
            ViewBag.excluding_user = excluding_user;
            // ViewBag.User = HttpContext.Session.GetInt32("loggedUserID");//never need to send this through template, in this case
            return View("Users");
        }

        [HttpGet]
        [Route("connect/{requesting_id}")]
        public IActionResult Connect(int requesting_id)
        {
            int? login_user = HttpContext.Session.GetInt32("loggedUserID"); //this is a two step process to see if a user is logged in, ideally it should be done whenever you render a new page
            User loggedUserID = _context.user.SingleOrDefault(_user => _user.UserId == login_user);
            
            Connection NewConnection = new Connection()
            {
                LeftId = (int) HttpContext.Session.GetInt32("loggedUserID"),
                RightId = requesting_id,
            };
            
            ViewBag.User = HttpContext.Session.GetInt32("loggedUserID");
            _context.connections.Add(NewConnection);
            _context.SaveChanges();
            return RedirectToAction("success");
        }

        [HttpGet]
        [Route("viewUser/{user_id}")]
        public IActionResult ViewUser(int user_id)
        {
            User current_user = _context.user.SingleOrDefault(u => u.UserId == user_id);
            
            ViewBag.userprofile = current_user;
            return View("ViewUser");
        }


        [HttpGet]
        [Route("accept/{LeftId}")]
        public IActionResult Accept(int LeftId)
        {
            int? userID = HttpContext.Session.GetInt32("loggedUserID"); //two step process on how to get the user object out of session using the userID
            User currentUser = _context.user.Where(u => u.UserId == userID).FirstOrDefault();

            // User current_user = _context.user.SingleOrDefault(u => u.UserId == user_id);
            Connection inviteToUpdate = _context.connections.Where(i => i.RightId == userID && i.LeftId == LeftId).SingleOrDefault();
            inviteToUpdate.Status = true;
            _context.SaveChanges();

            ViewBag.CurrentUser = currentUser;
            // ViewBag.userprofile = current_user;
            return RedirectToAction("success");
        }
        [HttpGet]
        [Route("ignore/{requesting_id}/")]
        public IActionResult Ignore(int requesting_id)
        {
            int? userID = HttpContext.Session.GetInt32("loggedUserID"); //two step process on how to get the user object out of session using the userID
            User currentUser = _context.user.Where(u => u.UserId == userID).FirstOrDefault();

            if (HttpContext.Session.GetString("loggedUserID") == null)
            {
                return Redirect("");
            }
            Connection inviteToDelete = _context.connections.Where(i => i.RightId == userID && i.LeftId == requesting_id ).SingleOrDefault();
            _context.connections.Remove(inviteToDelete);
            _context.SaveChanges();

            // int? currUser = HttpContext.Session.GetInt32("loggedEmail");
            // var useremail = HttpContext.Session.GetString("loggedEmail");
            // var log = _context.user.SingleOrDefault(u => u.email == useremail);
            // ViewBag.someuser = log.UserId;

            // Invitation delInvite = _context.invitations.SingleOrDefault(my => my.InvitationId == InvitationId); //retrieve the particular user's information from the DB
            // delInvite.AcceptingInviteId = 0;
            // _context.SaveChanges(); //save the changes in the DB

            return Redirect("/success");
        }
        //=======================LogOut=====================//
        [HttpGet]
        [Route("logout")]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            //how do you make it so they cannot go to the successful page?
            return RedirectToAction("LogUser"); 
        }
    }
}
