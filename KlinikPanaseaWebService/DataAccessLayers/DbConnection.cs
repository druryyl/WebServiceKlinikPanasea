using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlinikPanaseaWebService.DataAccessLayers
{
    public static class DbConnection
    {
        public static string ConnectionString()
        {
            string retVal = "";

            retVal = @"Data source =(local);Initial Catalog=KLINIK_PKL;Integrated Security=SSPI;";

            return retVal;
        }
    }
}