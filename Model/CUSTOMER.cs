using System;
namespace WZY.Model
{
	/// <summary>
	/// CUSTOMER:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CUSTOMER
	{
		public CUSTOMER()
		{}
		#region Model
		private int _custid;
		private int? _cateid;
		private string _custname;
		private string _pycode;
		private string _address;
		private string _tel;
		private string _fax;
		private string _post;
		private string _email;
		private string _owner;
		private string _ownertel;
		private string _ownerqq;
		private string _charge;
		private string _chargetel;
		private string _chargeqq;
		private string _summary;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int custid
		{
			set{ _custid=value;}
			get{return _custid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? cateid
		{
			set{ _cateid=value;}
			get{return _cateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string custname
		{
			set{ _custname=value;}
			get{return _custname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pycode
		{
			set{ _pycode=value;}
			get{return _pycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string post
		{
			set{ _post=value;}
			get{return _post;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string owner
		{
			set{ _owner=value;}
			get{return _owner;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ownertel
		{
			set{ _ownertel=value;}
			get{return _ownertel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ownerqq
		{
			set{ _ownerqq=value;}
			get{return _ownerqq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string charge
		{
			set{ _charge=value;}
			get{return _charge;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string chargetel
		{
			set{ _chargetel=value;}
			get{return _chargetel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string chargeqq
		{
			set{ _chargeqq=value;}
			get{return _chargeqq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string summary
		{
			set{ _summary=value;}
			get{return _summary;}
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

        public int uid { get; set; }
        public DateTime qianyue { get; set; }
        public string xuyue { get; set; }
        public DateTime? ownerbirth { get; set; }
        public int lunar1 { get; set; }
        public DateTime? chargebirth { get; set; }
        public int lunar2 { get; set; }
        public string custno { get; set; }
        public int recno { get; set; }
        public string contact { get; set; }
        public string contel { get; set; }

	}
}

