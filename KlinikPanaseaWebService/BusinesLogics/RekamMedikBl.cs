using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KlinikPanaseaWebService.Models;
using KlinikPanaseaWebService.DataAccessLayers;
using KlinikPanaseaWebService.BusinesLogics;

namespace KlinikPanaseaWebService.BusinesLogics
{
    public class RekamMedikBl
    {
        private RekamMedikDal dalRekamMedik = new RekamMedikDal();
        private JenisKelaminBl blJenisKelamin = new JenisKelaminBl();
        private GolDarahBl blGolDarah = new GolDarahBl();
        private ParamNoBl blParamNo = new ParamNoBl();

        public void Insert(RekamMedik dataRekamMedik)
        {
            //  cek apakah object data-nya kosong
            if (dataRekamMedik == null)
            {
                throw new Exception("Data Rekam Medik kosong");
            }

            if (dataRekamMedik.IdRekamMedik.Length != 0)
            {
                throw new Exception("Data Baru, ID Rekam Medik harus dikosongkan");
            }

            if (dataRekamMedik.NamaPasien.Length == 0)
            {
                throw new Exception("Nama Pasien kosong, simpan gagal");
            }

            //  cek apakah data RM tersebut sudah ada di database
            if (dalRekamMedik.GetData(dataRekamMedik.NamaPasien) != null)
            {
                throw new Exception("ID Rekam Medik sudah ada");
            }
            
            if (blJenisKelamin.GetData(dataRekamMedik.Sex.IdJenisKelamin) == null)
            {
                throw new Exception("Jenis Kelamin tidak valid");
            }

            if (blGolDarah.GetData(dataRekamMedik.GolonganDarah.IdGolDarah) == null)
            {
                throw new Exception("GolDarah tidak valid");
            }

            //  isikan ID Rekam Medik dengan No.Terakhir yang ada di ParamNo
            string noUrutRm = blParamNo.GetValue("NO_RM").ToString();
            //noUrutRm.PadLeft(6, '0');
            string xNo = noUrutRm.PadLeft(6, '0');
            dataRekamMedik.IdRekamMedik = xNo;
            //  data sudah valid, lempar ke DAL untuk disimpan
            dalRekamMedik.Insert(dataRekamMedik);
        }

        public void Update(RekamMedik dataRekamMedik)
        {
            //  cek apakah data yang akan diupdate memang sudah ada sebelumnya
            if (dalRekamMedik.GetData(dataRekamMedik.IdRekamMedik) == null)
            {
                throw new Exception("Data Rekam Medik tidak ditemukan");
            }

            if (dataRekamMedik.NamaPasien.Length == 0)
            {
                throw new Exception("Nama pasien kosong");
            }

            //  lolos validasi
            dalRekamMedik.Update(dataRekamMedik);
        }

        public void Delete(string idRekamMedik)
        {
            //  cek apakah data yang akan diupdate memang sudah ada sebelumnya
            if (dalRekamMedik.GetData(idRekamMedik) == null)
            {
                throw new Exception("Data Rekam Medik tidak ditemukan");
            }

            //  lolos validasi
            dalRekamMedik.Delete(idRekamMedik);
        }

        public RekamMedik GetData(string id)
        {
            RekamMedik retVal = null;
            retVal = dalRekamMedik.GetData(id);
            return retVal;
        }

        public List<RekamMedik> ListData()
        {
            List<RekamMedik> retVal = null;
            retVal = dalRekamMedik.ListData();
            return retVal;
        }
    }
}
