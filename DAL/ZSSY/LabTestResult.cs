using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL.ZSSY
{
	/// <summary>
	/// 数据访问类:LabTestResult
	/// </summary>
	public partial class LabTestResult
	{
		public LabTestResult()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(RuRo.Model.ZSSY.LabTestResult model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LabTestResult(");
			strSql.Append("ReportItemName,ReportItemCode,AbnormalIndicator,Result,Units,ResultDateTime,ReferenceResult)");
			strSql.Append(" values (");
			strSql.Append("@ReportItemName,@ReportItemCode,@AbnormalIndicator,@Result,@Units,@ResultDateTime,@ReferenceResult)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportItemName", SqlDbType.NVarChar,50),
					new SqlParameter("@ReportItemCode", SqlDbType.NVarChar,50),
					new SqlParameter("@AbnormalIndicator", SqlDbType.NChar,10),
					new SqlParameter("@Result", SqlDbType.NVarChar,2048),
					new SqlParameter("@Units", SqlDbType.NVarChar,50),
					new SqlParameter("@ResultDateTime", SqlDbType.NVarChar,50),
					new SqlParameter("@ReferenceResult", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ReportItemName;
			parameters[1].Value = model.ReportItemCode;
			parameters[2].Value = model.AbnormalIndicator;
			parameters[3].Value = model.Result;
			parameters[4].Value = model.Units;
			parameters[5].Value = model.ResultDateTime;
			parameters[6].Value = model.ReferenceResult;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(RuRo.Model.ZSSY.LabTestResult model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LabTestResult set ");
			strSql.Append("ReportItemName=@ReportItemName,");
			strSql.Append("ReportItemCode=@ReportItemCode,");
			strSql.Append("AbnormalIndicator=@AbnormalIndicator,");
			strSql.Append("Result=@Result,");
			strSql.Append("Units=@Units,");
			strSql.Append("ResultDateTime=@ResultDateTime,");
			strSql.Append("ReferenceResult=@ReferenceResult");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportItemName", SqlDbType.NVarChar,50),
					new SqlParameter("@ReportItemCode", SqlDbType.NVarChar,50),
					new SqlParameter("@AbnormalIndicator", SqlDbType.NChar,10),
					new SqlParameter("@Result", SqlDbType.NVarChar,2048),
					new SqlParameter("@Units", SqlDbType.NVarChar,50),
					new SqlParameter("@ResultDateTime", SqlDbType.NVarChar,50),
					new SqlParameter("@ReferenceResult", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.ReportItemName;
			parameters[1].Value = model.ReportItemCode;
			parameters[2].Value = model.AbnormalIndicator;
			parameters[3].Value = model.Result;
			parameters[4].Value = model.Units;
			parameters[5].Value = model.ResultDateTime;
			parameters[6].Value = model.ReferenceResult;
			parameters[7].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LabTestResult ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LabTestResult ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public RuRo.Model.ZSSY.LabTestResult GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,ReportItemName,ReportItemCode,AbnormalIndicator,Result,Units,ResultDateTime,ReferenceResult from LabTestResult ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			RuRo.Model.ZSSY.LabTestResult model=new RuRo.Model.ZSSY.LabTestResult();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public RuRo.Model.ZSSY.LabTestResult DataRowToModel(DataRow row)
		{
			RuRo.Model.ZSSY.LabTestResult model=new RuRo.Model.ZSSY.LabTestResult();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["ReportItemName"]!=null)
				{
					model.ReportItemName=row["ReportItemName"].ToString();
				}
				if(row["ReportItemCode"]!=null)
				{
					model.ReportItemCode=row["ReportItemCode"].ToString();
				}
				if(row["AbnormalIndicator"]!=null)
				{
					model.AbnormalIndicator=row["AbnormalIndicator"].ToString();
				}
				if(row["Result"]!=null)
				{
					model.Result=row["Result"].ToString();
				}
				if(row["Units"]!=null)
				{
					model.Units=row["Units"].ToString();
				}
				if(row["ResultDateTime"]!=null)
				{
					model.ResultDateTime=row["ResultDateTime"].ToString();
				}
				if(row["ReferenceResult"]!=null)
				{
					model.ReferenceResult=row["ReferenceResult"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,ReportItemName,ReportItemCode,AbnormalIndicator,Result,Units,ResultDateTime,ReferenceResult ");
			strSql.Append(" FROM LabTestResult ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,ReportItemName,ReportItemCode,AbnormalIndicator,Result,Units,ResultDateTime,ReferenceResult ");
			strSql.Append(" FROM LabTestResult ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM LabTestResult ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from LabTestResult T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "LabTestResult";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

