using Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;
namespace BLL
{
    public class GetDataFromHospital
    {

        #region  01.1 获取本地Barcode文件并将文件转换成前台页面需要的Json格式的字符串 + public string GetOPListForSpecimenByLocalFileToJsonStr()
        /// <summary>
        /// 获取本地文件并将文件转换成前台页面需要的Json格式的字符串
        /// </summary>
        /// <returns>转换好的Json格式的字符串</returns>
        public string GetOPListForSpecimenByLocalBracodeFileToJsonStr()
        {
            //return ConvertDicToJsonStr(GetOPListForSpecimenByLocalBarcodeFileToDic());
            return FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(GetOPListForSpecimenByLocalBarcodeFileToDic());
        }
        #endregion

        #region 01.2 根据本地文件获取医院数据并将数据转换成字典 + private Dictionary<string, string> GetOPListForSpecimenByLocalBarcodeFileToDic()
        /// <summary>
        /// 根据本地文件获取医院数据并将数据转换成字典 
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetOPListForSpecimenByLocalBarcodeFileToDic()
        {
            Dictionary<string, string> oPListForSpecimenDic = new Dictionary<string, string>();

            string oPListForSpecimenStr = HospitalXmlStrHelper.HospitalXmlFileToXmlStr("configXML\\WS.ForCenterLabServiceByBarcode.xml");
            oPListForSpecimenDic = ConvertOPListForSpecimenStrToDic(oPListForSpecimenStr);
            return oPListForSpecimenDic;
        }
        #endregion

        #region 02.1 根据本地Date文件获取医院数据并将数据转换成字典集合 + private List<Dictionary<string, string>> GetOPListForSpecimensByLocalFileToDic()
        /// <summary>
        /// 根据本地Date文件获取医院数据并将数据转换成字典集合
        /// </summary>
        /// <returns>字典集合</returns>
        private List<Dictionary<string, string>> GetOPListForSpecimensByLocalDateFileToDic()
        {
            //创建病人字典集合。
            List<Dictionary<string, string>> oPListForSpecimensDicList = new List<Dictionary<string, string>>();

            string oPListForSpecimenStr = HospitalXmlStrHelper.HospitalXmlFileToXmlStr("configXML\\WS.ForCenterLabServiceByDate.xml");
            XmlDocument getDataFromHospitalXml = HospitalXmlStrHelper.HospitalXmlStrToXmlDoc(oPListForSpecimenStr);

            if (getDataFromHospitalXml != null)//有数据并且能转换成xml文档
            {
                if (getDataFromHospitalXml.HasChildNodes)
                {
                    XmlNode xmlNode = getDataFromHospitalXml.SelectSingleNode("/OPListForSpecimenRt/ResultCode");

                    //创建临时集合保存多个人的数据
                    Dictionary<string, string> oPListForSpecimenTempDic = new Dictionary<string, string>();
                    if (xmlNode.InnerText == "0") //获取数据成功
                    {
                        //OPListForSpecimens/OPListForSpecimen
                        XmlNodeList xmlNodeList = getDataFromHospitalXml.SelectNodes("//OPListForSpecimens/*");

                        foreach (XmlNode item in xmlNodeList)
                        {
                            string tempOPListForSpecimenXml = item.OuterXml;
                            oPListForSpecimenTempDic = ConvertOPListForSpecimenStrToDic(tempOPListForSpecimenXml);
                            oPListForSpecimensDicList.Add(oPListForSpecimenTempDic);

                        }
                    }
                    else //获取数据失败
                    {
                        oPListForSpecimenTempDic.Clear();
                        oPListForSpecimenTempDic.Add("OPListForSpecimenRt", getDataFromHospitalXml.SelectSingleNode("/OPListForSpecimenRt/ResultContent").InnerText);
                        oPListForSpecimensDicList.Add(oPListForSpecimenTempDic);
                    }
                }
            }
            return oPListForSpecimensDicList;
        }
        #endregion

