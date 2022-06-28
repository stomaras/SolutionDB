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


    }
}