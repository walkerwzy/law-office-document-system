using System;
namespace WZY.Model
{
	/// <summary>
	/// office:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class office
	{
		public office()
		{}
		#region Model
		private string _zongzhi;
		private string _zhanlue;
		private string _zhidu;
		private string _bak1;
		private string _bak2;
		private string _bak3;
		/// <summary>
		/// 
		/// </summary>
		public string zongzhi
		{
			set{ _zongzhi=value;}
			get{return _zongzhi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zhanlue
		{
			set{ _zhanlue=value;}
			get{return _zhanlue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zhidu
		{
			set{ _zhidu=value;}
			get{return _zhidu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bak1
		{
			set{ _bak1=value;}
			get{return _bak1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bak2
		{
			set{ _bak2=value;}
			get{return _bak2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bak3
		{
			set{ _bak3=value;}
			get{return _bak3;}
		}
		#endregion Model

	}
}

