using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using KlinikPanaseaWebService.Models;
using KlinikPanaseaWebService.BusinesLogics;

namespace KlinikPanaseaWebService.Controllers
{
    public class RekamMedikController : ApiController
    {
        private RekamMedikBl blRekamMedik = new RekamMedikBl();

        // GET: api/RekamMedik
        public List<RekamMedik> Get()
        {
            return blRekamMedik.ListData();
        }

        // GET: api/RekamMedik/5
        public RekamMedik Get(string id)
        {
            return blRekamMedik.GetData(id);
        }

        // POST: api/RekamMedik
        public void Post(RekamMedik dataRekamMedik)
        {
            blRekamMedik.Insert(dataRekamMedik);
        }

        // PUT: api/RekamMedik/5
        public void Put(RekamMedik dataRekamMedik)
        {
            blRekamMedik.Update(dataRekamMedik);
        }

        // DELETE: api/RekamMedik/5
        public void Delete(string id)
        {
            blRekamMedik.Delete(id);
        }
    }
}
