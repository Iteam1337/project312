using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using project312.Models;
using project312.modules;

namespace project312.Controllers
{
    public class HomeController : Controller
    {
        IDatabaseAccess databaseAccess;
        public HomeController(IDatabaseAccess injectedDatabaseAccess) {
            databaseAccess = injectedDatabaseAccess;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult InsertSubscriber([FromBody] Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                databaseAccess.AddSubscriber(subscriber);
                return Json(new { message = subscriber.Name + " was created successfully!"});
            }
            else
            {
                return Json(ModelState);
            }
        }
    }
}
