using System;
namespace WZY.Model
{
	/// <summary>
	/// CLIENTMAP:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CLIENTMAP
	{
		public CLIENTMAP()
		{}
		#region Model
		private int? _uid;
		private int? _custid;
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
		public int? custid
		{
			set{ _custid=value;}
			get{return _custid;}
		}
		#endregion Model

	}
}

