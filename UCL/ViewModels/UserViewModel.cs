using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCL.Models;
using UCL.Models.Data;

namespace UCL.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(UserRepository ur, User user)
        {
            _ur = ur;
            User = user;
        }
        private UserRepository _ur;

        public User User { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}