//1. using statements; namespace.Controllers; HomeController : Controller;
//2. Feed method

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
// using DbConnection;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetObjectFromJson<Dachi>("DachiData") == null)
            {
                HttpContext.Session.SetObjectAsJson("DachiData", new Dachi());
            }            
            ViewBag.DachiData = HttpContext.Session.GetObjectFromJson<Dachi>("DachiData");
                if(ViewBag.DachiData.Fullness < 1 || ViewBag.DachiData.Happiness < 1 ){
                    ViewBag.DachiData.Message = "Your Dachi just died...";
                } 
                if(ViewBag.DachiData.Fullness > 100 && ViewBag.DachiData.Happiness > 100 && ViewBag.DachiData.energy > 100){
                    ViewBag.DachiData.Message = "Your Dachi just succeeded in life...";
                }

            return View();
        }

        [HttpGet]
        [Route("feed")]
        public IActionResult FeedDojodachi()
        {
            Dachi CurrDachiData = HttpContext.Session.GetObjectFromJson<Dachi>("DachiData");//tikriausiai reiks mintinai atsimint
            if(CurrDachiData.Meals > 0)
            {
                CurrDachiData.Feed();
                CurrDachiData.Message = "Your Dachi is eating!";
            } 
            else 
            {
                CurrDachiData.Message = "There are no meals! Go work to earn more!";
            }
            HttpContext.Session.SetObjectAsJson("DachiData",CurrDachiData);//antra dalis atsiminimui
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("play")]
        public IActionResult PlayDojodachi()
        {
            Dachi CurrDachiData = HttpContext.Session.GetObjectFromJson<Dachi>("DachiData");
            if(CurrDachiData.Energy<5)
            {
                CurrDachiData.Message = ("You don't have enough energy to play. Get some sleep!");
            }
            else
            {
                CurrDachiData.Play();
                CurrDachiData.Message = "Your Dachi is playing!";
            }
            
            HttpContext.Session.SetObjectAsJson("DachiData",CurrDachiData);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("work")]
        public IActionResult WorkDojodachi()
        {
            Dachi CurrDachiData = HttpContext.Session.GetObjectFromJson<Dachi>("DachiData");
            if(CurrDachiData.Energy<5)
            {
                CurrDachiData.Message = ("You don't have enough energy to work. Get some sleep!");
            }
            else
            {
                CurrDachiData.Work();
                CurrDachiData.Message = "Your Dachi is working!";
            }
            HttpContext.Session.SetObjectAsJson("DachiData",CurrDachiData);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("sleep")]
        public IActionResult SleepDojodachi()
        {
            Dachi CurrDachiData = HttpContext.Session.GetObjectFromJson<Dachi>("DachiData");
            if(CurrDachiData.Fullness<5 || CurrDachiData.Happiness<5)
            {
                CurrDachiData.Message = ("Your fullness and happiness need to be at least 5 each in order to sleep");
            }
            else
            {
                CurrDachiData.Sleep();
                CurrDachiData.Message = "Your Dachi is Sleeping!";
            }
            HttpContext.Session.SetObjectAsJson("DachiData",CurrDachiData);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
}
    }


    // Somewhere in your namespace, outside other classescopy
    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes theobject to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        
        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }