using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlinikPanaseaWebService.Models
{
    public class RekamMedik
    {
        public string IdRekamMedik { get; set; }

        public string NamaPasien { get; set; }

        public DateTime TglLahir { get; set; }

        public string Alamat { get; set; }

        public string Telpon { get; set; }

        public JenisKelamin Sex { get; set; }  

        public GolDarah GolonganDarah { get; set; }

        //  contructor
        public RekamMedik()
        {
            NamaPasien = "";
            IdRekamMedik = "";
            TglLahir = new DateTime(3000, 1, 1);
            Alamat = "";
            Telpon = "";

            Sex = new Models.JenisKelamin();
            GolonganDarah = new Models.GolDarah();
        }

    }
}