using System;
namespace WZY.Model
{
	/// <summary>
	/// DEPART:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DEPART
	{
		public DEPART()
		{}
		#region Model
		private int _deptid;
		private string _deptname;
		private int? _seq;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int deptid
		{
			set{ _deptid=value;}
			get{return _deptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string deptname
		{
			set{ _deptname=value;}
			get{return _deptname;}
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

	}
}

