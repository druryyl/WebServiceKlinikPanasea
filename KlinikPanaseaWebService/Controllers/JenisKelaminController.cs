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
    public class JenisKelaminController : ApiController
    {
        JenisKelaminBl blJenisKelamin = new JenisKelaminBl();

        // POST: api/JenisKelamin
        public void Post(JenisKelamin value)
        {
            blJenisKelamin.Insert(value);
        }

        // PUT: api/JenisKelamin/5
        public void Put(JenisKelamin value)
        {
            blJenisKelamin.Update(value);
        }

        // DELETE: api/JenisKelamin/5
        public void Delete(string id)
        {
            blJenisKelamin.Delete(id);
        }

        // GET: api/JenisKelamin
        public List<JenisKelamin> Get()
        {
            return blJenisKelamin.ListData();
        }

        // GET: api/JenisKelamin/5
        public JenisKelamin Get(string id)
        {
            return blJenisKelamin.GetData(id);
        }

    }
}
