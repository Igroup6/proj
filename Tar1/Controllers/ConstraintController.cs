using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tar1.Models;

namespace AkimShifts.Controllers

{
    public class ConstraintController : ApiController
    {
        // GET api/<controller>
        public List<Constraint> Get()
        {
            Constraint c = new Constraint();
            return c.getConstraint();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5    
        public void Put(int id, [FromBody] Constraint c)
        {
            Constraint constr = new Constraint();
            constr.upadteConstraint(c);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
