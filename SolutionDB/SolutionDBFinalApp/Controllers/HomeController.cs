using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolutionDBFinalApp.Controllers
{
    public class HomeController : Controller
    {
        private MyDatabase.MyDBContext myDBContext = new MyDatabase.MyDBContext();
        private SolutionDBFinalApp.Models.ApplicationDbContext userDb = new Models.ApplicationDbContext();

        public ActionResult Index()
        {
            var assigmentsPerUser = myDBContext.ProjectUser.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}