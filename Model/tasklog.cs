using System;
namespace WZY.Model
{
	/// <summary>
	/// tasklog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class tasklog
	{
		public tasklog()
		{}
		#region Model
		private int _recid;
		private DateTime _rectime;
		private DateTime? _expiretime;
		private int? _custid;
		private int? _userid;
		private int? _agentid;
		private string _tasklist;
		private string _footlist;
		private string _feedback;
		/// <summary>
		/// 
		/// </summary>
		public int recid
		{
			set{ _recid=value;}
			get{return _recid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime rectime
		{
			set{ _rectime=value;}
			get{return _rectime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? expiretime
		{
			set{ _expiretime=value;}
			get{return _expiretime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? custid
		{
			set{ _custid=value;}
			get{return _custid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? agentid
		{
			set{ _agentid=value;}
			get{return _agentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tasklist
		{
			set{ _tasklist=value;}
			get{return _tasklist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string footlist
		{
			set{ _footlist=value;}
			get{return _footlist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string feedback
		{
			set{ _feedback=value;}
			get{return _feedback;}
		}
		#endregion Model

	}
}

