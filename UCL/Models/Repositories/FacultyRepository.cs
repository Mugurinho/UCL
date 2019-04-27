using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCL.Models.Data;

namespace UCL.Models.Repositories
{
    public class FacultyRepository : RepositoryBase<UCLEntities, Faculty>
    {
        public FacultyRepository(UCLEntities entities) : base(entities)
        {

        }

        public Faculty GetFacultyById(int id)
        {
            return GetAll(x => x.FacultyId == id).FirstOrDefault();
        }
        
        //list the faculties in the dropdown
        public override IQueryable<Faculty> GetAll()
        {
            return base.GetAll(x => true);
        }

        //get programmes by title in the list
        public Faculty GetByName(string name)
        {
            return GetAll(x => x.FacultyName == name).FirstOrDefault();
        }

        public Faculty CreateFaculty(Faculty faculty, string facultyId)
        {
            Faculty fac = new Faculty
            {
                FacultyName = faculty.FacultyName,
                FacultyId = int.Parse(facultyId)
            };
            base.Add(fac);
            return fac;
        }
    }
}