using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities;
using MyDatabase;
using Repositories.Persistance;

namespace SolutionDBFinalApp.Controllers
{
    public class EmployeeController : Controller
    {
        private MyDBContext db = new MyDBContext();

        UnitOfWork companyUnit;

        public EmployeeController()
        {
            companyUnit = new UnitOfWork(db);
        }

        // GET: Employee
        public ActionResult Index()
        {
            var employees = companyUnit.Employees.EmployeesWithProjectsWithManagers().ToList();
            return View(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = companyUnit.Employees.GetAllEmployeesPerProjectPerManagerById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            GetProjects();
            GetManagers();

            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName");
            GetManagers();
            GetProjects();
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                companyUnit.Employees.Add(employee);
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            GetProjects();
            GetManagers();
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", employee.ProjectId);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,ProjectId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", employee.ProjectId);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [NonAction]
        public void GetManagers()
        {
            var managers = companyUnit.Managers.GetAll();
            ViewBag.Managers = managers;
        }

        [NonAction]
        public void GetProjects()
        {
            var projects = companyUnit.Projects.GetAll();
            ViewBag.Projects = projects;
        }

        [NonAction]
        public void ShowAlert(string message)
        {
            TempData["message"] = message;
        }
    }
}
