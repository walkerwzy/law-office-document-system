using System;
namespace WZY.Model
{
	/// <summary>
	/// SYSROLE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SYSROLE
	{
		public SYSROLE()
		{}
		#region Model
		private int _roleid;
		private string _rolename;
		private string _displayname;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int roleid
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rolename
		{
			set{ _rolename=value;}
			get{return _rolename;}
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

	}
}

