using System;
namespace WZY.Model
{
	/// <summary>
	/// settings:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class settings
	{
		public settings()
		{}
		#region Model
		private int? _uid;
		private int? _pagesize=20;
		private int? _depart;
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
		public int? pagesize
		{
			set{ _pagesize=value;}
			get{return _pagesize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? depart
		{
			set{ _depart=value;}
			get{return _depart;}
		}
		#endregion Model

	}
}

