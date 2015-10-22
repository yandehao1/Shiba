using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL.ZSSY
{
	/// <summary>
	/// 数据访问类:LabTestMaster
	/// </summary>
	public partial class LabTestMaster
	{
		public LabTestMaster()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(RuRo.Model.ZSSY.LabTestMaster model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LabTestMaster(");
			strSql.Append("Id,TestNo,priorityIndicator,WorkingId,TestCause,RelevantClinicDiag,Specimen,SpcmReceivedDateTime,OrderingDept,orderingProvider,PerformedBy,ResultStatus,ResultsRptDateTime,transcriptionist,VerifiedBy)");
			strSql.Append(" values (");
			strSql.Append("@Id,@TestNo,@priorityIndicator,@WorkingId,@TestCause,@RelevantClinicDiag,@Specimen,@SpcmReceivedDateTime,@OrderingDept,@orderingProvider,@PerformedBy,@ResultStatus,@ResultsRptDateTime,@transcriptionist,@VerifiedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@TestNo", SqlDbType.NVarChar,50),
					new SqlParameter("@priorityIndicator", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkingId", SqlDbType.NVarChar,50),
					new SqlParameter("@TestCause", SqlDbType.NVarChar,50),
					new SqlParameter("@RelevantClinicDiag", SqlDbType.NVarChar,-1),
					new SqlParameter("@Specimen", SqlDbType.NVarChar,50),
					new SqlParameter("@SpcmReceivedDateTime", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderingDept", SqlDbType.NVarChar,50),
					new SqlParameter("@orderingProvider", SqlDbType.NVarChar,50),
					new SqlParameter("@PerformedBy", SqlDbType.NVarChar,50),
					new SqlParameter("@ResultStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@ResultsRptDateTime", SqlDbType.NVarChar,50),
					new SqlParameter("@transcriptionist", SqlDbType.NVarChar,50),
					new SqlParameter("@VerifiedBy", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.TestNo;
			parameters[2].Value = model.priorityIndicator;
			parameters[3].Value = model.WorkingId;
			parameters[4].Value = model.TestCause;
			parameters[5].Value = model.RelevantClinicDiag;
			parameters[6].Value = model.Specimen;
			parameters[7].Value = model.SpcmReceivedDateTime;
			parameters[8].Value = model.OrderingDept;
			parameters[9].Value = model.orderingProvider;
			parameters[10].Value = model.PerformedBy;
			parameters[11].Value = model.ResultStatus;
			parameters[12].Value = model.ResultsRptDateTime;
			parameters[13].Value = model.transcriptionist;
			parameters[14].Value = model.VerifiedBy;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(RuRo.Model.ZSSY.LabTestMaster model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LabTestMaster set ");
			strSql.Append("Id=@Id,");
			strSql.Append("TestNo=@TestNo,");
			strSql.Append("priorityIndicator=@priorityIndicator,");
			strSql.Append("WorkingId=@WorkingId,");
			strSql.Append("TestCause=@TestCause,");
			strSql.Append("RelevantClinicDiag=@RelevantClinicDiag,");
			strSql.Append("Specimen=@Specimen,");
			strSql.Append("SpcmReceivedDateTime=@SpcmReceivedDateTime,");
			strSql.Append("OrderingDept=@OrderingDept,");
			strSql.Append("orderingProvider=@orderingProvider,");
			strSql.Append("PerformedBy=@PerformedBy,");
			strSql.Append("ResultStatus=@ResultStatus,");
			strSql.Append("ResultsRptDateTime=@ResultsRptDateTime,");
			strSql.Append("transcriptionist=@transcriptionist,");
			strSql.Append("VerifiedBy=@VerifiedBy");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@TestNo", SqlDbType.NVarChar,50),
					new SqlParameter("@priorityIndicator", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkingId", SqlDbType.NVarChar,50),
					new SqlParameter("@TestCause", SqlDbType.NVarChar,50),
					new SqlParameter("@RelevantClinicDiag", SqlDbType.NVarChar,-1),
					new SqlParameter("@Specimen", SqlDbType.NVarChar,50),
					new SqlParameter("@SpcmReceivedDateTime", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderingDept", SqlDbType.NVarChar,50),
					new SqlParameter("@orderingProvider", SqlDbType.NVarChar,50),
					new SqlParameter("@PerformedBy", SqlDbType.NVarChar,50),
					new SqlParameter("@ResultStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@ResultsRptDateTime", SqlDbType.NVarChar,50),
					new SqlParameter("@transcriptionist", SqlDbType.NVarChar,50),
					new SqlParameter("@VerifiedBy", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.TestNo;
			parameters[2].Value = model.priorityIndicator;
			parameters[3].Value = model.WorkingId;
			parameters[4].Value = model.TestCause;
			parameters[5].Value = model.RelevantClinicDiag;
			parameters[6].Value = model.Specimen;
			parameters[7].Value = model.SpcmReceivedDateTime;
			parameters[8].Value = model.OrderingDept;
			parameters[9].Value = model.orderingProvider;
			parameters[10].Value = model.PerformedBy;
			parameters[11].Value = model.ResultStatus;
			parameters[12].Value = model.ResultsRptDateTime;
			parameters[13].Value = model.transcriptionist;
			parameters[14].Value = model.VerifiedBy;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LabTestMaster ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public RuRo.Model.ZSSY.LabTestMaster GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,TestNo,priorityIndicator,WorkingId,TestCause,RelevantClinicDiag,Specimen,SpcmReceivedDateTime,OrderingDept,orderingProvider,PerformedBy,ResultStatus,ResultsRptDateTime,transcriptionist,VerifiedBy from LabTestMaster ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			RuRo.Model.ZSSY.LabTestMaster model=new RuRo.Model.ZSSY.LabTestMaster();
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
		public RuRo.Model.ZSSY.LabTestMaster DataRowToModel(DataRow row)
		{
			RuRo.Model.ZSSY.LabTestMaster model=new RuRo.Model.ZSSY.LabTestMaster();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["TestNo"]!=null)
				{
					model.TestNo=row["TestNo"].ToString();
				}
				if(row["priorityIndicator"]!=null)
				{
					model.priorityIndicator=row["priorityIndicator"].ToString();
				}
				if(row["WorkingId"]!=null)
				{
					model.WorkingId=row["WorkingId"].ToString();
				}
				if(row["TestCause"]!=null)
				{
					model.TestCause=row["TestCause"].ToString();
				}
				if(row["RelevantClinicDiag"]!=null)
				{
					model.RelevantClinicDiag=row["RelevantClinicDiag"].ToString();
				}
				if(row["Specimen"]!=null)
				{
					model.Specimen=row["Specimen"].ToString();
				}
				if(row["SpcmReceivedDateTime"]!=null)
				{
					model.SpcmReceivedDateTime=row["SpcmReceivedDateTime"].ToString();
				}
				if(row["OrderingDept"]!=null)
				{
					model.OrderingDept=row["OrderingDept"].ToString();
				}
				if(row["orderingProvider"]!=null)
				{
					model.orderingProvider=row["orderingProvider"].ToString();
				}
				if(row["PerformedBy"]!=null)
				{
					model.PerformedBy=row["PerformedBy"].ToString();
				}
				if(row["ResultStatus"]!=null)
				{
					model.ResultStatus=row["ResultStatus"].ToString();
				}
				if(row["ResultsRptDateTime"]!=null)
				{
					model.ResultsRptDateTime=row["ResultsRptDateTime"].ToString();
				}
				if(row["transcriptionist"]!=null)
				{
					model.transcriptionist=row["transcriptionist"].ToString();
				}
				if(row["VerifiedBy"]!=null)
				{
					model.VerifiedBy=row["VerifiedBy"].ToString();
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
			strSql.Append("select Id,TestNo,priorityIndicator,WorkingId,TestCause,RelevantClinicDiag,Specimen,SpcmReceivedDateTime,OrderingDept,orderingProvider,PerformedBy,ResultStatus,ResultsRptDateTime,transcriptionist,VerifiedBy ");
			strSql.Append(" FROM LabTestMaster ");
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
			strSql.Append(" Id,TestNo,priorityIndicator,WorkingId,TestCause,RelevantClinicDiag,Specimen,SpcmReceivedDateTime,OrderingDept,orderingProvider,PerformedBy,ResultStatus,ResultsRptDateTime,transcriptionist,VerifiedBy ");
			strSql.Append(" FROM LabTestMaster ");
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
			strSql.Append("select count(1) FROM LabTestMaster ");
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
			strSql.Append(")AS Row, T.*  from LabTestMaster T ");
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
			parameters[0].Value = "LabTestMaster";
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

