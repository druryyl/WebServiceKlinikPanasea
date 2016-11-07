using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KlinikPanaseaWebService.Models;
using System.Data.SqlClient;

namespace KlinikPanaseaWebService.DataAccessLayers
{
    public class RekamMedikDal
    {

        public void Insert(RekamMedik data)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    INSERT INTO     Rekam_Medik
                                    (
                                        ID_Rekam_Medik, ID_Jenis_Kelamin, ID_Golongan_Darah,
                                        Nama_Pasien, Tgl_Lahir, Alamat, Telepon    
                                    )
                    VALUES          (
                                        @KodeRekamMedik, @KodeJenisKelamin, @KodeGolDarah, 
                                        @NamaPasien, @TglLahir, @Alamat, @Telepon
                                    )";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@KodeRekamMedik", data.IdRekamMedik);
                cmd.Parameters.AddWithValue("@KodeJenisKelamin", data.Sex.IdJenisKelamin);
                cmd.Parameters.AddWithValue("@KodeGolDarah", data.GolonganDarah.IdGolDarah);
                cmd.Parameters.AddWithValue("@NamaPasien", data.NamaPasien);
                cmd.Parameters.AddWithValue("@TglLahir", data.TglLahir);
                cmd.Parameters.AddWithValue("@Alamat", data.Alamat);
                cmd.Parameters.AddWithValue("@Telepon", data.Telpon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public void Update(RekamMedik data)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    UPDATE      Rekam_Medik
                    SET         ID_Jenis_Kelamin = @KodeJenisKelamin, 
                                ID_Golongan_Darah = @KodeGolDarah,
                                Nama_Pasien = @NamaPasien, 
                                Tgl_Lahir = @TglLahir, 
                                Alamat = @Alamat, 
                                Telepon  =@Telepon    
                    WHERE       ID_Rekam_Medik = @KodeRekamMedik ";

                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@KodeRekamMedik", data.IdRekamMedik);
                cmd.Parameters.AddWithValue("@KodeJenisKelamin", data.Sex.IdJenisKelamin);
                cmd.Parameters.AddWithValue("@KodeGolDarah", data.GolonganDarah.IdGolDarah);
                cmd.Parameters.AddWithValue("@NamaPasien", data.NamaPasien);
                cmd.Parameters.AddWithValue("@TglLahir", data.TglLahir);
                cmd.Parameters.AddWithValue("@Alamat", data.Alamat);
                cmd.Parameters.AddWithValue("@Telepon", data.Telpon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public void Delete(string idRekamMedik)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    DELETE  Rekam_Medik 
                    WHERE   ID_Rekam_Medik = @Kode";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", idRekamMedik);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public RekamMedik GetData(string idRekamMedik)
        {
            RekamMedik retVal = null;

            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    SELECT      aa.ID_Rekam_Medik, aa.ID_Jenis_Kelamin, aa.ID_Golongan_Darah,
                                aa.Nama_Pasien, aa.Tgl_Lahir, aa.Alamat, aa.Telepon,            
                                ISNULL(bb.Kelamin, ' ') Kelamin,
                                ISNULL(cc.Jenis_Darah, ' ') Jenis_Darah,                    
                    FROM        Rekam_Medik aa
                    LEFT JOIN   Jenis_Kelamin bb ON aa.ID_Jenis_Kelamin = bb.ID_Jenis_Kelamin
                    LEFT JOIN   Golongan_Darah cc ON aa.ID_Golongan_Darah = cc.ID_Golongan_Darah 
                    WHERE       ID_Rekam_Medik = @Kode";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", idRekamMedik);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    retVal = new RekamMedik
                    {
                        IdRekamMedik = dr["ID_Rekam_Medik"].ToString(),
                        NamaPasien = dr["Nama_Pasien"].ToString(),
                        TglLahir = (DateTime)dr["Tgl_Lahir"],
                        Alamat = dr["Alamat"].ToString(),
                        Telpon = dr["Telepon"].ToString(),
                        GolonganDarah = new GolDarah
                        {
                            IdGolDarah = dr["ID_Golongan_Darah"].ToString(),
                            NamaGolDarah = dr["Jenis_Darah"].ToString(),
                        },
                        Sex = new JenisKelamin
                        {
                            IdJenisKelamin = dr["ID_Jenis_Kelamin"].ToString(),
                            NamaJenisKelamin = dr["Kelamin"].ToString(),
                        }
                    };
                }
                cmd.Dispose();
            }
            return retVal;
        }

        public List<RekamMedik> ListData()
        {
            List<RekamMedik> retVal = null;
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    SELECT      aa.ID_Rekam_Medik, aa.ID_Jenis_Kelamin, aa.ID_Golongan_Darah,
                                aa.Nama_Pasien, aa.Tgl_Lahir, aa.Alamat, aa.Telepon,            
                                ISNULL(bb.Kelamin, ' ') Kelamin,
                                ISNULL(cc.Jenis_Darah, ' ') Jenis_Darah                   
                    FROM        Rekam_Medik aa
                    LEFT JOIN   Jenis_Kelamin bb ON aa.ID_Jenis_Kelamin = bb.ID_Jenis_Kelamin
                    LEFT JOIN   Golongan_Darah cc ON aa.ID_Golongan_Darah = cc.ID_Golongan_Darah ";
                
                SqlCommand cmd = new SqlCommand(sSql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    retVal = new List<RekamMedik>();
                    while (dr.Read())
                    { 
                        retVal.Add(new RekamMedik
                        {
                            IdRekamMedik = dr["ID_Rekam_Medik"].ToString(),
                            NamaPasien = dr["Nama_Pasien"].ToString(),
                            TglLahir = (DateTime)dr["Tgl_Lahir"],
                            Alamat = dr["Alamat"].ToString(),
                            Telpon = dr["Telepon"].ToString(),
                            GolonganDarah = new GolDarah
                            {
                                IdGolDarah = dr["ID_Golongan_Darah"].ToString(),
                                NamaGolDarah = dr["Jenis_Darah"].ToString(),
                            },
                            Sex = new JenisKelamin
                            {
                                IdJenisKelamin = dr["ID_Jenis_Kelamin"].ToString(),
                                NamaJenisKelamin = dr["Kelamin"].ToString(),
                            }
                        });
                    }
                }
                cmd.Dispose();
            }
            return retVal;
        }
    }
}
