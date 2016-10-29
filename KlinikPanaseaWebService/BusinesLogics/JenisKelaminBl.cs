using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KlinikPanaseaWebService.Models;
using KlinikPanaseaWebService.DataAccessLayers;

namespace KlinikPanaseaWebService.BusinesLogics
{
    public class JenisKelaminBl
    {
        private JenisKelaminDal dalJenisKelamin = new JenisKelaminDal();

        public void Insert(JenisKelamin dataJenisKelamin)
        {
            //  cek apakah object data-nya kosong
            if (dataJenisKelamin == null)
            {
                throw new Exception("Data JenisKelamin kosong");
            }

            if (dataJenisKelamin.IdJenisKelamin.Length == 0 ||
                dataJenisKelamin.NamaJenisKelamin.Length == 0)
            {
                throw new Exception("ID JenisKelamin atau Nama JenisKelamin masing kosong");
            }

            //  cek apakah length kode-nya kurang dari 3 karakter
            if (dataJenisKelamin.IdJenisKelamin.Length > 3)
            {
                throw new Exception("ID JenisKelamin lebih dari 3 huruf");
            }

            //  cek apakah length nama lebih dari 30 karakter
            if (dataJenisKelamin.NamaJenisKelamin.Length > 30)
            {
                throw new Exception("Nama JenisKelamin lebih dari 30 huruf");
            }

            //  data sudah valid, lempar ke DAL untuk disimpan
            dalJenisKelamin.Insert(dataJenisKelamin);
        }

        public void Update(JenisKelamin dataJenisKelamin)
        {
            //  cek apakah data yang akan diupdate memang sudah ada sebelumnya
            if (dalJenisKelamin.GetData(dataJenisKelamin.IdJenisKelamin) == null)
            {
                throw new Exception("Data JenisKelamin tidak ditemukan");
            }

            if (dataJenisKelamin.NamaJenisKelamin.Length == 0)
            {
                throw new Exception("Nama JenisKelamin kosong");
            }
            if (dataJenisKelamin.NamaJenisKelamin.Length > 30)
            {
                throw new Exception("Nama JenisKelamin lebih dari 30 huruf");
            }

            //  lolos validasi
            dalJenisKelamin.Update(dataJenisKelamin);
        }

        public void Delete(string idJenisKelamin)
        {
            //  cek apakah data yang akan diupdate memang sudah ada sebelumnya
            if (dalJenisKelamin.GetData(idJenisKelamin) == null)
            {
                throw new Exception("Data JenisKelamin tidak ditemukan");
            }

            //  lolos validasi
            dalJenisKelamin.Delete(idJenisKelamin);
        }

        public JenisKelamin GetData(string id)
        {
            JenisKelamin retVal = null;
            retVal = dalJenisKelamin.GetData(id);
            return retVal;
        }

        public List<JenisKelamin> ListData()
        {
            List<JenisKelamin> retVal = null;
            retVal = dalJenisKelamin.ListData();
            return retVal;
        }

    }
}