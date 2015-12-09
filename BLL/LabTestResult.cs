using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace RuRo.BLL
{
    public partial class LabTestResult
    {
        WebService.ForCenterLabService wbs = new WebService.ForCenterLabService();
        Model.ResPondData respondData = new Model.ResPondData();
        private string GetDataFromHP(string oeordID, string testNo)
        {
            string res = string.Empty;
            try
            {
                //XmlDocument xd = Common.XmlHelper.XMLLoad("/configXML/GetPatientLabMaster.xml");
                //res = xd.OuterXml;
                //res.Remove(0, 43);
                res = wbs.GetPatientLabResult(oeordID, testNo);
            }
            catch (Exception ex)
            {
                Common.LogHelper.WriteError(ex);
            }
            return res;
        }
        public string GetData(string oeordID, string testNo)
        {
            string data = string.Empty;
            //data = "321";
            data = GetDataFromHP(oeordID, testNo);
            if (!string.IsNullOrEmpty(data))
            {
                bool tranRes = true;
                // XmlDocument xd = Common.XmlHelper.XMLLoad("/configXML/GetPatientLabMaster.xml");
                XmlDocument xd = Common.XmlHelper.XMLLoad(data, ref tranRes);
                if (tranRes && xd != null)
                {
                    //转换成功
                    XmlNode xn = xd.SelectSingleNode("/Response");
                    string xml2Str1 = JsonConvert.SerializeXmlNode(xn, Newtonsoft.Json.Formatting.None, true);
                    Response resp = JsonConvert.DeserializeObject<Response>(xml2Str1);
                    XmlNodeList xl = xd.SelectNodes("/Response/LabTestResults/LabTestResult");
                    List<Model.ZSSY.LabTestResult> list = new List<Model.ZSSY.LabTestResult>();
                    foreach (XmlNode item in xl)
                    {
                        try
                        {
                            string xmlStr = JsonConvert.SerializeXmlNode(item, Newtonsoft.Json.Formatting.None, true);
                            list.Add(JsonConvert.DeserializeObject<Model.ZSSY.LabTestResult>(xmlStr));
                        }
                        catch (Exception ex)
                        {
                            Common.LogHelper.WriteError(ex);
                            continue;
                        }
                    }
                    resp.LabTestResul = list.OrderBy(a => a.ReportItemName).ToList();
                    respondData.Data = resp;
                    respondData.Msg = "调用医院接口成功";
                    respondData.State = Model.State.ok;
                }
                else
                {
                    //转换不成功
                    respondData.Data = string.Empty;
                    respondData.Msg = "调用医院接口失败";
                    respondData.State = Model.State.err;
                }
            }
            return JsonConvert.SerializeObject(respondData);
        }
        class Response
        {
            public int ResultCode { get; set; }
            public string ResultContent { get; set; }
            public string TestNo { get; set; }
            public string VisitId { get; set; }
            public string Name { get; set; }
            public List<Model.ZSSY.LabTestResult> LabTestResul { get; set; }
        }
    }
}
