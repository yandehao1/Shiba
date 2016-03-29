//基础代码由科发EasyUi代码生成器v3.5(build 20140519)代码生成器生成,免费版自动增加版权注释,请保留版权信息，尊重作者劳动成果，如您有更好的建议请发至邮箱：843330160@qq.com
using System;
using System.Data;
using System.Text;
using System.Web;
using Model;
using DBUtility;

namespace DAL
{
  /// <summary>
  /// 数据访问层Info_DAL
  /// </summary>
  public class Info_DAL
  {
    public Info_DAL()
    {
    }



    /// <summary>
    /// 得到最大id
    /// </summary>
    public int GetMax_id(string p_strWhere)
    {
      int intResult = 0;

      string strSql = "select max(id) as m from Info";
      if(p_strWhere.Trim().Length > 0)
      {
         strSql += " where " + p_strWhere;
      }

      DataTable dtTemp = new DataTable();
      DbHelper.GetTable(strSql, ref dtTemp);

      if(dtTemp.Rows.Count>0)
      {
        if(dtTemp.Rows[0]["m"].ToString().Length>0)
        {
          intResult = dtTemp.Rows[0]["m"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["m"]);
        }
      }

      dtTemp.Dispose();

      return intResult + 1;
    }

    /// <summary>
    /// 得到最大id
    /// </summary>
    public int GetMax_id()
    {
      return GetMax_id("");
    }

    /// <summary>
    /// 判断数据是否存在
    /// </summary>
    public bool Exists(int intId)
    {
      bool bolResult=false;


      string strSql = "";
      strSql += "select count(1) as c from Info";
      strSql += " where ";
      strSql += "     id=" + intId + "";

      DataTable dtTemp = new DataTable();
      DbHelper.GetTable(strSql, ref dtTemp);

      if(dtTemp.Rows.Count>0)
      {
        bolResult=Convert.ToInt32(dtTemp.Rows[0]["c"])>0;
      }

      dtTemp.Dispose();

      return bolResult;
    }

    /// <summary>
    /// 获取数据总记录数
    /// </summary>
    public int GetRecordCount(string p_strWhere)
    {
      int intResult=0;

      string strSql = "";
      strSql += "select count(1) as c from Info";
      if(p_strWhere.Trim().Length > 0)
      {
         strSql += " where " + p_strWhere;
      }

      DataTable dtTemp = new DataTable();
      DbHelper.GetTable(strSql, ref dtTemp);

      if(dtTemp.Rows.Count>0)
      {
        intResult=Convert.ToInt32(dtTemp.Rows[0]["c"]);
      }

      dtTemp.Dispose();

      return intResult;
    }

    /// <summary>
    /// 获取数据总记录数
    /// </summary>
    public int GetRecordCount()
    {
      return GetRecordCount("");
    }

    /// <summary>
    /// 获取数据分页总数
    /// </summary>
    public int GetPageCount(string p_strWhere, int p_intPageSize)
    {
      int intResult=0;

      if(p_intPageSize > 0)
      {
        int intRecordCount = GetRecordCount(p_strWhere);
        intResult = Convert.ToInt32(Math.Truncate(Convert.ToDecimal(intRecordCount) / Convert.ToDecimal(p_intPageSize)));
        if (intRecordCount > (intResult * p_intPageSize))
        {
          intResult++;
        }
      }

      if(intResult == 0)
      {
          intResult++;
      }

      return intResult;
    }

    /// <summary>
    /// 获取数据分页总数
    /// </summary>
    public int GetPageCount(int p_intPageSize)
    {
      return GetPageCount("", p_intPageSize);
    }

