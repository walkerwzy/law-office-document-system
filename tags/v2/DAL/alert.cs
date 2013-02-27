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
	/// Data access:alert
	/// </summary>
	public partial class alert
	{
		public alert()
		{}
		#region  Method

		/// <summary>
		/// Whether there is Exists
		/// </summary>
		public bool Exists(long id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from alert where id=@id ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int64,id);
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
		/// Add a record
		/// </summary>
		public int Add(WZY.Model.alert model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into alert(");
			strSql.Append("uid,cont,alerttime,isprivate)");

			strSql.Append(" values (");
			strSql.Append("@uid,@cont,@alerttime,@isprivate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
			db.AddInParameter(dbCommand, "cont", DbType.String, model.cont);
			db.AddInParameter(dbCommand, "alerttime", DbType.DateTime, model.alerttime);
			db.AddInParameter(dbCommand, "isprivate", DbType.Byte, model.isprivate);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
			if(!int.TryParse(obj.ToString(),out result))
			{
				return 0;
			}
			return result;
		}
		/// <summary>
		/// Update a record
		/// </summary>
		public void Update(WZY.Model.alert model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update alert set ");
			strSql.Append("uid=@uid,");
			strSql.Append("cont=@cont,");
			strSql.Append("alerttime=@alerttime,");
			strSql.Append("isprivate=@isprivate");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int64, model.id);
			db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
			db.AddInParameter(dbCommand, "cont", DbType.String, model.cont);
			db.AddInParameter(dbCommand, "alerttime", DbType.DateTime, model.alerttime);
			db.AddInParameter(dbCommand, "isprivate", DbType.Byte, model.isprivate);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// Delete a record
		/// </summary>
		public void Delete(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from alert ");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int64,id);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// Get an object entity
		/// </summary>
		public WZY.Model.alert GetModel(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,uid,cont,alerttime,isprivate from alert ");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int64,id);
			WZY.Model.alert model=null;
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
		/// Query data list
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select b.displayname, id,uid,cont,alerttime,isprivate, (case isprivate when 0 then '公开' else '私人' end) as isp ");
			strSql.Append(" FROM alert a");
            strSql.Append(" left join ( select displayname,uid as userid from sysuser) b on b.userid=a.uid ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/*
		/// <summary>
		/// Paging data list
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "alert");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "id");
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
		public List<WZY.Model.alert> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,uid,cont,alerttime,isprivate ");
			strSql.Append(" FROM alert ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<WZY.Model.alert> list = new List<WZY.Model.alert>();
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
		public WZY.Model.alert ReaderBind(IDataReader dataReader)
		{
			WZY.Model.alert model=new WZY.Model.alert();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(long)ojb;
			}
			ojb = dataReader["uid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.uid=(int)ojb;
			}
			model.cont=dataReader["cont"].ToString();
			ojb = dataReader["alerttime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.alerttime=(DateTime)ojb;
			}
			ojb = dataReader["isprivate"];
			if(ojb != null && ojb != DBNull.Value)
			{
                model.isprivate = Convert.ToInt32(ojb);
			}
			return model;
		}

		#endregion  Method
	}
}

