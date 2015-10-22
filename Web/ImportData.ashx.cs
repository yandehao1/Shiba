using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreezerProPlugin
{
    /// <summary>
    /// ImportData 的摘要说明
    /// </summary>
    public class ImportData : IHttpHandler
    {

        /// <summary>
        /// 将数据提交到业务层处理
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string sampleSourceTypeName = context.Request["sampleSourceTypeName"];
            string sampleSourceName = context.Request["sampleSourceName"];
            string patientId = context.Request["patientId"];
            string sampleSourceDescription = context.Request["sampleSourceDescription"];
            string hiddenEncodeStr = context.Request["hidden"];//(*前台页面上存储的加密字符串，提交到导入数据时需要解密处理)

            if (sampleSourceTypeName == null || sampleSourceTypeName == null)
            {
                context.Response.Write("{\"result\":\"失败\",\"patientId\":" + "\"" + patientId + "\"}");
                context.Response.End();
            }
            else
            {
                BLL.ImportDataToFp ImportData = new BLL.ImportDataToFp();
                //提交数据到业务层处理并返回处理后的状态
                //StateEnumWithPostDataToFp stateWithPostDataToFp = ImportData.ReceiveDataAndToDic(sampleSourceTypeName, sampleSourceName, patientId, sampleSourceDescription, hiddenEncodeStr);
                string result = ImportData.ImportDataToFpAndRetunFpResult(sampleSourceTypeName, sampleSourceName, patientId, sampleSourceDescription, hiddenEncodeStr);
                if (result!="")
                {
                    if (result=="sampleSourceNameNotExist")
                    {
                        context.Response.Write("{\"success\":\"失败\",\"patientId\":" + "\"" + patientId + "\",\"Reason\":\"样本源类型不存在\"}");
                        context.Response.End();
                    }
                    if (result=="DecodError")
                    {
                        context.Response.Write("{\"success\":\"失败\",\"patientId\":" + "\"" + patientId + "\",\"Reason\":\"导入错误\"}");
                        context.Response.End();
                    }
                    if (FpJsonHelper.GetStrFromJsonStr("status", result) == "DONE")//导入成功
                    {
                        context.Response.Write("{\"success\":\"成功\",\"patientId\":" + "\"" + patientId + "\"}");
                        context.Response.End();
                    }
                    if (FpJsonHelper.GetStrFromJsonStr("status", result) == "ERROR")//导入失败
                    {
                        string reason = FpJsonHelper.GetStrFromJsonStr("message", result);
                        context.Response.Write("{\"success\":\"失败\",\"patientId\":" + "\"" + patientId + "\",\"Reason\":\""+reason+"\"}");
                        context.Response.End();
                    }
                }
                else
                {
                    context.Response.Write("{\"success\":\"失败\",\"patientId\":" + "\"" + patientId + "\",\"Reason\":\"数据错误\"}");
                    context.Response.End();
                }
                context.Response.End();
            }
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