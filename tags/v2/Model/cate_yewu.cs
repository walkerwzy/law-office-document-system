using System;
namespace WZY.Model
{
	/// <summary>
	/// 常年业务、诉讼业务、专项服务等
	/// </summary>
	[Serializable]
	public partial class cate_yewu
	{
		public cate_yewu()
		{}
		#region Model
		private int _cate_id;
		private string _cate_name;
		private int? _cate_index;
		private string _cate_remark;
		/// <summary>
		/// 
		/// </summary>
		public int cate_id
		{
			set{ _cate_id=value;}
			get{return _cate_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cate_name
		{
			set{ _cate_name=value;}
			get{return _cate_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? cate_index
		{
			set{ _cate_index=value;}
			get{return _cate_index;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cate_remark
		{
			set{ _cate_remark=value;}
			get{return _cate_remark;}
		}
		#endregion Model

	}
}

