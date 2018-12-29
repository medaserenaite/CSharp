using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        private static Random Rand = new Random();//Generating a random passcode

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //int? count = HttpContext.Session.GetInt32("count");
            //if(count is null)
            // {
            //  count +=1;
            //  Viewbag.Password = Generate() -----> the method with creating random passcode
            //  Viewbag.Count = count;
            // }
            // else
            // {
            //  count ++;
            //  Viewbag.Password = Generate() -----> the method with creating random passcode
            //  Viewbag.Count = count;
            // }
            //HttpContext.Session.SetInt32("count", (int)count); 
            int? RunCount = HttpContext.Session.GetInt32("RunCount");//Stores the string in session
            RunCount = (RunCount == null) ? 0 : RunCount;
            RunCount++;//Total count of generating passwords/refreshing

            
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string random14 = "";
            for (int i=0;i<14;i++)
            {
                random14 = random14 + (chars[Rand.Next(0, chars.Length)]);// also could be done                                 
            }
            ViewBag.PassCode = random14;//passing passcode and count to views through viewbag
            ViewBag.RunCount = RunCount;
            HttpContext.Session.SetInt32("RunCount", (int)RunCount);//The first string passed is the key and the second is the value we want to retrieve later
            return View();
        }
    }
}
//we could also create a new method, where we create a random number (without a route and httpget/post.... returning a random passcode)
//We can also create the same No-Route method for clearing sessions in order to clear it