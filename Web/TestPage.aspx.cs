using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Threading;
using System.Net;
using System.Text;
using System.IO;

namespace FreezerProPlugin
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //BLL.Test test = new BLL.Test();
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("Name", "李四");
            //dic.Add("Description", "病人李四");
            //dic.Add("报告日期", "2014-01-12 12:21");
            //dic.Add("住院号", "3201312");
            //string result = test.ImportDataToFp("内分泌科", dic);
            ////Response.Write(result);
            //BLL.Samples sample = new BLL.Samples();

            //Model.Sample_Info sam = sample.GetSample_Info("1");

            //Response.Write(sam.created_at+";"+sam.name);

            //Response.Write(samplelist[0].name);
            //for (int i = 0; i < 10; i++)
            //{
            //    Response.Write(DateTime.Now.ToLocalTime());
            //    Thread.Sleep(1000);
            //    Response.Write("<br/>");
            //}

            #region 测试怎么使用日期获取数据
            //测试怎么使用日期获取数据
            //Test test = new Test();

            //string[] dateStr = new string[] { "", "today", "yesterday", "week", "month", "2015-02-27", "2015/02/27", "2015.02.27", "2015-2-27", "2015/2/27", "2015.2.27", "27-02-2015", "27/02/2015", "27.02.2015", "27-2-2015", "27/2/2015", "27.2.2015", "02-27-2015", "02/27/2015", "02.27.2015", "27,2,2015", "2,27,2015", "2015,2,27", "26.1.2015,28.02.2015" ,"2015.01.25,2015.02.28"};
            //foreach (string item in dateStr)
            //{
            //    string uri = "http://192.168.233.128/api?username=admin&password=admin&method=samples_by_date";
            //    string date = "&date=" + item;
            //    Response.Write("请求地址为：");
            //    Response.Write(uri + date);
            //    string result = test.samples_by_date(uri, date);
            //    Response.Write("<br/>");
            //    Response.Write("请求结果为:");
            //    Response.Write("<br/>");
            //    Response.Write(result);
            //    Response.Write("<br/>");
            //    Response.Write("<br/>");
            //}
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("username", "admin");
            //dic.Add("password", "admin");
            //dic.Add("method", "samples_by_date"); 
            #endregion
            BLL.Test t = new Test();
           // string result=  t.reshis();
            //Response.Write(result);
        }
        //public bool AddData(string authors, string title)
        //{
        //    String url = "http://192.168.233.128/api?username=admin&password=admin&method=samples_by_date";
        //    HttpWebRequest hwr = WebRequest.Create(url) as HttpWebRequest;
        //    hwr.Method = "POST";
        //    hwr.ContentType = "application/x-www-form-urlencoded";
        //    string postdata = "date=" + title + "&authors=" + authors;

        //    byte[] data = Encoding.UTF8.GetBytes(postdata);
        //    using (Stream stream = hwr.GetRequestStream())
        //    {
        //        stream.Write(data, 0, data.Length);
        //    }
        //    var result = hwr.GetResponse() as HttpWebResponse;
        //    Response.Write("处理结果：" + WebResponseGet(result));

        //    return true;
        //}
        //public string WebResponseGet(HttpWebResponse webResponse)
        //{
        //    StreamReader responseReader = null;
        //    string responseData = "";
        //    try
        //    {
        //        responseReader = new StreamReader(webResponse.GetResponseStream());
        //        responseData = responseReader.ReadToEnd();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        webResponse.GetResponseStream().Close();
        //        responseReader.Close();
        //        responseReader = null;
        //    }
        //    return responseData;
        //}

    }

}