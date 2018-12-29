using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RazorFun.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}