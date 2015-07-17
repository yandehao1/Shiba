using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class bll_test
    {
        public string getdata(string url)
        {
            DAL.HttpItem item = new DAL.HttpItem();
            DAL.HttpHelper http = new DAL.HttpHelper();
            item.URL = url;
            return http.GetHtml(item).Html;
        }
        //提交数据到fp方法
        public string postdata(string url, string data)
        {
            DAL.HttpItem item = new DAL.HttpItem();
            DAL.HttpHelper http = new DAL.HttpHelper();
            item.URL = url;
            item.Method = "POSt";
            item.Encoding = Encoding.UTF8;
            item.Postdata = data;
            return http.GetHtml(item).Html;
        }

        public string ImportSampleSource(string url , string data)
        {
            DAL.WebClient web = new DAL.WebClient();
            web.Encoding = Encoding.UTF8;
            string result = web.Post(url, data);
            return result;
        }
    }
}
