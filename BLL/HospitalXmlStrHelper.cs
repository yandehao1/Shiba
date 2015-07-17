using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace BLL
{
    public  class HospitalXmlStrHelper
    {
        #region 将根据条码获取数据的webservice获取到的数据转换成xml文档 +  public static XmlDocument HospitalXmlStrToXmlDoc(string xmlStr)
        /// <summary>
        /// 将xml数据转换成xml文档(webservice获取的数据需要添加一个xml头文件,有根节点的数据加上头也可以转换成xml文档)，转换失败是返回null
        /// </summary>
        /// <param name="xmlStr">获取的xml格式的字符串</param>
        /// <returns>xml文档，转换失败是返回null</returns>
        public static XmlDocument HospitalXmlStrToXmlDoc(string xmlStr)
        {
            XmlDocument xmlHospitalDt = new XmlDocument();
            StringBuilder strXml = new StringBuilder();
            try
            {
                string xmlHead = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
                xmlHospitalDt.LoadXml(xmlHead + xmlStr);
            }
            catch (Exception ex) { xmlHospitalDt = null; }
            return xmlHospitalDt;
        } 
        #endregion

        #region 加载本地的xml文件创建新的xml文件（此文件里面获取的）+  public static string HospitalXmlFileToXmlDoc()
        /// <summary>
        /// 加载本地的xml文件创建新的xml文件（此文件里面获取的）
        /// </summary>
        /// <returns>OPListForSpecimen节点下的数据</returns>
        public static string HospitalXmlFileToXmlStr(string path)
        {
            XmlDocument xd = Common.XmlHelper.XMLLoad(path);
            //string xn = xd.SelectSingleNode("/OPListForSpecimen").InnerText;//有问题，未将对象应用到实例
            string xn = xd.InnerText;
            //StringBuilder xmlStr = new StringBuilder();
            //xmlStr.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            //xmlStr.Append(xn);
            //xd.RemoveAll();
            //xd.LoadXml(xmlStr.ToString());
            //return xd;

            return xn;
        } 
        #endregion
    }
}
