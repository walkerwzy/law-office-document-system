using System;
namespace WZY.Model
{
	/// <summary>
	/// employee:Entity class (attribute database fields of automatic extraction that describe information)
	/// </summary>
	[Serializable]
	public partial class employee
	{
		public employee()
		{}
		#region Model
		private int? _uid;
		private string _cert;
		private int? _gender;
		private string _nation;
		private DateTime? _birthday;
		private string _hukou;
		private string _family;
		private DateTime? _intime;
		private DateTime? _formtime;
		private string _summary;
		private string _remark;
		private string _photo;
		private DateTime? _baoxian;
		private DateTime? _lizhi;
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
		public string cert
		{
			set{ _cert=value;}
			get{return _cert;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? gender
		{
			set{ _gender=value;}
			get{return _gender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nation
		{
			set{ _nation=value;}
			get{return _nation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hukou
		{
			set{ _hukou=value;}
			get{return _hukou;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string family
		{
			set{ _family=value;}
			get{return _family;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? intime
		{
			set{ _intime=value;}
			get{return _intime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? formtime
		{
			set{ _formtime=value;}
			get{return _formtime;}
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
		/// <summary>
		/// 
		/// </summary>
		public string photo
		{
			set{ _photo=value;}
			get{return _photo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? baoxian
		{
			set{ _baoxian=value;}
			get{return _baoxian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? lizhi
		{
			set{ _lizhi=value;}
			get{return _lizhi;}
		}
		#endregion Model

	}
}

