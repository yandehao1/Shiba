//���������ɿƷ�EasyUi����������v3.5(build 20140519)��������������,��Ѱ��Զ����Ӱ�Ȩע��,�뱣����Ȩ��Ϣ�����������Ͷ��ɹ��������и��õĽ����뷢�����䣺843330160@qq.com
using System;
using System.Data;
using System.Text;
using System.Web;
using Model;
using DBUtility;

namespace DAL
{
  /// <summary>
  /// ���ݷ��ʲ�Info_DAL
  /// </summary>
  public class Info_DAL
  {
    public Info_DAL()
    {
    }



    /// <summary>
    /// �õ����id
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
    /// �õ����id
    /// </summary>
    public int GetMax_id()
    {
      return GetMax_id("");
    }

    /// <summary>
    /// �ж������Ƿ����
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
    /// ��ȡ�����ܼ�¼��
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
    /// ��ȡ�����ܼ�¼��
    /// </summary>
    public int GetRecordCount()
    {
      return GetRecordCount("");
    }

    /// <summary>
    /// ��ȡ���ݷ�ҳ����
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
    /// ��ȡ���ݷ�ҳ����
    /// </summary>
    public int GetPageCount(int p_intPageSize)
    {
      return GetPageCount("", p_intPageSize);
    }

    /// <summary>
    /// ���һ������ SQL
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

      if(model.Changed("����") == true)
      {
            strFieldSQL += ",����";
            strValueSQL += ",'" + model._����.Replace("'","''") + "'";
      }

      if(model.Changed("����") == true)
      {
            strFieldSQL += ",����";
            strValueSQL += ",'" + model._����.Replace("'","''") + "'";
      }

      if(model.Changed("�Ա�") == true)
      {
            strFieldSQL += ",�Ա�";
            strValueSQL += ",'" + model._�Ա�.Replace("'","''") + "'";
      }

      if(model.Changed("����") == true)
      {
            strFieldSQL += ",����";
            strValueSQL += ",'" + model._����.Replace("'","''") + "'";
      }

      if(model.Changed("ҽ��") == true)
      {
            strFieldSQL += ",ҽ��";
            strValueSQL += ",'" + model._ҽ��.Replace("'","''") + "'";
      }

      if(model.Changed("��ˮ��") == true)
      {
            strFieldSQL += ",��ˮ��";
            strValueSQL += ",'" + model._��ˮ��.Replace("'","''") + "'";
      }

      if(model.Changed("����") == true)
      {
            strFieldSQL += ",����";
            strValueSQL += ",'" + model._����.Replace("'","''") + "'";
      }

      if(model.Changed("סԺ��") == true)
      {
            strFieldSQL += ",סԺ��";
            strValueSQL += ",'" + model._סԺ��.Replace("'","''") + "'";
      }

      if(model.Changed("������") == true)
      {
            strFieldSQL += ",������";
            strValueSQL += ",'" + model._������.Replace("'","''") + "'";
      }

      if(model.Changed("���") == true)
      {
            strFieldSQL += ",���";
            strValueSQL += ",'" + model._���.Replace("'","''") + "'";
      }

