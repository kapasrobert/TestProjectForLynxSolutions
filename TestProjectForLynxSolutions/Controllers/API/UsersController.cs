using System;
using System.Collections.Generic;
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


        //GET /api/users
        public IEnumerable<User> GetUsers()
        {
            return myDbContext.Users.ToList();
        }


        //GET api/users/1
        public User GetUser(int id)
        {
            var user = myDbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return user;
        }


        //POST /api/users
        [HttpPost]
        public User CreateUser(User user)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            try
            {
                myDbContext.Users.Add(user);
                myDbContext.SaveChanges();

                return user;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }


        //PUT /api/usres/1
        [HttpPut]
        public void UpdateUser(int id, User user)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var userInDatabase = myDbContext.Users.SingleOrDefault(u => u.Id == id);

            if (userInDatabase == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            try
            {
                userInDatabase.UserName = user.UserName;
                userInDatabase.Password = user.Password;
                userInDatabase.FirstName = user.FirstName;
                userInDatabase.LastName = user.LastName;
                userInDatabase.Email = user.Email;
                userInDatabase.PhoneNumber = user.PhoneNumber;

                myDbContext.SaveChanges();
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
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
