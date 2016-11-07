using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

using KlinikPanaseaWebService.Models;
using KlinikPanaseaWebService.DataAccessLayers;

namespace KlinikPanaseaWebService.DataAccessLayers
{
    public class JenisKunjunganDal
    {

        public void Insert(JenisKunjungan data)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    INSERT INTO     Jenis_Kunjungan 
                                    (id_Kunjungan, Nama_Kunjungan)
                    VALUES          (@Kode, @Nama)";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", data.IdKunjungan);
                cmd.Parameters.AddWithValue("@Nama", data.NamaKunjungan);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public void Update(JenisKunjungan data)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    UPDATE  Jenis_Kunjungan 
                    SET     ID_Kunjungan = @Kode,
                            Nama_Kunjungan = @Nama 
                    WHERE   ID_Kunjungan = @Kode";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", data.IdKunjungan);
                cmd.Parameters.AddWithValue("@Nama", data.NamaKunjungan);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public void Delete(string idPoliklinik)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    DELETE  Jenis_Kunjungan 
                    WHERE   ID_Kunjungan = @Kode";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", idPoliklinik);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public JenisKunjungan GetData(string idKunjungan)
        {
            JenisKunjungan retVal = null;

            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    SELECT  ID_Kunjungan, Nama_Kunjungan
                    FROM    Jenis_Kunjungan
                    WHERE   ID_Kunjungan = @Kode";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", idKunjungan);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    retVal = new JenisKunjungan
                    {
                        IdKunjungan = dr["ID_Kunjungan"].ToString(),
                        NamaKunjungan = dr["Nama_Kunjungan"].ToString()
                    };
                }
                cmd.Dispose();
            }
            return retVal;
        }

        public List<JenisKunjungan> ListData()
        {
            List<JenisKunjungan> retVal = null;
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    SELECT  ID_Kunjungan, Nama_Kunjungan
                    FROM    Jenis_Kunjungan ";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    retVal = new List<JenisKunjungan>();

                    while (dr.Read())
                    {
                        retVal.Add(new JenisKunjungan
                        {
                            IdKunjungan = dr["id_kunjungan"].ToString(),
                            NamaKunjungan = dr["Nama_Kunjungan"].ToString()
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