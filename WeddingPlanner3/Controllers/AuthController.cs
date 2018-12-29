using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner3.Models;
using WeddingPlanner3.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace WeddingPlanner3.Controllers
{
    public class AuthController : Controller
    {
        
        private DataContext _context;
        public AuthController(DataContext context)
        {
            _context = context;
        }

        //----------------------------------------------------------- I N D E X ----------------------

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        //------------------------------------------------------------- R E G I S T E R ----------------------

        [HttpPost]
        [Route("register")]
        public IActionResult Registration(RegistrationViewModel reg)
        {
            if(!ModelState.IsValid)
            {
                return View("Index");
            }
            User UserInDB = _context.Users.FirstOrDefault(u => u.Email == reg.Email);
            if(UserInDB != null)
            {
                ModelState.AddModelError("Email", "User already exists");
                return View("Index");
            }
            PasswordHasher<RegistrationViewModel> hasher = new PasswordHasher<RegistrationViewModel>();
            string hashedPW = hasher.HashPassword(reg, reg.Password);
            User newUser = new User
            {
                FirstName = reg.FirstName,
                LastName = reg.LastName,
                Email = reg.Email,
                Password = hashedPW
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();

            User loggedIn = _context.Users
                .FirstOrDefault (u => u.Email == reg.Email);

            HttpContext.Session.SetInt32 ("userId", loggedIn.UserID);
            HttpContext.Session.SetString ("userName", loggedIn.FirstName);

            return RedirectToAction("Home"); 
        }

        //---------------------------------------------------------------- L O G I N -----------------------

        [HttpPost ("login")]
        public IActionResult Login(LoginViewModel LoginUser) 
        {
            if(!ModelState.IsValid)
            {
               return View("Index");
            }
            User userinDB = _context.Users.FirstOrDefault(u=>u.Email == LoginUser.Email);
            
            if(userinDB is null)
            {
                ModelState.AddModelError("Email","Invalid Email");
                return View("Index");
            }

            PasswordHasher<LoginViewModel> hasher = new PasswordHasher<LoginViewModel> ();
            var result = hasher.VerifyHashedPassword (LoginUser, userinDB.Password, LoginUser.Password);
            if (result == 0)
            {
                ModelState.AddModelError ("LoginEmail", "Invalid Login");
                return View ("Index");
            }
            User loggedIn = _context.Users.FirstOrDefault (u => u.Email == LoginUser.Email);
            
            HttpContext.Session.SetInt32 ("ID", loggedIn.UserID);
            HttpContext.Session.SetString("UserName", loggedIn.FirstName);
            HttpContext.Session.SetString("Login", "true");
            return RedirectToAction("Home");
        }//--------------------------------------------------------------- H O M E - G E T -------------------

        [HttpGet]
        [Route("Home")]
        public IActionResult Home(int wedding_id)
        {
            //getting user id, which is set in session(done in login)
            int? userId = HttpContext.Session.GetInt32 ("ID");
            //if user is not logged in - he/she can't see the page
            if (userId == null){
                return RedirectToAction ("Index");    
            }

            //getting all the wedding, including guests, who are attending? ? ?  ?? ? ? 
            List<Wedding> allWeddings = _context.Weddings
                .Include (w => w.Guests)
                .ThenInclude (g => g.Attending)
                .ToList ();

            //getting user username stored in session
            string userName = HttpContext.Session.GetString ("userName");

            //passing user id to viewbag(in order to be able to display on html)
            ViewBag.User = _context.Users.Where (u => u.UserID == userId).FirstOrDefault ();

            //passing username in order to view on html
            ViewBag.UserName = userName;

            //passing weddings in order to display on page
            ViewBag.Weddings = allWeddings;
            
            return View("Home");
        }
        //---------------------------------------------------------- L O G O U T --------------------------

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        //--------------------------------------------------------- N E W  W E D D I N G -------------------------

        [HttpGet]
        [Route("NewWedding")]
        public IActionResult NewWedding()
        {
            return View("NewWedding");
        }

        //--------------------------------------------------------- A D D  W E D D I N G ---------------------------

        [HttpPost]
        [Route("add")]
        public IActionResult AddWedding(AddWeddingViewModel wedding)
        {
            
            int? userID = HttpContext.Session.GetInt32("ID");
            if(userID == null)
            {
                return RedirectToAction("Index");
            }
            if(!ModelState.IsValid)
            {
                return View("NewWedding");
            }
            Wedding NewWedding = new Wedding
            {
                WedderOne = wedding.WedderOne,
                WedderTwo = wedding.WedderTwo,
                Date = DateTime.Now,
                UserID = (int) userID
            };
            _context.Weddings.Add(NewWedding);
            _context.SaveChanges();
            Console.WriteLine("####################################################################am i added#######################################################################");
            return RedirectToAction("Home");
        }
        [HttpGet]
        [Route("rsvp/{wedding_id}")]
        public IActionResult RSVP(int wedding_id)
        {
             //getting user id from session
            int? userId = HttpContext.Session.GetInt32 ("ID");


            //we use logged in user id to describe user who's going to join the wedding
            //this is going to be 'Attending' in the new guest table
            User userToJoin = _context.Users
                .FirstOrDefault (u => u.UserID == userId);


            //we're creating rsvp here so wedding attaches to the guest with a wedding id
            //are we joining the wedding with the creation of a new guest? 
            Wedding weddingToJoin = _context.Weddings
                .Include (g => g.Guests)
                .FirstOrDefault (w => w.WeddingID == wedding_id);


            //creating new guest!!!!!!!
            Guest newGuest = new Guest
            {
                UserID = (int) userId,
                WeddingID = wedding_id,
                Attending = userToJoin,
                Wedding = weddingToJoin
            };

            _context.Guests.Add (newGuest);
            _context.SaveChanges ();

            
            return RedirectToAction("Home");
        }
        [HttpGet ("unrsvp/{wedding_id}")]
        public IActionResult UnRsvp (int wedding_id)
        {
            int? userId = HttpContext.Session.GetInt32 ("ID");
            Guest rsvp = _context.Guests
                .FirstOrDefault (g => g.WeddingID == wedding_id && g.UserID == userId);

            _context.Remove(rsvp);
            _context.SaveChanges();

            return RedirectToAction ("Home");
        }
        [HttpGet]
        [Route("delete/{wedding_id}")]
        public IActionResult Delete(int wedding_id)
        {
            int? userId = HttpContext.Session.GetInt32 ("ID");
            if(userId == null)
            {
                return RedirectToAction("Index");
            }
            
            Wedding RetrievedWedding=_context.Weddings.FirstOrDefault(w=>w.WeddingID = wedding_id);
            _context.Weddings.Remove(RetrievedWedding);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }
    }
}