    /// <summary>
    /// 添加一条数据 SQL
    /// </summary>
    public string InsertSQL(Info model)
    {
      string strFieldSQL = "";
      string strValueSQL = "";

      if(model.Changed("id") == true)
      {
            strFieldSQL += ",id";
            strValueSQL += "," + model._id + "";
      }

      if(model.Changed("部门") == true)
      {
            strFieldSQL += ",部门";
            strValueSQL += ",'" + model._部门.Replace("'","''") + "'";
      }

      if(model.Changed("姓名") == true)
      {
            strFieldSQL += ",姓名";
            strValueSQL += ",'" + model._姓名.Replace("'","''") + "'";
      }

      if(model.Changed("性别") == true)
      {
            strFieldSQL += ",性别";
            strValueSQL += ",'" + model._性别.Replace("'","''") + "'";
      }

      if(model.Changed("年龄") == true)
      {
            strFieldSQL += ",年龄";
            strValueSQL += ",'" + model._年龄.Replace("'","''") + "'";
      }

      if(model.Changed("医生") == true)
      {
            strFieldSQL += ",医生";
            strValueSQL += ",'" + model._医生.Replace("'","''") + "'";
      }

      if(model.Changed("流水号") == true)
      {
            strFieldSQL += ",流水号";
            strValueSQL += ",'" + model._流水号.Replace("'","''") + "'";
      }

      if(model.Changed("卡号") == true)
      {
            strFieldSQL += ",卡号";
            strValueSQL += ",'" + model._卡号.Replace("'","''") + "'";
      }

      if(model.Changed("住院号") == true)
      {
            strFieldSQL += ",住院号";
            strValueSQL += ",'" + model._住院号.Replace("'","''") + "'";
      }

      if(model.Changed("病历号") == true)
      {
            strFieldSQL += ",病历号";
            strValueSQL += ",'" + model._病历号.Replace("'","''") + "'";
      }

      if(model.Changed("诊断") == true)
      {
            strFieldSQL += ",诊断";
            strValueSQL += ",'" + model._诊断.Replace("'","''") + "'";
      }

      if(model.Changed("日期") == true)
      {
            strFieldSQL += ",日期";
            strValueSQL += ",'" + model._日期.Replace("'","''") + "'";
      }

      string strSql = "";
      strSql += "insert into Info";
      strSql += "(";
      strSql += strFieldSQL.Substring(1);
      strSql += ")";
      strSql += " values";
      strSql += "(";
      strSql += strValueSQL.Substring(1);
      strSql += ")";

      return strSql;
    }

    /// <summary>
    /// 添加一条数据
    /// </summary>
    public bool Insert(Info model)
    {
      return DbHelper.ExecuteSql(InsertSQL(model));
    }

    /// <summary>
    /// 修改一条数据 SQL
    /// </summary>
    public string UpdateSQL(Info model, int intId)
    {
      string strUpdateSQL = "";
      string strConditionSQL = "";

      if(model.Changed("id") == true)
      {
            strUpdateSQL += ",id=" + model._id + "";
      }
      if(model.Changed("部门") == true)
      {
            strUpdateSQL += ",部门='" + model._部门.Replace("'","''") + "'";
      }
      if(model.Changed("姓名") == true)
      {
            strUpdateSQL += ",姓名='" + model._姓名.Replace("'","''") + "'";
      }
      if(model.Changed("性别") == true)
      {
            strUpdateSQL += ",性别='" + model._性别.Replace("'","''") + "'";
      }
      if(model.Changed("年龄") == true)
      {
            strUpdateSQL += ",年龄='" + model._年龄.Replace("'","''") + "'";
      }
      if(model.Changed("医生") == true)
      {
            strUpdateSQL += ",医生='" + model._医生.Replace("'","''") + "'";
      }
      if(model.Changed("流水号") == true)
      {
            strUpdateSQL += ",流水号='" + model._流水号.Replace("'","''") + "'";
      }
      if(model.Changed("卡号") == true)
      {
            strUpdateSQL += ",卡号='" + model._卡号.Replace("'","''") + "'";
      }
      if(model.Changed("住院号") == true)
      {
            strUpdateSQL += ",住院号='" + model._住院号.Replace("'","''") + "'";
      }
      if(model.Changed("病历号") == true)
      {
            strUpdateSQL += ",病历号='" + model._病历号.Replace("'","''") + "'";
      }
      if(model.Changed("诊断") == true)
      {
            strUpdateSQL += ",诊断='" + model._诊断.Replace("'","''") + "'";
      }
      if(model.Changed("日期") == true)
      {
            strUpdateSQL += ",日期='" + model._日期.Replace("'","''") + "'";
      }

      strConditionSQL += "     id=" + intId + "";
      strConditionSQL = strConditionSQL.Substring(5);

      string strSql = "";
      strSql += "update Info set ";
      strSql += strUpdateSQL.Substring(1);
      strSql += " where ";
      strSql += strConditionSQL;

      return strSql;
    }

    /// <summary>
    /// 修改一条数据
    /// </summary>
    public bool Update(Info model, int intId)
    {
      return DbHelper.ExecuteSql(UpdateSQL(model, intId));
    }

