//基础代码由科发EasyUi代码生成器v3.5(build 20140519)代码生成器生成,免费版自动增加版权注释,请保留版权信息，尊重作者劳动成果，如您有更好的建议请发至邮箱：843330160@qq.com
using System;
using System.Data;
using Model;
using DAL;

namespace BLL
{
  /// <summary>
  /// 业务逻辑层Info_BLL
  /// </summary>
  public class Info_BLL
  {
    public Info_BLL()
    {
    }


    private Info_DAL g_DAL = new Info_DAL();



    /// <summary>
    /// 得到最大id
    /// </summary>
    public int GetMax_id(string p_strWhere)
    {
      return g_DAL.GetMax_id(p_strWhere);
    }

    /// <summary>
    /// 得到最大id
    /// </summary>
    public int GetMax_id()
    {
      return g_DAL.GetMax_id();
    }

    /// <summary>
    /// 判断数据是否存在
    /// </summary>
    public bool Exists(int intId)
    {
      return g_DAL.Exists(intId);
    }

    /// <summary>
    /// 获取数据总记录数
    /// </summary>
    public int GetRecordCount(string p_strWhere)
    {
      return g_DAL.GetRecordCount(p_strWhere);
    }

    /// <summary>
    /// 获取数据总记录数
    /// </summary>
    public int GetRecordCount()
    {
      return g_DAL.GetRecordCount();
    }

    /// <summary>
    /// 获取数据分页总数
    /// </summary>
    public int GetPageCount(string p_strWhere, int p_intPageSize)
    {
      return g_DAL.GetPageCount(p_strWhere, p_intPageSize);
    }

    /// <summary>
    /// 获取数据分页总数
    /// </summary>
    public int GetPageCount(int p_intPageSize)
    {
      return g_DAL.GetPageCount(p_intPageSize);
    }

    /// <summary>
    /// 添加一条数据 SQL
    /// </summary>
    public string InsertSQL(Info model)
    {
      return g_DAL.InsertSQL(model);
    }

    /// <summary>
    /// 添加一条数据
    /// </summary>
    public bool Insert(Info model)
    {
      return g_DAL.Insert(model);
    }

    /// <summary>
    /// 修改一条数据 SQL
    /// </summary>
    public string UpdateSQL(Info model, int intId)
    {
      return g_DAL.UpdateSQL(model, intId);
    }

    /// <summary>
    /// 修改一条数据
    /// </summary>
    public bool Update(Info model, int intId)
    {
      return g_DAL.Update(model, intId);
    }

    /// <summary>
    /// 修改一个集合 SQL
    /// </summary>
    public string UpdateRangeSQL(Info model, string p_strWhere)
    {
      return g_DAL.UpdateRangeSQL(model, p_strWhere);
    }

    /// <summary>
    /// 修改一个集合
    /// </summary>
    public bool UpdateRange(Info model, string p_strWhere)
    {
      return g_DAL.UpdateRange(model, p_strWhere);
    }

    /// <summary>
    /// 修改全部数据 SQL
    /// </summary>
    public string UpdateAllSQL(Info model)
    {
      return g_DAL.UpdateAllSQL(model);
    }

    /// <summary>
    /// 修改全部数据
    /// </summary>
    public bool UpdateAll(Info model)
    {
      return g_DAL.UpdateAll(model);
    }

    /// <summary>
    /// 删除一条数据 SQL
    /// </summary>
    public string DeleteSQL(int intId)
    {
      return g_DAL.DeleteSQL(intId);
    }

    /// <summary>
    /// 删除一条数据
    /// </summary>
    public bool Delete(int intId)
    {
      return g_DAL.Delete(intId);
    }

    /// <summary>
    /// 删除一个集合 SQL
    /// </summary>
    public string DeleteRangeSQL(string p_strWhere)
    {
      return g_DAL.DeleteRangeSQL(p_strWhere);
    }

    /// <summary>
    /// 删除一个集合
    /// </summary>
    public bool DeleteRange(string p_strWhere)
    {
      return g_DAL.DeleteRange(p_strWhere);
    }

    /// <summary>
    /// 删除全部 SQL
    /// </summary>
    public string DeleteAllSQL()
    {
      return g_DAL.DeleteAllSQL();
    }

    /// <summary>
    /// 删除全部
    /// </summary>
    public bool DeleteAll()
    {
      return g_DAL.DeleteAll();
    }

    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public Info GetModel(int intId)
    {
      return g_DAL.GetModel(intId);
    }

    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public void GetModel(ref DataTable p_dtData, int intId)
    {
      g_DAL.GetModel(ref p_dtData, intId);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public Info[] GetModelList(string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
    {
      return g_DAL.GetModelList(p_strWhere, p_strOrder, p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public Info[] GetModelList(string p_strWhere)
    {
      return g_DAL.GetModelList(p_strWhere);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public Info[] GetModelList(string p_strWhere, string p_strOrder)
    {
      return g_DAL.GetModelList(p_strWhere, p_strOrder);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public Info[] GetModelList(int p_intPageNumber, int p_intPageSize)
    {
      return g_DAL.GetModelList(p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public Info[] GetModelList(string p_strWhere, int p_intPageNumber, int p_intPageSize)
    {
      return g_DAL.GetModelList(p_strWhere, p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public Info[] GetModelList()
    {
      return g_DAL.GetModelList();
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
    {
      g_DAL.GetModelList(ref p_dtData, p_strWhere, p_strOrder, p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, string p_strWhere)
    {
      g_DAL.GetModelList(ref p_dtData, p_strWhere);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, string p_strWhere, string p_strOrder)
    {
      g_DAL.GetModelList(ref p_dtData, p_strWhere, p_strOrder);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, int p_intPageNumber, int p_intPageSize)
    {
      g_DAL.GetModelList(ref p_dtData, p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public void GetModelList(ref DataTable p_dtData, string p_strWhere, int p_intPageNumber, int p_intPageSize)
    {
      g_DAL.GetModelList(ref p_dtData, p_strWhere, p_intPageNumber, p_intPageSize);
    }

    /// <summary>
    /// 得到对象集合
    /// </summary>
    public void GetModelList(ref DataTable p_dtData)
    {
      g_DAL.GetModelList(ref p_dtData);
    }
  }
}
