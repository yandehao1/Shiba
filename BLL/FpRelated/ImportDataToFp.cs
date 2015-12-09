using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Common;
using System.IO;
using RuRo.Common;

namespace BLL
{
    public class ImportDataToFp
    {
        SampleSocrce sampleSouce = new SampleSocrce();

        #region 01.读取从医院获取到的数据到字典

        //读取用条码获取的xml文件
        /// <summary>
        /// 读取从医院获取到的数据到字典
        /// </summary>
        /// <param name="xmlPath">文件路径或者文件流</param>
        /// <param name="xPath">文档中的位置</param>
        /// <returns></returns>
        private Dictionary<string, string> GetPatientInfoSpecimenResponseXmlToDic(string xmlPath, string xPath)
        {
            Dictionary<string, string> hospitalDic = new Dictionary<string, string>();//创建医院数据字典
            try
            {
                //XmlDocument xmlHospitalDt = XmlHelper.XMLLoad(xmlPath);//加载xml数据
                //string str = xmlHospitalDt.InnerText;//读取数据
                //xmlHospitalDt.LoadXml(str);//重新组装XML数据
                XmlDocument xmlHospitalDt = HospitalXmlStrHelper.HospitalXmlStrToXmlDoc(xmlPath);
                if (xmlHospitalDt != null)
                {
                    if (xmlHospitalDt.HasChildNodes)
                    {
                        XmlNodeList xmlnodelist = xmlHospitalDt.SelectNodes(xPath);
                        if (xmlnodelist.Count > 0)
                        {
                            foreach (XmlNode item in xmlnodelist)
                            {
                                if (!hospitalDic.Keys.Contains(item.Name))
                                {
                                    hospitalDic.Add(item.Name, item.InnerText == "" ? "" : item.InnerText);
                                }
                            }
                        }
                    }
                }
                return hospitalDic;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 获取字段匹配文件中的数据到字典

        /// <summary>
        /// 获取字段匹配文件中的数据到字典
        /// </summary>
        /// <param name="xmlPath">路径</param>
        /// <param name="xPath">（默认是："/Matchings/*）</param>
        /// <returns>匹配好的字典</returns>
        private Dictionary<string, string> GetMatchFieldsXmlToDic(string xmlPath, string xPath)
        {
            Dictionary<string, string> MatchFieldDic = new Dictionary<string, string>();//创建医院数据字典
            try
            {
                XmlDocument xmlMatchFieldDc = XmlHelper.XMLLoad(xmlPath);//读取xml文件
                if (xmlMatchFieldDc.HasChildNodes)//判断是否包含节点
                {
                    XmlNodeList xmlnodelist = xmlMatchFieldDc.SelectNodes(xPath);//获取指定节点
                    if (xmlnodelist.Count > 0)
                    {
                        foreach (XmlNode item in xmlnodelist)
                        {
                            string KeyFieldName = item.SelectSingleNode("./KeyFieldName").InnerText;
                            string ValueFieldName = item.SelectSingleNode("./ValueFieldName").InnerText;
                            if (!MatchFieldDic.Keys.Contains(KeyFieldName))
                            {
                                MatchFieldDic.Add(KeyFieldName, ValueFieldName);
                            }
                        }
                    }
                }
                return MatchFieldDic;
            }
            catch (Exception ex) { return MatchFieldDic; }
        }
        #endregion

        #region *** 不用的--思路参考---UI层提交过来的数据，需要处理此数据并返回处理后的状态
        /// <summary>
        /// UI层提交过来的数据，需要处理此数据并返回处理后的状态
        /// </summary>
        /// <param name="sampleSourceTypeName">选择的样本源类型</param>
        /// <param name="sampleSourceName">修改后的样本源名称</param>
        /// <param name="patientId">病人唯一标识</param>
        /// <param name="sampleSourceDescription">修改后的样本源描述</param>
        /// <param name="hiddenXml">提交回来的隐藏XML格式的文件</param>
        /// <returns></returns>
        public Common.StateEnumWithPostDataToFp ImportSampleSource(string sampleSourceTypeName, string sampleSourceName, string patientId, string sampleSourceDescription, string hiddenEncodeStr)
        {
            //01.根据样本源类型获取字段集合(得到字段列表)
            SampleSocrce sampleSource = new SampleSocrce();
            List<string> sampleSourceTypeField = sampleSource.GetSampleSourceTypeFieldByTypeName(sampleSourceTypeName);
            //02.获取字段匹配字典（得到配置文件中的字段匹配列表）
            Dictionary<string, string> matchField = GetMatchFieldsXmlToDic("configXML\\MatchFields.xml", "/Matchings/*");
            //03.根据用户字段和字段匹配字典生成用户自定义区域字段字典(得到字段列表对应的字段与医院数据匹配字段的字典)
            Dictionary<string, string> sampleSourceFieldsDic = new Dictionary<string, string>();
            foreach (string item in sampleSourceTypeField)
            {
                //样本源下的字段在字段匹配表中有对应的key--value
                if (matchField.Keys.Contains(item))
                {
                    //新匹配生成的字典中不包含item key就将item加入到字典中
                    if (!sampleSourceFieldsDic.Keys.Contains(item))
                    {
                        sampleSourceFieldsDic.Add(item, matchField[item]);
                    }
                }
            }

            //04.获取医院数据字典
            Dictionary<string, string> hospitalDic = new Dictionary<string, string>();
            //创建数据层对象获取数据
            GetDataFromHospital hospital = new GetDataFromHospital();
            //hospitalDic = hospital.GetOPListForSpecimenByBarcodeAndToDic(hiddenEncodeStr);

            Dictionary<string, string> sampleSourceDic = new Dictionary<string, string>();
            //循环样本源字段字典匹配医院字典中的数据
            foreach (KeyValuePair<string, string> keyValue in sampleSourceFieldsDic)
            {
                if (!sampleSourceDic.Keys.Contains(keyValue.Key))
                {
                    if (hospitalDic.Keys.Contains(keyValue.Value))
                    {
                        sampleSourceDic.Add(keyValue.Key, hospitalDic[keyValue.Value]);
                    }
                }
            }
            //05.将样本源名称和描述加入字典
            sampleSourceDic.Add("Name", sampleSourceName);
            sampleSourceDic.Add("Description", sampleSourceName);

            // //06.序列化用户自定义区域字段字典
            // StringBuilder jsonStr = new StringBuilder();
            // jsonStr.Append("{");
            // foreach (KeyValuePair<string,string> item in sampleSourceDic)
            // {
            //     jsonStr.AppendFormat("\"{0}\":\"{1}\",", item.Key, item.Value == "" ? "" : item.Value);
            // }
            //string jsonstr= jsonStr.ToString().TrimEnd(',') + "}";
            //07.调用数据层提交数据

            //string str = sampleSource.ImportSampleSourceDataToFp("&sample_source_type=" + sampleSourceTypeName + "&json=" + jsonstr);

            #region test
            string result = sampleSource.ImportSampleSourceDataToFp(sampleSourceTypeName, sampleSourceDic);

            #endregion
            //08.将处理后的结果返回，并将处理后的状态返回个UI
            if (true)
            {
                return StateEnumWithPostDataToFp.成功;
            }
        }
        #endregion


        #region 提交数据到FP并返回FP处理的结果 + public string ImportDataToFpAndRetunFpResult(string sampleSourceTypeName, string sampleSourceName, string patientId, string sampleSourceDescription, string hiddenEncodeStr)
        /// <summary>
        /// 提交数据到FP并返回FP处理的结果
        /// </summary>
        /// <param name="sampleSourceTypeName">样本源类型名称</param>
        /// <param name="sampleSourceName">样本源名称</param>
        /// <param name="patientId">样本源唯一标识</param>
        /// <param name="sampleSourceDescription">样本源描述</param>
        /// <param name="hiddenEncodeStr">隐藏域中的加密字段</param>
        /// <returns></returns>
        public string ImportDataToFpAndRetunFpResult(string sampleSourceTypeName, string sampleSourceName, string patientId, string sampleSourceDescription, string hiddenEncodeStr)
        {
            Dictionary<string, string> sampleSourceNameAndDesDic = sampleSouce.GetSampleSourceTypeNameAndDecToDic();
            if (sampleSourceNameAndDesDic.Keys.Contains(sampleSourceTypeName))//系统中有此样本源
            {
                //01.接受前台页面发送回来的数据，并将数据转换成字典
                Dictionary<string, string> oPListForSpecimenDic = new Dictionary<string, string>();
                oPListForSpecimenDic = DecodeHiddenEncodeStr(hiddenEncodeStr);
                if (oPListForSpecimenDic.Count > 0)//解码成功（）
                {
                    //02.获取用户自定义字段集合（根据指定的样本源类型名称）
                    //03.获取配置文件中的字段匹配字典
                    //04.根据用户自定义字段字典和字段匹配字典生成需要导入到Fp中的字段字典
                    Dictionary<string, string> sampleSourceFieldsDic = new Dictionary<string, string>();
                    sampleSourceFieldsDic = MathcSampleSourceFieldsWithConfigFile(sampleSourceTypeName, sampleSourceName, sampleSourceDescription, oPListForSpecimenDic);
                    //06.调用API提交数据到Fp
                    string result = sampleSouce.ImportSampleSourceDataToFp(sampleSourceTypeName, sampleSourceFieldsDic);
                    return result;
                }
                else
                {
                    //解析前台页面中的隐藏数据失败(隐藏域数据解析错误？-->加密出错？？-->数据来源错误？)
                    return "DecodError";
                }
            }
            else
            {
                //样本源类型不存在
                return "sampleSourceNameNotExist";
            }

        }
        #endregion
        #region 将页面传回的隐藏域中的数据解码并转换成字典 +  private Dictionary<string, string> DecodeHiddenEncodeStr(string hiddenEncodeStr)
        /// <summary>
        /// 将页面传回的隐藏域中的数据解码并转换成字典
        /// </summary>
        /// <param name="hiddenEncodeStr">被加密的数据</param>
        /// <returns>字典</returns>
        private Dictionary<string, string> DecodeHiddenEncodeStr(string hiddenEncodeStr)
        {
            //创建从前台页面提交回来的数据
            Dictionary<string, string> oPListForSpecimenDic = new Dictionary<string, string>();
            string hiddenDecodeStr = Common.EncodeAndDecodeString.Decode(hiddenEncodeStr);
            if (hiddenDecodeStr != "")
            {
                oPListForSpecimenDic = Common.FpJsonHelper.JsonStrToDictionary<string, string>(hiddenDecodeStr);
            }
            return oPListForSpecimenDic;
        }
        #endregion
        #region 当前样本元类型下的用户自定义字段和医院字段的匹配字典 +  private Dictionary<string, string> MathcSampleSourceFieldsWithConfigFile(string sampleSourceTypeName, string sampleSourceName, string sampleSourceDescription, Dictionary<string, string> oPListForSpecimenDic)
        /// <summary>
        /// 根据样本元类型名称和配置文件以及医院数据生成最终的样本源字段名称和数据的字典
        /// </summary>
        /// <param name="sampleSourceTypeName">样本源类型名称</param>
        /// <param name="sampleSourceName">样本源Name</param>
        /// <param name="sampleSourceDescription">样本源Description</param>
        /// <param name="oPListForSpecimenDic">医院数据</param>
        /// <returns>最终生成的的样本源字段名称和数据的字典</returns>
        private Dictionary<string, string> MathcSampleSourceFieldsWithConfigFile(string sampleSourceTypeName, string sampleSourceName, string sampleSourceDescription, Dictionary<string, string> oPListForSpecimenDic)
        {
            //resultDic是提取当前样本源类型下面的所有字段字典
            Dictionary<string, string> resultDic = new Dictionary<string, string>();
            resultDic.Add("Name", sampleSourceName);
            resultDic.Add("Description", sampleSourceDescription);
            //获取用户自定义字段集合（根据指定的样本源类型名称）
            List<string> sampleSourceFieldsList = new List<string>();
            sampleSourceFieldsList = sampleSouce.GetSampleSourceTypeFieldByTypeName(sampleSourceTypeName);

            //获取配置文件中的字段匹配字典
            Dictionary<string, string> matchFieldsDic = new Dictionary<string, string>();
            matchFieldsDic = GetMatchFieldsXmlToDic("configXML\\MatchFields.xml", "/Matchings/*");

            //循环遍历样本源自定义字段
            foreach (string item in sampleSourceFieldsList)
            {
                //检查配置文件中是否包含用户自定义字段
                if (matchFieldsDic.Keys.Contains(item))
                {
                    //确保当前字段在最终的自定字段名和value中不存在（防止重key）
                    if (!resultDic.Keys.Contains(item))
                    {
                        ////如：key:唯一标识号,value:PatientId
                        //resultDic.Add(item, matchFieldsDic[item]);
                        //医院数据中包含当前用户自定义字段对应的字段
                        if (oPListForSpecimenDic.Keys.Contains(matchFieldsDic[item]))
                        {
                            if (!string.IsNullOrEmpty(oPListForSpecimenDic[matchFieldsDic[item]]))
                            {
                                string key = matchFieldsDic[item];
                                string value = oPListForSpecimenDic[matchFieldsDic[item]];
                                if (item =="出生日期")
                                {
                                    resultDic.Add(item, value.Replace("-","."));
                                    continue;
                                }
                                if (item == "现病史")
                                {
                                    if (value.Length>2048)
                                    {
                                        resultDic.Add(item, value.Trim().Remove(0, 2048));
                                        continue;
                                    }
                                    else
                                    {
                                        resultDic.Add(item, value.Trim());
                                    }
                                }
                                else
                                {
                                    resultDic.Add(item, value.Trim());
                                }
                            }
                        }
                    }
                }
            }
            return resultDic;
        }
        #endregion

        private Dictionary<string, string> AddFile(Dictionary<string, string> dic)
        {
            if (dic.Keys.Contains("出生日期"))
            {
                string date = dic["出生日期"];
                DateTime datetime;
                if (DateTime.TryParse(date, out datetime))
                {
                    string age = (DateTime.Now - datetime).ToString("yyyy.MM.dd");
                    if (!dic.Keys.Contains("年龄"))
                    {
                        dic.Add("年龄", age);
                    }
                }
            }
            return dic;
        }
    }
}
