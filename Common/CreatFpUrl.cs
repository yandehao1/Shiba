using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuRo.Common
{
    public class CreatFpUrl
    {
        
        ///// <summary>
        ///// FpUrl--用户登陆之后从cookie中获取--如果禁用cookie则会一直提醒登陆
        ///// </summary>
        private string fpUrl;
        public string FpUrl
        {
            get { return fpUrl; }
            set { fpUrl = value; }
        }
        public CreatFpUrl()
        {
            string url = System.Configuration.ConfigurationManager.AppSettings["FpUrl"];
            string username = Common.CookieHelper.GetCookieValue("username"); 
            string password = Common.DEncrypt.DESEncrypt.Decrypt(Common.CookieHelper.GetCookieValue("password"));
            FpUrl = string.Format("{0}/api?username={1}&password={2}", url, username, password);
        }
    }
}
