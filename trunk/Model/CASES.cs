using System;
namespace WZY.Model
{
	/// <summary>
	/// CASES:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CASES
	{
		public CASES()
		{}
		#region Model
		private int _caseid;
		private int? _cateid;
		private int? _custid;
		private string _yuangao;
		private string _beigao;
		private string _anyou;
		private DateTime? _shouan;
		private DateTime? _dijiaotime;
		private string _faguan;
		private string _faguantel;
		private string _office;
		private DateTime? _kaiting;
		private DateTime? _panjuetime;
		private decimal? _fee;
		private int? _detail;
		private int? _analysis;
		private int? _evidence;
		private int? _opinion;
		private int? _quote;
		private int? _result;
		private int? _resultreport;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int caseid
		{
			set{ _caseid=value;}
			get{return _caseid;}
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
		public int? custid
		{
			set{ _custid=value;}
			get{return _custid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yuangao
		{
			set{ _yuangao=value;}
			get{return _yuangao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string beigao
		{
			set{ _beigao=value;}
			get{return _beigao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string anyou
		{
			set{ _anyou=value;}
			get{return _anyou;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? shouan
		{
			set{ _shouan=value;}
			get{return _shouan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dijiaotime
		{
			set{ _dijiaotime=value;}
			get{return _dijiaotime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string faguan
		{
			set{ _faguan=value;}
			get{return _faguan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string faguantel
		{
			set{ _faguantel=value;}
			get{return _faguantel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string office
		{
			set{ _office=value;}
			get{return _office;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? kaiting
		{
			set{ _kaiting=value;}
			get{return _kaiting;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? panjuetime
		{
			set{ _panjuetime=value;}
			get{return _panjuetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fee
		{
			set{ _fee=value;}
			get{return _fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? analysis
		{
			set{ _analysis=value;}
			get{return _analysis;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? evidence
		{
			set{ _evidence=value;}
			get{return _evidence;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? opinion
		{
			set{ _opinion=value;}
			get{return _opinion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? quote
		{
			set{ _quote=value;}
			get{return _quote;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? resultreport
		{
			set{ _resultreport=value;}
			get{return _resultreport;}
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

        public string caseno { get; set; }
        public int uid { get; set; }

        public int qisu { get; set; }
        public int taolun { get; set; }
        public string court { get; set; }

	}
}

