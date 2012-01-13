using System;
namespace WZY.Model
{
	/// <summary>
	/// CONTRACT:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CONTRACT
	{
		public CONTRACT()
		{}
		#region Model
		private string _c_no;
		private int? _custid;
		private DateTime? _c_stime;
		private decimal? _c_fee;
		private DateTime? _c_etime;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public string c_no
		{
			set{ _c_no=value;}
			get{return _c_no;}
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
		public DateTime? c_stime
		{
			set{ _c_stime=value;}
			get{return _c_stime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? c_fee
		{
			set{ _c_fee=value;}
			get{return _c_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? c_etime
		{
			set{ _c_etime=value;}
			get{return _c_etime;}
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

        public string username { get; set; }
        public DateTime? c_ctime { get; set; }
	}
}

