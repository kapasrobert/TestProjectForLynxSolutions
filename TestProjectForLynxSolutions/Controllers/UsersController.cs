﻿using System;
using System.Linq;
using System.Web.Mvc;
using TestProjectForLynxSolutions.Models;

namespace TestProjectForLynxSolutions.Controllers
{
    public class UsersController : Controller
    {
        private MyDbContext myDbContext;


        public UsersController()
        {
            myDbContext = new MyDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            myDbContext.Dispose();
        }


        //Display all users
        public ViewResult Index()
        {
            var users = myDbContext.Users.ToList();

            return View(users);
        }


        //User detail
        public ActionResult Details(int id)
        {
            var user = myDbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return HttpNotFound();

            return View(user);
        }


        //Show new user creation page
        public ViewResult New()
        {
            //initialize the user object to automatically set the Id to 0, 
            //otherwise the ValidationSummary will contain "The Id field is required"
            var user = new User();

            return View("UserForm", user);
        }


        //Get a user and load the edit page for that user
        public ActionResult Edit(int id)
        {
            var user = myDbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return HttpNotFound();

            return View("UserForm", user);
        }


        //Save a new user or edit an existing user
        [HttpPost]
        public ActionResult Save(User user)
        {
            //server side validation
            //check if user data is valid
            if (!ModelState.IsValid)
            {
                return View("UserForm", user);
            }

            //try to save the new or existing user
            try
            {
                if (user.Id == 0)  //create new user
                {
                    myDbContext.Users.Add(user);
                }
                else  //edit existing user
                {
                    var userInDatabase = myDbContext.Users.Single(u => u.Id == user.Id);
                    userInDatabase.UserName = user.UserName;
                    userInDatabase.Password = user.Password;
                    userInDatabase.FirstName = user.FirstName;
                    userInDatabase.LastName = user.LastName;
                    userInDatabase.Email = user.Email;
                    userInDatabase.PhoneNumber = user.PhoneNumber;
                }

                myDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string exmsg = ex.Message;
                //error message
            }

            return RedirectToAction("Index", "Users");
        }
    }
}