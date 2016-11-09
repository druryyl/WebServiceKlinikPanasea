using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Transactions;

namespace KlinikPanaseaWebService.DataAccessLayers
{
    public class ParamNoDal
    {
        public decimal GetValue(string KodeNo)
        {
            decimal retVal = 1;
            TransactionOptions tranOption = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            };
            using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Suppress, tranOption))
            {
                using (SqlConnection conn2 = new SqlConnection(DbConnection.ConnectionString()))
                using (SqlConnection conn = new SqlConnection(DbConnection.ConnectionString()))
                {
                    conn.Open();
                    string sSql = @"
                        SELECT      Value 
                        FROM        ParamNo
                        WHERE       KodeNomor = @Kode ";
                    SqlCommand cmd = new SqlCommand(sSql, conn);
                    cmd.Parameters.AddWithValue("@Kode", KodeNo);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        retVal = (decimal)dr["Value"];
                    }
                    else
                    {
                        sSql = @"
                            INSERT INTO    ParamNo(KodeNomor,Value)
                            VALUES          (@Kode, 1) ";
                        SqlCommand cmd2 = new SqlCommand(sSql, conn2);
                        cmd2.Parameters.AddWithValue("@Kode", KodeNo);
                        conn2.Open();
                        cmd2.ExecuteNonQuery();
                        cmd2.Dispose();
                    }

                    dr.Close();
                    cmd.Dispose();

                    //  tambahkan nomor terakhir +1
                    sSql = @"
                        UPDATE      ParamNo 
                        SET         Value = @NewValue
                        WHERE       KodeNomor = @Kode ";
                    cmd = new SqlCommand(sSql, conn);
                    cmd.Parameters.AddWithValue("@NewValue", retVal + 1);
                    cmd.Parameters.AddWithValue("@Kode", KodeNo);
                    cmd.ExecuteNonQuery();

                    tran.Complete();
                }
            }
            return retVal;
        }

    }
}