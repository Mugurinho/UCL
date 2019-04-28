using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCL.Models;
using UCL.Models.Data;
using UCL.Models.Repositories;

namespace UCL.ViewModels
{
    public class ProgrammeViewModel
    {
        private ProgrammeRepository _pr;
        public ProgrammeViewModel(ProgrammeRepository pr, Programme programme)
        {
            _pr = pr;
            Programme = programme;
            Programmes = _pr.GetAll().OrderBy(x => x.ProgrammeId);
        }

        public IEnumerable<Programme> Programmes { get; set; }
        public Programme Programme { get; set; }
        public IQueryable<Faculty> Faculties { get; set; }


        private List<SelectListItem> facultyList = null;
        public List<SelectListItem> FacultyList
        {
            get
            {
                if (facultyList == null)
                {
                    facultyList = new List<SelectListItem>();
                    facultyList.AddRange(_pr.GetFaculties().Select(x => new SelectListItem { Text = x.FacultyName, Value = x.FacultyId.ToString() }));
                }
                return facultyList;
            }
        }
    }
}