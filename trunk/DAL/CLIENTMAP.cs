using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
//using Maticsoft.DBUtility;//Please add references
namespace WZY.DAL
{
	/// <summary>
	/// 数据访问类:CLIENTMAP
	/// </summary>
	public partial class CLIENTMAP
	{
		public CLIENTMAP()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WZY.Model.CLIENTMAP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into clientmap(");
			strSql.Append("uid,custid)");

			strSql.Append(" values (");
			strSql.Append("@uid,@custid)");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
			db.AddInParameter(dbCommand, "custid", DbType.Int32, model.custid);
			db.ExecuteNonQuery(dbCommand);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WZY.Model.CLIENTMAP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update clientmap set ");
			strSql.Append("uid=@uid,");
			strSql.Append("custid=@custid");
			strSql.Append(" where ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
			db.AddInParameter(dbCommand, "custid", DbType.Int32, model.custid);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from clientmap ");
			strSql.Append(" where ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WZY.Model.CLIENTMAP GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select uid,custid from clientmap ");
			strSql.Append(" where ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			WZY.Model.CLIENTMAP model=null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select uid,custid ");
			strSql.Append(" FROM clientmap ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "clientmap");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "cateid");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}*/

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<WZY.Model.CLIENTMAP> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select uid,custid ");
			strSql.Append(" FROM clientmap ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<WZY.Model.CLIENTMAP> list = new List<WZY.Model.CLIENTMAP>();
			Database db = DatabaseFactory.CreateDatabase();
			using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public WZY.Model.CLIENTMAP ReaderBind(IDataReader dataReader)
		{
			WZY.Model.CLIENTMAP model=new WZY.Model.CLIENTMAP();
			object ojb; 
			ojb = dataReader["uid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.uid=(int)ojb;
			}
			ojb = dataReader["custid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.custid=(int)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