    /// <summary>
    /// 修改一个集合 SQL
    /// </summary>
    public string UpdateRangeSQL(Info model, string p_strWhere)
    {
      string strUpdateSQL = "";

      if(model.Changed("id") == true)
      {
            strUpdateSQL += ",id=" + model._id + "";
      }
      if(model.Changed("部门") == true)
      {
            strUpdateSQL += ",部门='" + model._部门.Replace("'","''") + "'";
      }
      if(model.Changed("姓名") == true)
      {
            strUpdateSQL += ",姓名='" + model._姓名.Replace("'","''") + "'";
      }
      if(model.Changed("性别") == true)
      {
            strUpdateSQL += ",性别='" + model._性别.Replace("'","''") + "'";
      }
      if(model.Changed("年龄") == true)
      {
            strUpdateSQL += ",年龄='" + model._年龄.Replace("'","''") + "'";
      }
      if(model.Changed("医生") == true)
      {
            strUpdateSQL += ",医生='" + model._医生.Replace("'","''") + "'";
      }
      if(model.Changed("流水号") == true)
      {
            strUpdateSQL += ",流水号='" + model._流水号.Replace("'","''") + "'";
      }
      if(model.Changed("卡号") == true)
      {
            strUpdateSQL += ",卡号='" + model._卡号.Replace("'","''") + "'";
      }
      if(model.Changed("住院号") == true)
      {
            strUpdateSQL += ",住院号='" + model._住院号.Replace("'","''") + "'";
      }
      if(model.Changed("病历号") == true)
      {
            strUpdateSQL += ",病历号='" + model._病历号.Replace("'","''") + "'";
      }
      if(model.Changed("诊断") == true)
      {
            strUpdateSQL += ",诊断='" + model._诊断.Replace("'","''") + "'";
      }
      if(model.Changed("日期") == true)
      {
            strUpdateSQL += ",日期='" + model._日期.Replace("'","''") + "'";
      }

      string strSql = "";
      strSql += "update Info set ";
      strSql += strUpdateSQL.Substring(1);
      strSql += " where " + p_strWhere;

      return strSql;
    }

    /// <summary>
    /// 修改一个集合
    /// </summary>
    public bool UpdateRange(Info model, string p_strWhere)
    {
      return DbHelper.ExecuteSql(UpdateRangeSQL(model, p_strWhere));
    }

    /// <summary>
    /// 修改全部数据 SQL
    /// </summary>
    public string UpdateAllSQL(Info model)
    {
      string strUpdateSQL = "";

      if(model.Changed("id") == true)
      {
            strUpdateSQL += ",id=" + model._id + "";
      }
      if(model.Changed("部门") == true)
      {
            strUpdateSQL += ",部门='" + model._部门.Replace("'","''") + "'";
      }
      if(model.Changed("姓名") == true)
      {
            strUpdateSQL += ",姓名='" + model._姓名.Replace("'","''") + "'";
      }
      if(model.Changed("性别") == true)
      {
            strUpdateSQL += ",性别='" + model._性别.Replace("'","''") + "'";
      }
      if(model.Changed("年龄") == true)
      {
            strUpdateSQL += ",年龄='" + model._年龄.Replace("'","''") + "'";
      }
      if(model.Changed("医生") == true)
      {
            strUpdateSQL += ",医生='" + model._医生.Replace("'","''") + "'";
      }
      if(model.Changed("流水号") == true)
      {
            strUpdateSQL += ",流水号='" + model._流水号.Replace("'","''") + "'";
      }
      if(model.Changed("卡号") == true)
      {
            strUpdateSQL += ",卡号='" + model._卡号.Replace("'","''") + "'";
      }
      if(model.Changed("住院号") == true)
      {
            strUpdateSQL += ",住院号='" + model._住院号.Replace("'","''") + "'";
      }
      if(model.Changed("病历号") == true)
      {
            strUpdateSQL += ",病历号='" + model._病历号.Replace("'","''") + "'";
      }
      if(model.Changed("诊断") == true)
      {
            strUpdateSQL += ",诊断='" + model._诊断.Replace("'","''") + "'";
      }
      if(model.Changed("日期") == true)
      {
            strUpdateSQL += ",日期='" + model._日期.Replace("'","''") + "'";
      }

      string strSql = "";
      strSql += "update Info set ";
      strSql += strUpdateSQL.Substring(1);

      return strSql;
    }

    /// <summary>
    /// 修改全部数据
    /// </summary>
    public bool UpdateAll(Info model)
    {
      return DbHelper.ExecuteSql(UpdateAllSQL(model));
    }

    /// <summary>
    /// 删除一条数据 SQL
    /// </summary>
    public string DeleteSQL(int intId)
    {
      string strSql = "";
      string strConditionSQL = "";

      strConditionSQL += "     id=" + intId + "";
      strConditionSQL = strConditionSQL.Substring(5);

      strSql += "delete from Info";
      strSql += " where ";
      strSql += strConditionSQL;

      return strSql;
    }

