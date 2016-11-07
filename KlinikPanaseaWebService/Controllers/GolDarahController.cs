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
        GolDarahBl blGolDarah = new GolDarahBl();

        // POST: api/GolDarah
        public void Post(GolDarah value)
        {
            blGolDarah.Insert(value);
        }

        // PUT: api/GolDarah/5
        public void Put(GolDarah value)
        {
            blGolDarah.Update(value);
        }

        // DELETE: api/GolDarah/5
        public void Delete(string id)
        {
            blGolDarah.Delete(id);
        }

        // GET: api/GolDarah
        public List<GolDarah> Get()
        {
            return blGolDarah.ListData();
        } 

        // GET: api/GolDarah/5
        public GolDarah Get(string id)
        {
            return blGolDarah.GetData(id);
        }
    }
}
