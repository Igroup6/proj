using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tar1.Models;

namespace AkimShifts.Controllers
{
    public class UserController : ApiController
    {
        // GET api/<controller>
        public List<User> Get()
        {
            User u = new User();
            return u.GetUsers();
        }

        // GET api/<controller>/5
        public List<User> Get(int id)
        {
            User u = new User();
            return u.GetUnitUsers(id);
        }

        // POST api/<controller>
        public void Post([FromBody]User user)
        {
            user.InsertUser();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}