using System;
namespace WZY.Model
{
	/// <summary>
	/// SYSUSER:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SYSUSER
	{
		public SYSUSER()
		{}
		#region Model
		private int _uid;
		private int? _roleid;
		private int? _deptid;
		private string _username;
		private string _password;
		private string _displayname;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? roleid
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? deptid
		{
			set{ _deptid=value;}
			get{return _deptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string displayname
		{
			set{ _displayname=value;}
			get{return _displayname;}
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

        public int stat { get; set; }
        public string pycode { get; set; }

	}
}

