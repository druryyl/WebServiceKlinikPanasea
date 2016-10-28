using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KlinikPanaseaWebService.Models;
using KlinikPanaseaWebService.DataAccessLayers;


namespace KlinikPanaseaWebService.BusinesLogics
{
    public class PoliklinikBl
    {
        private PoliklinikDal dalPoliklinik = new PoliklinikDal();

        public void Insert(Poliklinik dataPoliklinik)
        {
            //  cek apakah object data-nya kosong
            if (dataPoliklinik == null)
            {
                throw new Exception("Data Poliklinik kosong");
            }

            if (dataPoliklinik.IdPoliklinik.Length == 0 || 
                dataPoliklinik.NamaPoliklinik.Length == 0)
            {
                throw new Exception("ID Poliklinik atau Nama Poliklinik masih kosong");
            }

            //  cek apakah length kode-nya kurang dari 3 karakter
            if (dataPoliklinik.IdPoliklinik.Length > 3)
            {
                throw new Exception("ID Poliklinik lebih dari 3 huruf");
            }

            //  cek apakah length nama lebih dari 30 karakter
            if (dataPoliklinik.NamaPoliklinik.Length > 30)
            {
                throw new Exception("Nama Poliklinik lebih dari 30 huruf");
            }

            //  data sudah valid, lempar ke DAL untuk disimpan
            dalPoliklinik.Insert(dataPoliklinik);
        }

        public void Update(Poliklinik dataPoliklinik)
        {
            //  cek apakah data yang akan diupdate memang sudah ada sebelumnya
            if(dalPoliklinik.GetData(dataPoliklinik.IdPoliklinik) == null)
            {
                throw new Exception("Data poliklinik tidak ditemukan");
            }

            if (dataPoliklinik.NamaPoliklinik.Length == 0)
            {
                throw new Exception("Nama Poliklinik kosong");
            }
            if (dataPoliklinik.NamaPoliklinik.Length > 30)
            {
                throw new Exception("Nama Poliklinik lebih dari 30 huruf");
            }

            //  lolos validasi
            dalPoliklinik.Update(dataPoliklinik);
        }

        public void Delete(string idPoliklinik)
        {
            //  cek apakah data yang akan diupdate memang sudah ada sebelumnya
            if (dalPoliklinik.GetData(idPoliklinik) == null)
            {
                throw new Exception("Data poliklinik tidak ditemukan");
            }

            //  lolos validasi
            dalPoliklinik.Delete(idPoliklinik);
        }

        public Poliklinik GetData(string id)
        {
            Poliklinik retVal = null;
            retVal = dalPoliklinik.GetData(id);
            return retVal;
        }

        public List<Poliklinik> ListData()
        {
            List<Poliklinik> retVal = null;
            retVal = dalPoliklinik.ListData();
            return retVal;
        }
    }
}