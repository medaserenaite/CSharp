using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using CRUDelicious2.Models;
using System.Linq;


namespace CRUDelicious2.Controllers
{
    public class HomeController : Controller
    {
        private CRUDcontext dbContext;
        public HomeController(CRUDcontext context)
    {
        dbContext = context;
    }

        // GET: /Home/--------------------------------------------------------------------------
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dish> AllDishes = dbContext.dishes.ToList();
            ViewBag.dishes = AllDishes;
            return View();
        }

        //-----------NEW---------------------------------------------------------------
        
        [HttpGet]
        [Route("New")]
        public IActionResult New()
        {
            return View("New");
        }

        //-----------CREATE------------------------------------------------------------------
        
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Dish dish)
        {
            Dish newDish = new Dish
            {
                Name = dish.Name,
                Chef = dish.Chef,
                Tastiness =dish.Tastiness,
                Calories = dish.Calories,
                Description = dish.Description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now

            };
            dbContext.Add(newDish);
            dbContext.SaveChanges();
            Console.WriteLine("######################################################AADDDEEEDDD##########################");
            return RedirectToAction("Index");
        }

        //--------SHOW------------------------------------------------------------------

        [HttpGet]
        [Route("Show")]
        public IActionResult Show()
        {
            return RedirectToAction("Show");
        }

        //--------{DISH ID}------------------------------------------------------------------

        [HttpGet]
        [Route("{dish_id}")]
        public IActionResult Show(int dish_id)
        {
            Dish RetrievedDish = dbContext.dishes.SingleOrDefault(dish=> dish.DishID == dish_id);//dish a
            ViewBag.retrieveddish = RetrievedDish;
            return View("Show");
        }

        //------------EDIT--------------------------------------------

        [HttpGet]
        [Route("Edit/{dish_id}")]
        public IActionResult Edit(int dish_id)
        {
            Dish RetrievedDish = dbContext.dishes.SingleOrDefault(dish=> dish.DishID == dish_id);
            ViewBag.retrieveddish = RetrievedDish;
            
            return View("Edit");
        }

        //-----------UPDATE---------------------------------------

        [HttpPost]
        [Route("Update/{dish_id}")]
        public IActionResult Update(Dish editDish, int dish_id)
        {
            Dish RetrievedDish = dbContext.dishes.SingleOrDefault(a=> a.DishID == dish_id);
            RetrievedDish.Name = editDish.Name;
            RetrievedDish.Chef = editDish.Chef;
            RetrievedDish.Tastiness = editDish.Tastiness;
            RetrievedDish.Calories = editDish.Calories;
            RetrievedDish.Description = editDish.Description;
            RetrievedDish.UpdatedAt = DateTime.Now;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        //------------DELETE-------------------------------------
        [HttpGet]
        [Route("Delete/{dish_id}")]
        public IActionResult Delete(int dish_id)
        {
            Dish RetrievedDish = dbContext.dishes.SingleOrDefault(dish=> dish.DishID == dish_id);
            dbContext.dishes.Remove(RetrievedDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