        #region 02.2 获取本地Date文件并将文件转换成前台页面需要的Json格式的字符串 + public string GetOPListForSpecimenByLocalDateFileToJsonStr()
        /// <summary>
        /// 获取本地文件并将文件转换成前台页面需要的Json格式的字符串
        /// </summary>
        /// <returns>转换好的Json格式的字符串</returns>
        public string GetOPListForSpecimenByLocalDateFileToJsonStr()
        {
            //return ConvertDicListToJsonStr();
            return FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(GetOPListForSpecimensByLocalDateFileToDic());
        }
        #endregion

        #region ******不建议使用  根据条码获取医院数据 + public string GetOPListForSpecimenByBarcode(string barcode)
        //提交条码获取数据——此处要去院系统获取数据
        /// <summary>
        /// 根据条码获取医院数据
        /// </summary>
        /// <param name="barcode">条码号</param>
        /// <returns>datagrid需要的数据</returns>
        public string GetOPListForSpecimenByBarcode(string barcode)
        {
            StringBuilder result = new StringBuilder();
            //01.根据条码号调用webservice获取数据
            RuRo.BLL.WebService.ForCenterLabService centerLabServiceSoapClient = new RuRo.BLL.WebService.ForCenterLabService();
            try
            {
                string getDataFromHospitalStr = centerLabServiceSoapClient.GetPatientInfoSpecimen(barcode);//(调用webservice时取消注释)
                #region 有数据并且不为null
                if (getDataFromHospitalStr != "" && getDataFromHospitalStr != null)//有数据并且不为null
                {
                    //02.将数据转换成xml数据
                    XmlDocument getDataFromHospitalXml = HospitalXmlStrHelper.HospitalXmlStrToXmlDoc(getDataFromHospitalStr);
                    if (getDataFromHospitalXml != null)//有数据并且能转换成xml文档
                    {
                        if (getDataFromHospitalXml.HasChildNodes)
                        {
                            //创建前台页面Grid的字段数据
                            string sampleSourceName = "", sampleSourceType = "", sampleSourceDescription = "", patientId = "", patientName = "", scheduledDateTime = "", importStatus = "待导入", diagBeforeOperation="", hiddenXml = getDataFromHospitalStr;
                            XmlNodeList xmlnodelist = getDataFromHospitalXml.SelectNodes("/OPListForSpecimen/*");//获取OPListForSpecimen下的所有子节点
                            #region 有子节点返回节点数据
                            if (xmlnodelist.Count > 0)//有子节点返回节点数据
                            {
                                foreach (XmlNode item in xmlnodelist)
                                {
                                    switch (item.Name)
                                    {
                                        case "PatientId":
                                            patientId = item.InnerText;//标识号
                                            sampleSourceName = item.InnerText;
                                            break;
                                        case "DeptCode":
                                            sampleSourceType = item.InnerText == "" ? "" : (item.InnerText.Split('-'))[1];
                                            sampleSourceDescription = sampleSourceType == "" ? "" : sampleSourceType + "病区";//此处是后台生成前台页面的Grid,当前台改变时需要子前台页面再次绑定。
                                            break;
                                        case "Name":
                                            patientName = item.InnerText == "" ? "" : item.InnerText;
                                            break;
                                        //case "Sex":
                                        //    patientSex = item.InnerText == "" ? "" : item.InnerText;
                                        //    break;
                                        case "ScheduledDateTime":
                                            scheduledDateTime = item.InnerText == "" ? "" : item.InnerText;
                                            break;
                                        case"DiagBeforeOperation":
                                            diagBeforeOperation = item.InnerText;
                                            break;
                                        default:
                                            break;
                                    }

                                }
                                result.Append("{");
                                result.AppendFormat("\"sampleSourceName\":\"{0}\",\"sampleSourceTypeName\":\"{1}\",\"sampleSourceDescription\":\"{2}\",\"scheduledDateTime\":\"{3}\",\"patientName\":\"{4}\",\"diagBeforeOperation\":\"{5}\",\"importStatus\":\"{6}\",\"patientId\":\"{7}\"", sampleSourceName, sampleSourceType, sampleSourceDescription, scheduledDateTime, patientName, diagBeforeOperation, importStatus,patientId);
                                result.Append("}");

                            }
                            //\"hiddenXml\":\"{7}\" , hiddenXml
                            #endregion
                            //OPListForSpecimen无子节点并且OPListForSpecimen下有数据,
                            else if (xmlnodelist.Count == 0 && getDataFromHospitalXml.SelectSingleNode("/OPListForSpecimen").InnerText != "")
                            {
                                result.Append(getDataFromHospitalXml.SelectSingleNode("/OPListForSpecimen").InnerText);

                            }
                        }
                        else//有数据并且能转换成xml,但是数据下面无OPListForSpecimen节点
                        {
                            result.Append(string.Empty);
                        }
                        #region 直接返回的测试数据
                        //if (barcode == "1")
                        //{
                        //    return "{\"sampleSourceName\":\"0000217014\",\"sampleSourceType\":\"感染科\",\"sampleSourceDescription\":\"蔡XX\",\"patientId\":\"0000217014\",\"patientName\":\"蔡XX\",\"patientSex\":\"女\",\"importStatus\":\"待导入\",\"hiddenXml\":\"隐藏的数据\"}";
                        //}
                        //if (barcode == "2")
                        //{
                        //    return "{\"sampleSourceName\":\"0001815970\",\"sampleSourceDescription\":\"李XX\",\"patientId\":\"0001815970\",\"patientName\":\"李XX\",\"patientSex\":\"女\",\"importStatus\":\"待导入\",\"hiddenXml\":\"隐藏的数据\",\"sampleSourceType\":\"风湿科\",\"selected\":true,}"; 
                        #endregion
                    }
                    else//不能转化成XML
                    {
                        result.Append(string.Empty);
                    }
                }
                #endregion
                else //没数据返回
                {
                    result.Append(string.Empty);
                }
            }
            catch (Exception ex)
            {
                result.Append(string.Empty);
            }
            return result.ToString();
        }
        #endregion
       
