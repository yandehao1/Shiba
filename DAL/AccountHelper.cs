using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Threading;
using System.Web;
using System.Web.SessionState;

namespace DAL
{
    public class AccountHelper : IHttpHandler, IRequiresSessionState
    {

        /// <summary>
        /// 直接读取存在cookie和session中的账号密码信息
        /// </summary>
        /// <returns></returns>
        public static List<string> GetActiveAccountUesrName()
        {

            List<string> userNameAndPasswordList = new List<string>();
            string Username = "", Password = "";//账号密码
            if (HttpContext.Current.Request.Cookies["loginCookie"] != null)
            {
                Username = HttpContext.Current.Request.Cookies["loginCookie"].Values["Username"].ToString();
                Password = HttpContext.Current.Request.Cookies["loginCookie"].Values["Password"].ToString();
                userNameAndPasswordList.Add(Username);
                userNameAndPasswordList.Add(Password);
            }
            return userNameAndPasswordList;
        }


        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
