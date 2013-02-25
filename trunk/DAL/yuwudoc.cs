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
	/// 数据访问类:yuwudoc
	/// </summary>
	public partial class yuwudoc
	{
		public yuwudoc()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(recid)+1 from yuwudoc";
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
		public bool Exists(int recid)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from yuwudoc where recid=@recid ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "recid", DbType.Int32,recid);
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
		public int Add(WZY.Model.yuwudoc model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into yuwudoc(");
			strSql.Append("cate_id,cateid)");

			strSql.Append(" values (");
			strSql.Append("@cate_id,@cateid)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "cate_id", DbType.Byte, model.cate_id);
			db.AddInParameter(dbCommand, "cateid", DbType.Int32, model.cateid);
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
		public bool Update(WZY.Model.yuwudoc model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update yuwudoc set ");
			strSql.Append("cate_id=@cate_id,");
			strSql.Append("cateid=@cateid");
			strSql.Append(" where recid=@recid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "recid", DbType.Int32, model.recid);
			db.AddInParameter(dbCommand, "cate_id", DbType.Byte, model.cate_id);
			db.AddInParameter(dbCommand, "cateid", DbType.Int32, model.cateid);
			int rows=db.ExecuteNonQuery(dbCommand);

			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int recid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from yuwudoc ");
			strSql.Append(" where recid=@recid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "recid", DbType.Int32,recid);
			int rows=db.ExecuteNonQuery(dbCommand);

			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string recidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from yuwudoc ");
            strSql.Append(" where recid in (" + recidlist + ")  ");
            var database = DatabaseFactory.CreateDatabase();
            int rows = database.ExecuteNonQuery(CommandType.Text, strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WZY.Model.yuwudoc GetModel(int recid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select recid,cate_id,cateid from yuwudoc ");
			strSql.Append(" where recid=@recid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "recid", DbType.Int32,recid);
			WZY.Model.yuwudoc model=null;
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
		/// 得到一个对象实体
		/// </summary>
		public WZY.Model.yuwudoc DataRowToModel(DataRow row)
		{
			WZY.Model.yuwudoc model=new WZY.Model.yuwudoc();
			if (row != null)
			{
				if(row["recid"]!=null && row["recid"].ToString()!="")
				{
					model.recid=int.Parse(row["recid"].ToString());
				}
				if(row["cate_id"]!=null && row["cate_id"].ToString()!="")
				{
					model.cate_id=int.Parse(row["cate_id"].ToString());
				}
				if(row["cateid"]!=null && row["cateid"].ToString()!="")
				{
					model.cateid=int.Parse(row["cateid"].ToString());
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
			strSql.Append("select recid,cate_id,cateid ");
			strSql.Append(" FROM yuwudoc ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" recid,cate_id,cateid ");
			strSql.Append(" FROM yuwudoc ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM yuwudoc ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
            }
            var database = DatabaseFactory.CreateDatabase();
            object obj = database.ExecuteScalar(CommandType.Text, strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.recid desc");
			}
			strSql.Append(")AS Row, T.*  from yuwudoc T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            var database = DatabaseFactory.CreateDatabase();
            return database.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "yuwudoc");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "recid");
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
		public List<WZY.Model.yuwudoc> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select recid,cate_id,cateid ");
			strSql.Append(" FROM yuwudoc ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<WZY.Model.yuwudoc> list = new List<WZY.Model.yuwudoc>();
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
		public WZY.Model.yuwudoc ReaderBind(IDataReader dataReader)
		{
			WZY.Model.yuwudoc model=new WZY.Model.yuwudoc();
			object ojb; 
			ojb = dataReader["recid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.recid=(int)ojb;
			}
			ojb = dataReader["cate_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.cate_id=(int)ojb;
			}
			ojb = dataReader["cateid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.cateid=(int)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