        #region 03.2 将oPListForSpecimen字典数据转换成Json格式的字符串发送到前台页面显示 +private string ConvertDicToJsonStr(Dictionary<string, string> oPListForSpecimenDic)
        /// <summary>
        /// 将oPListForSpecimen字典数据转换成Json格式的字符串
        /// </summary>
        /// <param name="oPListForSpecimenDic">oPListForSpecimenDic字典数据</param>
        /// <returns>oPListForSpecimen字典转换成的Json格式的字符串</returns>
        private string ConvertDicToJsonStr(Dictionary<string, string> oPListForSpecimenDic)
        {
            //(自己循环创建json格式的字符串需哟将特殊字符替换掉)
            //StringBuilder oPListForSpecimenJsonStr = new StringBuilder();
            //创建前台页面Grid的字段数据
            //string sampleSourceName = "", sampleSourceType = "", sampleSourceDescription = "", patientId = "", patientName = "", patientSex = "", importStatus = "待导入", hidden;
            //创建前台页面DataGrid需要的行数据字典
            Dictionary<string, string> oPListForSpecimenDicResult = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> item in oPListForSpecimenDic)
            {
                if (!oPListForSpecimenDicResult.Keys.Contains(item.Key))
                {
                    switch (item.Key)
                    {
                        case "PatientId":
                            oPListForSpecimenDicResult.Add("sampleSourceName", item.Value);
                            oPListForSpecimenDicResult.Add("patientId", item.Value);
                            break;
                        case "DeptCode":
                            oPListForSpecimenDicResult.Add("sampleSourceTypeName", item.Value == "" ? "" : (item.Value.Split('-'))[1]);
                            oPListForSpecimenDicResult.Add("sampleSourceDescription", item.Value == "" ? "" : (item.Value.Split('-'))[1] + "病区");
                            break;
                        case "Name":
                            oPListForSpecimenDicResult.Add("patientName", item.Value);
                            break;
                        //case "Sex":
                        //    oPListForSpecimenDicResult.Add("patientSex", item.Value);
                        //    break;
                        case "ScheduledDateTime":
                            oPListForSpecimenDicResult.Add("scheduledDateTime", item.Value);
                            break;
                        case "DiagBeforeOperation":
                            oPListForSpecimenDicResult.Add("diagBeforeOperation", item.Value);
                            break;
                        case "KeepSpecimenSign":
                            oPListForSpecimenDicResult.Add("KeepSpecimenSign", item.Value);
                            break;
                        case "LabInfo":
                            oPListForSpecimenDicResult.Add("LabInfo", item.Value);
                            break;
                        default:
                            break;
                    }
                }
            }
            //此处需要将整个的医院获取的字典加密之后传入隐藏字段中，直接传会是[object object]
            //0001.序列化oPListForSpecimenDic字典成Json对象
            string tempHiddenStr = FpJsonHelper.DictionaryToJsonString(oPListForSpecimenDic);
            string hidden = EncodeAndDecodeString.Encode(tempHiddenStr);
            //0002.将对象加密成字符串
            oPListForSpecimenDicResult.Add("importStatus", "待导入");
            oPListForSpecimenDicResult.Add("hidden", hidden);
            //将字典转换成Json对象
            string oPListForSpecimenDicResultJsonStr = Common.FpJsonHelper.DictionaryToJsonString(oPListForSpecimenDicResult);
            return oPListForSpecimenDicResultJsonStr;

        }
        #endregion
        
