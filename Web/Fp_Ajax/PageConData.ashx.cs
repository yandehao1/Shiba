using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RuRo.Web.Fp_Ajax
{
    /// <summary>
    /// PageConData 的摘要说明
    /// </summary>
    public class PageConData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string username = Common.CookieHelper.GetCookieValue("username");
            string pwd = Common.CookieHelper.GetCookieValue("password");
            string password = string.Empty;
            if (!string.IsNullOrEmpty(pwd))
            {
                try
                {
                    password = Common.DEncrypt.DESEncrypt.Decrypt(pwd);
                }
                catch (Exception ex)
                {
                    Common.LogHelper.WriteError(ex);
                    context.Response.Redirect("Login.aspx");
                }
            }

            FpUtility.Fp_Common.UnameAndPwd up = new FpUtility.Fp_Common.UnameAndPwd(username, password);

            string mark = context.Request.Params["conMarc"];
            switch (mark)
            {
                //case "SexFlag": Response.Write(ReturnGender()); break;
                //// case "Mzzybz": Response.Write(ReturnIn_CodeType()); break;
                //case "BloodTypeFlag": Response.Write(ReturnBloodTypeFlag()); break;
                //case "SamplingMethod": Response.Write(ReturnSamplingMethodData()); break;
                //case "DiagnoseTypeFlag": Response.Write(ReturnDiagnoseTypeFlag()); break;
                //case "departments": Response.Write(ReturnDepartments()); break;
                //case "SampleType": Response.Write(ReturnSampleType(up)); break;
                case "ssType": context.Response.Write(ReturnSampleSocrceType(up)); break;
                //case "SampleGroups": Response.Write(ReturnSampleGroups(up)); break;
                default:
                    break;
            }

        }

        /// <summary>
        /// 样品源类型数据
        /// </summary>
        /// <returns></returns>
        private string ReturnSampleSocrceType(FpUtility.Fp_Common.UnameAndPwd up)
        {
            //string res = "[{\"value\": \"0\",\"text\": \"基本信息-心研所\" },{\"value\": \"1\", \"text\": \"基本信息-肺癌所\"}]";
            Common.CreatFpUrl fpurl = new Common.CreatFpUrl();
            string url = fpurl.FpUrl;
            Dictionary<string, string> dic = FpUtility.Fp_BLL.SampleSocrce.GetAllIdAndNamesDic(up);
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            if (dic.Count > 0)
            {
                foreach (KeyValuePair<string, string> dd in dic)
                {
                    Dictionary<string, string> temdic = new Dictionary<string, string>();
                    temdic.Add("value", dd.Key);
                    temdic.Add("text", dd.Value);
                    list.Add(temdic);
                }
            }
            string json = FpUtility.Fp_Common.FpJsonHelper.DictionaryListToJsonString(list);
            return json;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}