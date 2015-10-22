//基础代码由科发EasyUi代码生成器v3.5(build 20140519)代码生成器生成,免费版自动增加版权注释,请保留版权信息，尊重作者劳动成果，如您有更好的建议请发至邮箱：843330160@qq.com
using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using DBUtility;
using System.Collections.Generic;
using System.Text;
namespace RuRo
{
    /// <summary>
    /// HttpHandler处理程序基础代码由科发EasyUi代码生成器v3.5(build 20140519)代码生成器生成,免费版自动增加版权注释,请保留版权信息，尊重作者劳动成果，如您有更好的建议请发至邮箱：843330160@qq.com
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class LabTestResult_handler : IHttpHandler
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
                    case "qry":/*查询*/
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
            BLL.LabTestResult_BLL bll_LabTestResult = new BLL.LabTestResult_BLL();
            Model.LabTestResult model_LabTestResult = new Model.LabTestResult();
            DataTable dt = new DataTable();
            if (context.Request["pk"] != null)
            {
                int pk = int.Parse(context.Request["pk"]);
                model_LabTestResult = bll_LabTestResult.GetModel(pk);
                bll_LabTestResult.GetModel(ref dt, pk);
            }
            string strJson = JSONHelper.DataTable2Json(dt, true);
            context.Response.Write(strJson);
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
                //获取保存方式
                string mode = context.Request["mode"].ToString();
                int strPk = 0;
                if (mode == "upd")
                {
                    strPk = int.Parse(context.Request["pk"].ToString());
                }
                BLL.LabTestResult_BLL bll_LabTestResult = new BLL.LabTestResult_BLL();
                Model.LabTestResult model_LabTestResult = new Model.LabTestResult(); 
                #region 实体类赋值
                if (mode == "ins")
                {
                    //编码表采用Max获取，请注意设置字段长度
                    model_LabTestResult._id = bll_LabTestResult.GetMax_id();//主键赋值
                }

                if(context.Request["reportitemname"]!=null)
                    model_LabTestResult._reportitemname = context.Request["reportitemname"];

                if(context.Request["reportitemcode"]!=null)
                    model_LabTestResult._reportitemcode = context.Request["reportitemcode"];

                if(context.Request["abnormalindicator"]!=null)
                    model_LabTestResult._abnormalindicator = context.Request["abnormalindicator"];

                if(context.Request["result"]!=null)
                    model_LabTestResult._result = context.Request["result"];

                if(context.Request["units"]!=null)
                    model_LabTestResult._units = context.Request["units"];

                if(context.Request["resultdatetime"]!=null)
                    model_LabTestResult._resultdatetime = context.Request["resultdatetime"];

                if(context.Request["referenceresult"]!=null)
                    model_LabTestResult._referenceresult = context.Request["referenceresult"];

                #endregion
                if (mode == "ins")
                {
                    if (bll_LabTestResult.Insert(model_LabTestResult))
                    {
                        rlt.success = true;
                        rlt.msg = "新增保存成功";
                    }
                    else
                    {
                        rlt.success = false;
                        rlt.msg = "新增保存失败:" + DbError.getErrorMsg();
                    }
                }

