using FreezerProUtility.Fp_Common;
using FreezerProUtility.Fp_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace FreezerProUtility.Fp_BLL
{
    public class Token
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public Token(Fp_Common.UnameAndPwd up)
        {
            UserName = up.UserName;
            PassWord = up.PassWord;
        }
        #endregion
        private string Get_Auth_Token()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username",UserName);
            dic.Add("password",PassWord);
            dic.Add("method", Fp_Common.FpMethod.gen_token.ToString());
            Fp_DAL.CallApi call = new CallApi(dic);
            string result = call.GetData();
            return result;
        }

        /// <summary>
        /// 检查是否能获取到auth_token（能获取说明账号密码路径都没问题）
        /// </summary>
        /// <returns>返回检查结果</returns>
        public bool checkAuth_Token()
        {
            string auth_TokenStr = Get_Auth_Token();
            return ValidationData.checkAuth_Token(auth_TokenStr);
        }
    }
}
