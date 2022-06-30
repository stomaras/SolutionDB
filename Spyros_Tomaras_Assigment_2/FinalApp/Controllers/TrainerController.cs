using Entities;
using Entities.CustomValidations;
using Entities.Factory;
using MyDatabase;
using Repositories.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult Index()
        {
            var trainers = schoolUnitOfWork.Trainers.GetAll();
            return View(trainers);
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




        [NonAction]
        public void ShowAlert(string message)
        {
            TempData["message"] = message;
        }


    }
}