using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreezerProUtility.Fp_BLL
{
    public class postData
    {
        public static string postDataToFp(Dictionary<string,string> dataDic)
        {
            FreezerProUtility.Fp_DAL.CallApi call = new Fp_DAL.CallApi(dataDic);
            string res = call.PostData();
            return res;
        }
    }
}
