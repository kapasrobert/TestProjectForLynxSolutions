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

        // GET: Users
        public ViewResult Index()
        {
            var users = myDbContext.Users.ToList();

            return View(users);
        }

        // GET: User detail
        public ActionResult Details(int id)
        {
            var user = myDbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return HttpNotFound();

            return View(user);
        }
    }
}