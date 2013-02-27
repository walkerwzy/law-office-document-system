using System;
namespace WZY.Model
{
	/// <summary>
	/// entry:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class entry
	{
		public entry()
		{}
		#region Model
		private int _eid;
		private int? _uid;
		private string _etype;
		private string _etitle;
		private string _econt;
		private DateTime? _createdate;
		private DateTime? _modifydate;
		/// <summary>
		/// 
		/// </summary>
		public int eid
		{
			set{ _eid=value;}
			get{return _eid;}
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
		public string etype
		{
			set{ _etype=value;}
			get{return _etype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string etitle
		{
			set{ _etitle=value;}
			get{return _etitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string econt
		{
			set{ _econt=value;}
			get{return _econt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createdate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? modifydate
		{
			set{ _modifydate=value;}
			get{return _modifydate;}
		}
		#endregion Model

	}
}

