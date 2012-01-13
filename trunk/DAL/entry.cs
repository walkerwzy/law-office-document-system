using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

namespace WZY.DAL
{
	/// <summary>
	/// 数据访问类:entry
	/// </summary>
	public partial class entry
	{
		public entry()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(eid)+1 from entry";
			Database db = DatabaseFactory.CreateDatabase();
			object obj = db.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int eid)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from entry where eid=@eid ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "eid", DbType.Int32,eid);
			int cmdresult;
			object obj = db.ExecuteScalar(dbCommand);
			if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
			{
				cmdresult = 0;
			}
			else
			{
				cmdresult = int.Parse(obj.ToString());
			}
			if (cmdresult == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(WZY.Model.entry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into entry(");
			strSql.Append("uid,etype,etitle,econt,createdate,modifydate)");

			strSql.Append(" values (");
			strSql.Append("@uid,@etype,@etitle,@econt,@createdate,@modifydate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
			db.AddInParameter(dbCommand, "etype", DbType.AnsiString, model.etype);
			db.AddInParameter(dbCommand, "etitle", DbType.String, model.etitle);
			db.AddInParameter(dbCommand, "econt", DbType.String, model.econt);
			db.AddInParameter(dbCommand, "createdate", DbType.DateTime, model.createdate);
			db.AddInParameter(dbCommand, "modifydate", DbType.DateTime, model.modifydate);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
			if(!int.TryParse(obj.ToString(),out result))
			{
				return 0;
			}
			return result;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WZY.Model.entry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update entry set ");
			strSql.Append("uid=@uid,");
			strSql.Append("etype=@etype,");
			strSql.Append("etitle=@etitle,");
			strSql.Append("econt=@econt,");
			strSql.Append("createdate=@createdate,");
			strSql.Append("modifydate=@modifydate");
			strSql.Append(" where eid=@eid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "eid", DbType.Int32, model.eid);
			db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
			db.AddInParameter(dbCommand, "etype", DbType.AnsiString, model.etype);
			db.AddInParameter(dbCommand, "etitle", DbType.String, model.etitle);
			db.AddInParameter(dbCommand, "econt", DbType.String, model.econt);
			db.AddInParameter(dbCommand, "createdate", DbType.DateTime, model.createdate);
			db.AddInParameter(dbCommand, "modifydate", DbType.DateTime, model.modifydate);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int eid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from entry ");
			strSql.Append(" where eid=@eid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "eid", DbType.Int32,eid);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WZY.Model.entry GetModel(int eid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select eid,uid,etype,etitle,econt,createdate,modifydate from entry ");
			strSql.Append(" where eid=@eid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "eid", DbType.Int32,eid);
			WZY.Model.entry model=null;
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
			strSql.Append("select eid,uid,etype,etitle,econt,createdate,modifydate ");
			strSql.Append(" FROM entry ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "entry");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "eid");
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
		public List<WZY.Model.entry> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select eid,uid,etype,etitle,econt,createdate,modifydate ");
			strSql.Append(" FROM entry ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<WZY.Model.entry> list = new List<WZY.Model.entry>();
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
		public WZY.Model.entry ReaderBind(IDataReader dataReader)
		{
			WZY.Model.entry model=new WZY.Model.entry();
			object ojb; 
			ojb = dataReader["eid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.eid=(int)ojb;
			}
			ojb = dataReader["uid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.uid=(int)ojb;
			}
			model.etype=dataReader["etype"].ToString();
			model.etitle=dataReader["etitle"].ToString();
			model.econt=dataReader["econt"].ToString();
			ojb = dataReader["createdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.createdate=(DateTime)ojb;
			}
			ojb = dataReader["modifydate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.modifydate=(DateTime)ojb;
			}
			return model;
		}

		#endregion  Method

        public void Delete(WZY.Model.entry model)
        {
            Delete(model.eid);
        }
	}
}

