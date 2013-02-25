using System;
namespace WZY.Model
{
	/// <summary>
	/// 常年业务、诉讼业务、专项服务等
	/// </summary>
	[Serializable]
	public partial class yuwudoc
	{
		public yuwudoc()
		{}
		#region Model
		private int _recid;
		private int? _typeid;
		private int? _cateid;
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
		public int? typeid
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? cateid
		{
			set{ _cateid=value;}
			get{return _cateid;}
		}
		#endregion Model

	}
}

