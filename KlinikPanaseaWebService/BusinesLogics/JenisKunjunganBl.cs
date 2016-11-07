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

            if (dataJenisKunjungan.IdKunjungan.Length == 0 ||
                dataJenisKunjungan.NamaKunjungan.Length == 0)
            {
                throw new Exception("ID JenisKunjungan atau Nama JenisKunjungan masing kosong");
            }

            //  cek apakah length kode-nya kurang dari 3 karakter
            if (dataJenisKunjungan.IdKunjungan.Length > 3)
            {
                throw new Exception("ID JenisKunjungan lebih dari 3 huruf");
            }

            //  cek apakah length nama lebih dari 30 karakter
            if (dataJenisKunjungan.NamaKunjungan.Length > 30)
            {
                throw new Exception("Nama JenisKunjungan lebih dari 30 huruf");
            }

            //  data sudah valid, lempar ke DAL untuk disimpan
            dalJenisKunjungan.Insert(dataJenisKunjungan);
        }

        public void Update(JenisKunjungan dataJenisKunjungan)
        {
            //  cek apakah data yang akan diupdate memang sudah ada sebelumnya
            if (dalJenisKunjungan.GetData(dataJenisKunjungan.IdKunjungan) == null)
            {
                throw new Exception("Data Jenis Kunjungan tidak ditemukan");
            }

            if (dataJenisKunjungan.NamaKunjungan.Length == 0)
            {
                throw new Exception("Nama Kunjungan kosong");
            }
            if (dataJenisKunjungan.NamaKunjungan.Length > 30)
            {
                throw new Exception("Nama Kunjungan lebih dari 30 huruf");
            }

            //  lolos validasi
            dalJenisKunjungan.Update(dataJenisKunjungan);
        }

        public void Delete(string id_Kunjungan)
        {
            //  cek apakah data yang akan diupdate memang sudah ada sebelumnya
            if (dalJenisKunjungan.GetData(id_Kunjungan) == null)
            {
                throw new Exception("Data JenisKunjungan tidak ditemukan");
            }

            //  lolos validasi
            dalJenisKunjungan.Delete(id_Kunjungan);
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