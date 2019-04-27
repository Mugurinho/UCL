using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCL.Models.Data;
using UCL.Models.Repositories;
using UCL.ViewModels;

namespace UCL.Controllers
{
    public class FacultyController : Controller
    {
        public FacultyController(FacultyRepository fr)
        {
            _fr = fr;
        }
        protected FacultyRepository _fr;

        public ActionResult Index()
        {
            var fvm = new FacultyViewModel();
            fvm.Faculties = _fr.GetAll().OrderBy(x => x.FacultyName);
            if (fvm.Faculties == null && fvm.Faculties.Count() < 0) throw new HttpException(404, "The resource you are looking could have been removed, had its name changed, or is temporarily unavailable.");
            return View(fvm);
        }

        //get the data from the model with dropdown
        public ActionResult Create()
        {
            var fvm = new FacultyViewModel();
            fvm.FacultyList = new List<SelectListItem>();
            fvm.Faculties = _fr.GetAll();
            if (fvm.Faculties == null && fvm.Faculties.Count() < 0)
            {
                throw new HttpException(404, "Faculties not found!");
            }
            foreach (var faculty in fvm.Faculties)
            {
                fvm.FacultyList.Add(new SelectListItem { Text = faculty.FacultyName, Value = faculty.FacultyId.ToString() });
            }
            return View(fvm);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Faculty faculty, string facultyId)
        {
            var fvm = new FacultyViewModel();
            if (ModelState.IsValid)
            {
                try
                {
                    fvm.Faculty = _fr.CreateFaculty(faculty, facultyId);
                    if (fvm.Faculty == null)
                    {
                        throw new HttpException(404, "Faculty not found!");
                    }
                    _fr.SubmitChanges();
                    return RedirectToAction("Index", fvm);
                }
                catch (Exception)
                {
                    throw new HttpException(404, "Unexpected error!");
                }
            }
            return View(fvm);
        }
    }
}