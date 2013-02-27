using System;
namespace WZY.Model
{
	/// <summary>
	/// alert:Entity class (attribute database fields of automatic extraction that describe information)
	/// </summary>
	[Serializable]
	public partial class alert
	{
		public alert()
		{}
		#region Model
		private long _id;
		private int? _uid;
		private string _cont;
		private DateTime? _alerttime;
		private int? _isprivate=0;
		/// <summary>
		/// 
		/// </summary>
		public long id
		{
			set{ _id=value;}
			get{return _id;}
		}
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
		public string cont
		{
			set{ _cont=value;}
			get{return _cont;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? alerttime
		{
			set{ _alerttime=value;}
			get{return _alerttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isprivate
		{
			set{ _isprivate=value;}
			get{return _isprivate;}
		}
		#endregion Model

	}
}

