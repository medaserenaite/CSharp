using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using portfolio.Models;

namespace portfolio.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        //-----------------------------------------
        [HttpGet("projects")]
        public ViewResult Projects()
        {
            return View("projects");
        }
        //-----------------------------------------
        [HttpGet("contact")]
        public ViewResult Contact()
        {
            return View("contact");
        }
    }
}