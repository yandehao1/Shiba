using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Common
{
    public  class Config
    {
        #region FP登陆地址、登陆账号、密码、URI、自动属性public string IP { get; set; }
        /// <summary>
        /// FP访问IP、读取后台页面生成的配置文件生成
        /// </summary>
        public  string IP { get; set; }
        /// <summary>
        /// FP中的账号密码
        /// </summary>
        public  string UserName { get; set; }
        /// <summary>
        /// FP中的密码
        /// </summary>
        public  string PassWord { get; set; }
        /// <summary>
        /// token
        /// </summary>
        public  string Token { get; set; }
        /// <summary>
        /// 用于访问FP的链接字符串
        /// </summary>
        public  string URI { get; set; }

        public Config()
        {
            IP = "192.168.233.128";
            UserName = "admin";
            PassWord = "admin";
            URI = string.Format("http://{0}/api?",IP);
        }
        #endregion

    }
}