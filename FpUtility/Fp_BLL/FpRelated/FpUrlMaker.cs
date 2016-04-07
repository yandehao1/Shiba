using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FpUtility.Fp_BLL
{
    public class FpUrlMaker
    {
        public FpUrlMaker(string username,string password)
        {
            this.UserName = username;
            this.PassWord = password;
            this.ConnFpUrl = string.Format("{0}/api?username={1}&password={2}", url, UserName, PassWord);
        }
        //读取配置文件中的FpUrl
        string url = System.Configuration.ConfigurationManager.AppSettings["FpUrl"];
        public string ConnFpUrl { get; set; }
        //账号
        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        //密码
        private string password;
        public string PassWord
        {
            get { return password; }
            set { password = value; }
        }
    }
}
