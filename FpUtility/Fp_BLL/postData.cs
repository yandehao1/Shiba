using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FpUtility.Fp_BLL
{
    public class postData
    {
        public static string postDataToFp(Dictionary<string,string> dataDic)
        {
            FpUtility.Fp_DAL.CallApi call = new Fp_DAL.CallApi(dataDic);
            string res = call.PostData();
            return res;
        }
    }
}
