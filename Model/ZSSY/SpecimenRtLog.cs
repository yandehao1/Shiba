using System;
namespace RuRo.Model.ZSSY
{
	/// <summary>
	/// 回发数据记录存档
	/// </summary>
	[Serializable]
	public partial class SpecimenRtLog
	{
		public SpecimenRtLog()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _patiendid;
		private string _sampleid;
		private string _postbackstatus;
		private DateTime? _postbackdate= DateTime.Now;
		/// <summary>
		/// 自增列
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 回发此数据的用户
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 回发的患者唯一标识
		/// </summary>
		public string PatiendId
		{
			set{ _patiendid=value;}
			get{return _patiendid;}
		}
		/// <summary>
		/// 回发的样本id
		/// </summary>
		public string SampleId
		{
			set{ _sampleid=value;}
			get{return _sampleid;}
		}
		/// <summary>
		/// 回发后的状态
		/// </summary>
		public string PostBackStatus
		{
			set{ _postbackstatus=value;}
			get{return _postbackstatus;}
		}
		/// <summary>
		/// 回发时间
		/// </summary>
		public DateTime? PostBackDate
		{
			set{ _postbackdate=value;}
			get{return _postbackdate;}
		}
		#endregion Model

	}
}

