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
        public JsonResult Index()
        {
            return Json(new { message = "Hello Worlds"});
        }
        public JsonResult InsertSubscriber()
        {
            databaseAccess.AddSubscriber("hellgrenj@gmail.com", "johan");
            return Json(new { message = "Hello test"});
        }
    }
}
