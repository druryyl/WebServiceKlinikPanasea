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
        private JenisKelaminDal daljeniskelamin = new JenisKelaminDal();

        public void Insert(jeniskelamin datajeniskelamin)
        {
            //  cek apakah object data-nya kosong
            if (datajeniskelamin == null)
            {
                throw new Exception("Data jeniskelamin kosong");
            }

            if (datajeniskelamin.Idjeniskelamin.Length == 0 ||
                datajeniskelamin.Namajeniskelamin.Length == 0)
            {
                throw new Exception("ID jeniskelamin atau Nama jeniskelamin masing kosong");
            }

            //  cek apakah length kode-nya kurang dari 3 karakter
            if (datajeniskelamin.Idjeniskelamin.Length > 3)
            {
                throw new Exception("ID jeniskelamin lebih dari 3 huruf");
            }

            //  cek apakah length nama lebih dari 30 karakter
            if (datajeniskelamin.Namajeniskelamin.Length > 30)
            {
                throw new Exception("Nama jeniskelamin lebih dari 30 huruf");
            }

            //  data sudah valid, lempar ke DAL untuk disimpan
            daljeniskelamin.Insert(datajeniskelamin);
        }

        public void Update(jeniskelamin datajeniskelamin)
        {
            //  cek apakah data yang akan diupdate memang sudah ada sebelumnya
            if (daljeniskelamin.GetData(datajeniskelamin.Idjeniskelamin) == null)
            {
                throw new Exception("Data jeniskelamin tidak ditemukan");
            }

            if (datajeniskelamin.Namajeniskelamin.Length == 0)
            {
                throw new Exception("Nama jeniskelamin kosong");
            }
            if (datajeniskelamin.Namajeniskelamin.Length > 30)
            {
                throw new Exception("Nama jeniskelamin lebih dari 30 huruf");
            }

            //  lolos validasi
            daljeniskelamin.Update(datajeniskelamin);
        }

        public void Delete(string idjeniskelamin)
        {
            //  cek apakah data yang akan diupdate memang sudah ada sebelumnya
            if (daljeniskelamin.GetData(idjeniskelamin) == null)
            {
                throw new Exception("Data jeniskelamin tidak ditemukan");
            }

            //  lolos validasi
            daljeniskelamin.Delete(idjeniskelamin);
        }

        public jeniskelamin GetData(string id)
        {
            jeniskelamin retVal = null;
            retVal = daljeniskelamin.GetData(id);
            return retVal;
        }

        public List<jeniskelamin> ListData()
        {
            List<jeniskelamin> retVal = null;
            retVal = daljeniskelamin.ListData();
            return retVal;
        }

    }
}