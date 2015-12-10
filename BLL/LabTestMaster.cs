using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using BLL;
using Newtonsoft.Json;

namespace RuRo.BLL
{
    public partial class LabTestMaster
    {
        WebService.ForCenterLabService wbs = new WebService.ForCenterLabService();
        Model.ResPondData respondData = new Model.ResPondData();
        private string GetDataFromHP(string patientId, string visitId)
        {
            string res = string.Empty;
            try
            {
                // XmlDocument xd = Common.XmlHelper.XMLLoad("/configXML/GetPatientLabMaster.xml");
                //res = xd.OuterXml;
                //res.Remove(0, 43);
                res = wbs.GetPatientLabMaster(patientId, visitId);
            }
            catch (Exception ex)
            {
                Common.LogHelper.WriteError(ex);
            }
            return res;
        }
        public string GetData(string patientId, string visitId)
        {
            string data = string.Empty;
            respondData.State = Model.State.err;
            respondData.Data = string.Empty;

            data = GetDataFromHP(patientId, visitId);
            if (!string.IsNullOrEmpty(data))
            {
                bool tranRes = true;
                //XmlDocument xd = Common.XmlHelper.XMLLoad("/configXML/GetPatientLabMaster.xml");
                XmlDocument xd = Common.XmlHelper.XMLLoad(data, ref tranRes);
                if (tranRes && xd != null)
                {
                    Response resp = new Response();
                    //转换成功
                    XmlNode xn = xd.SelectSingleNode("/Response");
                    string xml2Str1 = JsonConvert.SerializeXmlNode(xn, Newtonsoft.Json.Formatting.None, true);
                    try
                    {
                        resp = JsonConvert.DeserializeObject<Response>(xml2Str1);
                    }
                    catch (Exception ex)
                    {
                        Common.LogHelper.WriteError(ex);
                        resp.Name = xd.SelectSingleNode("/Response/Name") == null ? "" : (xd.SelectSingleNode("/Response/Name").InnerText);
                        resp.PatientId = xd.SelectSingleNode("/Response/PatientId") == null ? "" : (xd.SelectSingleNode("/Response/PatientId").InnerText);
                        resp.ResultCode = xd.SelectSingleNode("/Response/ResultCode") == null ? "" : (xd.SelectSingleNode("/Response/ResultCode").InnerText);
                        resp.ResultContent = xd.SelectSingleNode("/Response/ResultContent") == null ? "" : (xd.SelectSingleNode("/Response/ResultContent").InnerText);
                        resp.VisitId = xd.SelectSingleNode("/Response/VisitId")== null ? "" : (xd.SelectSingleNode("/Response/VisitId").InnerText);
                    }
                    XmlNodeList xl = xd.SelectNodes("/Response/LabTestMasters/LabTestMaster") == null ? null : xd.SelectNodes("/Response/LabTestMasters/LabTestMaster");
                    List<Model.ZSSY.LabTestMaster> list = new List<Model.ZSSY.LabTestMaster>();
                    if (xl!=null)
                    {
                        foreach (XmlNode item in xl)
                        {
                            try
                            {
                                string xmlStr = JsonConvert.SerializeXmlNode(item, Newtonsoft.Json.Formatting.None, true);
                                list.Add(JsonConvert.DeserializeObject<Model.ZSSY.LabTestMaster>(xmlStr));
                            }
                            catch (Exception ex)
                            {
                                Common.LogHelper.WriteError(ex);
                                continue;
                            }
                        }
                        resp.LabTestMaste = list.OrderBy(a => a.TestCause).ToList();
                    }
                    respondData.Data = resp;
                    respondData.Msg = "调用医院接口成功";
                    respondData.State = Model.State.ok;
                }
                else
                {
                    respondData.Msg = "调用医院接口成功,无数据";
                }
            }
            else
            {
                respondData.Msg = "调用医院接口失败";
            }
            return JsonConvert.SerializeObject(respondData);
        }
        class Response
        {
            public string ResultCode { get; set; }
            public string ResultContent { get; set; }
            public string PatientId { get; set; }
            public string VisitId { get; set; }
            public string Name { get; set; }
            public List<Model.ZSSY.LabTestMaster> LabTestMaste { get; set; }
        }
    }
}
