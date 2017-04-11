using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public JsonResult InsertSubscriber()
        {
           databaseAccess.AddSubscriber("hellgrenj@gmail.com", "johan");
           return Json(new { message = "Hello test"});
        }
    }
}