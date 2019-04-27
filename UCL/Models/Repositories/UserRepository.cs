using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCL.Models.Data;
using UCL.Models;

namespace UCL.Models
{
    public class UserRepository : RepositoryBase<UCLEntities, User>
    {
        private const string UserSession = "CurrentUser";

        public UserRepository(UCLEntities entities) : base(entities)
        {

        }

        //return all existing users from database when Index
        public override IQueryable<User> GetAll()
        {
            return base.GetAll();
        }

        //return user by id when Edit action
        public User GetUserById(int id)
        {
            return GetAll(x => x.UserId == id).FirstOrDefault();
        }

        //create new user when Create action
        public void Create(User user)
        {
            Add(user);
            SubmitChanges();
        }

        //update users when Edit action
        public void Update(User user)
        {
            SubmitChanges();
        }

        public void Delete(int id)
        {
            SubmitChanges();
        }

        public User CurrentUser
        {
            get
            {
                return (User)HttpContext.Current.Session[UserSession];
            }
        }
    }
}