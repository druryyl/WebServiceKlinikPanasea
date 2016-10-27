using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

using KlinikPanaseaWebService.Models;
using KlinikPanaseaWebService.DataAccessLayers;

namespace KlinikPanaseaWebService.DataAccessLayer
{
    public class PoliklinikDal
    {

        public void Insert(Poliklinik data)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    INSERT INTO     poliklinik 
                                    (id_poliklinik, nama_poliklinik)
                    VALUES          (@Kode, @Nama)";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", data.IdPoliklinik);
                cmd.Parameters.AddWithValue("@Nama", data.NamaPoliklinik);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public void Update(Poliklinik data)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    UPDATE  poliklinik 
                    SET     id_poliklinik = @Kode,
                            nama_poliklinik = @Nama 
                    WHERE   id_poliklinik = @Kode";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", data.IdPoliklinik);
                cmd.Parameters.AddWithValue("@Nama", data.NamaPoliklinik);
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
                    DELETE  poliklinik 
                    WHERE   id_poliklinik = @Kode";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", idPoliklinik);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public Poliklinik GetData(string idPoliklinik)
        {
            Poliklinik retVal = null;

            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                string sSql = @"
                    SELECT  id_poliklinik, nama_poliklinik
                    FROM    poliklinik
                    WHERE   id_poliklinik = @Kode";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", idPoliklinik);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    retVal = new Poliklinik
                    {
                        IdPoliklinik = dr["id_poliklinik"].ToString(),
                        NamaPoliklinik = dr["nama_poliklinik"].ToString()
                    };
                }
                cmd.Dispose();
            }
            return retVal;
        }

        public List<Poliklinik> ListData()
        {
            List<Poliklinik> retVal = null;
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    SELECT  id_poliklinik, nama_poliklinik
                    FROM    poliklinik ";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    retVal = new List<Poliklinik>();

                    while (dr.Read())
                    {
                        retVal.Add(new Poliklinik
                        {
                            IdPoliklinik = dr["id_poliklinik"].ToString(),
                            NamaPoliklinik = dr["nama_poliklinik"].ToString()
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