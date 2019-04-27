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
        public IQueryable<Programme> Programmes { get; set; }
        public Programme Programme { get; set; }
        public List<SelectListItem> FacultyList { get; set; }
        public IQueryable<Faculty> Faculties { get; set; }
    }
}