    /// <summary>
    /// 删除一条数据
    /// </summary>
    public bool Delete(int intId)
    {
      return DbHelper.ExecuteSql(DeleteSQL(intId));
    }

    /// <summary>
    /// 删除一个集合 SQL
    /// </summary>
    public string DeleteRangeSQL(string p_strWhere)
    {
      string strSql = "";
      strSql += "delete from Info";
      strSql += " where " + p_strWhere;

      return strSql;
    }

    /// <summary>
    /// 删除一个集合
    /// </summary>
    public bool DeleteRange(string p_strWhere)
    {
      return DbHelper.ExecuteSql(DeleteRangeSQL(p_strWhere));
    }

    /// <summary>
    /// 删除全部 SQL
    /// </summary>
    public string DeleteAllSQL()
    {
      string strSql = "";
      strSql += "delete from Info";

      return strSql;
    }

    /// <summary>
    /// 删除全部
    /// </summary>
    public bool DeleteAll()
    {
      return DbHelper.ExecuteSql(DeleteAllSQL());
    }

    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public Info GetModel(int intId)
    {
      string strSql = "";
      strSql += "select * from Info";
      strSql += " where ";
      strSql += "     id=" + intId + "";

      DataTable dtTemp = new DataTable();
      DbHelper.GetTable(strSql, ref dtTemp);

      Info model = new Info();

      if(dtTemp.Rows.Count>0)
      {
        model = new Info();

        model._id = dtTemp.Rows[0]["id"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["id"]);
        model._部门 = dtTemp.Rows[0]["部门"] == DBNull.Value ? "" : dtTemp.Rows[0]["部门"].ToString();
        model._姓名 = dtTemp.Rows[0]["姓名"] == DBNull.Value ? "" : dtTemp.Rows[0]["姓名"].ToString();
        model._性别 = dtTemp.Rows[0]["性别"] == DBNull.Value ? "" : dtTemp.Rows[0]["性别"].ToString();
        model._年龄 = dtTemp.Rows[0]["年龄"] == DBNull.Value ? "" : dtTemp.Rows[0]["年龄"].ToString();
        model._医生 = dtTemp.Rows[0]["医生"] == DBNull.Value ? "" : dtTemp.Rows[0]["医生"].ToString();
        model._流水号 = dtTemp.Rows[0]["流水号"] == DBNull.Value ? "" : dtTemp.Rows[0]["流水号"].ToString();
        model._卡号 = dtTemp.Rows[0]["卡号"] == DBNull.Value ? "" : dtTemp.Rows[0]["卡号"].ToString();
        model._住院号 = dtTemp.Rows[0]["住院号"] == DBNull.Value ? "" : dtTemp.Rows[0]["住院号"].ToString();
        model._病历号 = dtTemp.Rows[0]["病历号"] == DBNull.Value ? "" : dtTemp.Rows[0]["病历号"].ToString();
        model._诊断 = dtTemp.Rows[0]["诊断"] == DBNull.Value ? "" : dtTemp.Rows[0]["诊断"].ToString();
        model._日期 = dtTemp.Rows[0]["日期"] == DBNull.Value ? "" : dtTemp.Rows[0]["日期"].ToString();
      }

      dtTemp.Dispose();

      return model;
    }

    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public void GetModel(ref DataTable p_dtData, int intId)
    {
      p_dtData.Clear();

      string strSql = "";
      strSql += "select * from Info";
      strSql += " where ";
      strSql += "     id=" + intId + "";

      DbHelper.GetTable(strSql, ref p_dtData);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public Info[] GetModelList(string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
    {
      int m_intPageNumber = p_intPageNumber;
      int m_intPageCount = GetPageCount(p_strWhere, p_intPageSize);

      if((m_intPageNumber < 1) || (m_intPageNumber == 0))
      {
         m_intPageNumber = 1;
      }

      if(m_intPageNumber == -1)
      {
         m_intPageNumber = m_intPageCount;
      }

      if(m_intPageNumber > m_intPageCount)
      {
         m_intPageNumber = m_intPageCount;
      }

      string strSql = "";
      strSql += "select * from Info";
      if(p_strWhere.Trim().Length > 0)
      {
         strSql += " where " + p_strWhere;
      }
      if(p_strOrder.Trim().Length > 0)
      {
         strSql += " order by " + p_strOrder;
      }

      DataTable dtTemp = new DataTable();

      if(p_intPageSize > 0)
      {
         DbHelper.GetTable(strSql, ref dtTemp, (m_intPageNumber-1)*p_intPageSize, p_intPageSize);
      }
      else
      {
         DbHelper.GetTable(strSql, ref dtTemp);
      }

      Info[] arrModel=new Info[dtTemp.Rows.Count];

      for(int N=0;N<dtTemp.Rows.Count;N++)
      {
        arrModel[N] = new Info();

        arrModel[N]._id = dtTemp.Rows[N]["id"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["id"]);
        arrModel[N]._部门 = dtTemp.Rows[N]["部门"] == DBNull.Value ? "" : dtTemp.Rows[N]["部门"].ToString();
        arrModel[N]._姓名 = dtTemp.Rows[N]["姓名"] == DBNull.Value ? "" : dtTemp.Rows[N]["姓名"].ToString();
        arrModel[N]._性别 = dtTemp.Rows[N]["性别"] == DBNull.Value ? "" : dtTemp.Rows[N]["性别"].ToString();
        arrModel[N]._年龄 = dtTemp.Rows[N]["年龄"] == DBNull.Value ? "" : dtTemp.Rows[N]["年龄"].ToString();
        arrModel[N]._医生 = dtTemp.Rows[N]["医生"] == DBNull.Value ? "" : dtTemp.Rows[N]["医生"].ToString();
        arrModel[N]._流水号 = dtTemp.Rows[N]["流水号"] == DBNull.Value ? "" : dtTemp.Rows[N]["流水号"].ToString();
        arrModel[N]._卡号 = dtTemp.Rows[N]["卡号"] == DBNull.Value ? "" : dtTemp.Rows[N]["卡号"].ToString();
        arrModel[N]._住院号 = dtTemp.Rows[N]["住院号"] == DBNull.Value ? "" : dtTemp.Rows[N]["住院号"].ToString();
        arrModel[N]._病历号 = dtTemp.Rows[N]["病历号"] == DBNull.Value ? "" : dtTemp.Rows[N]["病历号"].ToString();
        arrModel[N]._诊断 = dtTemp.Rows[N]["诊断"] == DBNull.Value ? "" : dtTemp.Rows[N]["诊断"].ToString();
        arrModel[N]._日期 = dtTemp.Rows[N]["日期"] == DBNull.Value ? "" : dtTemp.Rows[N]["日期"].ToString();
      }

      dtTemp.Dispose();

      return arrModel;
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public Info[] GetModelList(string p_strWhere)
    {
      return GetModelList(p_strWhere, "", -1, -1);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public Info[] GetModelList(string p_strWhere, string p_strOrder)
    {
      return GetModelList(p_strWhere, p_strOrder, -1, -1);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public Info[] GetModelList(int p_intPageNumber, int p_intPageSize)
    {
      return GetModelList("", "", p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public Info[] GetModelList(string p_strWhere, int p_intPageNumber, int p_intPageSize)
    {
      return GetModelList(p_strWhere, "", p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public Info[] GetModelList()
    {
      return GetModelList("", "", -1, -1);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
    {
      p_dtData.Clear();

      int m_intPageNumber = p_intPageNumber;
      int m_intPageCount = GetPageCount(p_strWhere, p_intPageSize);

      if((m_intPageNumber < 1) || (m_intPageNumber == 0))
      {
         m_intPageNumber = 1;
      }

      if(m_intPageNumber == -1)
      {
         m_intPageNumber = m_intPageCount;
      }

      if(m_intPageNumber > m_intPageCount)
      {
         m_intPageNumber = m_intPageCount;
      }

      string strSql = "";
      strSql += "select * from Info";
      if(p_strWhere.Trim().Length > 0)
      {
         strSql += " where " + p_strWhere;
      }
      if(p_strOrder.Trim().Length > 0)
      {
         strSql += " order by " + p_strOrder;
      }

      if(p_intPageSize > 0)
      {
         DbHelper.GetTable(strSql, ref p_dtData, (m_intPageNumber-1)*p_intPageSize, p_intPageSize);
      }
      else
      {
         DbHelper.GetTable(strSql, ref p_dtData);
      }
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, string p_strWhere)
    {
      GetModelList(ref p_dtData, p_strWhere, "", -1, -1);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, string p_strWhere, string p_strOrder)
    {
      GetModelList(ref p_dtData, p_strWhere, p_strOrder, -1, -1);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, int p_intPageNumber, int p_intPageSize)
    {
      GetModelList(ref p_dtData, "", "", p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, string p_strWhere, int p_intPageNumber, int p_intPageSize)
    {
      GetModelList(ref p_dtData, p_strWhere, "", p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public void GetModelList(ref DataTable p_dtData)
    {
      GetModelList(ref p_dtData, "", "", -1, -1);
    }
  }
}
