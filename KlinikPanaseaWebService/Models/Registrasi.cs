using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlinikPanaseaWebService.Models
{
    public class Registrasi
    {
        public string  IdRegistrasi { get; set; }
        public DateTime TanggalPeriksa { get; set; }    
        public int Usia { get; set; }   
        public int TinggiBadan { get; set; }    
        public int BeratBadan { get; set; } 
        public string Keluhan { get; set; } 
        public string Diagnosa { get; set; }    
        public string NamaObat { get; set; }    

        public RekamMedik Pasien { get; set; }
        public Poliklinik PoliTujuan { get; set; }
        public JenisKunjungan JenisKunjungan { get; set; }

        // buat constructor
        public Registrasi()
        {
            Pasien = new RekamMedik();
            PoliTujuan = new Poliklinik();
            JenisKunjungan = new JenisKunjungan();
        }
    }
}