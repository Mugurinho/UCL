using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCL.Models;
using UCL.Models.Data;
using UCL.Models.Repositories;
using UCL.ViewModels;

namespace UCL.Controllers
{
    public class ProgrammeController : Controller
    {
        public ProgrammeController(ProgrammeRepository pr, FacultyRepository fr)
        {
            _pr = pr;
            _fr = fr;
        }
        private ProgrammeRepository _pr;
        private FacultyRepository _fr;
        
        // get programmes
        public ActionResult Index()
        {
            var pvm = new ProgrammeViewModel(_pr, null);
            return View(pvm);
        }

        //get the data from the model with dropdown
        public ActionResult Create()
        {
            var pvm = new ProgrammeViewModel(_pr, null);
            return View(pvm);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Programme programme)
        {
            var pvm = new ProgrammeViewModel(_pr, programme);
            if (ModelState.IsValid)
            {
                _pr.Create(pvm.Programme);
                //return RedirectToAction("Edit", new { id = pvm.Programme.ProgrammeId });
                return RedirectToAction("Index");
            }
            return View(pvm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProgrammeViewModel pvm = new ProgrammeViewModel(_pr, _pr.GetByID(id));
            return View(pvm);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection fc)
        {
            ProgrammeViewModel pvm = new ProgrammeViewModel(_pr, _pr.GetByID(id));
            TryUpdateModel(pvm);
            if(ModelState.IsValid)
            {
                _pr.Update(pvm.Programme);
                return RedirectToAction("Index");
            }
            return View(pvm);

        }
    }
}