                if (mode == "upd")
                {
                    if (bll_LabTestResult.Update(model_LabTestResult, strPk))
                    {
                        rlt.success = true;
                        rlt.msg = "修改保存成功";
                    }
                    else
                    {
                        rlt.success = false;
                        rlt.msg = "修改保存失败:" + DbError.getErrorMsg();
                    }
                }
            }
            catch(Exception exception)
            {
                rlt.success = false;
                rlt.msg = exception.Message;
            }
            context.Response.Write(JSONHelper.Convert2Json(rlt)); 
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="context"></param>
        private static void DeleteData(HttpContext context)
        {
            result rlt = new result();
            if (context.Request["pk"] != null)
            {
                string pk = context.Request["pk"];
                string[] ArrayPk = pk.Split(',');
                BLL.LabTestResult_BLL bll_LabTestResult = new BLL.LabTestResult_BLL();
                int successNumber = 0;
                string  errorMessage = "";
                foreach (string strPk in ArrayPk)
                {
                    if (bll_LabTestResult.Delete(int.Parse(strPk)))
                    {
                        successNumber += 1;
                    }
                }
                rlt.success = true;
                rlt.msg = "成功删除[" + successNumber.ToString() + "/" + ArrayPk.Length.ToString() + "]条数据;" + errorMessage; 
            }
            else
            {
                rlt.success = false;
                rlt.msg = "PK字段为Null";
            }
            context.Response.Write(JSONHelper.Convert2Json(rlt));
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="context"></param>
        /// <param name="export">是否导出Excel文件</param>
        private static void QueryData(HttpContext context, bool export)
        {
            #region 获取Jquery回传Server分页页码和每页行数
            int page,rows;
            if (context.Request["page"] != null)
               page = int.Parse(context.Request["page"]);
            else
               page = 1; 
            if (context.Request["rows"]!= null)
                rows = int.Parse(context.Request["rows"]);
            else
                rows = 10;
            #endregion

            #region 获取Jquery回传查询条件参数
            string strWhere = " 1=1 ";
            if (context.Request["so_keywords"] != null)
            {
                string strKeywords = context.Request["so_keywords"];
                if (strKeywords.Length > 0)
                {
                    strWhere += " and (";
                    strWhere += " id like '%" + strKeywords + "%'";
                    strWhere += " or reportitemname like '%" + strKeywords + "%'";
                    strWhere += " or reportitemcode like '%" + strKeywords + "%'";
                    strWhere += " or abnormalindicator like '%" + strKeywords + "%'";
                    strWhere += " or result like '%" + strKeywords + "%'";
                    strWhere += ")";
                }
            }
            #endregion

            #region 字段排序
            string sort = "id";
            string order = "asc";
            if (context.Request["sort"] != null)
                sort = context.Request["sort"];
            if (context.Request["order"] != null)
                order = context.Request["order"];
            #endregion

            #region 分页数据
            DataTable m_dtTable = new DataTable();
            PageAction pageAction = new PageAction();
            pageAction.CurPage = page;
            pageAction.PageSize = rows;
            pageAction.TabName = "LabTestResult";
            pageAction.Fields = "*";
            pageAction.PkField = "id";
            pageAction.Condition = strWhere;
            pageAction.Sort = sort + " " + order;
            DbHelper.FillDataTable(pageAction, m_dtTable); 
            #endregion 


            /*编码绑定代码由KFEasyUiMaker根据编码字段定义自动生成,因此未考虑最佳性能；
             如编码表数据较少情况下，可根据实际情况处理为：先查出编码表组合再遍历赋值。*/
            #region 根据下拉列表编码设置datagrid显示值
            for (int i = 0; i < m_dtTable.Rows.Count; i++)
            {
            }

            #endregion 
            if (export)
            {
                DataTable export_dataTable = new DataTable();
                pageAction.Fields = "id as id,reportitemname as 子项名称,reportitemcode as 子项编码,abnormalindicator as N-正常L-低H-高,result as 正文描述,units as 检验结果为数值型,resultdatetime as 检验日期及时间,referenceresult as 结果参考值";
                DbHelper.GetTable(pageAction.Sql, ref export_dataTable);
                commExcel._ExportExcel(export_dataTable, "LabTestResult");
                result rlt = new result();
                rlt.success = true;
                rlt.msg = commExcel._Url("LabTestResult");
                context.Response.Write(JSONHelper.Convert2Json(rlt));
            }
            else
            {
                string strJson = JSONHelper.CreateJsonParameters(m_dtTable,true, pageAction.RdCount);
                context.Response.Write(strJson);
            }
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
            string strSql = @"select 字段名,count(*) records from labtestresult group by 字段名";
            DataTable dt = new DataTable();
            DbHelper.GetTable(strSql, ref dt);

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
            xmlData.Append("</chart>");
            string ChartHtml = FusionCharts.RenderChartHTML("../js/FusionCharts/" + swf + ".swf","", xmlData.ToString(), "myChart", "600", "350", false);
            result rlt = new result();
            rlt.success = true;
            rlt.msg = ChartHtml;
            context.Response.Write(JSONHelper.Convert2Json(rlt));

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

