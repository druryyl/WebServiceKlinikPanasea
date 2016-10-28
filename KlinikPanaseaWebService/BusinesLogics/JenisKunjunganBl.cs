using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KlinikPanaseaWebService.Models;
using KlinikPanaseaWebService.DataAccessLayers;

namespace KlinikPanaseaWebService.BusinesLogics
{
    public class JenisKunjunganBl
    {
        private JenisKunjunganDal dalJenisKunjungan = new JenisKunjunganDal();

        public void Insert(JenisKunjungan dataJenisKunjungan)
        {
            //  cek apakah object data-nya kosong
            if (dataJenisKunjungan == null)
            {
                throw new Exception("Data JenisKunjungan kosong");
            }

            if (dataJenisKunjungan.IdJenisKunjungan.Length == 0 ||
                dataJenisKunjungan.NamaJenisKunjungan.Length == 0)
            {
                throw new Exception("ID JenisKunjungan atau Nama JenisKunjungan masing kosong");
            }

            //  cek apakah length kode-nya kurang dari 3 karakter
            if (dataJenisKunjungan.IdJenisKunjungan.Length > 3)
            {
                throw new Exception("ID JenisKunjungan lebih dari 3 huruf");
            }

            //  cek apakah length nama lebih dari 30 karakter
            if (dataJenisKunjungan.NamaJenisKunjungan.Length > 30)
            {
                throw new Exception("Nama JenisKunjungan lebih dari 30 huruf");
            }

            //  data sudah valid, lempar ke DAL untuk disimpan
            dalJenisKunjungan.Insert(dataJenisKunjungan);
        }

        public void Update(JenisKunjungan dataJenisKunjungan)
        {
            //  cek apakah data yang akan diupdate memang sudah ada sebelumnya
            if (dalJenisKunjungan.GetData(dataJenisKunjungan.IdJenisKunjungan) == null)
            {
                throw new Exception("Data JenisKunjungan tidak ditemukan");
            }

            if (dataJenisKunjungan.NamaJenisKunjungan.Length == 0)
            {
                throw new Exception("Nama JenisKunjungan kosong");
            }
            if (dataJenisKunjungan.NamaJenisKunjungan.Length > 30)
            {
                throw new Exception("Nama JenisKunjungan lebih dari 30 huruf");
            }

            //  lolos validasi
            dalJenisKunjungan.Update(dataJenisKunjungan);
        }

        public void Delete(string idJenisKunjungan)
        {
            //  cek apakah data yang akan diupdate memang sudah ada sebelumnya
            if (dalJenisKunjungan.GetData(idJenisKunjungan) == null)
            {
                throw new Exception("Data JenisKunjungan tidak ditemukan");
            }

            //  lolos validasi
            dalJenisKunjungan.Delete(idJenisKunjungan);
        }

        public JenisKunjungan GetData(string id)
        {
            JenisKunjungan retVal = null;
            retVal = dalJenisKunjungan.GetData(id);
            return retVal;
        }

        public List<JenisKunjungan> ListData()
        {
            List<JenisKunjungan> retVal = null;
            retVal = dalJenisKunjungan.ListData();
            return retVal;
        }

    }
}