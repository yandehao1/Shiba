//基础代码由科发EasyUi代码生成器v3.5(build 20140519)代码生成器生成,免费版自动增加版权注释,请保留版权信息，尊重作者劳动成果，如您有更好的建议请发至邮箱：843330160@qq.com
using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.Text;
namespace RuRo.Web
{
    public class Info_handler : IHttpHandler
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
                        QueryData(context,false);
                        break;
                    case "exp":/*导出*/
                        QueryData(context,true);
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
            result rlt = new result(); 
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
            string code = context.Request["getcode"].ToString();
            string StrCodeType = context.Request["selectType"].ToString();
            BLL.Info_BLL bll = new BLL.Info_BLL();
            if (StrCodeType == "zhuyuan")
            {
                mes = bll.GetZhuYuanData(code);
                context.Response.Write(mes);
            }
            if (StrCodeType == "kahao")
            {
                mes = bll.GetMenZhenData(code);
                context.Response.Write(mes);
            }
            #region 根据下拉列表编码设置datagrid显示值
            for (int i = 0; i < m_dtTable.Rows.Count; i++)
            {
            }

            #endregion 

        }
        /// <summary>
        /// FusionChart统计图格式化字符串
        /// </summary>
        /// <param name="context"></param>
        private static void ChartData(HttpContext context)
        {
            //统计图dome代码==========================Begin
            //统计图请根据实际业务情况，改造SQL统计实现真实数据显示
            //string swf = "Column3D";
            //if (context.Request["swf"] != null)
            //    swf = context.Request["swf"];
            //StringBuilder xmlData = new StringBuilder();
            //xmlData.Append("<chart caption='IT行业年均收入' subCaption='2014年' xAxisName='城市' yAxisName='收入' showValues='0' formatNumberScale='0' showBorder='1'  logoURL='/images/login_banquan.gif'  logoPosition='BR' logoAlpha='20'>");
            //xmlData.Append("<set label='成都' value='5120' />");
            //xmlData.Append("<set label='上海' value='9800' />");
            //xmlData.Append("<set label='北京' value='9800' />");
            //xmlData.Append("<set label='天津' value='6300' />");
            //xmlData.Append("<set label='广州' value='10080' />");
            //xmlData.Append("</chart>");
            //string ChartHtml = FusionCharts.RenderChartHTML("../js/FusionCharts/" + swf + ".swf","", xmlData.ToString(), "myChart", "600", "350", false);
            //result rlt = new result();
            //rlt.success = true;
            //rlt.msg = ChartHtml;
            //context.Response.Write(JSONHelper.Convert2Json(rlt));
            //统计图dome代码==========================End



            string swf = "Column3D";
            if (context.Request["swf"] != null)
                swf = context.Request["swf"];
            string strSql = @"select 字段名,count(*) records from info group by 字段名";
            DataTable dt = new DataTable();
            //DbHelper.GetTable(strSql, ref dt);

            StringBuilder xmlData = new StringBuilder();
            xmlData.AppendFormat(@"<chart caption='{0}' 
                                    subCaption='{1}' 
                                    xAxisName='{2}' 
                                    yAxisName='{3}' 
                                    showValues='0' 
                                    formatNumberScale='0' 
                                    showBorder='1'  
                                    logoURL='/images/login_banquan.gif'  
                                    logoPosition='BR' 
                                    logoAlpha='20'>",
                                    "统计图","统计图副标题","X坐标标题","数量");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                xmlData.AppendFormat("<set label='{0}' value='{1}' />",dt.Rows[i]["字段名"],dt.Rows[i]["records"]);  
            }
            //xmlData.Append("</chart>");
            //string ChartHtml = FusionCharts.RenderChartHTML("../js/FusionCharts/" + swf + ".swf","", xmlData.ToString(), "myChart", "600", "350", false);
            //result rlt = new result();
            //rlt.success = true;
            //rlt.msg = ChartHtml;
            //context.Response.Write(JSONHelper.Convert2Json(rlt));

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

