using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreezerProUtility.Fp_Model;

namespace FreezerProUtility.Fp_BLL
{
    public class Freezers
    {

        //{"Total":1,"Freezers":[{"id":1,"name":"001号冰箱","description":"001号冰箱","access":0,"subdivisions":4,"boxes":0,"barcode_tag":"7000000001","rfid_tag":"355AB1CBC000007000000001"}]}
        //获取冰箱结构
        public static List<Fp_Model.Freezer> GetAll(Fp_Common.UnameAndPwd up)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.freezers.ToString());
            FreezerProUtility.Fp_DAL.CallApi call = new FreezerProUtility.Fp_DAL.CallApi(dic);
            List<Freezer> list = call.getdata<Freezer>("Freezers");
            return list;
        }
        public static Freezer GetBy(Fp_Common.UnameAndPwd up, string name)
        {
            Fp_Model.Freezer freezer = GetAll(up).Where<Fp_Model.Freezer>(a => a.name == name).FirstOrDefault();
            return freezer;
        }
    }
}
