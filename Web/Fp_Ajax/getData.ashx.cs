using RuRo.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RuRo.Web.Fp_Ajax
{
    /// <summary>
    /// getData 的摘要说明
    /// </summary>
    public class getData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["mode"] != null)
            {
                string mode = context.Request["mode"].ToString();
                switch (mode)
                {
                    case "inf":/*查询实体类*/
                        InfoData(context);
                        break;
                    case "ins":/*新增*/
                        SaveData(context);
                        break;
                    case "upd":/*修改*/
                        SaveData(context);
                        break;
                    case "del":/*删除*/
                        DeleteData(context);
                        break;
                    case "qrycode":/*查询*/
                        QueryData(context, false);
                        break;
                    case "qryname":/*姓名查询*/
                        QueryNameData(context, false);
                        break;
                    case "exp":/*导出*/
                        QueryData(context, true);
                        break;
                }
            }
            else
                QueryData(context, false);
        }
        /// <summary>
        /// 姓名查询方式
        /// </summary>
        /// <param name="context"></param>
        /// <param name="p"></param>
        private void QueryNameData(HttpContext context, bool p)
        {
            string mes = "";
            //string strName = HttpUtility.UrlDecode(context.Request["getname"].ToString());
            string strName = context.Request["getname"].ToString();
            string StrType = context.Request["nametype"].ToString();
            string Strksrq = context.Request["ksdate"].ToString();
            string Strjsrq = context.Request["jsdate"].ToString();
            BLL.Info_BLL bll = new BLL.Info_BLL();
            if (StrType=="kahao")
            {
                mes = bll.GetMenZhenDataForName(strName, Strksrq, Strjsrq);//正式获取
                context.Response.Write(mes);
            }
            else if (StrType=="zhuyuan")
            {
                mes = bll.GetZhuYuanDataForName(strName);//正式获取
                context.Response.Write(mes);
            }
        }

        /// <summary>
        /// 查询info数据实体类
        /// </summary>
        /// <param name="context"></param>
        private static void InfoData(HttpContext context)
        {
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="context"></param>
        private static void SaveData(HttpContext context)
        {
            result rlt = new result();
            try
            {
                string ssType = string.Empty,
                       ssName = string.Empty,
                       ssDecription = string.Empty;
                //获取保存方式
                BLL.Info_BLL bll_Info = new BLL.Info_BLL();
                Model.Info model_Info = new Model.Info();
                #region 实体类赋值
                if (context.Request["部门"] != null)
                    model_Info.部门 = context.Request["部门"];

                if (context.Request["姓名"] != null)
                    model_Info.姓名 = context.Request["姓名"];

                if (context.Request["性别"] != null)
                    model_Info.性别 = context.Request["性别"];

                if (context.Request["年龄"] != null)
                    model_Info.年龄 = context.Request["年龄"];

                if (context.Request["医生"] != null)
                    model_Info.医生 = context.Request["医生"];

                if (context.Request["流水号"] != null)
                    model_Info.流水号 = context.Request["流水号"];

                if (context.Request["卡号"] != null)
                    model_Info.卡号 = context.Request["卡号"];

                if (context.Request["住院号"] != null)
                    model_Info.住院号 = context.Request["PATIENT_NO"];

                if (context.Request["病历号"] != null)
                    model_Info.病历号 = context.Request["病历号"];

                if (context.Request["诊断"] != null)
                    model_Info.诊断 = context.Request["诊断"];

                if (context.Request["日期"] != null)
                    model_Info.日期 = context.Request["日期"];

                #endregion
                //数据转换
                if (context.Request["ssType"] != null)
                    ssType = context.Request["ssType"];
                if (context.Request["pId"] != null)
                    ssName = context.Request["pId"];
                if (context.Request["ssType"] != null)
                    ssDecription = context.Request["姓名"];
                //数据匹配
                BLL.ImpSampleSource imp = new BLL.ImpSampleSource();
                string result = imp.Import(model_Info, ssType, ssName, ssDecription);
                context.Response.Write(result);

            }
            catch (Exception exception)
            {
                rlt.success = false;
                rlt.msg = exception.Message;
                context.Response.Write(JSONHelper.Convert2Json(rlt));
            }

        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="context"></param>
        private static void DeleteData(HttpContext context)
        {
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="context"></param>
        /// <param name="export">是否导出Excel文件</param>
        private static void QueryData(HttpContext context, bool export)
        {
            string mes = "";
            string code = context.Request["getcode"].ToString();
            string StrCodeType = context.Request["type"].ToString();
            BLL.Info_BLL bll = new BLL.Info_BLL();
            //获取正式数据
            if (StrCodeType == "zhuyuan")
            {
                mes = bll.GetZhuYuanData(code);//正式获取
                // mes = bll.GetZhuYuanTest(code);//测试
                context.Response.Write(mes);
            }
            if (StrCodeType == "kahao")
            {
                mes = bll.GetMenZhenData(code);//正式获取
                //mes = bll.GetmenzhenTest(code);//测试
                context.Response.Write(mes);
            }
        }
        #region JSON实体返回类定义
        /// <summary>
        /// 实体Ajax返回类
        /// </summary>
        public class result
        {
            bool _success = false;
            string _msg = "";
            public bool success
            {
                set { _success = value; }
                get { return _success; }
            }
            public string msg
            {
                set { _msg = value; }
                get { return _msg; }
            }
        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}