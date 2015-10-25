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
            FreezerProUtility.Fp_Common.UnameAndPwd up = new FreezerProUtility.Fp_Common.UnameAndPwd(username, password);

            string mark = Request.Params["conMarc"];
            switch (mark)
            {
                case "SexFlag": Response.Write(ReturnGender()); break;
               // case "Mzzybz": Response.Write(ReturnIn_CodeType()); break;
                case "BloodTypeFlag": Response.Write(ReturnBloodTypeFlag()); break;
                case "SamplingMethod": Response.Write(ReturnSamplingMethodData()); break;
                case "DiagnoseTypeFlag": Response.Write(ReturnDiagnoseTypeFlag()); break;
                case "departments": Response.Write(ReturnDepartments()); break;
                case "SampleType": Response.Write(ReturnSampleType(up)); break;
                case "ssType": Response.Write(ReturnSampleSocrceType(up)); break;
                case "SampleGroups": Response.Write(ReturnSampleGroups(up)); break;
                default:
                    break;
            }
        }

        private string ReturnSampleGroups(FreezerProUtility.Fp_Common.UnameAndPwd up)
        {
            Common.CreatFpUrl fpurl = new Common.CreatFpUrl();
            string url = fpurl.FpUrl;
            Dictionary<string, string> dic = FreezerProUtility.Fp_BLL.SampleGroup.GetAllIdAndNameDic(up);
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
            string json = FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryListToJsonString(list);
            return json;
        }

        //初始化唯一选择框
        private string ReturnIn_CodeType()
        {
            string res = "[{\"value\": \"0\",\"text\": \"卡号\" },{\"value\": \"1\", \"text\": \"住院号\"}]";
            return res;
        }

        //初始化性别
        private string ReturnGender()
        {
            string res = "[{\"value\": \"0\",\"text\": \"未知\" },{\"value\": \"1\", \"text\": \"男\"}, { \"value\": \"2\", \"text\": \"女\"} ]";
            return res;
        }

        //初始化血型
        private string ReturnBloodTypeFlag()
        {
            string res = "[{\"BloodTypeFlag\": \"1\",\"text\": \"A\" },{\"BloodTypeFlag\": \"2\", \"text\": \"B\"}, { \"BloodTypeFlag\": \"3\", \"text\": \"AB\"},{\"BloodTypeFlag\": \"4\",\"text\": \"O\" },{\"BloodTypeFlag\": \"5\", \"text\": \"其它\"}, { \"BloodTypeFlag\": \"6\", \"text\": \"未查\"} ]";
            return res;
        }

        private string ReturnSamplingMethodData()
        {
            string res = "[{ \"samplingMethod\": \"手术前\", \"text\": \"手术前\" }, { \"samplingMethod\": \"手术时\", \"text\": \"手术时\" },{ \"samplingMethod\": \"手术一周后\", \"text\": \"手术一周后\" }, { \"samplingMethod\": \"化疗前\", \"text\": \"化疗前\" },{ \"samplingMethod\": \"化疗两周期结束后，第三周化疗期前\", \"text\": \"化疗两周期结束后，第三周化疗期前\" },{ \"samplingMethod\": \"第五周期化疗前\", \"text\": \"第五周期化疗前\" },{ \"samplingMethod\": \"第六周期化疗技术后\", \"text\": \"第六周期化疗技术后\" },{ \"samplingMethod\": \"靶向治疗前\", \"text\": \"靶向治疗前\" },{ \"samplingMethod\": \"疾病出现进展时\", \"text\": \"疾病出现进展时\" },{ \"samplingMethod\": \"更换治疗方案前\", \"text\": \"更换治疗方案前\" },{ \"samplingMethod\": \"其他\", \"text\": \"其他\" } ]";
            return res;
        }

        private string ReturnDiagnoseTypeFlag()
        {
            string res = "[{\"DiagnoseTypeFlag\": \"0\",\"text\": \"门诊诊断\" },{\"DiagnoseTypeFlag\": \"1\", \"text\": \"入院诊断\"}, { \"DiagnoseTypeFlag\": \"2\", \"text\": \"出院主要诊断\"} , { \"DiagnoseTypeFlag\": \"3\", \"text\": \"出院次要诊\"} ]";
            return res;
        }

        public static Dictionary<string, string> DiagnoseTypeFlagDic()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("0", "门诊诊断");
            dic.Add("1", "入院诊断");
            dic.Add("2", "出院主要诊断");
            dic.Add("3", "出院次要诊");
            return dic;
        }

        /// <summary>
        /// 样品类型数据
        /// </summary>
        /// <returns></returns>
        private string ReturnSampleType(FreezerProUtility.Fp_Common.UnameAndPwd up)
        {
            //string res = "[{\"value\": \"0\",\"text\": \"正常组织-心研所\" },{\"value\": \"1\", \"text\": \"正常组织-肺癌所\"}, { \"value\": \"2\", \"text\": \"组织-心研所\"} , { \"value\": \"3\", \"text\": \"组织-肺癌所\"} ]";
            Common.CreatFpUrl fpurl = new Common.CreatFpUrl();
            string url = fpurl.FpUrl;
            Dictionary<string, string> dic = FreezerProUtility.Fp_BLL.Samples.GetAllIdAndNamesDic(up);
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
            string json = FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryListToJsonString(list);
            return json;
        }

        /// <summary>
        /// 样品源类型数据
        /// </summary>
        /// <returns></returns>
        private string ReturnSampleSocrceType(FreezerProUtility.Fp_Common.UnameAndPwd up)
        {
            //string res = "[{\"value\": \"0\",\"text\": \"基本信息-心研所\" },{\"value\": \"1\", \"text\": \"基本信息-肺癌所\"}]";
            Common.CreatFpUrl fpurl = new Common.CreatFpUrl();
            string url = fpurl.FpUrl;
            Dictionary<string, string> dic = FreezerProUtility.Fp_BLL.SampleSocrce.GetAllIdAndNamesDic(up);
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
            string json = FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryListToJsonString(list);
            return json;
        }

        private string ReturnDepartments()
        {
            string res = "[{ \"value\": \"0\", \"text\": \"肺癌所\" }, { \"value\": \"1\", \"text\": \"心研所\" }]";
            return res;
        }

        //private string ReturnSampleType()
        //{
        //    string url = Common.CreatFpUrl.FpUrl;
        //    Dictionary<string, string> dic = FreezerProUtility.Fp_BLL.Samples.GetAllSample_TypesNames(url);
        //    string json = FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryToJsonString(dic);

        //    return json;
        //}
    }
}