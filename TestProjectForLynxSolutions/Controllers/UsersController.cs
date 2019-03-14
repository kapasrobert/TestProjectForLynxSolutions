using System;
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
        public ActionResult New()
        {
            return View();
        }

        //Getting new user from view, and saving it into database
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                myDbContext.Users.Add(user);
                myDbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                //error message
            }

            return RedirectToAction("Index", "Users");
        }
    }
}