using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL.ZSSY
{
	/// <summary>
	/// 数据访问类:OPListForSpecimen
	/// </summary>
	public partial class OPListForSpecimen
	{
		public OPListForSpecimen()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(RuRo.Model.ZSSY.OPListForSpecimen model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OPListForSpecimen(");
			strSql.Append("PatientId,InpNO,VisitId,Name,NamePhonetic,Sex,DateOfBirth,BirthPlace,Citizenship,Nation,IDNO,Identity,ChargeType,MailingAddress,ZipCode,PhoneNumberHome,PhoneNumbeBusiness,NextOfKin,RelationShip,NextOfKinAddr,NextOfKinZipCode,NextOfKinPhome,DeptCode,BedNO,AdmissionDateTime,DoctorInCharge,ScheduleId,DiagBeforeOperation,ScheduledDateTime,KeepSpecimenSign,OperatingRoom,Surgeon,InPatPreillness,InPatPastillness,InPatFamillness,LabInfo)");
			strSql.Append(" values (");
			strSql.Append("@PatientId,@InpNO,@VisitId,@Name,@NamePhonetic,@Sex,@DateOfBirth,@BirthPlace,@Citizenship,@Nation,@IDNO,@Identity,@ChargeType,@MailingAddress,@ZipCode,@PhoneNumberHome,@PhoneNumbeBusiness,@NextOfKin,@RelationShip,@NextOfKinAddr,@NextOfKinZipCode,@NextOfKinPhome,@DeptCode,@BedNO,@AdmissionDateTime,@DoctorInCharge,@ScheduleId,@DiagBeforeOperation,@ScheduledDateTime,@KeepSpecimenSign,@OperatingRoom,@Surgeon,@InPatPreillness,@InPatPastillness,@InPatFamillness,@LabInfo)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PatientId", SqlDbType.NVarChar,50),
					new SqlParameter("@InpNO", SqlDbType.NVarChar,50),
					new SqlParameter("@VisitId", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@NamePhonetic", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NChar,10),
					new SqlParameter("@DateOfBirth", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthPlace", SqlDbType.NVarChar,50),
					new SqlParameter("@Citizenship", SqlDbType.NChar,10),
					new SqlParameter("@Nation", SqlDbType.NChar,10),
					new SqlParameter("@IDNO", SqlDbType.NChar,32),
					new SqlParameter("@Identity", SqlDbType.NVarChar,50),
					new SqlParameter("@ChargeType", SqlDbType.NVarChar,50),
					new SqlParameter("@MailingAddress", SqlDbType.NVarChar,256),
					new SqlParameter("@ZipCode", SqlDbType.NChar,10),
					new SqlParameter("@PhoneNumberHome", SqlDbType.NChar,32),
					new SqlParameter("@PhoneNumbeBusiness", SqlDbType.NChar,32),
					new SqlParameter("@NextOfKin", SqlDbType.NVarChar,50),
					new SqlParameter("@RelationShip", SqlDbType.NVarChar,50),
					new SqlParameter("@NextOfKinAddr", SqlDbType.NVarChar,256),
					new SqlParameter("@NextOfKinZipCode", SqlDbType.NVarChar,50),
					new SqlParameter("@NextOfKinPhome", SqlDbType.NChar,32),
					new SqlParameter("@DeptCode", SqlDbType.NVarChar,50),
					new SqlParameter("@BedNO", SqlDbType.NChar,10),
					new SqlParameter("@AdmissionDateTime", SqlDbType.NVarChar,50),
					new SqlParameter("@DoctorInCharge", SqlDbType.NVarChar,50),
					new SqlParameter("@ScheduleId", SqlDbType.NVarChar,50),
					new SqlParameter("@DiagBeforeOperation", SqlDbType.NVarChar,-1),
					new SqlParameter("@ScheduledDateTime", SqlDbType.NVarChar,50),
					new SqlParameter("@KeepSpecimenSign", SqlDbType.NChar,10),
					new SqlParameter("@OperatingRoom", SqlDbType.NVarChar,50),
					new SqlParameter("@Surgeon", SqlDbType.NVarChar,50),
					new SqlParameter("@InPatPreillness", SqlDbType.NVarChar,-1),
					new SqlParameter("@InPatPastillness", SqlDbType.NVarChar,-1),
					new SqlParameter("@InPatFamillness", SqlDbType.NVarChar,-1),
					new SqlParameter("@LabInfo", SqlDbType.NVarChar,128)};
			parameters[0].Value = model.PatientId;
			parameters[1].Value = model.InpNO;
			parameters[2].Value = model.VisitId;
			parameters[3].Value = model.Name;
			parameters[4].Value = model.NamePhonetic;
			parameters[5].Value = model.Sex;
			parameters[6].Value = model.DateOfBirth;
			parameters[7].Value = model.BirthPlace;
			parameters[8].Value = model.Citizenship;
			parameters[9].Value = model.Nation;
			parameters[10].Value = model.IDNO;
			parameters[11].Value = model.Identity;
			parameters[12].Value = model.ChargeType;
			parameters[13].Value = model.MailingAddress;
			parameters[14].Value = model.ZipCode;
			parameters[15].Value = model.PhoneNumberHome;
			parameters[16].Value = model.PhoneNumbeBusiness;
			parameters[17].Value = model.NextOfKin;
			parameters[18].Value = model.RelationShip;
			parameters[19].Value = model.NextOfKinAddr;
			parameters[20].Value = model.NextOfKinZipCode;
			parameters[21].Value = model.NextOfKinPhome;
			parameters[22].Value = model.DeptCode;
			parameters[23].Value = model.BedNO;
			parameters[24].Value = model.AdmissionDateTime;
			parameters[25].Value = model.DoctorInCharge;
			parameters[26].Value = model.ScheduleId;
			parameters[27].Value = model.DiagBeforeOperation;
			parameters[28].Value = model.ScheduledDateTime;
			parameters[29].Value = model.KeepSpecimenSign;
			parameters[30].Value = model.OperatingRoom;
			parameters[31].Value = model.Surgeon;
			parameters[32].Value = model.InPatPreillness;
			parameters[33].Value = model.InPatPastillness;
			parameters[34].Value = model.InPatFamillness;
			parameters[35].Value = model.LabInfo;

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
		public bool Update(RuRo.Model.ZSSY.OPListForSpecimen model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OPListForSpecimen set ");
			strSql.Append("PatientId=@PatientId,");
			strSql.Append("InpNO=@InpNO,");
			strSql.Append("VisitId=@VisitId,");
			strSql.Append("Name=@Name,");
			strSql.Append("NamePhonetic=@NamePhonetic,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("DateOfBirth=@DateOfBirth,");
			strSql.Append("BirthPlace=@BirthPlace,");
			strSql.Append("Citizenship=@Citizenship,");
			strSql.Append("Nation=@Nation,");
			strSql.Append("IDNO=@IDNO,");
			strSql.Append("Identity=@Identity,");
			strSql.Append("ChargeType=@ChargeType,");
			strSql.Append("MailingAddress=@MailingAddress,");
			strSql.Append("ZipCode=@ZipCode,");
			strSql.Append("PhoneNumberHome=@PhoneNumberHome,");
			strSql.Append("PhoneNumbeBusiness=@PhoneNumbeBusiness,");
			strSql.Append("NextOfKin=@NextOfKin,");
			strSql.Append("RelationShip=@RelationShip,");
			strSql.Append("NextOfKinAddr=@NextOfKinAddr,");
			strSql.Append("NextOfKinZipCode=@NextOfKinZipCode,");
			strSql.Append("NextOfKinPhome=@NextOfKinPhome,");
			strSql.Append("DeptCode=@DeptCode,");
			strSql.Append("BedNO=@BedNO,");
			strSql.Append("AdmissionDateTime=@AdmissionDateTime,");
			strSql.Append("DoctorInCharge=@DoctorInCharge,");
			strSql.Append("ScheduleId=@ScheduleId,");
			strSql.Append("DiagBeforeOperation=@DiagBeforeOperation,");
			strSql.Append("ScheduledDateTime=@ScheduledDateTime,");
			strSql.Append("KeepSpecimenSign=@KeepSpecimenSign,");
			strSql.Append("OperatingRoom=@OperatingRoom,");
			strSql.Append("Surgeon=@Surgeon,");
			strSql.Append("InPatPreillness=@InPatPreillness,");
			strSql.Append("InPatPastillness=@InPatPastillness,");
			strSql.Append("InPatFamillness=@InPatFamillness,");
			strSql.Append("LabInfo=@LabInfo");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@PatientId", SqlDbType.NVarChar,50),
					new SqlParameter("@InpNO", SqlDbType.NVarChar,50),
					new SqlParameter("@VisitId", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@NamePhonetic", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NChar,10),
					new SqlParameter("@DateOfBirth", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthPlace", SqlDbType.NVarChar,50),
					new SqlParameter("@Citizenship", SqlDbType.NChar,10),
					new SqlParameter("@Nation", SqlDbType.NChar,10),
					new SqlParameter("@IDNO", SqlDbType.NChar,32),
					new SqlParameter("@Identity", SqlDbType.NVarChar,50),
					new SqlParameter("@ChargeType", SqlDbType.NVarChar,50),
					new SqlParameter("@MailingAddress", SqlDbType.NVarChar,256),
					new SqlParameter("@ZipCode", SqlDbType.NChar,10),
					new SqlParameter("@PhoneNumberHome", SqlDbType.NChar,32),
					new SqlParameter("@PhoneNumbeBusiness", SqlDbType.NChar,32),
					new SqlParameter("@NextOfKin", SqlDbType.NVarChar,50),
					new SqlParameter("@RelationShip", SqlDbType.NVarChar,50),
					new SqlParameter("@NextOfKinAddr", SqlDbType.NVarChar,256),
					new SqlParameter("@NextOfKinZipCode", SqlDbType.NVarChar,50),
					new SqlParameter("@NextOfKinPhome", SqlDbType.NChar,32),
					new SqlParameter("@DeptCode", SqlDbType.NVarChar,50),
					new SqlParameter("@BedNO", SqlDbType.NChar,10),
					new SqlParameter("@AdmissionDateTime", SqlDbType.NVarChar,50),
					new SqlParameter("@DoctorInCharge", SqlDbType.NVarChar,50),
					new SqlParameter("@ScheduleId", SqlDbType.NVarChar,50),
					new SqlParameter("@DiagBeforeOperation", SqlDbType.NVarChar,-1),
					new SqlParameter("@ScheduledDateTime", SqlDbType.NVarChar,50),
					new SqlParameter("@KeepSpecimenSign", SqlDbType.NChar,10),
					new SqlParameter("@OperatingRoom", SqlDbType.NVarChar,50),
					new SqlParameter("@Surgeon", SqlDbType.NVarChar,50),
					new SqlParameter("@InPatPreillness", SqlDbType.NVarChar,-1),
					new SqlParameter("@InPatPastillness", SqlDbType.NVarChar,-1),
					new SqlParameter("@InPatFamillness", SqlDbType.NVarChar,-1),
					new SqlParameter("@LabInfo", SqlDbType.NVarChar,128),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.PatientId;
			parameters[1].Value = model.InpNO;
			parameters[2].Value = model.VisitId;
			parameters[3].Value = model.Name;
			parameters[4].Value = model.NamePhonetic;
			parameters[5].Value = model.Sex;
			parameters[6].Value = model.DateOfBirth;
			parameters[7].Value = model.BirthPlace;
			parameters[8].Value = model.Citizenship;
			parameters[9].Value = model.Nation;
			parameters[10].Value = model.IDNO;
			parameters[11].Value = model.Identity;
			parameters[12].Value = model.ChargeType;
			parameters[13].Value = model.MailingAddress;
			parameters[14].Value = model.ZipCode;
			parameters[15].Value = model.PhoneNumberHome;
			parameters[16].Value = model.PhoneNumbeBusiness;
			parameters[17].Value = model.NextOfKin;
			parameters[18].Value = model.RelationShip;
			parameters[19].Value = model.NextOfKinAddr;
			parameters[20].Value = model.NextOfKinZipCode;
			parameters[21].Value = model.NextOfKinPhome;
			parameters[22].Value = model.DeptCode;
			parameters[23].Value = model.BedNO;
			parameters[24].Value = model.AdmissionDateTime;
			parameters[25].Value = model.DoctorInCharge;
			parameters[26].Value = model.ScheduleId;
			parameters[27].Value = model.DiagBeforeOperation;
			parameters[28].Value = model.ScheduledDateTime;
			parameters[29].Value = model.KeepSpecimenSign;
			parameters[30].Value = model.OperatingRoom;
			parameters[31].Value = model.Surgeon;
			parameters[32].Value = model.InPatPreillness;
			parameters[33].Value = model.InPatPastillness;
			parameters[34].Value = model.InPatFamillness;
			parameters[35].Value = model.LabInfo;
			parameters[36].Value = model.Id;

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
			strSql.Append("delete from OPListForSpecimen ");
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
			strSql.Append("delete from OPListForSpecimen ");
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
		public RuRo.Model.ZSSY.OPListForSpecimen GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,PatientId,InpNO,VisitId,Name,NamePhonetic,Sex,DateOfBirth,BirthPlace,Citizenship,Nation,IDNO,Identity,ChargeType,MailingAddress,ZipCode,PhoneNumberHome,PhoneNumbeBusiness,NextOfKin,RelationShip,NextOfKinAddr,NextOfKinZipCode,NextOfKinPhome,DeptCode,BedNO,AdmissionDateTime,DoctorInCharge,ScheduleId,DiagBeforeOperation,ScheduledDateTime,KeepSpecimenSign,OperatingRoom,Surgeon,InPatPreillness,InPatPastillness,InPatFamillness,LabInfo from OPListForSpecimen ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			RuRo.Model.ZSSY.OPListForSpecimen model=new RuRo.Model.ZSSY.OPListForSpecimen();
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
		public RuRo.Model.ZSSY.OPListForSpecimen DataRowToModel(DataRow row)
		{
			RuRo.Model.ZSSY.OPListForSpecimen model=new RuRo.Model.ZSSY.OPListForSpecimen();
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
				if(row["InpNO"]!=null)
				{
					model.InpNO=row["InpNO"].ToString();
				}
				if(row["VisitId"]!=null)
				{
					model.VisitId=row["VisitId"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["NamePhonetic"]!=null)
				{
					model.NamePhonetic=row["NamePhonetic"].ToString();
				}
				if(row["Sex"]!=null)
				{
					model.Sex=row["Sex"].ToString();
				}
				if(row["DateOfBirth"]!=null)
				{
					model.DateOfBirth=row["DateOfBirth"].ToString();
				}
				if(row["BirthPlace"]!=null)
				{
					model.BirthPlace=row["BirthPlace"].ToString();
				}
				if(row["Citizenship"]!=null)
				{
					model.Citizenship=row["Citizenship"].ToString();
				}
				if(row["Nation"]!=null)
				{
					model.Nation=row["Nation"].ToString();
				}
				if(row["IDNO"]!=null)
				{
					model.IDNO=row["IDNO"].ToString();
				}
				if(row["Identity"]!=null)
				{
					model.Identity=row["Identity"].ToString();
				}
				if(row["ChargeType"]!=null)
				{
					model.ChargeType=row["ChargeType"].ToString();
				}
				if(row["MailingAddress"]!=null)
				{
					model.MailingAddress=row["MailingAddress"].ToString();
				}
				if(row["ZipCode"]!=null)
				{
					model.ZipCode=row["ZipCode"].ToString();
				}
				if(row["PhoneNumberHome"]!=null)
				{
					model.PhoneNumberHome=row["PhoneNumberHome"].ToString();
				}
				if(row["PhoneNumbeBusiness"]!=null)
				{
					model.PhoneNumbeBusiness=row["PhoneNumbeBusiness"].ToString();
				}
				if(row["NextOfKin"]!=null)
				{
					model.NextOfKin=row["NextOfKin"].ToString();
				}
				if(row["RelationShip"]!=null)
				{
					model.RelationShip=row["RelationShip"].ToString();
				}
				if(row["NextOfKinAddr"]!=null)
				{
					model.NextOfKinAddr=row["NextOfKinAddr"].ToString();
				}
				if(row["NextOfKinZipCode"]!=null)
				{
					model.NextOfKinZipCode=row["NextOfKinZipCode"].ToString();
				}
				if(row["NextOfKinPhome"]!=null)
				{
					model.NextOfKinPhome=row["NextOfKinPhome"].ToString();
				}
				if(row["DeptCode"]!=null)
				{
					model.DeptCode=row["DeptCode"].ToString();
				}
				if(row["BedNO"]!=null)
				{
					model.BedNO=row["BedNO"].ToString();
				}
				if(row["AdmissionDateTime"]!=null)
				{
					model.AdmissionDateTime=row["AdmissionDateTime"].ToString();
				}
				if(row["DoctorInCharge"]!=null)
				{
					model.DoctorInCharge=row["DoctorInCharge"].ToString();
				}
				if(row["ScheduleId"]!=null)
				{
					model.ScheduleId=row["ScheduleId"].ToString();
				}
				if(row["DiagBeforeOperation"]!=null)
				{
					model.DiagBeforeOperation=row["DiagBeforeOperation"].ToString();
				}
				if(row["ScheduledDateTime"]!=null)
				{
					model.ScheduledDateTime=row["ScheduledDateTime"].ToString();
				}
				if(row["KeepSpecimenSign"]!=null)
				{
					model.KeepSpecimenSign=row["KeepSpecimenSign"].ToString();
				}
				if(row["OperatingRoom"]!=null)
				{
					model.OperatingRoom=row["OperatingRoom"].ToString();
				}
				if(row["Surgeon"]!=null)
				{
					model.Surgeon=row["Surgeon"].ToString();
				}
				if(row["InPatPreillness"]!=null)
				{
					model.InPatPreillness=row["InPatPreillness"].ToString();
				}
				if(row["InPatPastillness"]!=null)
				{
					model.InPatPastillness=row["InPatPastillness"].ToString();
				}
				if(row["InPatFamillness"]!=null)
				{
					model.InPatFamillness=row["InPatFamillness"].ToString();
				}
				if(row["LabInfo"]!=null)
				{
					model.LabInfo=row["LabInfo"].ToString();
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
			strSql.Append("select Id,PatientId,InpNO,VisitId,Name,NamePhonetic,Sex,DateOfBirth,BirthPlace,Citizenship,Nation,IDNO,Identity,ChargeType,MailingAddress,ZipCode,PhoneNumberHome,PhoneNumbeBusiness,NextOfKin,RelationShip,NextOfKinAddr,NextOfKinZipCode,NextOfKinPhome,DeptCode,BedNO,AdmissionDateTime,DoctorInCharge,ScheduleId,DiagBeforeOperation,ScheduledDateTime,KeepSpecimenSign,OperatingRoom,Surgeon,InPatPreillness,InPatPastillness,InPatFamillness,LabInfo ");
			strSql.Append(" FROM OPListForSpecimen ");
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
			strSql.Append(" Id,PatientId,InpNO,VisitId,Name,NamePhonetic,Sex,DateOfBirth,BirthPlace,Citizenship,Nation,IDNO,Identity,ChargeType,MailingAddress,ZipCode,PhoneNumberHome,PhoneNumbeBusiness,NextOfKin,RelationShip,NextOfKinAddr,NextOfKinZipCode,NextOfKinPhome,DeptCode,BedNO,AdmissionDateTime,DoctorInCharge,ScheduleId,DiagBeforeOperation,ScheduledDateTime,KeepSpecimenSign,OperatingRoom,Surgeon,InPatPreillness,InPatPastillness,InPatFamillness,LabInfo ");
			strSql.Append(" FROM OPListForSpecimen ");
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
			strSql.Append("select count(1) FROM OPListForSpecimen ");
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
			strSql.Append(")AS Row, T.*  from OPListForSpecimen T ");
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
			parameters[0].Value = "OPListForSpecimen";
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

