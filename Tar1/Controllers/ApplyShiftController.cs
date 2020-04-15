using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tar1.Models;

namespace AkimShifts.Controllers
{
    public class ApplyShiftController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/<controller>/5
        public List<ApplyShift> Get(int id)
        {
            ApplyShift appS = new ApplyShift();
            return appS.GetApplyShift(id);
             
        }
        // POST api/<controller>
        public void Post([FromBody]List<ApplyShift> AS)
        {
            ApplyShift appS = new ApplyShift();
            appS.InsertApplyShift(AS);
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