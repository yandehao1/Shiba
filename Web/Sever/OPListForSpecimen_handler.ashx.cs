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
    public class OPListForSpecimen_handler : IHttpHandler
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
            BLL.OPListForSpecimen_BLL bll_OPListForSpecimen = new BLL.OPListForSpecimen_BLL();
            Model.OPListForSpecimen model_OPListForSpecimen = new Model.OPListForSpecimen();
            DataTable dt = new DataTable();
            if (context.Request["pk"] != null)
            {
                int pk = int.Parse(context.Request["pk"]);
                model_OPListForSpecimen = bll_OPListForSpecimen.GetModel(pk);
                bll_OPListForSpecimen.GetModel(ref dt, pk);
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
                BLL.OPListForSpecimen_BLL bll_OPListForSpecimen = new BLL.OPListForSpecimen_BLL();
                Model.OPListForSpecimen model_OPListForSpecimen = new Model.OPListForSpecimen(); 
                #region 实体类赋值
                if (mode == "ins")
                {
                    //编码表采用Max获取，请注意设置字段长度
                    model_OPListForSpecimen._id = bll_OPListForSpecimen.GetMax_id();//主键赋值
                }

                if(context.Request["patientid"]!=null)
                    model_OPListForSpecimen._patientid = context.Request["patientid"];

                if(context.Request["inpno"]!=null)
                    model_OPListForSpecimen._inpno = context.Request["inpno"];

                if(context.Request["visitid"]!=null)
                    model_OPListForSpecimen._visitid = context.Request["visitid"];

                if(context.Request["name"]!=null)
                    model_OPListForSpecimen._name = context.Request["name"];

                if(context.Request["namephonetic"]!=null)
                    model_OPListForSpecimen._namephonetic = context.Request["namephonetic"];

                if(context.Request["sex"]!=null)
                    model_OPListForSpecimen._sex = context.Request["sex"];

                if(context.Request["dateofbirth"]!=null)
                    model_OPListForSpecimen._dateofbirth = context.Request["dateofbirth"];

                if(context.Request["birthplace"]!=null)
                    model_OPListForSpecimen._birthplace = context.Request["birthplace"];

                if(context.Request["citizenship"]!=null)
                    model_OPListForSpecimen._citizenship = context.Request["citizenship"];

                if(context.Request["nation"]!=null)
                    model_OPListForSpecimen._nation = context.Request["nation"];

                if(context.Request["idno"]!=null)
                    model_OPListForSpecimen._idno = context.Request["idno"];

                if(context.Request["identity"]!=null)
                    model_OPListForSpecimen._identity = context.Request["identity"];

                if(context.Request["chargetype"]!=null)
                    model_OPListForSpecimen._chargetype = context.Request["chargetype"];

                if(context.Request["mailingaddress"]!=null)
                    model_OPListForSpecimen._mailingaddress = context.Request["mailingaddress"];

                if(context.Request["zipcode"]!=null)
                    model_OPListForSpecimen._zipcode = context.Request["zipcode"];

                if(context.Request["phonenumberhome"]!=null)
                    model_OPListForSpecimen._phonenumberhome = context.Request["phonenumberhome"];

                if(context.Request["phonenumbebusiness"]!=null)
                    model_OPListForSpecimen._phonenumbebusiness = context.Request["phonenumbebusiness"];

                if(context.Request["nextofkin"]!=null)
                    model_OPListForSpecimen._nextofkin = context.Request["nextofkin"];

                if(context.Request["relationship"]!=null)
                    model_OPListForSpecimen._relationship = context.Request["relationship"];

                if(context.Request["nextofkinaddr"]!=null)
                    model_OPListForSpecimen._nextofkinaddr = context.Request["nextofkinaddr"];

                if(context.Request["nextofkinzipcode"]!=null)
                    model_OPListForSpecimen._nextofkinzipcode = context.Request["nextofkinzipcode"];

                if(context.Request["nextofkinphome"]!=null)
                    model_OPListForSpecimen._nextofkinphome = context.Request["nextofkinphome"];

                if(context.Request["deptcode"]!=null)
                    model_OPListForSpecimen._deptcode = context.Request["deptcode"];

                if(context.Request["bedno"]!=null)
                    model_OPListForSpecimen._bedno = context.Request["bedno"];

                if(context.Request["admissiondatetime"]!=null)
                    model_OPListForSpecimen._admissiondatetime = context.Request["admissiondatetime"];

                if(context.Request["doctorincharge"]!=null)
                    model_OPListForSpecimen._doctorincharge = context.Request["doctorincharge"];

                if(context.Request["scheduleid"]!=null)
                    model_OPListForSpecimen._scheduleid = context.Request["scheduleid"];

                if(context.Request["diagbeforeoperation"]!=null)
                    model_OPListForSpecimen._diagbeforeoperation = context.Request["diagbeforeoperation"];

                if(context.Request["scheduleddatetime"]!=null)
                    model_OPListForSpecimen._scheduleddatetime = context.Request["scheduleddatetime"];

                if(context.Request["keepspecimensign"]!=null)
                    model_OPListForSpecimen._keepspecimensign = context.Request["keepspecimensign"];

                if(context.Request["operatingroom"]!=null)
                    model_OPListForSpecimen._operatingroom = context.Request["operatingroom"];

                if(context.Request["surgeon"]!=null)
                    model_OPListForSpecimen._surgeon = context.Request["surgeon"];

                if(context.Request["inpatpreillness"]!=null)
                    model_OPListForSpecimen._inpatpreillness = context.Request["inpatpreillness"];

                if(context.Request["inpatpastillness"]!=null)
                    model_OPListForSpecimen._inpatpastillness = context.Request["inpatpastillness"];

                if(context.Request["inpatfamillness"]!=null)
                    model_OPListForSpecimen._inpatfamillness = context.Request["inpatfamillness"];

                if(context.Request["labinfo"]!=null)
                    model_OPListForSpecimen._labinfo = context.Request["labinfo"];

                #endregion
                if (mode == "ins")
                {
                    if (bll_OPListForSpecimen.Insert(model_OPListForSpecimen))
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
                    if (bll_OPListForSpecimen.Update(model_OPListForSpecimen, strPk))
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
                BLL.OPListForSpecimen_BLL bll_OPListForSpecimen = new BLL.OPListForSpecimen_BLL();
                int successNumber = 0;
                string  errorMessage = "";
                foreach (string strPk in ArrayPk)
                {
                    if (bll_OPListForSpecimen.Delete(int.Parse(strPk)))
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
                    strWhere += " or patientid like '%" + strKeywords + "%'";
                    strWhere += " or inpno like '%" + strKeywords + "%'";
                    strWhere += " or visitid like '%" + strKeywords + "%'";
                    strWhere += " or name like '%" + strKeywords + "%'";
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
            pageAction.TabName = "OPListForSpecimen";
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
                pageAction.Fields = "id as id,patientid as 病人唯一标识号,inpno as 住院号,visitid as 就诊号,name as 姓名,namephonetic as 姓名拼音,sex as 性别,dateofbirth as 出生日期,birthplace as 行政区名称,citizenship as 国家简称,nation as 民族,idno as 身份证号,identity as 患者工作身份,chargetype as 病人收费类别,mailingaddress as 永久通信地址,zipcode as 邮政编码,phonenumberhome as 家庭电话号码,phonenumbebusiness as 单位电话号码,nextofkin as 亲属姓名,relationship as 亲属关系,nextofkinaddr as 联系人地址,nextofkinzipcode as 联系人邮政编码,nextofkinphome as 联系人电话号码,deptcode as 当前科室代码@名称,bedno as 病人所住床号,admissiondatetime as 入院日期及时间,doctorincharge as 主治医生工号@姓名,scheduleid as 手术id号,diagbeforeoperation as 主要诊断,scheduleddatetime as 预约进行该次手术的日期及时间,keepspecimensign as 是否留标本,operatingroom as 手术室代码@名称,surgeon as 手术医师工号@姓名,inpatpreillness as 现病史,inpatpastillness as 既往史,inpatfamillness as 家族史,labinfo as 乙肝梅毒等阳性结果";
                DbHelper.GetTable(pageAction.Sql, ref export_dataTable);
                commExcel._ExportExcel(export_dataTable, "OPListForSpecimen");
                result rlt = new result();
                rlt.success = true;
                rlt.msg = commExcel._Url("OPListForSpecimen");
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
            string strSql = @"select 字段名,count(*) records from oplistforspecimen group by 字段名";
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

