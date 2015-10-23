using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace RuRo.BLL
{
    public class ImpSampleSource
    {
        public string Import(object obj, string sampleSourceType)
        {
            UnameAndPwd up = new UnameAndPwd();
            //将前台传入的对象转换成字段
            Dictionary<string, string> data = new Dictionary<string, string>();
            //获取医院字段匹配字典
            Dictionary<string, string> matchField = GetMatchFieldsXmlToDic("configXML\\MatchFields.xml", "/Matchings/*");
            //过滤字段
            FreezerProUtility.Fp_BLL.SampleSocrce.ImportSampleSourceDataToFp(up.GetUp(), sampleSourceType, data);
            return "";
        }
        private Dictionary<string, string> GetMatchFieldsXmlToDic(string xmlPath, string xPath)
        {
            Dictionary<string, string> MatchFieldDic = new Dictionary<string, string>();//创建医院数据字典

            XmlDocument xmlMatchFieldDc = XmlHelper.XMLLoad(xmlPath);//读取xml文件
            if (xmlMatchFieldDc != null && xmlMatchFieldDc.HasChildNodes)
            {
                XmlNodeList xmlnodelist = xmlMatchFieldDc.SelectNodes(xPath);//获取指定节点
                try
                {
                    if (xmlnodelist.Count > 0)
                    {
                        foreach (XmlNode item in xmlnodelist)
                        {
                            try
                            {
                                string KeyFieldName = item.SelectSingleNode("./KeyFieldName").InnerText;
                                string ValueFieldName = item.SelectSingleNode("./ValueFieldName").InnerText;
                                if (!MatchFieldDic.Keys.Contains(KeyFieldName))
                                {
                                    MatchFieldDic.Add(KeyFieldName, ValueFieldName);
                                }
                            }
                            catch (Exception ex)
                            {
                                Common.LogHelper.WriteError(ex);
                                continue;
                            }
                        }
                    }
                    return MatchFieldDic;
                }
                catch (Exception ex)
                {
                    Common.LogHelper.WriteError(ex);
                }
            }
            return MatchFieldDic;
        }

    }
}
