using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL.ZSSY
{
	/// <summary>
	/// 数据访问类:SpecimenRt
	/// </summary>
	public partial class SpecimenRt
	{
		public SpecimenRt()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "SpecimenRt"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SpecimenRt");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(RuRo.Model.ZSSY.SpecimenRt model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SpecimenRt(");
			strSql.Append("PatientId,PatientName,VisitId,SampleId,SampleName,OtherInfo)");
			strSql.Append(" values (");
			strSql.Append("@PatientId,@PatientName,@VisitId,@SampleId,@SampleName,@OtherInfo)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PatientId", SqlDbType.NVarChar,50),
					new SqlParameter("@PatientName", SqlDbType.NVarChar,50),
					new SqlParameter("@VisitId", SqlDbType.NVarChar,50),
					new SqlParameter("@SampleId", SqlDbType.NVarChar,50),
					new SqlParameter("@SampleName", SqlDbType.NVarChar,50),
					new SqlParameter("@OtherInfo", SqlDbType.NVarChar,-1)};
			parameters[0].Value = model.PatientId;
			parameters[1].Value = model.PatientName;
			parameters[2].Value = model.VisitId;
			parameters[3].Value = model.SampleId;
			parameters[4].Value = model.SampleName;
			parameters[5].Value = model.OtherInfo;

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
		public bool Update(RuRo.Model.ZSSY.SpecimenRt model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SpecimenRt set ");
			strSql.Append("PatientId=@PatientId,");
			strSql.Append("PatientName=@PatientName,");
			strSql.Append("VisitId=@VisitId,");
			strSql.Append("SampleId=@SampleId,");
			strSql.Append("SampleName=@SampleName,");
			strSql.Append("OtherInfo=@OtherInfo");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@PatientId", SqlDbType.NVarChar,50),
					new SqlParameter("@PatientName", SqlDbType.NVarChar,50),
					new SqlParameter("@VisitId", SqlDbType.NVarChar,50),
					new SqlParameter("@SampleId", SqlDbType.NVarChar,50),
					new SqlParameter("@SampleName", SqlDbType.NVarChar,50),
					new SqlParameter("@OtherInfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.PatientId;
			parameters[1].Value = model.PatientName;
			parameters[2].Value = model.VisitId;
			parameters[3].Value = model.SampleId;
			parameters[4].Value = model.SampleName;
			parameters[5].Value = model.OtherInfo;
			parameters[6].Value = model.Id;

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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SpecimenRt ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SpecimenRt ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
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
		public RuRo.Model.ZSSY.SpecimenRt GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,PatientId,PatientName,VisitId,SampleId,SampleName,OtherInfo from SpecimenRt ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			RuRo.Model.ZSSY.SpecimenRt model=new RuRo.Model.ZSSY.SpecimenRt();
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
		public RuRo.Model.ZSSY.SpecimenRt DataRowToModel(DataRow row)
		{
			RuRo.Model.ZSSY.SpecimenRt model=new RuRo.Model.ZSSY.SpecimenRt();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["PatientId"]!=null)
				{
					model.PatientId=row["PatientId"].ToString();
				}
				if(row["PatientName"]!=null)
				{
					model.PatientName=row["PatientName"].ToString();
				}
				if(row["VisitId"]!=null)
				{
					model.VisitId=row["VisitId"].ToString();
				}
				if(row["SampleId"]!=null)
				{
					model.SampleId=row["SampleId"].ToString();
				}
				if(row["SampleName"]!=null)
				{
					model.SampleName=row["SampleName"].ToString();
				}
				if(row["OtherInfo"]!=null)
				{
					model.OtherInfo=row["OtherInfo"].ToString();
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
			strSql.Append("select Id,PatientId,PatientName,VisitId,SampleId,SampleName,OtherInfo ");
			strSql.Append(" FROM SpecimenRt ");
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
			strSql.Append(" Id,PatientId,PatientName,VisitId,SampleId,SampleName,OtherInfo ");
			strSql.Append(" FROM SpecimenRt ");
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
			strSql.Append("select count(1) FROM SpecimenRt ");
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
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from SpecimenRt T ");
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
			parameters[0].Value = "SpecimenRt";
			parameters[1].Value = "Id";
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

