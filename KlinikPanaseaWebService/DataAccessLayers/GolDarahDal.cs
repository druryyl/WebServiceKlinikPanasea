using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KlinikPanaseaWebService.Models;
using System.Data.SqlClient;

namespace KlinikPanaseaWebService.DataAccessLayers
{
    public class GolDarahDal
    {
        public void Insert(GolDarah data)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    INSERT INTO     Golongan_Darah 
                                    (ID_Golongan_Darah, Jenis_Darah)
                    VALUES          (@Kode, @Nama)";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", data.IdGolDarah);
                cmd.Parameters.AddWithValue("@Nama", data.NamaGolDarah);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public void Update(GolDarah data)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    UPDATE  Golongan_Darah 
                    SET     ID_Golongan_Darah = @Kode
                            Jenis_Darah = @Nama 
                    WHERE   ID_Golongan_Darah = @Kode";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", data.IdGolDarah);
                cmd.Parameters.AddWithValue("@Nama", data.NamaGolDarah);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public void Delete(string idGolDarah)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    DELETE  Golongan_Darah 
                    WHERE   ID_Golongan_Darah = @Kode";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", idGolDarah);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public GolDarah GetData(string idGolDarah)
        {
            GolDarah retVal = null;

            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    SELECT  ID_Golongan_Darah, Jenis_Darah
                    FROM    Golongan_Darah
                    WHERE   ID_Golongan_Darah = @Kode";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@Kode", idGolDarah );
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    retVal = new GolDarah
                    {
                        IdGolDarah = dr["ID_Golongan_Darah"].ToString(),
                        NamaGolDarah = dr["Jenis_Darah"].ToString()
                    };
                }
                cmd.Dispose();
            }
            return retVal;
        }

        public List<GolDarah> ListData()
        {
            List<GolDarah> retVal = null;
            using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
            {
                conn.Open();
                string sSql = @"
                    SELECT  ID_Golongan_Darah, Jenis_Darah
                    FROM    Golongan_Darah ";
                SqlCommand cmd = new SqlCommand(sSql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    retVal = new List<GolDarah>();

                    while (dr.Read())
                    {
                        retVal.Add(new GolDarah
                        {
                            IdGolDarah = dr["ID_Golongan_Darah"].ToString(),
                            NamaGolDarah = dr["Jenis_Darah"].ToString()
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