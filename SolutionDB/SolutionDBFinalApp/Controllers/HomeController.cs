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

            var employeeNamesWithProjects = from assPerUser in assigmentsPerUser
                       join employee in myDBContext.Employees
                       on assPerUser.ProjectId equals employee.ProjectId
                       select new
                       {
                           EmployeeNames = employee.LastName
                           
                       };



            return Json(employeeNamesWithProjects, JsonRequestBehavior.AllowGet);
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