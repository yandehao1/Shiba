//���������ɿƷ�EasyUi����������v3.5(build 20140519)��������������,��Ѱ��Զ����Ӱ�Ȩע��,�뱣����Ȩ��Ϣ�����������Ͷ��ɹ��������и��õĽ����뷢�����䣺843330160@qq.com
using System;
using System.Data;
using Model;
using DAL;

namespace BLL
{
  /// <summary>
  /// ҵ���߼���Info_BLL
  /// </summary>
  public class Info_BLL
  {
    public Info_BLL()
    {
    }


    private Info_DAL g_DAL = new Info_DAL();



    /// <summary>
    /// �õ����id
    /// </summary>
    public int GetMax_id(string p_strWhere)
    {
      return g_DAL.GetMax_id(p_strWhere);
    }

    /// <summary>
    /// �õ����id
    /// </summary>
    public int GetMax_id()
    {
      return g_DAL.GetMax_id();
    }

    /// <summary>
    /// �ж������Ƿ����
    /// </summary>
    public bool Exists(int intId)
    {
      return g_DAL.Exists(intId);
    }

    /// <summary>
    /// ��ȡ�����ܼ�¼��
    /// </summary>
    public int GetRecordCount(string p_strWhere)
    {
      return g_DAL.GetRecordCount(p_strWhere);
    }

    /// <summary>
    /// ��ȡ�����ܼ�¼��
    /// </summary>
    public int GetRecordCount()
    {
      return g_DAL.GetRecordCount();
    }

    /// <summary>
    /// ��ȡ���ݷ�ҳ����
    /// </summary>
    public int GetPageCount(string p_strWhere, int p_intPageSize)
    {
      return g_DAL.GetPageCount(p_strWhere, p_intPageSize);
    }

    /// <summary>
    /// ��ȡ���ݷ�ҳ����
    /// </summary>
    public int GetPageCount(int p_intPageSize)
    {
      return g_DAL.GetPageCount(p_intPageSize);
    }

    /// <summary>
    /// ���һ������ SQL
    /// </summary>
    public string InsertSQL(Info model)
    {
      return g_DAL.InsertSQL(model);
    }

    /// <summary>
    /// ���һ������
    /// </summary>
    public bool Insert(Info model)
    {
      return g_DAL.Insert(model);
    }

    /// <summary>
    /// �޸�һ������ SQL
    /// </summary>
    public string UpdateSQL(Info model, int intId)
    {
      return g_DAL.UpdateSQL(model, intId);
    }

    /// <summary>
    /// �޸�һ������
    /// </summary>
    public bool Update(Info model, int intId)
    {
      return g_DAL.Update(model, intId);
    }

    /// <summary>
    /// �޸�һ������ SQL
    /// </summary>
    public string UpdateRangeSQL(Info model, string p_strWhere)
    {
      return g_DAL.UpdateRangeSQL(model, p_strWhere);
    }

    /// <summary>
    /// �޸�һ������
    /// </summary>
    public bool UpdateRange(Info model, string p_strWhere)
    {
      return g_DAL.UpdateRange(model, p_strWhere);
    }

    /// <summary>
    /// �޸�ȫ������ SQL
    /// </summary>
    public string UpdateAllSQL(Info model)
    {
      return g_DAL.UpdateAllSQL(model);
    }

    /// <summary>
    /// �޸�ȫ������
    /// </summary>
    public bool UpdateAll(Info model)
    {
      return g_DAL.UpdateAll(model);
    }

    /// <summary>
    /// ɾ��һ������ SQL
    /// </summary>
    public string DeleteSQL(int intId)
    {
      return g_DAL.DeleteSQL(intId);
    }

    /// <summary>
    /// ɾ��һ������
    /// </summary>
    public bool Delete(int intId)
    {
      return g_DAL.Delete(intId);
    }

    /// <summary>
    /// ɾ��һ������ SQL
    /// </summary>
    public string DeleteRangeSQL(string p_strWhere)
    {
      return g_DAL.DeleteRangeSQL(p_strWhere);
    }

    /// <summary>
    /// ɾ��һ������
    /// </summary>
    public bool DeleteRange(string p_strWhere)
    {
      return g_DAL.DeleteRange(p_strWhere);
    }

    /// <summary>
    /// ɾ��ȫ�� SQL
    /// </summary>
    public string DeleteAllSQL()
    {
      return g_DAL.DeleteAllSQL();
    }

    /// <summary>
    /// ɾ��ȫ��
    /// </summary>
    public bool DeleteAll()
    {
      return g_DAL.DeleteAll();
    }

    /// <summary>
    /// �õ�һ������ʵ��
    /// </summary>
    public Info GetModel(int intId)
    {
      return g_DAL.GetModel(intId);
    }

    /// <summary>
    /// �õ�һ������ʵ��
    /// </summary>
    public void GetModel(ref DataTable p_dtData, int intId)
    {
      g_DAL.GetModel(ref p_dtData, intId);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public Info[] GetModelList(string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
    {
      return g_DAL.GetModelList(p_strWhere, p_strOrder, p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public Info[] GetModelList(string p_strWhere)
    {
      return g_DAL.GetModelList(p_strWhere);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public Info[] GetModelList(string p_strWhere, string p_strOrder)
    {
      return g_DAL.GetModelList(p_strWhere, p_strOrder);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public Info[] GetModelList(int p_intPageNumber, int p_intPageSize)
    {
      return g_DAL.GetModelList(p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public Info[] GetModelList(string p_strWhere, int p_intPageNumber, int p_intPageSize)
    {
      return g_DAL.GetModelList(p_strWhere, p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public Info[] GetModelList()
    {
      return g_DAL.GetModelList();
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
    {
      g_DAL.GetModelList(ref p_dtData, p_strWhere, p_strOrder, p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, string p_strWhere)
    {
      g_DAL.GetModelList(ref p_dtData, p_strWhere);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, string p_strWhere, string p_strOrder)
    {
      g_DAL.GetModelList(ref p_dtData, p_strWhere, p_strOrder);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, int p_intPageNumber, int p_intPageSize)
    {
      g_DAL.GetModelList(ref p_dtData, p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, string p_strWhere, int p_intPageNumber, int p_intPageSize)
    {
      g_DAL.GetModelList(ref p_dtData, p_strWhere, p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// �õ����󼯺�
    /// </summary>
    public void GetModelList(ref DataTable p_dtData)
    {
      g_DAL.GetModelList(ref p_dtData);
    }
  }
}
