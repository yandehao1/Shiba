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
                    case "exp":/*导出*/
                        QueryData(context, true);
                        break;
                }
            }
            else
                QueryData(context, false);
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
            //result rlt = new result();
            //try
            //{
            //    //获取保存方式
            //    string mode = context.Request["mode"].ToString();
            //    int strPk = 0;
            //    if (mode == "upd")
            //    {
            //        strPk = int.Parse(context.Request["pk"].ToString());
            //    }
            //    BLL.Info_BLL bll_Info = new BLL.Info_BLL();
            //    Model.Info model_Info = new Model.Info(); 
            //    #region 实体类赋值
            //    if (mode == "ins")
            //    {
            //        //编码表采用Max获取，请注意设置字段长度
            //        model_Info._id = bll_Info.GetMax_id();//主键赋值
            //    }

            //    if(context.Request["部门"]!=null)
            //        model_Info._部门 = context.Request["部门"];

            //    if(context.Request["姓名"]!=null)
            //        model_Info._姓名 = context.Request["姓名"];

            //    if(context.Request["性别"]!=null)
            //        model_Info._性别 = context.Request["性别"];

            //    if(context.Request["年龄"]!=null)
            //        model_Info._年龄 = context.Request["年龄"];

            //    if(context.Request["医生"]!=null)
            //        model_Info._医生 = context.Request["医生"];

            //    if(context.Request["流水号"]!=null)
            //        model_Info._流水号 = context.Request["流水号"];

            //    if(context.Request["卡号"]!=null)
            //        model_Info._卡号 = context.Request["卡号"];

            //    if(context.Request["住院号"]!=null)
            //        model_Info._住院号 = context.Request["住院号"];

            //    if(context.Request["病历号"]!=null)
            //        model_Info._病历号 = context.Request["病历号"];

            //    if(context.Request["诊断"]!=null)
            //        model_Info._诊断 = context.Request["诊断"];

            //    if(context.Request["日期"]!=null)
            //        model_Info._日期 = context.Request["日期"];

            //    #endregion
            //    if (mode == "ins")
            //    {
            //        if (bll_Info.Insert(model_Info))
            //        {
            //            rlt.success = true;
            //            rlt.msg = "新增保存成功";
            //        }
            //        else
            //        {
            //            rlt.success = false;
            //            rlt.msg = "新增保存失败:" + DbError.getErrorMsg();
            //        }
            //    }

            //    if (mode == "upd")
            //    {
            //        if (bll_Info.Update(model_Info, strPk))
            //        {
            //            rlt.success = true;
            //            rlt.msg = "修改保存成功";
            //        }
            //        else
            //        {
            //            rlt.success = false;
            //            rlt.msg = "修改保存失败:" + DbError.getErrorMsg();
            //        }
            //    }
            //}
            //catch(Exception exception)
            //{
            //    rlt.success = false;
            //    rlt.msg = exception.Message;
            //}
            // context.Response.Write(JSONHelper.Convert2Json(rlt)); 
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
                //mes = bll.GetZhuYuanData(code);//正式获取
                mes = bll.GetZhuYuanTest(code);//测试
                context.Response.Write(mes);
            }
            if (StrCodeType == "kahao")
            {
                //mes = bll.GetMenZhenData(code);//正式获取
                mes = bll.GetmenzhenTest(code);//测试
                context.Response.Write(mes);
            }
            //获取测试数据

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