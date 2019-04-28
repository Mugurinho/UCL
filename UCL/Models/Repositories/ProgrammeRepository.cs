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

        public void Create(Programme programme)
        {
            Add(programme);
            SubmitChanges();
        }

        public void Update(Programme programme)
        {
            SubmitChanges();
        }

        public IEnumerable<Faculty> GetFaculties()
        {
            return _entities.Faculties.ToList();
        }
    }
}