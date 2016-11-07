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
    public class JenisKunjunganController : ApiController
    {
        JenisKunjunganBl blJenisKunjungan = new JenisKunjunganBl();

        // POST: api/JenisKunjungan
        public void Post(JenisKunjungan value)
        {
            blJenisKunjungan.Insert(value);
        }

        // PUT: api/JenisKunjungan/5
        public void Put(JenisKunjungan value)
        {
            blJenisKunjungan.Update(value);
        }

        // DELETE: api/JenisKunjungan/5
        public void Delete(string id)
        {
            blJenisKunjungan.Delete(id);
        }

        // GET: api/JenisKunjungan
        public List<JenisKunjungan> Get()
        {
            return blJenisKunjungan.ListData();
        }

        // GET: api/JenisJenisKunjungan/5
        public JenisKunjungan Get(string id)
        {
            return blJenisKunjungan.GetData(id);
        }

    }
}
