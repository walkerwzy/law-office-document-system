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
	/// 数据访问类:cate_yewu
	/// </summary>
	public partial class cate_yewu
	{
		public cate_yewu()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(cate_id)+1 from cate_yewu";
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
		public bool Exists(int cate_id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from cate_yewu where cate_id=@cate_id ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "cate_id", DbType.Byte,cate_id);
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
		public int Add(WZY.Model.cate_yewu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into cate_yewu(");
			strSql.Append("cate_name,cate_index,cate_remark)");

			strSql.Append(" values (");
			strSql.Append("@cate_name,@cate_index,@cate_remark)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "cate_name", DbType.AnsiString, model.cate_name);
			db.AddInParameter(dbCommand, "cate_index", DbType.Byte, model.cate_index);
			db.AddInParameter(dbCommand, "cate_remark", DbType.AnsiString, model.cate_remark);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
            Helper.HelperCache.RemoveCache("cate_yewu");
			if(!int.TryParse(obj.ToString(),out result))
			{
				return 0;
			}
			return result;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WZY.Model.cate_yewu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update cate_yewu set ");
			strSql.Append("cate_name=@cate_name,");
			strSql.Append("cate_index=@cate_index,");
			strSql.Append("cate_remark=@cate_remark");
			strSql.Append(" where cate_id=@cate_id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "cate_id", DbType.Byte, model.cate_id);
			db.AddInParameter(dbCommand, "cate_name", DbType.AnsiString, model.cate_name);
			db.AddInParameter(dbCommand, "cate_index", DbType.Byte, model.cate_index);
			db.AddInParameter(dbCommand, "cate_remark", DbType.AnsiString, model.cate_remark);
			int rows=db.ExecuteNonQuery(dbCommand);

            Helper.HelperCache.RemoveCache("cate_yewu");
			if (rows > 0)
			{
				return true;
			}
		    return false;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int cate_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from cate_yewu ");
			strSql.Append(" where cate_id=@cate_id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "cate_id", DbType.Byte,cate_id);
			int rows=db.ExecuteNonQuery(dbCommand);

            Helper.HelperCache.RemoveCache("cate_yewu");
			if (rows > 0)
			{
				return true;
			}
		    return false;
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string cate_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from cate_yewu ");
			strSql.Append(" where cate_id in ("+cate_idlist + ")  ");
            var database = DatabaseFactory.CreateDatabase();
            int rows = database.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            Helper.HelperCache.RemoveCache("cate_yewu");
			if (rows > 0)
			{
				return true;
			}
		    return false;
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WZY.Model.cate_yewu GetModel(int cate_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select cate_id,cate_name,cate_index,cate_remark from cate_yewu ");
			strSql.Append(" where cate_id=@cate_id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "cate_id", DbType.Byte,cate_id);
			WZY.Model.cate_yewu model=null;
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
		public WZY.Model.cate_yewu DataRowToModel(DataRow row)
		{
			WZY.Model.cate_yewu model=new WZY.Model.cate_yewu();
			if (row != null)
			{
				if(row["cate_id"]!=null && row["cate_id"].ToString()!="")
				{
					model.cate_id=int.Parse(row["cate_id"].ToString());
				}
				if(row["cate_name"]!=null)
				{
					model.cate_name=row["cate_name"].ToString();
				}
				if(row["cate_index"]!=null && row["cate_index"].ToString()!="")
				{
					model.cate_index=int.Parse(row["cate_index"].ToString());
				}
				if(row["cate_remark"]!=null)
				{
					model.cate_remark=row["cate_remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
            //字典数据，先查缓存
            var cate = Helper.HelperCache.GetCache("cate_yewu");
            if (cate == null)
            {
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select cate_id,cate_name,cate_index,cate_remark ");
			strSql.Append(" FROM cate_yewu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
            cate = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
            Helper.HelperCache.Insert("cate_yewu", cate, 24);
            }
            return cate as DataSet;
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(top>0)
			{
				strSql.Append(" top "+top.ToString());
			}
			strSql.Append(" cate_id,cate_name,cate_index,cate_remark ");
			strSql.Append(" FROM cate_yewu ");
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
			strSql.Append("select count(1) FROM cate_yewu ");
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
		    return Convert.ToInt32(obj);
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
				strSql.Append("order by T.cate_id desc");
			}
			strSql.Append(")AS Row, T.*  from cate_yewu T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "cate_yewu");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "cate_id");
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
		public List<WZY.Model.cate_yewu> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select cate_id,cate_name,cate_index,cate_remark ");
			strSql.Append(" FROM cate_yewu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<WZY.Model.cate_yewu> list = new List<WZY.Model.cate_yewu>();
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
		public WZY.Model.cate_yewu ReaderBind(IDataReader dataReader)
		{
			WZY.Model.cate_yewu model=new WZY.Model.cate_yewu();
			object ojb; 
			ojb = dataReader["cate_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.cate_id=(int)ojb;
			}
			model.cate_name=dataReader["cate_name"].ToString();
			ojb = dataReader["cate_index"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.cate_index=(int)ojb;
			}
			model.cate_remark=dataReader["cate_remark"].ToString();
			return model;
		}

		#endregion  Method
	}
}

