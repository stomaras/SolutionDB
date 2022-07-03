using Entities;
using Entities.CustomValidations;
using Entities.Factory;
using Entities.Queries;
using Microsoft.AspNetCore.Mvc;
using MyDatabase;
using Repositories.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FinalApp.Controllers
{
    public class TrainerController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWork schoolUnitOfWork;

        public TrainerController()
        {
            schoolUnitOfWork = new UnitOfWork(db);
        }


        // GET: Trainer
        public ActionResult Index(TrainerSearchQuery trainerSearchQuery, string sortOrder)
        {
            List<Trainer> trainers = (List<Trainer>)schoolUnitOfWork.Trainers.GetAll();
            // Filtering ....

            ViewBag.currentSubject = trainerSearchQuery.searchSubject;

            var Filtertrainers = schoolUnitOfWork.Trainers.FilterTrainers(trainerSearchQuery, trainers);

            // Sorting ...
            ViewBag.FirstNameSortParam = String.IsNullOrEmpty(sortOrder) ? "FirstNameDesc" : "";
            ViewBag.LastNameSortParam = sortOrder == "LastNameAsc" ? "LastNameDesc" : "LastNameAsc";

            switch (sortOrder)
            {
                case "FirstNameAsc": Filtertrainers = Filtertrainers.OrderBy(x => x.FirstName).ToList();break;
                case "FirstNameDesc": Filtertrainers = Filtertrainers.OrderByDescending(x => x.FirstName).ToList();break;

                case "LastNameAsc" : Filtertrainers = Filtertrainers.OrderBy(x => x.LastName).ToList();break;
                case "LastNameDesc" : Filtertrainers = Filtertrainers.OrderByDescending(x => x.LastName).ToList();break;

                default: Filtertrainers = Filtertrainers.OrderBy(x => x.FirstName).ToList();break;
            }



            return View(Filtertrainers);
        }

       

        // GET: Trainer Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var trainer = schoolUnitOfWork.Trainers.GetById(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }


        // Get: Trainer Create
        public ActionResult Create()
        {
            return View();
        }

        // POST : Trainer Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                
                schoolUnitOfWork.Trainers.Insert(trainer);
                ShowAlert("You have successfully created employee with first name:" + trainer.FirstName + " with last name " + trainer.LastName);
                return RedirectToAction("Index");
            }
            return View(trainer);
        }

        // GET : Trainer Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var trainer = schoolUnitOfWork.Trainers.GetById(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST : Trainer Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                schoolUnitOfWork.Trainers.Update(trainer);
                ShowAlert($"You have successfully edited trainer with first name {trainer.FirstName}, with last name {trainer.LastName}");
                return RedirectToAction("Index");
            }
            return View(trainer);
        }

        // GET : DELETE
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var trainer = schoolUnitOfWork.Trainers.GetById(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }





        // POST : DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainer trainer = schoolUnitOfWork.Trainers.GetById(id);
            schoolUnitOfWork.Trainers.Delete(trainer);
            ShowAlert($"Trainer with first name {trainer.FirstName}, with last name {trainer.LastName} deleted successfully");
            return RedirectToAction("Index");
        }

        [NonAction]
        public void ShowAlert(string message)
        {
            TempData["message"] = message;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                schoolUnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}