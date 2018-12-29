using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WeddingPlanner3.Models;

namespace WeddingPlanner3.Controllers
{   
    public class WeddingController : Controller
    {
 
        
    }
}
        // [HttpGet]
        // [Route("weddings")]
        // public IActionResult Index()
        // {
        //     List<Wedding> allWeddings = _context.Weddings.Include(w => w.Planner).Include(u => u.Guest).ToList();

        //     foreach ( var wedding in allWeddings)
        //     {
        //         System.Console.WriteLine($"{wedding.WedderOne} is getting married to {wedding.WedderOne} wedding planned by )
        //         foreach(var guest in wedding.Guest)
        //         {

        //         }
        //     }
        //     string userName=HttpContext.Session.GetString("userName");
        //     ViewBag.UserName = userName;
        //     return View();
        // // }

