using System;
namespace WZY.Model
{
	/// <summary>
	/// DOCS:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DOCS
	{
		public DOCS()
		{}
		#region Model
		private int _docid;
		private int? _uid;
		private int? _cateid;
		private int? _custid;
		private string _docname;
		private string _docpath;
		private DateTime? _uptime;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int docid
		{
			set{ _docid=value;}
			get{return _docid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? cateid
		{
			set{ _cateid=value;}
			get{return _cateid;}
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
		public string docname
		{
			set{ _docname=value;}
			get{return _docname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string docpath
		{
			set{ _docpath=value;}
			get{return _docpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? uptime
		{
			set{ _uptime=value;}
			get{return _uptime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

