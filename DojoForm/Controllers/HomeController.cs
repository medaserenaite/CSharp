using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DojoForm.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
//------------------------------------------------------------------
        [HttpPost("Results")]
        public IActionResult Results(string name, string location, string language, string comment)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View("Results");
        }
    }
}