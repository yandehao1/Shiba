using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;
namespace BLL
{
    public class Token
    {
        //创建数据层对象
        DataWithFP dateWithFP;
        string auth_Token;

        public string Auth_Token
        {
            get { return auth_Token; }
            set { auth_Token = value; }
        }

        public bool CkeckRes { get; set; }
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public Token(string username, string password)
        {
            dateWithFP = new DataWithFP(username, password);
            FreezerProUtility.Fp_Common.UnameAndPwd up = new FreezerProUtility.Fp_Common.UnameAndPwd(username, password);
            FreezerProUtility.Fp_BLL.Token token = new FreezerProUtility.Fp_BLL.Token(up);
            CkeckRes = token.checkAuth_Token();
            Auth_Token = dateWithFP.getDateFromFp(FpMethod.gen_token);
        }
        #endregion
        /// <summary>
        /// 检查是否能获取到auth_token（能获取说明账号密码路径都没问题）
        /// </summary>
        /// <returns>返回检查结果</returns>
        public bool checkAuth_Token()
        {
            return ValidationData.checkAuth_Token(Auth_Token);
        }
    }
}
