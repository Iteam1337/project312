using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace exampleWebApp.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult Index()
        {
            return Json(new { message = "Hello Worlds"});
        }
        public JsonResult Test()
        {
            return Json(new { message = "Hello test"});
        }
    }
}
