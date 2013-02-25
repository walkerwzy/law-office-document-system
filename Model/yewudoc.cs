/**  版本信息模板在安装目录下，可自行修改。
* yewudoc.cs
*
* 功 能： N/A
* 类 名： yewudoc
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/25 17:16:12   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace WZY.Model
{
	/// <summary>
	/// yewudoc:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class yewudoc
	{
		public yewudoc()
		{}
		#region Model
		private int _recid;
		private int? _typeid;
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
		public int? typeid
		{
			set{ _typeid=value;}
			get{return _typeid;}
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

