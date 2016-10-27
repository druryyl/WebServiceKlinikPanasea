using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KlinikPanaseaWebService.Models;
using System.Data.SqlClient;

namespace KlinikPanaseaWebService.DataAccessLayers
{
    public class JenisKelaminDal
    {
        public void Insert(JenisKelamin data)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                string sSql = @"
                    INSERT INTO     Jenis_Kelamin 
                                    (ID_Jenis_Kelamin, Kelamin)
                    VALUES          (@Kode, @Nama)";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", data.IdJenisKelamin);
                cmd.Parameters.AddWithValue("@Nama", data.NamaJenisKelamin);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public void Update(JenisKelamin data)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                string sSql = @"
                    UPDATE  Jenis_Kelamin 
                    SET     ID_Jenis_Kelamin = @Kode
                            Kelamin = @Nama 
                    WHERE   ID_Jenis_Kelamin = @Kode";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", data.IdJenisKelamin);
                cmd.Parameters.AddWithValue("@Nama", data.NamaJenisKelamin);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public void Delete(string idGolDarah)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                string sSql = @"
                    DELETE  Jenis_Kelamin 
                    WHERE   ID_Jenis_Kelamin = @Kode";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", idGolDarah);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public Poliklinik GetData(string idGolDarah)
        {
            Poliklinik retVal = null;

            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                string sSql = @"
                    SELECT  ID_Jenis_Kelamin, Kelamin
                    FROM    Jenis_Kelamin
                    WHERE   ID_Jenis_Kelamin = @Kode";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", idGolDarah);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    retVal = new Poliklinik
                    {
                        IdPoliklinik = dr["ID_Jenis_Kelamin"].ToString(),
                        NamaPoliklinik = dr["Kelamin"].ToString()
                    };
                }
                cmd.Dispose();
            }
            return retVal;
        }

        public List<JenisKelamin> ListData()
        {
            List<JenisKelamin> retVal = null;
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                string sSql = @"
                    SELECT  ID_Jenis_Kelamin, Kelamin
                    FROM    Jenis_Kelamin ";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    retVal = new List<JenisKelamin>();

                    while (dr.Read())
                    {
                        retVal.Add(new JenisKelamin
                        {
                            IdJenisKelamin = dr["ID_Jenis_Kelamin"].ToString(),
                            NamaJenisKelamin = dr["Kelamin"].ToString()
                        });
                    }
                }
                dr.Close();
                dr.Dispose();
                cmd.Dispose();
            }
            return retVal;
        }
    }
}