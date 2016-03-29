using FpUtility.Fp_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FpUtility.Fp_BLL
{
    public class Get_Perfect_Box
    {
        /// 查询指定冰箱指定位置是否存在符合条件的盒子
        public static string get_perfect_box(Fp_Common.UnameAndPwd up, string space, string freezer_name)
        {
            string resultStr = string.Empty;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.get_perfect_box.ToString());
            dic.Add("freezer_name", freezer_name);
            dic.Add("space", space);
            FpUtility.Fp_DAL.CallApi call = new FpUtility.Fp_DAL.CallApi(dic);
            resultStr = call.GetData();
            return resultStr;
            //暂时如此，直接返回查询之后的结果，能不能查到得到都返回，后期需要将返回结果解析之后返回
            //http://192.168.183.130/api?username=admin&password=123456&method=get_perfect_box&freezer_name=tem->admin->06&space=8
            //{"success":true,"box_id":1351,"location":"tem->admin->06->02->1"}
        }
        public static List<Fp_Model.Freezer> GetAll(Fp_Common.UnameAndPwd up)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.freezers.ToString());
            FpUtility.Fp_DAL.CallApi call = new FpUtility.Fp_DAL.CallApi(dic);
            List<Fp_Model.Freezer> freezersList = call.getdata<Fp_Model.Freezer>("Freezers");
            return freezersList;
        }

    }
}
