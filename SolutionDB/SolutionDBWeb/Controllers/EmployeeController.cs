using MyDatabase;
using Repositories.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolutionDBWeb.Controllers
{
    public class EmployeeController : Controller
    {
        public static MyDBContext myDBContext = new MyDBContext();

        public UnitOfWork UnitOfWork = new UnitOfWork(myDBContext);
        // GET: Employee
        public ActionResult Index()
        {
            var employees = UnitOfWork.Employees.GetAll();
            return View(employees);
        }
    }
}