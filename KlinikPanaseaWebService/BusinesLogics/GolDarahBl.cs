using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KlinikPanaseaWebService.Models;
using KlinikPanaseaWebService.DataAccessLayers;

namespace KlinikPanaseaWebService.BusinesLogics
{
    public class GolDarahBl
    {
        private GolDarahDal dalGolDarah = new GolDarahDal();

        public void Insert(GolDarah dataGolDarah)
        {
            //  cek apakah object data-nya kosong
            if (dataGolDarah == null)
            {
                throw new Exception("Data GolDarah kosong");
            }

            if (dataGolDarah.IdGolDarah.Length == 0 ||
                dataGolDarah.NamaGolDarah.Length == 0)
            {
                throw new Exception("ID GolDarah atau Nama GolDarah masih kosong");
            }

            //  cek apakah length kode-nya kurang dari 3 karakter
            if (dataGolDarah.IdGolDarah.Length > 3)
            {
                throw new Exception("ID GolDarah lebih dari 3 huruf");
            }

            //  cek apakah length nama lebih dari 30 karakter
            if (dataGolDarah.NamaGolDarah.Length > 30)
            {
                throw new Exception("Nama GolDarah lebih dari 30 huruf");
            }

            //  data sudah valid, lempar ke DAL untuk disimpan
            dalGolDarah.Insert(dataGolDarah);
        }

        public void Update(GolDarah dataGolDarah)
        {
            //  cek apakah data yang akan diupdate memang sudah ada sebelumnya
            if (dalGolDarah.GetData(dataGolDarah.IdGolDarah) == null)
            {
                throw new Exception("Data GolDarah tidak ditemukan");
            }

            if (dataGolDarah.NamaGolDarah.Length == 0)
            {
                throw new Exception("Nama GolDarah kosong");
            }
            if (dataGolDarah.NamaGolDarah.Length > 30)
            {
                throw new Exception("Nama GolDarah lebih dari 30 huruf");
            }

            //  lolos validasi
            dalGolDarah.Update(dataGolDarah);
        }

        public void Delete(string idGolDarah)
        {
            //  cek apakah data yang akan diupdate memang sudah ada sebelumnya
            if (dalGolDarah.GetData(idGolDarah) == null)
            {
                throw new Exception("Data GolDarah tidak ditemukan");
            }

            //  lolos validasi
            dalGolDarah.Delete(idGolDarah);
        }

        public GolDarah GetData(string id)
        {
            GolDarah retVal = null;
            retVal = dalGolDarah.GetData(id);
            return retVal;
        }

        public List<GolDarah> ListData()
        {
            List<GolDarah> retVal = null;
            retVal = dalGolDarah.ListData();
            return retVal;
        }

    }
}