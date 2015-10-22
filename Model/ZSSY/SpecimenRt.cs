using System;
namespace RuRo.Model.ZSSY
{
	/// <summary>
	/// 主要作用是用于判断是否需要回发给His
	/// </summary>
	[Serializable]
	public partial class SpecimenRt
	{
		public SpecimenRt()
		{}
		#region Model
		private int _id;
		private string _patientid;
		private string _patientname;
		private string _visitid;
		private string _sampleid;
		private string _samplename;
		private string _otherinfo;
		/// <summary>
		/// 序号自增列
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 患者唯一标识号
		/// </summary>
		public string PatientId
		{
			set{ _patientid=value;}
			get{return _patientid;}
		}
		/// <summary>
		/// 患者名称
		/// </summary>
		public string PatientName
		{
			set{ _patientname=value;}
			get{return _patientname;}
		}
		/// <summary>
		/// 患者就诊号
		/// </summary>
		public string VisitId
		{
			set{ _visitid=value;}
			get{return _visitid;}
		}
		/// <summary>
		/// 样本Id
		/// </summary>
		public string SampleId
		{
			set{ _sampleid=value;}
			get{return _sampleid;}
		}
		/// <summary>
		/// 样本Name
		/// </summary>
		public string SampleName
		{
			set{ _samplename=value;}
			get{return _samplename;}
		}
		/// <summary>
		/// 其他信息（样本类型、总管数、在库管数、出库管数、创建时间、更新时间）
		/// </summary>
		public string OtherInfo
		{
			set{ _otherinfo=value;}
			get{return _otherinfo;}
		}
		#endregion Model

	}
}

