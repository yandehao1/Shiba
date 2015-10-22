using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL.ZSSY
{
	/// <summary>
	/// 数据访问类:ImportSampleSourceLog
	/// </summary>
	public partial class ImportSampleSourceLog
	{
		public ImportSampleSourceLog()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "ImportSampleSourceLog"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ImportSampleSourceLog");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(RuRo.Model.ZSSY.ImportSampleSourceLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ImportSampleSourceLog(");
			strSql.Append("sampleSourceName,sampleSourceType,sampleSourceDescription,patientId,patientName,patientSex,importStatus,hidden,ResultStatus,ImportDate)");
			strSql.Append(" values (");
			strSql.Append("@sampleSourceName,@sampleSourceType,@sampleSourceDescription,@patientId,@patientName,@patientSex,@importStatus,@hidden,@ResultStatus,@ImportDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@sampleSourceName", SqlDbType.NVarChar,50),
					new SqlParameter("@sampleSourceType", SqlDbType.NVarChar,50),
					new SqlParameter("@sampleSourceDescription", SqlDbType.NVarChar,50),
					new SqlParameter("@patientId", SqlDbType.NVarChar,50),
					new SqlParameter("@patientName", SqlDbType.NVarChar,50),
					new SqlParameter("@patientSex", SqlDbType.NVarChar,50),
					new SqlParameter("@importStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@hidden", SqlDbType.NVarChar,-1),
					new SqlParameter("@ResultStatus", SqlDbType.NVarChar,500),
					new SqlParameter("@ImportDate", SqlDbType.SmallDateTime)};
			parameters[0].Value = model.sampleSourceName;
			parameters[1].Value = model.sampleSourceType;
			parameters[2].Value = model.sampleSourceDescription;
			parameters[3].Value = model.patientId;
			parameters[4].Value = model.patientName;
			parameters[5].Value = model.patientSex;
			parameters[6].Value = model.importStatus;
			parameters[7].Value = model.hidden;
			parameters[8].Value = model.ResultStatus;
			parameters[9].Value = model.ImportDate;

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
		public bool Update(RuRo.Model.ZSSY.ImportSampleSourceLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ImportSampleSourceLog set ");
			strSql.Append("sampleSourceName=@sampleSourceName,");
			strSql.Append("sampleSourceType=@sampleSourceType,");
			strSql.Append("sampleSourceDescription=@sampleSourceDescription,");
			strSql.Append("patientId=@patientId,");
			strSql.Append("patientName=@patientName,");
			strSql.Append("patientSex=@patientSex,");
			strSql.Append("importStatus=@importStatus,");
			strSql.Append("hidden=@hidden,");
			strSql.Append("ResultStatus=@ResultStatus,");
			strSql.Append("ImportDate=@ImportDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@sampleSourceName", SqlDbType.NVarChar,50),
					new SqlParameter("@sampleSourceType", SqlDbType.NVarChar,50),
					new SqlParameter("@sampleSourceDescription", SqlDbType.NVarChar,50),
					new SqlParameter("@patientId", SqlDbType.NVarChar,50),
					new SqlParameter("@patientName", SqlDbType.NVarChar,50),
					new SqlParameter("@patientSex", SqlDbType.NVarChar,50),
					new SqlParameter("@importStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@hidden", SqlDbType.NVarChar,-1),
					new SqlParameter("@ResultStatus", SqlDbType.NVarChar,500),
					new SqlParameter("@ImportDate", SqlDbType.SmallDateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.sampleSourceName;
			parameters[1].Value = model.sampleSourceType;
			parameters[2].Value = model.sampleSourceDescription;
			parameters[3].Value = model.patientId;
			parameters[4].Value = model.patientName;
			parameters[5].Value = model.patientSex;
			parameters[6].Value = model.importStatus;
			parameters[7].Value = model.hidden;
			parameters[8].Value = model.ResultStatus;
			parameters[9].Value = model.ImportDate;
			parameters[10].Value = model.id;

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
			strSql.Append("delete from ImportSampleSourceLog ");
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
			strSql.Append("delete from ImportSampleSourceLog ");
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
		public RuRo.Model.ZSSY.ImportSampleSourceLog GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sampleSourceName,sampleSourceType,sampleSourceDescription,patientId,patientName,patientSex,importStatus,hidden,ResultStatus,ImportDate from ImportSampleSourceLog ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			RuRo.Model.ZSSY.ImportSampleSourceLog model=new RuRo.Model.ZSSY.ImportSampleSourceLog();
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
		public RuRo.Model.ZSSY.ImportSampleSourceLog DataRowToModel(DataRow row)
		{
			RuRo.Model.ZSSY.ImportSampleSourceLog model=new RuRo.Model.ZSSY.ImportSampleSourceLog();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["sampleSourceName"]!=null)
				{
					model.sampleSourceName=row["sampleSourceName"].ToString();
				}
				if(row["sampleSourceType"]!=null)
				{
					model.sampleSourceType=row["sampleSourceType"].ToString();
				}
				if(row["sampleSourceDescription"]!=null)
				{
					model.sampleSourceDescription=row["sampleSourceDescription"].ToString();
				}
				if(row["patientId"]!=null)
				{
					model.patientId=row["patientId"].ToString();
				}
				if(row["patientName"]!=null)
				{
					model.patientName=row["patientName"].ToString();
				}
				if(row["patientSex"]!=null)
				{
					model.patientSex=row["patientSex"].ToString();
				}
				if(row["importStatus"]!=null)
				{
					model.importStatus=row["importStatus"].ToString();
				}
				if(row["hidden"]!=null)
				{
					model.hidden=row["hidden"].ToString();
				}
				if(row["ResultStatus"]!=null)
				{
					model.ResultStatus=row["ResultStatus"].ToString();
				}
				if(row["ImportDate"]!=null && row["ImportDate"].ToString()!="")
				{
					model.ImportDate=DateTime.Parse(row["ImportDate"].ToString());
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
			strSql.Append("select id,sampleSourceName,sampleSourceType,sampleSourceDescription,patientId,patientName,patientSex,importStatus,hidden,ResultStatus,ImportDate ");
			strSql.Append(" FROM ImportSampleSourceLog ");
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
			strSql.Append(" id,sampleSourceName,sampleSourceType,sampleSourceDescription,patientId,patientName,patientSex,importStatus,hidden,ResultStatus,ImportDate ");
			strSql.Append(" FROM ImportSampleSourceLog ");
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
			strSql.Append("select count(1) FROM ImportSampleSourceLog ");
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
			strSql.Append(")AS Row, T.*  from ImportSampleSourceLog T ");
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
			parameters[0].Value = "ImportSampleSourceLog";
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

