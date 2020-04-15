using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tar1.Models;

namespace AkimShifts.Controllers
{
    public class PeriodController : ApiController
    {
        // GET api/<controller>
        public void Get()
        {
         
        }

        // GET api/<controller>/5
        public bool Get(int id)
        {
            Period p = new Period();
           return p.GetPer(id);
        }

        // POST api/<controller>
        public void Post([FromBody]Period p)
        {
            p.InsertPeriod();
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