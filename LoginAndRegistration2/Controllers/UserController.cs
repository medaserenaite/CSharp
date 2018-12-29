using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using LoginAndRegistration2.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using LoginAndRegistration2.ViewModels;

namespace LoginAndRegistration2.Controllers
{
    public class UserController : Controller
    {
        private DataContext dbContext;
 
        // here we can "inject" our context service into the constructor
        public UserController(DataContext context)
        {
            dbContext = context;
        }

        //---------------------------------------------------------------------------------------INDEX--------------------------------
    
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // List<User> AllUsers = dbContext.users.ToList();
            // ViewBag.users = AllUsers;
            return View();
        }

        //-----------------------------------------------------------------------------------------CREATE METHOD------------------------------

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(User user)
        {
            if(!ModelState.IsValid)
            {
                if(dbContext.users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                }
                return View("Index");
            }
            else{
                PasswordHasher<User> Hasher = new PasswordHasher<User>();//----
                user.Password = Hasher.HashPassword(user, user.Password);//-----
                User newUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
            dbContext.Add(newUser);
            dbContext.SaveChanges();
            Console.WriteLine("###############################################success???#############################################################################################################");
            return RedirectToAction("GoToLogin");
            } 
        }

        //---------------------------------------------------------------------------------------LOGIN--------------------------------

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(ViewModels.LoginViewModel LoginUser) {
            if(ModelState.IsValid){
                var userinDB = dbContext.users.FirstOrDefault(u=>u.Email == LoginUser.Email);
                if(userinDB == null)
                {
                    ModelState.AddModelError("Email","Invalid Email");
                    return View();
                }
                var hasher = new PasswordHasher<ViewModels.LoginViewModel>();
                var result = hasher.VerifyHashedPassword(LoginUser, userinDB.Password, LoginUser.Password);
                if (result == 0){
                    ModelState.AddModelError("Password", "Invalid Password");
                    return View();
                }else{
                    var UserName = userinDB.FirstName;
                    HttpContext.Session.SetString("UserName", UserName);
                    HttpContext.Session.SetString("Login", "true");
                    return RedirectToAction("Success");
                }
            }
            return View ("Index");
        }
       
        //----------------------------------------------------------------------------------------GOTOLOGINPAGE-------------------------------

        [HttpGet]
        [Route("GoToLogin")]
        public IActionResult GoToLogin()
        {
            return View("Login");
        }

        //-----------------------------------------------------------------------------------------------------------------------

        [HttpGet]
        [Route("Success")]
        public IActionResult Success()
        {
            if(HttpContext.Session.GetString("Login") != "true" )
            {
                return RedirectToAction("Success");
            }
            else
            {
                ViewBag.FirstName =HttpContext.Session.GetString("FirstName"); ;
                return View ("Success");
            }
        
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}
