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
        public JsonResult Index()
        {
            return Json(new { message = "Hello Worlds"});
        }
        
        [HttpPost]
        public JsonResult InsertSubscriber([FromBody] Subscriber subscriber)
        {
            databaseAccess.AddSubscriber(subscriber);
            return Json(new { message = subscriber.Name + " was created successfully!"});
        }
    }
}
