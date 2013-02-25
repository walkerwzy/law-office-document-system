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
		private int? _cate_id;
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
		public int? cate_id
		{
			set{ _cate_id=value;}
			get{return _cate_id;}
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

