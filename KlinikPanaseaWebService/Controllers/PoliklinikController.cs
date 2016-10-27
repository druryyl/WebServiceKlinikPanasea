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
    public class PoliklinikController : ApiController
    {
        PoliklinikBl blPoliklinik = new PoliklinikBl();

        // POST: api/Poliklinik
        public void Post(Poliklinik value)
        {
            blPoliklinik.Insert(value);    
        }

        // PUT: api/Poliklinik/5
        public void Put(Poliklinik value)
        {
            blPoliklinik.Update(value);
        }

        // DELETE: api/Poliklinik/5
        public void Delete(string id)
        {
            blPoliklinik.Delete(id);
        }

        // GET: api/Poliklinik
        public List<Poliklinik> Get()
        {
            return blPoliklinik.ListData();
        }

        // GET: api/Poliklinik/5
        public Poliklinik Get(string id)
        {
            return blPoliklinik.GetData(id);
        }

    }
}
