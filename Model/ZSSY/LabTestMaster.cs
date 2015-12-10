using System;
namespace RuRo.Model.ZSSY
{
	/// <summary>
	/// FP中样本源记录
	/// </summary>
	[Serializable]
	public partial class LabTestMaster
	{
		public LabTestMaster() 
		{}
		#region Model
		private int _id;
		private string _testno;
		private string _priorityindicator;
		private string _workingid;
		private string _testcause;
		private string _relevantclinicdiag;
		private string _specimen;
		private string _spcmreceiveddatetime;
		private string _orderingdept;
		private string _orderingprovider;
		private string _performedby;
		private string _resultstatus;
		private string _resultsrptdatetime;
		private string _transcriptionist;
		private string _verifiedby;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 检验申请单号
		/// </summary>
		public string TestNo
		{
			set{ _testno=value;}
			get{return _testno;}
		}
		/// <summary>
		/// 优先标志
		/// </summary>
		public string priorityIndicator
		{
			set{ _priorityindicator=value;}
			get{return _priorityindicator;}
		}
		/// <summary>
		/// 工作单号
		/// </summary>
		public string WorkingId
		{
			set{ _workingid=value;}
			get{return _workingid;}
		}
		/// <summary>
		/// 检验目的
		/// </summary>
		public string TestCause
		{
			set{ _testcause=value;}
			get{return _testcause;}
		}
		/// <summary>
		/// 临床诊断
		/// </summary>
		public string RelevantClinicDiag
		{
			set{ _relevantclinicdiag=value;}
			get{return _relevantclinicdiag;}
		}
		/// <summary>
		/// 标本
		/// </summary>
		public string Specimen
		{
			set{ _specimen=value;}
			get{return _specimen;}
		}
		/// <summary>
		/// 采样时间
		/// </summary>
		public string SpcmReceivedDateTime
		{
			set{ _spcmreceiveddatetime=value;}
			get{return _spcmreceiveddatetime;}
		}
		/// <summary>
		/// 开医嘱科室
		/// </summary>
		public string OrderingDept
		{
			set{ _orderingdept=value;}
			get{return _orderingdept;}
		}
		/// <summary>
		/// 医生工号
		/// </summary>
		public string orderingProvider
		{
			set{ _orderingprovider=value;}
			get{return _orderingprovider;}
		}
		/// <summary>
		/// 执行科室
		/// </summary>
		public string PerformedBy
		{
			set{ _performedby=value;}
			get{return _performedby;}
		}
		/// <summary>
		/// 执行情况
		/// </summary>
		public string ResultStatus
		{
			set{ _resultstatus=value;}
			get{return _resultstatus;}
		}
		/// <summary>
		/// 报告完成时间
		/// </summary>
		public string ResultsRptDateTime
		{
			set{ _resultsrptdatetime=value;}
			get{return _resultsrptdatetime;}
		}
		/// <summary>
		/// 报告者工号
		/// </summary>
		public string transcriptionist
		{
			set{ _transcriptionist=value;}
			get{return _transcriptionist;}
		}
		/// <summary>
		/// 审核者工号
		/// </summary>
		public string VerifiedBy
		{
			set{ _verifiedby=value;}
			get{return _verifiedby;}
		}
		#endregion Model

	}
}

