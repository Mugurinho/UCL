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
            var pvm = new ProgrammeViewModel();
            pvm.Programmes = _pr.GetAll().OrderBy(x => x.ProgrammeId);
            if (pvm.Programmes == null && pvm.Programmes.Count() < 0) throw new HttpException(404, "The resource you are looking could have been removed, had its name changed, or is temporarily unavailable.");
            return View(pvm);
        }

        //get the data from the model with dropdown
        public ActionResult Create()
        {
            var pvm = new ProgrammeViewModel();
            pvm.FacultyList = new List<SelectListItem>();
            pvm.Faculties = _fr.GetAll();
            if (pvm.Faculties == null && pvm.Faculties.Count() < 0)
            {
                throw new HttpException(404, "Faculties not found!");
            }
            foreach (var faculty in pvm.Faculties)
            {
                pvm.FacultyList.Add(new SelectListItem { Text = faculty.FacultyName, Value = faculty.FacultyId.ToString() });
            }
            return View(pvm);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Programme programme, string facultyId)
        {
            var pvm = new ProgrammeViewModel();
            if (ModelState.IsValid)
            {
                try
                {
                    pvm.Programme = _pr.CreateProgramme(programme, facultyId);
                    if (pvm.Programme == null)
                    {
                        throw new HttpException(404, "Programme not found!");
                    }
                    _pr.SubmitChanges();
                    return RedirectToAction("Index", pvm);
                }
                catch (Exception)
                {
                    throw new HttpException(404, "Unexpected error!");
                }
            }
            return View(pvm);
        }
    }
}