        #region 04.2 将传入的oPListForSpecimen 集合转换成Json格式的字符串 +private string ConvertListDicToJsonStr(List<Dictionary<string, string>> listDic)
        /// <summary>
        /// 将传入的oPListForSpecimen 集合转换成Json格式的字符串
        /// </summary>
        /// <param name="listDic">oPListForSpecimen 集合</param>
        /// <returns>Json字符串</returns>
        private string ConvertDicListToJsonStr(List<Dictionary<string, string>> listDic)
        {
            StringBuilder result = new StringBuilder();
            if (listDic.Count > 0)
            {
                string s = "";
                if (listDic[0].TryGetValue("OPListForSpecimenRt", out s))
                {
                    result.Append("{");
                    result.AppendFormat("\"{0}\":\"{1}\"", "OPListForSpecimenRt", s);
                    result.Append("}");
                }
                else if (true)
                {
                    result.Append("[");
                    foreach (Dictionary<string, string> item in listDic)
                    {
                        result.Append(ConvertDicToJsonStr(item));
                        result.Append(",");
                    }
                    result.Remove(result.Length - 1, 1).Append("]");
                }
            }
            return result.ToString();
        }
        #endregion

        #region 05.1 将传入的OPListForSpecimen xml字符串信息转换成字段信息字典 +  private Dictionary<string, string> ConvertOPListForSpecimenStrToDic(string oPListForSpecimenStr)
        /// <summary>
        /// 将传入的OPListForSpecimen xml字符串信息转换成字段信息字典，数据传入时已经做了筛选包含OPListForSpecimen节点且有子节点
        /// </summary>
        /// <param name="oPListForSpecimenStr">xml格式的字符串</param>
        /// <returns>字段信息字典</returns>
        private Dictionary<string, string> ConvertOPListForSpecimenStrToDic(string oPListForSpecimenStr)
        {
            //OPListForSpecimen字典
            Dictionary<string, string> oPListForSpecimenDic = new Dictionary<string, string>();
            //将OPListForSpecimen  XML格式的数据转换成XML文档
            XmlDocument oPListForSpecimenXmlDoc = new XmlDocument();
            oPListForSpecimenXmlDoc = HospitalXmlStrHelper.HospitalXmlStrToXmlDoc(oPListForSpecimenStr);
            //能转换成xml文档
            if (oPListForSpecimenXmlDoc != null)
            {
                //获取文档下的OPListForSpecimen下的子节点集合
                XmlNodeList oPListForSpecimenNodeList = oPListForSpecimenXmlDoc.SelectNodes("/OPListForSpecimen/*");
                //有子节点
                if (oPListForSpecimenNodeList.Count > 0)
                {
                    //循环节点
                    foreach (XmlNode item in oPListForSpecimenNodeList)
                    {
                        //字典中不包含当前节点name就加入到节点中
                        if (!oPListForSpecimenDic.Keys.Contains(item.Name))
                        {

                            oPListForSpecimenDic.Add(item.Name, item.InnerText);
                        }
                    }
                }
                //OPListForSpecimen下面没有子节点,获取当前节点的值
                else if (oPListForSpecimenNodeList.Count == 0)
                {
                    try
                    {
                        XmlNode xd = oPListForSpecimenXmlDoc.SelectSingleNode("/OPListForSpecimen");
                        oPListForSpecimenDic.Add(xd.Name, FpJsonHelper.SerializationStr(xd.InnerText));
                    }
                    catch (Exception)
                    {
                        oPListForSpecimenDic.Clear();
                    }
                }
            }
            else
            {
                //xml文档为null
                oPListForSpecimenDic.Clear();
            }
            return oPListForSpecimenDic;
        }
        #endregion
       
