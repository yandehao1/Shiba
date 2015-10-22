using System;
namespace RuRo.Model.ZSSY
{
	/// <summary>
	/// FP中样本源记录
	/// </summary>
	[Serializable]
	public partial class ImportSampleSourceLog
	{
		public ImportSampleSourceLog()
		{}
		#region Model
		private int _id;
		private string _samplesourcename;
		private string _samplesourcetype;
		private string _samplesourcedescription;
		private string _patientid;
		private string _patientname;
		private string _patientsex;
		private string _importstatus;
		private string _hidden;
		private string _resultstatus;
		private DateTime? _importdate= DateTime.Now;
		/// <summary>
		/// 自增列
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 样本源Name
		/// </summary>
		public string sampleSourceName
		{
			set{ _samplesourcename=value;}
			get{return _samplesourcename;}
		}
		/// <summary>
		/// 样本源类型
		/// </summary>
		public string sampleSourceType
		{
			set{ _samplesourcetype=value;}
			get{return _samplesourcetype;}
		}
		/// <summary>
		/// 样本源描述
		/// </summary>
		public string sampleSourceDescription
		{
			set{ _samplesourcedescription=value;}
			get{return _samplesourcedescription;}
		}
		/// <summary>
		/// 患者唯一标识
		/// </summary>
		public string patientId
		{
			set{ _patientid=value;}
			get{return _patientid;}
		}
		/// <summary>
		/// 患者姓名
		/// </summary>
		public string patientName
		{
			set{ _patientname=value;}
			get{return _patientname;}
		}
		/// <summary>
		/// 患者性别
		/// </summary>
		public string patientSex
		{
			set{ _patientsex=value;}
			get{return _patientsex;}
		}
		/// <summary>
		/// 导入数据之前的状态
		/// </summary>
		public string importStatus
		{
			set{ _importstatus=value;}
			get{return _importstatus;}
		}
		/// <summary>
		/// 隐藏域数据
		/// </summary>
		public string hidden
		{
			set{ _hidden=value;}
			get{return _hidden;}
		}
		/// <summary>
		/// 导入数据之后的状态
		/// </summary>
		public string ResultStatus
		{
			set{ _resultstatus=value;}
			get{return _resultstatus;}
		}
		/// <summary>
		/// 执行导入的时间
		/// </summary>
		public DateTime? ImportDate
		{
			set{ _importdate=value;}
			get{return _importdate;}
		}
		#endregion Model

	}
}

