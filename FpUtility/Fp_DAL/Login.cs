using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FpUtility.Fp_DAL
{
    public class Login
    {
        Fp_Model.NameAndPwd up = new Fp_Model.NameAndPwd();
        public Login(string username, string password)
        {
            up.UserName = username;
            up.PassWord = password;
        }
        public bool CheckLogin()
        {
            bool result = false;
            Dictionary<string, string> dicData = new Dictionary<string, string>();
            dicData.Add("username", up.UserName);
            dicData.Add("password", up.PassWord);
            dicData.Add("method", "gen_token");
            CallApi api = new CallApi(dicData);
            string strResult = api.PostData();
            if (!string.IsNullOrEmpty(strResult) && strResult.Contains("auth_token"))
            {
                result = true;
                Fp_Common.SessionHelper.SetSession(up.GetType().Name.ToString() + "_" + up.UserName, dicData);
            }
            else
            {
                Fp_Common.SessionHelper.Del(up.GetType().Name.ToString() + "_" + up.UserName);
            }
            return result;
        }
    }
}
