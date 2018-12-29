using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DateTime.Controllers
{
    public class HomeController : Controller//we get controller from ASp net core dot mvc
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
