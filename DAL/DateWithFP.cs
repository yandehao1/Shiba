using System;
using System.Collections.Generic;
using System.Text;
using RuRo.DAL;
using RuRo.Common;
using Common;

namespace DAL
{

    /// <summary>
    /// 和Fp交换数据
    /// </summary>
    public class DataWithFP
    {
        #region 访问Fp的用户名属性
        private string username = "";
        /// <summary>
        /// Fp访问名称
        /// </summary>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        #endregion

        #region 访问Fp的密码属性
        private string passWord = "";
        /// <summary>
        /// Fp访问密码
        /// </summary>
        public string Password
        {
            get { return passWord; }
            set { passWord = value; }
        }
        #endregion

        #region auth_token 属性
        string auth_token;
        public string Auth_token
        {
            get { return auth_token; }
            set { auth_token = value; }
        }
        #endregion

        //连接字符串（包含username、password）
        string uriStr = "";
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="uri">“http://192.168.1.100”</param>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        public DataWithFP()
        {
            List<string> NameAndPasswd = AccountHelper.GetActiveAccountUesrName();
            if (NameAndPasswd != null)
            {
                if (NameAndPasswd.Count > 0)
                {
                    Username = NameAndPasswd[0];
                    passWord = NameAndPasswd[1];
                }
                else
                {
                    Username = RuRo.Common.CookieHelper.GetCookieValue("username");
                    passWord = RuRo.Common.CookieHelper.GetCookieValue("password");
                    if (!string.IsNullOrEmpty(passWord))
                    {
                        passWord = RuRo.Common.DEncrypt.DESEncrypt.Decrypt(passWord);
                    }
                }
            }
            uriStr = string.Format("{0}/api?", FpUtility.Fp_Common.XmlHelper.Read("configXML\\UriConfigXml.xml", "Uri"));
        }
        //指定账号密码
        public DataWithFP(string username, string password)
        {
            Username = username;
            passWord = password;
            uriStr = string.Format("{0}/api?", FpUtility.Fp_Common.XmlHelper.Read("configXML\\UriConfigXml.xml", "Uri"));
        }
        #endregion

        #region 有参取数据方法 + public string getDateFromFp(FpMethod fpMethod, string parameters)
        /// <summary>
        /// 有参取数据方法
        /// </summary>
        /// <param name="fpMethod">具体方法</param>
        /// <param name="parameters">可选参数如（&id=1）“没有就空字符串”</param>
        /// <returns>查询到的结果字符串</returns>
        public string getDateFromFp(FpMethod fpMethod, Dictionary<string,string> dicData)
        {
            //string url = string.Format("{0}username={1}&password={2}&method={3}", uriStr, username, passWord, fpMethod);
            //return postdata(url, parameters);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", Username);
            dic.Add("password", Password);
            dic.Add("method", fpMethod.ToString());
            if (dicData!=null&&dicData.Count>0)
            {
                foreach (var item in dicData)
                {
                    dic.Add(item.Key, item.Value);
                }
            }
           return FpUtility.Fp_BLL.postData.postDataToFp(dic);
        }
        public string getDateFromFp(FpMethod fpMethod)
        {
            //string url = string.Format("{0}username={1}&password={2}&method={3}", uriStr, username, passWord, fpMethod);
            //return postdata(url, parameters);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", Username);
            dic.Add("password", Password);
            dic.Add("method", fpMethod.ToString());
            return FpUtility.Fp_BLL.postData.postDataToFp(dic);
        }
        #endregion

        #region post数据到fp + public string postDateToFp(FpMethod fpMethod, string date) 如import_source

        /// <summary>
        /// post数据到fp（update_source）
        /// </summary>
        /// <param name="fpMethod">api方法</param>
        /// <param name="date">数据（要包含参数,不包含账号和密码、passWord）</param>
        /// <returns>返回结果</returns>
        public string GetDataDateById(FpMethod fpMethod, string date)
        {
            string result = string.Empty;
            //string url = string.Format("{0}username={1}&auth_token={2}&method={3}", uriStr, username, passWord, fpMethod);
            //result = postdata(url, date);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", Username);
            dic.Add("password", Password);
            dic.Add("method", fpMethod.ToString());
            dic.Add("id", date);
            result= FpUtility.Fp_BLL.postData.postDataToFp(dic);
            return result;
        }
        #endregion


        public string ImportSampleSource(Common.FpMethod _FpMethod, string data)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", username);
            dic.Add("password", passWord);
            dic.Add("method", _FpMethod.ToString());
            dic.Add("json", data);
            return "";
        }
    }
}
