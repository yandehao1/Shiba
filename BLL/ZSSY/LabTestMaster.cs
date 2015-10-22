using System;
using System.Data;
using System.Collections.Generic;
using RuRo.Common;
using RuRo.Model.ZSSY;
namespace RuRo.BLL.ZSSY
{
	/// <summary>
	/// FP中样本源记录
	/// </summary>
	public partial class LabTestMaster
	{
		private readonly RuRo.DAL.ZSSY.LabTestMaster dal=new RuRo.DAL.ZSSY.LabTestMaster();
		public LabTestMaster()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(RuRo.Model.ZSSY.LabTestMaster model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(RuRo.Model.ZSSY.LabTestMaster model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public RuRo.Model.ZSSY.LabTestMaster GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public RuRo.Model.ZSSY.LabTestMaster GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "LabTestMasterModel-" ;
			object objModel = RuRo.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = RuRo.Common.ConfigHelper.GetConfigInt("ModelCache");
						RuRo.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (RuRo.Model.ZSSY.LabTestMaster)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<RuRo.Model.ZSSY.LabTestMaster> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<RuRo.Model.ZSSY.LabTestMaster> DataTableToList(DataTable dt)
		{
			List<RuRo.Model.ZSSY.LabTestMaster> modelList = new List<RuRo.Model.ZSSY.LabTestMaster>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				RuRo.Model.ZSSY.LabTestMaster model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

