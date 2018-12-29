using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RazorFun.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Users()
        {
            string[] names = new string[]
            {
                "Sally",
                "Billy",
                "Joe",
                "Moose"
            };
            return View("users");
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}