        #region  03.1 根据条码号获取医院数据并将数据转换成字典 +   public Dictionary<string, string> GetOPListForSpecimenByBarcodeAndToDic(string barcode)
        /// <summary>
        /// 根据条码号获取医院数据并将数据转换成字典
        /// </summary>
        /// <param name="barcode">条码</param>
        /// <returns>数据字典</returns>
        private Dictionary<string, string> GetOPListForSpecimenByBarcodeAndToDic(string barcode)
        {
            //01.创建字典
            Dictionary<string, string> hospitalDic = new Dictionary<string, string>();
            //02.创建webservice获取数据
            RuRo.BLL.WebService.ForCenterLabService centerLabServiceSoapClient = new RuRo.BLL.WebService.ForCenterLabService();
            try
            {
                //02.1 根据条码号调用GetPatientInfoSpecimen方法获取单个人的数据
                string getDataFromHospitalStr = centerLabServiceSoapClient.GetPatientInfoSpecimen(barcode);
               // string getDataFromHospitalStr = GetOPListForSpecimenByLocalBracodeFileToJsonStr();//调用本地数据
                if (getDataFromHospitalStr != null && getDataFromHospitalStr != "")//有数据并且不为null
                {
                    //03.将数据转换成xml数据有数据并且能转换成xml文档
                    XmlDocument getDataFromHospitalXml = new XmlDocument();
                    //转换失败时返回null
                    getDataFromHospitalXml = HospitalXmlStrHelper.HospitalXmlStrToXmlDoc(getDataFromHospitalStr);
                    //转换成功
                    if (getDataFromHospitalXml != null)
                    {
                        //有子元素
                        if (getDataFromHospitalXml.HasChildNodes)
                        {
                            ////获取OPListForSpecimen下的所有子节点
                            //XmlNodeList xmlnodelist = getDataFromHospitalXml.SelectNodes("/OPListForSpecimen/*");
                            ////有子节点返回节点数据
                            //if (xmlnodelist.Count > 0)
                            //{
                            hospitalDic = ConvertOPListForSpecimenStrToDic(getDataFromHospitalStr);
                            //}
                        }
                    }
                }
                else //没数据返回
                {
                    hospitalDic.Clear();
                }
            }
            catch (Exception ex)
            {
                hospitalDic.Clear();
            }
            return hospitalDic;
        }
        #endregion

