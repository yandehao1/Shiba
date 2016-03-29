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
            #region 获取Jquery回传Server分页页码和每页行数
            //int page,rows;
            //if (context.Request["page"] != null)
            //   page = int.Parse(context.Request["page"]);
            //else
            //   page = 1; 
            //if (context.Request["rows"]!= null)
            //    rows = int.Parse(context.Request["rows"]);
            //else
            //    rows = 10;
            #endregion

            #region 获取Jquery回传查询条件参数
            //string strWhere = " 1=1 ";
            //if (context.Request["so_keywords"] != null)
            //{
            //    string strKeywords = context.Request["so_keywords"];
            //    if (strKeywords.Length > 0)
            //    {
            //        strWhere += " and (";
            //        strWhere += " id like '%" + strKeywords + "%'";
            //        strWhere += " or 部门 like '%" + strKeywords + "%'";
            //        strWhere += " or 姓名 like '%" + strKeywords + "%'";
            //        strWhere += " or 性别 like '%" + strKeywords + "%'";
            //        strWhere += " or 年龄 like '%" + strKeywords + "%'";
            //        strWhere += ")";
            //    }
            //}
            #endregion

            #region 字段排序
            //string sort = "id";
            //string order = "asc";
            //if (context.Request["sort"] != null)
            //    sort = context.Request["sort"];
            //if (context.Request["order"] != null)
            //    order = context.Request["order"];
            #endregion

            #region 分页数据
            DataTable m_dtTable = new DataTable();
            // PageAction pageAction = new PageAction();
            //pageAction.CurPage = page;
            //pageAction.PageSize = rows;
            //pageAction.TabName = "Info";
            //pageAction.Fields = "*";
            //pageAction.PkField = "id";
            //pageAction.Condition = strWhere;
            //pageAction.Sort = sort + " " + order;
            // DbHelper.FillDataTable(pageAction, m_dtTable); 
            #endregion
            string mes = "";
            string code = context.Request["code"].ToString();
            string StrCodeType = context.Request["type"].ToString();
            BLL.Info_BLL bll = new BLL.Info_BLL();
            //获取正式数据
            if (StrCodeType == "zhuyuan")
            {
                //mes = bll.GetZhuYuanData(code);//正式获取
                mes = bll.GetZhuYuanData(code);//测试
                context.Response.Write(mes);
            }
            if (StrCodeType == "kahao")
            {
                //mes = bll.GetMenZhenData(code);//正式获取
                mes = bll.GetmenzhenTest(code);//测试
                context.Response.Write(mes);
            }
            //获取测试数据

            #region 根据下拉列表编码设置datagrid显示值
            for (int i = 0; i < m_dtTable.Rows.Count; i++)
            {
            }

            #endregion

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