      if(model.Changed("����") == true)
      {
            strFieldSQL += ",����";
            strValueSQL += ",'" + model._����.Replace("'","''") + "'";
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
    /// ���һ������
    /// </summary>
    public bool Insert(Info model)
    {
      return DbHelper.ExecuteSql(InsertSQL(model));
    }

    /// <summary>
    /// �޸�һ������ SQL
    /// </summary>
    public string UpdateSQL(Info model, int intId)
    {
      string strUpdateSQL = "";
      string strConditionSQL = "";

      if(model.Changed("id") == true)
      {
            strUpdateSQL += ",id=" + model._id + "";
      }
      if(model.Changed("����") == true)
      {
            strUpdateSQL += ",����='" + model._����.Replace("'","''") + "'";
      }
      if(model.Changed("����") == true)
      {
            strUpdateSQL += ",����='" + model._����.Replace("'","''") + "'";
      }
      if(model.Changed("�Ա�") == true)
      {
            strUpdateSQL += ",�Ա�='" + model._�Ա�.Replace("'","''") + "'";
      }
      if(model.Changed("����") == true)
      {
            strUpdateSQL += ",����='" + model._����.Replace("'","''") + "'";
      }
      if(model.Changed("ҽ��") == true)
      {
            strUpdateSQL += ",ҽ��='" + model._ҽ��.Replace("'","''") + "'";
      }
      if(model.Changed("��ˮ��") == true)
      {
            strUpdateSQL += ",��ˮ��='" + model._��ˮ��.Replace("'","''") + "'";
      }
      if(model.Changed("����") == true)
      {
            strUpdateSQL += ",����='" + model._����.Replace("'","''") + "'";
      }
      if(model.Changed("סԺ��") == true)
      {
            strUpdateSQL += ",סԺ��='" + model._סԺ��.Replace("'","''") + "'";
      }
      if(model.Changed("������") == true)
      {
            strUpdateSQL += ",������='" + model._������.Replace("'","''") + "'";
      }
      if(model.Changed("���") == true)
      {
            strUpdateSQL += ",���='" + model._���.Replace("'","''") + "'";
      }
      if(model.Changed("����") == true)
      {
            strUpdateSQL += ",����='" + model._����.Replace("'","''") + "'";
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
    /// �޸�һ������
    /// </summary>
    public bool Update(Info model, int intId)
    {
      return DbHelper.ExecuteSql(UpdateSQL(model, intId));
    }

    /// <summary>
    /// �޸�һ������ SQL
    /// </summary>
    public string UpdateRangeSQL(Info model, string p_strWhere)
    {
      string strUpdateSQL = "";

      if(model.Changed("id") == true)
      {
            strUpdateSQL += ",id=" + model._id + "";
      }
      if(model.Changed("����") == true)
      {
            strUpdateSQL += ",����='" + model._����.Replace("'","''") + "'";
      }
      if(model.Changed("����") == true)
      {
            strUpdateSQL += ",����='" + model._����.Replace("'","''") + "'";
      }
      if(model.Changed("�Ա�") == true)
      {
            strUpdateSQL += ",�Ա�='" + model._�Ա�.Replace("'","''") + "'";
      }
      if(model.Changed("����") == true)
      {
            strUpdateSQL += ",����='" + model._����.Replace("'","''") + "'";
      }
      if(model.Changed("ҽ��") == true)
      {
            strUpdateSQL += ",ҽ��='" + model._ҽ��.Replace("'","''") + "'";
      }
      if(model.Changed("��ˮ��") == true)
      {
            strUpdateSQL += ",��ˮ��='" + model._��ˮ��.Replace("'","''") + "'";
      }
      if(model.Changed("����") == true)
      {
            strUpdateSQL += ",����='" + model._����.Replace("'","''") + "'";
      }
      if(model.Changed("סԺ��") == true)
      {
            strUpdateSQL += ",סԺ��='" + model._סԺ��.Replace("'","''") + "'";
      }
      if(model.Changed("������") == true)
      {
            strUpdateSQL += ",������='" + model._������.Replace("'","''") + "'";
      }
      if(model.Changed("���") == true)
      {
            strUpdateSQL += ",���='" + model._���.Replace("'","''") + "'";
      }
      if(model.Changed("����") == true)
      {
            strUpdateSQL += ",����='" + model._����.Replace("'","''") + "'";
      }

      string strSql = "";
      strSql += "update Info set ";
      strSql += strUpdateSQL.Substring(1);
      strSql += " where " + p_strWhere;

      return strSql;
    }

    /// <summary>
    /// �޸�һ������
    /// </summary>
    public bool UpdateRange(Info model, string p_strWhere)
    {
      return DbHelper.ExecuteSql(UpdateRangeSQL(model, p_strWhere));
    }

    /// <summary>
    /// �޸�ȫ������ SQL
    /// </summary>
    public string UpdateAllSQL(Info model)
    {
      string strUpdateSQL = "";

      if(model.Changed("id") == true)
      {
            strUpdateSQL += ",id=" + model._id + "";
      }
      if(model.Changed("����") == true)
      {
            strUpdateSQL += ",����='" + model._����.Replace("'","''") + "'";
      }
      if(model.Changed("����") == true)
      {
            strUpdateSQL += ",����='" + model._����.Replace("'","''") + "'";
      }
      if(model.Changed("�Ա�") == true)
      {
            strUpdateSQL += ",�Ա�='" + model._�Ա�.Replace("'","''") + "'";
      }
      if(model.Changed("����") == true)
      {
            strUpdateSQL += ",����='" + model._����.Replace("'","''") + "'";
      }
      if(model.Changed("ҽ��") == true)
      {
            strUpdateSQL += ",ҽ��='" + model._ҽ��.Replace("'","''") + "'";
      }
      if(model.Changed("��ˮ��") == true)
      {
            strUpdateSQL += ",��ˮ��='" + model._��ˮ��.Replace("'","''") + "'";
      }
      if(model.Changed("����") == true)
      {
            strUpdateSQL += ",����='" + model._����.Replace("'","''") + "'";
      }
      if(model.Changed("סԺ��") == true)
      {
            strUpdateSQL += ",סԺ��='" + model._סԺ��.Replace("'","''") + "'";
      }
      if(model.Changed("������") == true)
      {
            strUpdateSQL += ",������='" + model._������.Replace("'","''") + "'";
      }
      if(model.Changed("���") == true)
      {
            strUpdateSQL += ",���='" + model._���.Replace("'","''") + "'";
      }
      if(model.Changed("����") == true)
      {
            strUpdateSQL += ",����='" + model._����.Replace("'","''") + "'";
      }

      string strSql = "";
      strSql += "update Info set ";
      strSql += strUpdateSQL.Substring(1);

      return strSql;
    }

    /// <summary>
    /// �޸�ȫ������
    /// </summary>
    public bool UpdateAll(Info model)
    {
      return DbHelper.ExecuteSql(UpdateAllSQL(model));
    }

    /// <summary>
    /// ɾ��һ������ SQL
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
    /// ɾ��һ������
    /// </summary>
    public bool Delete(int intId)
    {
      return DbHelper.ExecuteSql(DeleteSQL(intId));
    }

    /// <summary>
    /// ɾ��һ������ SQL
    /// </summary>
    public string DeleteRangeSQL(string p_strWhere)
    {
      string strSql = "";
      strSql += "delete from Info";
      strSql += " where " + p_strWhere;

      return strSql;
    }

    /// <summary>
    /// ɾ��һ������
    /// </summary>
    public bool DeleteRange(string p_strWhere)
    {
      return DbHelper.ExecuteSql(DeleteRangeSQL(p_strWhere));
    }

    /// <summary>
    /// ɾ��ȫ�� SQL
    /// </summary>
    public string DeleteAllSQL()
    {
      string strSql = "";
      strSql += "delete from Info";

      return strSql;
    }

    /// <summary>
    /// ɾ��ȫ��
    /// </summary>
    public bool DeleteAll()
    {
      return DbHelper.ExecuteSql(DeleteAllSQL());
    }

    /// <summary>
    /// �õ�һ������ʵ��
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
        model._���� = dtTemp.Rows[0]["����"] == DBNull.Value ? "" : dtTemp.Rows[0]["����"].ToString();
        model._���� = dtTemp.Rows[0]["����"] == DBNull.Value ? "" : dtTemp.Rows[0]["����"].ToString();
        model._�Ա� = dtTemp.Rows[0]["�Ա�"] == DBNull.Value ? "" : dtTemp.Rows[0]["�Ա�"].ToString();
        model._���� = dtTemp.Rows[0]["����"] == DBNull.Value ? "" : dtTemp.Rows[0]["����"].ToString();
        model._ҽ�� = dtTemp.Rows[0]["ҽ��"] == DBNull.Value ? "" : dtTemp.Rows[0]["ҽ��"].ToString();
        model._��ˮ�� = dtTemp.Rows[0]["��ˮ��"] == DBNull.Value ? "" : dtTemp.Rows[0]["��ˮ��"].ToString();
        model._���� = dtTemp.Rows[0]["����"] == DBNull.Value ? "" : dtTemp.Rows[0]["����"].ToString();
        model._סԺ�� = dtTemp.Rows[0]["סԺ��"] == DBNull.Value ? "" : dtTemp.Rows[0]["סԺ��"].ToString();
        model._������ = dtTemp.Rows[0]["������"] == DBNull.Value ? "" : dtTemp.Rows[0]["������"].ToString();
        model._��� = dtTemp.Rows[0]["���"] == DBNull.Value ? "" : dtTemp.Rows[0]["���"].ToString();
        model._���� = dtTemp.Rows[0]["����"] == DBNull.Value ? "" : dtTemp.Rows[0]["����"].ToString();
      }

      dtTemp.Dispose();

      return model;
    }

    /// <summary>
    /// �õ�һ������ʵ��
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
    /// �õ����󼯺�
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
        arrModel[N]._���� = dtTemp.Rows[N]["����"] == DBNull.Value ? "" : dtTemp.Rows[N]["����"].ToString();
        arrModel[N]._���� = dtTemp.Rows[N]["����"] == DBNull.Value ? "" : dtTemp.Rows[N]["����"].ToString();
        arrModel[N]._�Ա� = dtTemp.Rows[N]["�Ա�"] == DBNull.Value ? "" : dtTemp.Rows[N]["�Ա�"].ToString();
        arrModel[N]._���� = dtTemp.Rows[N]["����"] == DBNull.Value ? "" : dtTemp.Rows[N]["����"].ToString();
        arrModel[N]._ҽ�� = dtTemp.Rows[N]["ҽ��"] == DBNull.Value ? "" : dtTemp.Rows[N]["ҽ��"].ToString();
        arrModel[N]._��ˮ�� = dtTemp.Rows[N]["��ˮ��"] == DBNull.Value ? "" : dtTemp.Rows[N]["��ˮ��"].ToString();
        arrModel[N]._���� = dtTemp.Rows[N]["����"] == DBNull.Value ? "" : dtTemp.Rows[N]["����"].ToString();
        arrModel[N]._סԺ�� = dtTemp.Rows[N]["סԺ��"] == DBNull.Value ? "" : dtTemp.Rows[N]["סԺ��"].ToString();
        arrModel[N]._������ = dtTemp.Rows[N]["������"] == DBNull.Value ? "" : dtTemp.Rows[N]["������"].ToString();
        arrModel[N]._��� = dtTemp.Rows[N]["���"] == DBNull.Value ? "" : dtTemp.Rows[N]["���"].ToString();
        arrModel[N]._���� = dtTemp.Rows[N]["����"] == DBNull.Value ? "" : dtTemp.Rows[N]["����"].ToString();
      }

