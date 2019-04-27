using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCL.Models.Data;
using UCL.Models;

namespace UCL.Models.Repositories
{
    public class ProgrammeRepository : RepositoryBase<UCLEntities, Programme>
    {
        //private const string UserSession = "CurrentUser";

        public ProgrammeRepository(UCLEntities entities) : base(entities)
        {

        }

        // return programmes 
        public override IQueryable<Programme> GetAll()
        {
            return base.GetAll(x => true);
        }

        //return programmes by id
        public Programme GetByID(int id)
        {
            return GetAll(x => x.ProgrammeId == id).FirstOrDefault();
        }

        //get programmes by title in the list
        public Programme GetByTitle(string title)
        {
            return GetAll(x => x.ProgrammeTitle == title).FirstOrDefault();
        }

        public Programme CreateProgramme(Programme programme, string facultyId)
        {
            Programme pro = new Programme
            {
                ProgrammeTitle = programme.ProgrammeTitle,
                ProgrammeDescription = programme.ProgrammeDescription,
                ProgrammeFee = programme.ProgrammeFee,
                FacultyId = int.Parse(facultyId)
            };
            base.Add(pro);
            return pro;
        }
    }
}