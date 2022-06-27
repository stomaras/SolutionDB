using MyDatabase;
using Repositories.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}