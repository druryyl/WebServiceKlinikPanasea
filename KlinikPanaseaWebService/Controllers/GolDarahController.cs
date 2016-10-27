using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KlinikPanaseaWebService.BusinesLogics;
using KlinikPanaseaWebService.Models;

namespace KlinikPanaseaWebService.Controllers
{
    public class GolDarahController : ApiController
    {

        // GET: api/GolDarah
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GolDarah/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GolDarah
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GolDarah/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GolDarah/5
        public void Delete(int id)
        {
        }
    }
}
