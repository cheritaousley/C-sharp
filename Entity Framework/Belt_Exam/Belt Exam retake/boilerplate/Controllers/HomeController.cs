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
                    HttpContext.Session.SetString("loggedUser", NewUser.first_name);
                    
                }
                return Redirect("/success");
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
                if(login_user.email != null)
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
           
            return Redirect("/success");

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
            int? userID = HttpContext.Session.GetInt32("loggedUserID"); //checking to see if user is logged in --then grabbing that user's id out of session
            User currentUser = _context.user.Where(u => u.UserId == userID).FirstOrDefault();
            
            List<Auction> AllAuctions = _context.auctions.ToList();
            List<Auction> userAuctions = _context.auctions.Include(u => u.User).Where(u => u.UserId == userID).ToList();
            
            ViewBag.AllAuctions = AllAuctions;
            ViewBag.CurrentUser = currentUser;
            return View("Success");
        }

        [HttpGet]
        [Route("newAuction")]
        public IActionResult newAuction()
        {
            int? userID = HttpContext.Session.GetInt32("loggedUserID"); //checking to see if user is logged in --then grabbing that user's id out of session
            User currentUser = _context.user.Where(u => u.UserId == userID).FirstOrDefault();

            return View("newAuction");
        }

        [HttpPost]
        [Route("createAuction")]
        public IActionResult createAuction(AuctionViewModel auctionMe, int bidder_id)
        {
            int? userID = HttpContext.Session.GetInt32("loggedUserID"); //checking to see if user is logged in --then grabbing that user's id out of session
            User currentUser = _context.user.Where(u => u.UserId == userID).FirstOrDefault();
            if(currentUser != null)
            {
                Auction NewAuction = new Auction
                {
                    product_name = auctionMe.product_name,
                    description = auctionMe.description,
                    price = auctionMe.price,
                    date = auctionMe.date,
                    UserId = (int) HttpContext.Session.GetInt32("loggedUserID"),
                };
                if (TryValidateModel(NewAuction))
                {
                    _context.auctions.Add(NewAuction);
                    _context.SaveChanges();
                    return Redirect("/success");

                }
                else
                {
                    ViewBag.errors = ModelState.Values;
                    return View("newAuction");
                }
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                return View("newAuction");
            }
        }

        [HttpGet]
        [Route("viewAuction/{auction_id}")]
        public IActionResult ViewAuction(int auction_id)
        {
            int? userID = HttpContext.Session.GetInt32("loggedUserID"); //checking to see if user is logged in --then grabbing that user's id out of session
            User currentUser = _context.user.Where(u => u.UserId == userID).FirstOrDefault();

            Auction currentAuction = _context.auctions.SingleOrDefault(u => u.AuctionId == auction_id);

            ViewBag.auctionprofile = currentAuction;
            return View("ViewAuction");
        }

        [HttpPost]
        [Route("makeBid/{auction_id}")]
        public IActionResult makeBid(int auction_id, BidderViewModel bid)
        {
            int? userID = HttpContext.Session.GetInt32("loggedUserID"); //two step process on how to get the user object out of session using the userID
            User currentUser = _context.user.Where(u => u.UserId == userID).FirstOrDefault();
            // User walletToUpdate = _context.user.Where(i => i.UserId == userID).SingleOrDefault();
            // walletToUpdate.wallet = -1;
            // _context.SaveChanges();
            Bidder NewBid = new Bidder
            {
                bidAmount = bid.bidAmount,
                UserId = currentUser.UserId,
                AuctionId = auction_id
            };
            _context.bidders.Add(NewBid);
            _context.SaveChanges();
        
            ViewBag.CurrentUser = currentUser;
            return RedirectToAction("success");
        }

        [HttpGet]
        [Route("updateWallet")]
        public IActionResult updateWallet(int bidAmount)
        {
            int? userID = HttpContext.Session.GetInt32("loggedUserID"); //two step process on how to get the user object out of session using the userID
            User currentUser = _context.user.Where(u => u.UserId == userID).FirstOrDefault();
            User walletToUpdate = _context.user.Where(i => i.UserId == userID).SingleOrDefault();
            walletToUpdate.wallet = -bidAmount;
            _context.SaveChanges();
            return RedirectToAction("success");
        }

        [HttpGet]
        [Route("delete")]
        public IActionResult DeleteBid(int auction_id)
        {
            int? userID = HttpContext.Session.GetInt32("loggedUserID"); //two step process on how to get the user object out of session using the userID
            User currentUser = _context.user.Where(u => u.UserId == userID).FirstOrDefault();
            Auction auctionToDelete = _context.auctions.Where(i => i.AuctionId == auction_id && i.UserId ==userID).SingleOrDefault();
            _context.auctions.Remove(auctionToDelete);
            _context.SaveChanges();
            return RedirectToAction("Success");

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