      dtTemp.Dispose();

      return arrModel;
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public Info[] GetModelList(string p_strWhere)
    {
      return GetModelList(p_strWhere, "", -1, -1);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public Info[] GetModelList(string p_strWhere, string p_strOrder)
    {
      return GetModelList(p_strWhere, p_strOrder, -1, -1);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public Info[] GetModelList(int p_intPageNumber, int p_intPageSize)
    {
      return GetModelList("", "", p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public Info[] GetModelList(string p_strWhere, int p_intPageNumber, int p_intPageSize)
    {
      return GetModelList(p_strWhere, "", p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public Info[] GetModelList()
    {
      return GetModelList("", "", -1, -1);
    }

    /// <summary>
    /// �õ����󼯺�
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
    /// �õ����󼯺�
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, string p_strWhere)
    {
      GetModelList(ref p_dtData, p_strWhere, "", -1, -1);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, string p_strWhere, string p_strOrder)
    {
      GetModelList(ref p_dtData, p_strWhere, p_strOrder, -1, -1);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, int p_intPageNumber, int p_intPageSize)
    {
      GetModelList(ref p_dtData, "", "", p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, string p_strWhere, int p_intPageNumber, int p_intPageSize)
    {
      GetModelList(ref p_dtData, p_strWhere, "", p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public void GetModelList(ref DataTable p_dtData)
    {
      GetModelList(ref p_dtData, "", "", -1, -1);
    }
  }
}
