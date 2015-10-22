using System;
namespace RuRo.Model.ZSSY
{
	/// <summary>
	/// FP中样本源记录
	/// </summary>
	[Serializable]
	public partial class LabTestResult
	{
		public LabTestResult()
		{}
		#region Model
		private int _id;
		private string _reportitemname;
		private string _reportitemcode;
		private string _abnormalindicator;
		private string _result;
		private string _units;
		private string _resultdatetime;
		private string _referenceresult;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 子项名称
		/// </summary>
		public string ReportItemName
		{
			set{ _reportitemname=value;}
			get{return _reportitemname;}
		}
		/// <summary>
		/// 子项编码
		/// </summary>
		public string ReportItemCode
		{
			set{ _reportitemcode=value;}
			get{return _reportitemcode;}
		}
		/// <summary>
		/// N-正常L-低H-高
		/// </summary>
		public string AbnormalIndicator
		{
			set{ _abnormalindicator=value;}
			get{return _abnormalindicator;}
		}
		/// <summary>
		/// 正文描述
		/// </summary>
		public string Result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 检验结果为数值型
		/// </summary>
		public string Units
		{
			set{ _units=value;}
			get{return _units;}
		}
		/// <summary>
		/// 检验日期及时间
		/// </summary>
		public string ResultDateTime
		{
			set{ _resultdatetime=value;}
			get{return _resultdatetime;}
		}
		/// <summary>
		/// 结果参考值
		/// </summary>
		public string ReferenceResult
		{
			set{ _referenceresult=value;}
			get{return _referenceresult;}
		}
		#endregion Model

	}
}

