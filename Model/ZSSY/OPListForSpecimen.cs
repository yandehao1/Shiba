using System;
namespace RuRo.Model.ZSSY
{
	/// <summary>
	/// FP中样本源记录
	/// </summary>
	[Serializable]
	public partial class OPListForSpecimen
	{
		public OPListForSpecimen()
		{}
		#region Model
		private int _id;
		private string _patientid;
		private string _inpno;
		private string _visitid;
		private string _name;
		private string _namephonetic;
		private string _sex;
		private string _dateofbirth;
		private string _birthplace;
		private string _citizenship;
		private string _nation;
		private string _idno;
		private string _identity;
		private string _chargetype;
		private string _mailingaddress;
		private string _zipcode;
		private string _phonenumberhome;
		private string _phonenumbebusiness;
		private string _nextofkin;
		private string _relationship;
		private string _nextofkinaddr;
		private string _nextofkinzipcode;
		private string _nextofkinphome;
		private string _deptcode;
		private string _bedno;
		private string _admissiondatetime;
		private string _doctorincharge;
		private string _scheduleid;
		private string _diagbeforeoperation;
		private string _scheduleddatetime;
		private string _keepspecimensign;
		private string _operatingroom;
		private string _surgeon;
		private string _inpatpreillness;
		private string _inpatpastillness;
		private string _inpatfamillness;
		private string _labinfo;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 病人唯一标识号
		/// </summary>
		public string PatientId
		{
			set{ _patientid=value;}
			get{return _patientid;}
		}
		/// <summary>
		/// 住院号
		/// </summary>
		public string InpNO
		{
			set{ _inpno=value;}
			get{return _inpno;}
		}
		/// <summary>
		/// 就诊号
		/// </summary>
		public string VisitId
		{
			set{ _visitid=value;}
			get{return _visitid;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 姓名拼音
		/// </summary>
		public string NamePhonetic
		{
			set{ _namephonetic=value;}
			get{return _namephonetic;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 出生日期
		/// </summary>
		public string DateOfBirth
		{
			set{ _dateofbirth=value;}
			get{return _dateofbirth;}
		}
		/// <summary>
		/// 行政区名称
		/// </summary>
		public string BirthPlace
		{
			set{ _birthplace=value;}
			get{return _birthplace;}
		}
		/// <summary>
		/// 国家简称
		/// </summary>
		public string Citizenship
		{
			set{ _citizenship=value;}
			get{return _citizenship;}
		}
		/// <summary>
		/// 民族
		/// </summary>
		public string Nation
		{
			set{ _nation=value;}
			get{return _nation;}
		}
		/// <summary>
		/// 身份证号
		/// </summary>
		public string IDNO
		{
			set{ _idno=value;}
			get{return _idno;}
		}
		/// <summary>
		/// 患者工作身份
		/// </summary>
		public string Identity
		{
			set{ _identity=value;}
			get{return _identity;}
		}
		/// <summary>
		/// 病人收费类别
		/// </summary>
		public string ChargeType
		{
			set{ _chargetype=value;}
			get{return _chargetype;}
		}
		/// <summary>
		/// 永久通信地址
		/// </summary>
		public string MailingAddress
		{
			set{ _mailingaddress=value;}
			get{return _mailingaddress;}
		}
		/// <summary>
		/// 邮政编码
		/// </summary>
		public string ZipCode
		{
			set{ _zipcode=value;}
			get{return _zipcode;}
		}
		/// <summary>
		/// 家庭电话号码
		/// </summary>
		public string PhoneNumberHome
		{
			set{ _phonenumberhome=value;}
			get{return _phonenumberhome;}
		}
		/// <summary>
		/// 单位电话号码
		/// </summary>
		public string PhoneNumbeBusiness
		{
			set{ _phonenumbebusiness=value;}
			get{return _phonenumbebusiness;}
		}
		/// <summary>
		/// 亲属姓名
		/// </summary>
		public string NextOfKin
		{
			set{ _nextofkin=value;}
			get{return _nextofkin;}
		}
		/// <summary>
		/// 亲属关系
		/// </summary>
		public string RelationShip
		{
			set{ _relationship=value;}
			get{return _relationship;}
		}
		/// <summary>
		/// 联系人地址
		/// </summary>
		public string NextOfKinAddr
		{
			set{ _nextofkinaddr=value;}
			get{return _nextofkinaddr;}
		}
		/// <summary>
		/// 联系人邮政编码
		/// </summary>
		public string NextOfKinZipCode
		{
			set{ _nextofkinzipcode=value;}
			get{return _nextofkinzipcode;}
		}
		/// <summary>
		/// 联系人电话号码
		/// </summary>
		public string NextOfKinPhome
		{
			set{ _nextofkinphome=value;}
			get{return _nextofkinphome;}
		}
		/// <summary>
		/// 当前科室代码@名称
		/// </summary>
		public string DeptCode
		{
			set{ _deptcode=value;}
			get{return _deptcode;}
		}
		/// <summary>
		/// 病人所住床号
		/// </summary>
		public string BedNO
		{
			set{ _bedno=value;}
			get{return _bedno;}
		}
		/// <summary>
		/// 入院日期及时间
		/// </summary>
		public string AdmissionDateTime
		{
			set{ _admissiondatetime=value;}
			get{return _admissiondatetime;}
		}
		/// <summary>
		/// 主治医生工号@姓名
		/// </summary>
		public string DoctorInCharge
		{
			set{ _doctorincharge=value;}
			get{return _doctorincharge;}
		}
		/// <summary>
		/// 手术id号
		/// </summary>
		public string ScheduleId
		{
			set{ _scheduleid=value;}
			get{return _scheduleid;}
		}
		/// <summary>
		/// 主要诊断
		/// </summary>
		public string DiagBeforeOperation
		{
			set{ _diagbeforeoperation=value;}
			get{return _diagbeforeoperation;}
		}
		/// <summary>
		/// 预约进行该次手术的日期及时间
		/// </summary>
		public string ScheduledDateTime
		{
			set{ _scheduleddatetime=value;}
			get{return _scheduleddatetime;}
		}
		/// <summary>
		/// 是否留标本
		/// </summary>
		public string KeepSpecimenSign
		{
			set{ _keepspecimensign=value;}
			get{return _keepspecimensign;}
		}
		/// <summary>
		/// 手术室代码@名称
		/// </summary>
		public string OperatingRoom
		{
			set{ _operatingroom=value;}
			get{return _operatingroom;}
		}
		/// <summary>
		/// 手术医师工号@姓名
		/// </summary>
		public string Surgeon
		{
			set{ _surgeon=value;}
			get{return _surgeon;}
		}
		/// <summary>
		/// 现病史
		/// </summary>
		public string InPatPreillness
		{
			set{ _inpatpreillness=value;}
			get{return _inpatpreillness;}
		}
		/// <summary>
		/// 既往史
		/// </summary>
		public string InPatPastillness
		{
			set{ _inpatpastillness=value;}
			get{return _inpatpastillness;}
		}
		/// <summary>
		/// 家族史
		/// </summary>
		public string InPatFamillness
		{
			set{ _inpatfamillness=value;}
			get{return _inpatfamillness;}
		}
		/// <summary>
		/// 乙肝梅毒等阳性结果
		/// </summary>
		public string LabInfo
		{
			set{ _labinfo=value;}
			get{return _labinfo;}
		}
		#endregion Model

	}
}

