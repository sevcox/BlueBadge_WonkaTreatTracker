using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TreatTracker.WebAPI.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        /// <summary>
        /// Looks up wonka data by the id entered in
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
