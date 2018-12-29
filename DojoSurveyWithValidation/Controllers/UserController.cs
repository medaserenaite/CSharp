using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using DojoSurveyWithValidation.Models;//ADD THIS TO CONNECT TO MODELS
using Microsoft.AspNetCore.Http;

namespace DojoSurveyWithValidation.Controllers
{
    public class UserController : Controller
    {
        //---------------------------------------------Index----------------------------
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        //---------------------------------------------Results Page----------------------------
        // [HttpGet]
        // [Route("Results")]
        // public RedirectToActionResult Results()
        // {
        //     return RedirectToAction("Results");
        // }
        //---------------------------------------------Submit action---------------------------
        [HttpPost]
        [Route("submit")]
        public IActionResult Submit(SurveyForm surveyForm)
        {
            if(!ModelState.IsValid)
            {
                return View("Index", surveyForm);
            } 
            return RedirectToAction("Results", surveyForm);
        }
    }
}
