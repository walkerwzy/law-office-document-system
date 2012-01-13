using System;
namespace WZY.Model
{
	/// <summary>
	/// CATE_CASE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CATE_CASE
	{
		public CATE_CASE()
		{}
		#region Model
		private int _cateid;
		private string _catename;
		private int? _seq;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int cateid
		{
			set{ _cateid=value;}
			get{return _cateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string catename
		{
			set{ _catename=value;}
			get{return _catename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? seq
		{
			set{ _seq=value;}
			get{return _seq;}
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

        public string prefix { get; set; }
	}
}

