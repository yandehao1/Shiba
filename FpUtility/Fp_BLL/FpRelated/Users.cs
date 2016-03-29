using FpUtility.Fp_DAL;
using FpUtility.Fp_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FpUtility.Fp_BLL
{
    public class Users
    {

        //获取用户信息
        private static List<User> GetAll(Fp_Common.UnameAndPwd up)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.users.ToString());
            Fp_DAL.CallApi call = new CallApi(dic);
            List<Fp_Model.User> list = call.getdata<Fp_Model.User>("Users");
            return list;
        }
        public static User GetBy(Fp_Common.UnameAndPwd up, string name)
        {
            List<User> list = GetAll(up);
            if (list != null && list.Count > 0)
            {
                return list.Where(a => a.uesrname == name).FirstOrDefault();
            }
            else
            {
                return new User();
            }
        }
    }
}
