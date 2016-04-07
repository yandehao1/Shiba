
using FpUtility.Fp_Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FpUtility.Fp_DAL
{
    /// <summary>
    /// 调用Api提交数据类
    /// </summary>
    internal class CallApi
    {
        #region 属性
        /// <summary>
        /// 链接Fp的Url http://192.168.1.1
        /// </summary>
        internal string Url { get; set; }
        /// <summary>
        /// 数据字典
        /// </summary>
        internal Dictionary<string, string> dataDic { get; set; } 
        #endregion

        #region 构造函数
        internal CallApi(Dictionary<string, string> datadic)
        {
            this.Url = System.Configuration.ConfigurationManager.AppSettings["FpUrl"];
            this.dataDic = datadic;
        }
        internal CallApi(string url, Dictionary<string, string> datadic)
        {
            this.Url = url;
            this.dataDic = datadic;
        } 
        #endregion

        #region 方法
        internal string PostData()
        {
            StringBuilder jsonData = new StringBuilder();
            if (dataDic != null && dataDic.Count > 0)
            {
                foreach (KeyValuePair<string, string> p in dataDic)
                {
                    if (!string.IsNullOrEmpty(p.Value))
                    {
                        jsonData.AppendFormat("&{0}={1}", p.Key.Trim().ToString(), p.Value.Trim().ToString());
                    }
                }
            }
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = Url + "/api",//URL     必需项       
                Method = "post",//URL     可选项 默认为Get   
                IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写   
                Cookie = "",//字符串Cookie     可选项   
                Referer = "",//来源URL     可选项   
                Postdata = jsonData.ToString(),//Post数据     可选项GET时不需要写 
                PostEncoding = Encoding.UTF8,  
                Timeout = 100000,//连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000   
                UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)",//用户的浏览器类型，版本，操作系统     可选项有默认值   
                ContentType = "application/x-www-form-urlencoded",//返回类型    可选项有默认值   
                Allowautoredirect = true,//是否根据301跳转     可选项   
                //CerPath = "d:\123.cer",//证书绝对路径     可选项不需要证书时可以不写这个参数   
                //Connectionlimit = 1024,//最大连接数     可选项 默认为1024    
                ProxyIp = "",//代理服务器ID     可选项 不需要代理 时可以不设置这三个参数    
                //ProxyPwd = "123456",//代理服务器密码     可选项    
                //ProxyUserName = "administrator",//代理服务器账户名     可选项   
                ResultType = ResultType.String
            };
            HttpResult result = http.GetHtml(item);
            string html = result.Html;
            string cookie = result.Cookie;
            return html;
        }

        internal string GetData()
        {
          return  PostData();
        }
        internal List<T> getdata<T>(string datawith)
        {
            List<T> list = new List<T>();
            string str_Json = PostData();
            if (ValidationData.checkTotal(str_Json))
            {
                list = FpJsonHelper.JObjectToList<T>(datawith, str_Json);
            }
            return list;
        }
        internal T getdata<T>() where T : class,new()
        {
            T t = new T();
            string str_Json = PostData();
            if (ValidationData.checkTotal(str_Json))
            {
                t = FpJsonHelper.DeserializeObject<T>(str_Json);
            }
            return t;
        }
        #endregion
    }
}
