using FreezerProUtility.Fp_Common;
using FreezerProUtility.Fp_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreezerProUtility.Fp_BLL
{
    public class UserFields
    {        //创建数据层对象

        #region 获取自定义字段集合 + public List<UserFields> UserFields()
        public static List<Fp_Model.UserFields> GetAll(Fp_Common.UnameAndPwd up)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.gen_token.ToString());
            Fp_DAL.CallApi call = new CallApi(dic);
            List<Fp_Model.UserFields> list = call.getdata<Fp_Model.UserFields>("UserFields");
            return list;
        }
        #endregion

    }
}
