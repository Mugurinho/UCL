using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UCL.Models;
using UCL.Models.Data;
using UCL.ViewModels;

namespace UCL.Controllers
{
    public class UserController : Controller
    {
        //using repository resources from Models > Repositories
        public UserController(UserRepository ur)
        {
            _ur = ur;
        }
        private UserRepository _ur;

        //get a table of user data
        public ActionResult Index()
        {
            var uvm = new UserViewModel(_ur, null);
            uvm.Users = _ur.GetAll();
            return View(uvm);
        }

        public ActionResult Details(int id)
        {
            var user = _ur.GetUserById(id);
            var uvm = new UserViewModel(_ur, user);
            return View(uvm);
        }

        //get an empty form with fields for creating new user
        public ActionResult Create()
        {
            var uvm = new UserViewModel(_ur, null);
            return View(uvm);
        }

        //post form filled with new data to create new user
        [HttpPost]
        public ActionResult Create(User user)
        {
            var uvm = new UserViewModel(_ur, user);
            if (ModelState.IsValid)
            {
                _ur.Create(uvm.User);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }

        //get edit form with existing user data
        public ActionResult Edit(int id)
        {
            var uvm = new UserViewModel(_ur, null);
            uvm.User = _ur.GetUserById(id);
            if (uvm.User == null)
            {
                return HttpNotFound();
            }
            return View(uvm);
        }

        //post edit form with new user data
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, User user)
        {
            var uvm = new UserViewModel(_ur, null);
            uvm.User = _ur.GetUserById(id);
            TryUpdateModel(uvm);
            if (ModelState.IsValid)
            {
                _ur.Update(uvm.User);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
       
        //not working fully atm
       [HttpPost]
       public ActionResult Delete(int id)
        {
            var uvm = new UserViewModel(_ur, null);
             _ur.Delete(id);
            if (uvm.User == null)
            {
                return HttpNotFound();
            }
            return View(uvm);
        }
    }
}