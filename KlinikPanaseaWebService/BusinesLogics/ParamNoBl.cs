using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KlinikPanaseaWebService.DataAccessLayers;


namespace KlinikPanaseaWebService.BusinesLogics
{
    public class ParamNoBl
    {
        private ParamNoDal dalParamNo = new ParamNoDal();

        public decimal GetValue(string KodeNo)
        {
            return dalParamNo.GetValue(KodeNo);
        }
    }
}