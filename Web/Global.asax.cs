using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;
using System.Globalization;

namespace FreezerProPlugin
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

            // 在出现未处理的错误时运行的代码
            Exception objErr = Server.GetLastError().GetBaseException();
            //记录出现错误的IP地址
            string strIP = Request.UserHostAddress;
            string err = "Ip【" + strIP + "】" + Environment.NewLine + "Error in【" + Request.Url.ToString() +
                               "】" + Environment.NewLine + "Error Message【" + objErr.Message.ToString() + "】";
            //记录错误
            WriteError(err);
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }



    /// <summary>
    /// 用于将错误信息输出到txt文件
    /// </summary>
    /// <param name="errorMessage">错误详细信息</param>
    private static void WriteError(string errorMessage)
    {
        try
        {
            string path = "~/Error/" + DateTime.Today.ToString("yyMMdd") + ".txt";
            if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
            }
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                w.WriteLine("\r\nLog Entry : ");
                w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                w.WriteLine(errorMessage);
                w.WriteLine("________________________________________________________");
                w.Flush();
                w.Close();
            }
        }
        catch (Exception ex)
        {
            WriteError(ex.Message);
        }
    }
    }
}