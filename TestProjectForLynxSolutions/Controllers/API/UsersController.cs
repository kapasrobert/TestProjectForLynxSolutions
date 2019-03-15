using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using TestProjectForLynxSolutions.Models;

namespace TestProjectForLynxSolutions.Controllers.API
{
    public class UsersController : ApiController
    {
        private MyDbContext myDbContext;

        public UsersController()
        {
            myDbContext = new MyDbContext();
        }


        //DELETE /api/users/1
        [HttpDelete]
        public void DeleteUser(int id)
        {
            var userInDatabase = myDbContext.Users.SingleOrDefault(u => u.Id == id);

            if (userInDatabase == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            try
            {
                myDbContext.Users.Remove(userInDatabase);
                myDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //handle error
            }
        }
    }
}
