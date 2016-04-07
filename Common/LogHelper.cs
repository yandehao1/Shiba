using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace RuRo.Common
{
    public class LogHelper
    {

        public static void WriteError(string errorMessage)
        {
            try
            {
                string path = "~/Error/AppError/" + DateTime.Today.ToString("yyMMdd") + ".txt";
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
        public static void WriteError(Exception ex)
        {
            //记录错误
            StringBuilder str = new StringBuilder();
            Type type = ex.GetType();
            foreach (var item in type.GetProperties())
            {
                string tem = string.Empty;
                try
                {
                    tem = Common.ReflectHelper.GetValue(ex, item.Name);
                    if (!string.IsNullOrEmpty(tem))
                    {
                        str.AppendFormat("{0}：【{1}】{2}", item.Name,tem, Environment.NewLine);
                    }
                }
                catch (Exception e)
                {
                    WriteError(e.Message);
                    continue;
                }

            }

            try
            {
                string path = "~/Error/AppExError/" + DateTime.Today.ToString("yyMMdd") + ".txt";
                if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
                }
                using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    w.WriteLine("\r\nLog Entry : ");
                    w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    w.WriteLine(str.ToString());
                    w.WriteLine("________________________________________________________");
                    w.Flush();
                    w.Close();
                }
            }
            catch
            {
                WriteError(ex.Message);
            }
        }
    }
}
