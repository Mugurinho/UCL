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

        //query and return all existing users from database
        public override IQueryable<User> GetAll()
        {
            return base.GetAll();
        }

        //return users by id
        public User GetUserById(int id)
        {
            return GetAll(x => x.UserId == id).FirstOrDefault();
        }

        //create new user
        public void Create(User user)
        {
            Add(user);
            SubmitChanges();
        }

        //update users
        public void Update(User user)
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