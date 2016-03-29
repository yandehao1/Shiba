using System;
using System.Collections.Generic;

namespace RuRo.Web
{
    public partial class PageConData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/plain";
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
                    Response.Redirect("Login.aspx");
                }
            }
            FpUtility.Fp_Common.UnameAndPwd up = new FpUtility.Fp_Common.UnameAndPwd(username, password);

            string mark = Request.Params["conMarc"];
            switch (mark)
            {
                case "SampleType": Response.Write(ReturnSampleType(up)); break;
                case "ssType": Response.Write(ReturnSampleSocrceType(up)); break;
                case "SampleGroups": Response.Write(ReturnSampleGroups(up)); break;
                default:
                    break;
            }
        }

        private string ReturnSampleGroups(FpUtility.Fp_Common.UnameAndPwd up)
        {
            Common.CreatFpUrl fpurl = new Common.CreatFpUrl();
            string url = fpurl.FpUrl;
            Dictionary<string, string> dic = FpUtility.Fp_BLL.SampleGroup.GetAllIdAndNameDic(up);
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

        /// <summary>
        /// 样品类型数据
        /// </summary>
        /// <returns></returns>
        private string ReturnSampleType(FpUtility.Fp_Common.UnameAndPwd up)
        {
            Common.CreatFpUrl fpurl = new Common.CreatFpUrl();
            string url = fpurl.FpUrl;
            Dictionary<string, string> dic = FpUtility.Fp_BLL.Samples.GetAllIdAndNamesDic(up);
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

        /// <summary>
        /// 样品源类型数据
        /// </summary>
        /// <returns></returns>
        private string ReturnSampleSocrceType(FpUtility.Fp_Common.UnameAndPwd up)
        {
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
    }
}