        #region 04.1 根据日期查询数据 + private List<Dictionary<string, string>> GetOPInfoListForSpecimenByTimeRangeAndToDicList(string dateBegin, string dateEnd)
        //根据日期和调用webservice查询数据
        /// <summary>
        /// 根据日期和调用webservice查询数据
        /// </summary>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <returns>OPInfoListForSpecimen数据字典集合</returns>
        private List<Dictionary<string, string>> GetOPInfoListForSpecimenByTimeRangeAndToDicList(string dateBegin, string dateEnd)
        {
            //创建病人字典集合。
            List<Dictionary<string, string>> oPListForSpecimensDicList = new List<Dictionary<string, string>>();

            RuRo.BLL.WebService.ForCenterLabService centerLabServiceSoapClient = new RuRo.BLL.WebService.ForCenterLabService();

            try
            {
                string oPInfoListForSpecimenStr = centerLabServiceSoapClient.GetOPInfoListForSpecimen(dateBegin, dateEnd);
                if (oPInfoListForSpecimenStr != null && oPInfoListForSpecimenStr != "")//有数据并且不为null
                {
                    //02.将数据转换成xml数据
                    XmlDocument getDataFromHospitalXml = HospitalXmlStrHelper.HospitalXmlStrToXmlDoc(oPInfoListForSpecimenStr);
                    if (getDataFromHospitalXml != null)//有数据并且能转换成xml文档
                    {
                        if (getDataFromHospitalXml.HasChildNodes)
                        {
                            XmlNode xmlNode = getDataFromHospitalXml.SelectSingleNode("/OPListForSpecimenRt/ResultCode");
                            //创建临时集合保存多个人的数据
                            Dictionary<string, string> oPListForSpecimenTempDic = new Dictionary<string, string>();
                            if (xmlNode.InnerText == "0") //获取数据成功
                            {
                                //OPListForSpecimens/OPListForSpecimen
                                XmlNodeList xmlNodeList = getDataFromHospitalXml.SelectNodes("//OPListForSpecimens/*");
                                foreach (XmlNode item in xmlNodeList)
                                {
                                    string tempOPListForSpecimenXml = item.OuterXml;
                                    oPListForSpecimenTempDic = ConvertOPListForSpecimenStrToDic(tempOPListForSpecimenXml);
                                    oPListForSpecimensDicList.Add(oPListForSpecimenTempDic);
                                }
                            }
                            else if (xmlNode.InnerText == "-1")
                            //获取数据失败
                            {
                                oPListForSpecimenTempDic.Clear();
                                oPListForSpecimenTempDic.Add("OPListForSpecimenRt", FpJsonHelper.SerializationStr(getDataFromHospitalXml.SelectSingleNode("/OPListForSpecimenRt/ResultContent").InnerText));
                                oPListForSpecimensDicList.Add(oPListForSpecimenTempDic);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                oPListForSpecimensDicList.Clear();
            }
            return oPListForSpecimensDicList;
        }
        #endregion

        #region UI层调用--根据条码获取数据
        /// <summary>
        /// 使用条码获取数据，可能返回OPListForSpecimen单个字符串、正常数据、“”；
        /// </summary>
        /// <param name="barcode">条码</param>
        /// <returns>Json格式的字符串（包含有隐藏域文件）</returns>
        public string GetDataByBarcode(string barcode)
        {
            //01.创建字典
            Dictionary<string, string> oPListForSpecimen = new Dictionary<string, string>();
            //02.调用方法获取数据并将数据转换成字典
            oPListForSpecimen = GetOPListForSpecimenByBarcodeAndToDic(barcode);
            string result = "";
            if (oPListForSpecimen != null)//链接无错误
            {
                if (oPListForSpecimen.Count > 0)//有获取到数据
                {
                    //03.调用方法将字典转换成JSON数据
                    if (oPListForSpecimen.Keys.Contains("OPListForSpecimen"))
                    {
                        string value = "";
                        if (oPListForSpecimen.TryGetValue("OPListForSpecimen", out value))
                        {
                            result = "{\"OPListForSpecimen:\":\"" + value + "\"}";
                        }
                    }
                    else if (oPListForSpecimen.Count > 1)
                    {
                       // result = ConvertDicToJsonStr(oPListForSpecimen);
                        result = FpJsonHelper.DictionaryToJsonString(oPListForSpecimen);
                    }
                }
            }
            return result;
        }
        #endregion


        public string GetDataByDateTime(string dateBegin, string dateEnd)
        {
            string result = "";
            List<Dictionary<string, string>> listDic = new List<Dictionary<string, string>>();
            listDic = GetOPInfoListForSpecimenByTimeRangeAndToDicList(dateBegin, dateEnd);
            if (listDic.Count > 0)
            {
                //result = ConvertDicListToJsonStr(listDic);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(listDic);
            }
            return result;
        }
    }
}
