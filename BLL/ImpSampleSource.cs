using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using RuRo.Common;

namespace RuRo.BLL
{
    public class ImpSampleSource
    {
        public string Import(object obj, string sampleSourceTypeName, string ssName, string ssDescription)
        {
            UnameAndPwd up = new UnameAndPwd();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //将前台传入的对象转换成字典
            Dictionary<string, string> dataDic = Common.ObjAndDic.ObjectToDic(obj);
            //获取医院字段匹配字典
            Dictionary<string, string> matchField = GetMatchFieldsXmlToDic("configXML\\MatchFields.xml", "/Matchings/*");
            //过滤字段
            //根据样品源类型过滤字段
            List<string> list = FpUtility.Fp_BLL.SampleSocrce.GetSampleSourceTypeFieldByTypeName(up.GetUp(), sampleSourceTypeName);
            //匹配字段并转换成
            dic = MatchDic(list, dataDic, matchField);
            Dictionary<string, string> nameAndDescDic = new Dictionary<string, string>() { { "Name", ssName }, { "Description", ssDescription } };
            Dictionary<string, string> temDic = new Dictionary<string, string>();
            if (dic != null && dic.Count > 0)
            {
                foreach (var item in dic)
                {
                    if (!nameAndDescDic.ContainsKey(item.Key))
                    {
                        nameAndDescDic.Add(item.Key, item.Value);
                    }
                }
            }
            temDic = nameAndDescDic;

            string result = FpUtility.Fp_BLL.SampleSocrce.ImportSampleSourceDataToFp(up.GetUp(), sampleSourceTypeName, temDic);
            return result;
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

        private Dictionary<string, string> MatchDic(List<string> list, Dictionary<string, string> datadic, Dictionary<string, string> matchDic)
        {
            Dictionary<string, string> resDic = new Dictionary<string, string>();
            //循环样品源类型字典
            foreach (var item in list)
            {
                //匹配字典中包含这个中文字段
                //"姓名"："Name"
                if (matchDic.ContainsKey(item))
                {
                    //获取当前value的键值对 matchDic ==> "唯一标识号:PatientId"
                    KeyValuePair<string, string> k = matchDic.Where(a => a.Key == item).FirstOrDefault();

                    //datadic ==>"PatientId：0000000"
                    if (datadic.ContainsKey(k.Value))
                    {
                        //dataDic==> "唯一标识号 :0000000"
                        if (resDic.ContainsKey(item))
                        {
                            if (!string.IsNullOrEmpty(datadic[k.Value]) && string.IsNullOrEmpty(resDic[item]))
                            {
                                resDic[item] = datadic[k.Value];
                            }
                        }
                        else
                        {
                            resDic.Add(item, datadic[k.Value]);
                        }
                    }
                }
            }
            return resDic;
        }

    }
}
