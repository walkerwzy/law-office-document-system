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
	/// 数据访问类:tasklog
	/// </summary>
	public class tasklog
	{
		public tasklog()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(recid)+1 from tasklog";
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
			strSql.Append("select count(1) from tasklog where recid=@recid ");
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
		public int Add(WZY.Model.tasklog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tasklog(");
			strSql.Append("rectime,expiretime,custid,userid,agentid,tasklist,footlist,feedback)");

			strSql.Append(" values (");
			strSql.Append("@rectime,@expiretime,@custid,@userid,@agentid,@tasklist,@footlist,@feedback)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "rectime", DbType.DateTime, model.rectime);
			db.AddInParameter(dbCommand, "expiretime", DbType.DateTime, model.expiretime);
			db.AddInParameter(dbCommand, "custid", DbType.Int32, model.custid);
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			db.AddInParameter(dbCommand, "agentid", DbType.Int32, model.agentid);
			db.AddInParameter(dbCommand, "tasklist", DbType.String, model.tasklist);
			db.AddInParameter(dbCommand, "footlist", DbType.String, model.footlist);
			db.AddInParameter(dbCommand, "feedback", DbType.String, model.feedback);
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
		public bool Update(WZY.Model.tasklog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tasklog set ");
			strSql.Append("rectime=@rectime,");
			strSql.Append("expiretime=@expiretime,");
			strSql.Append("custid=@custid,");
			strSql.Append("userid=@userid,");
			strSql.Append("agentid=@agentid,");
			strSql.Append("tasklist=@tasklist,");
			strSql.Append("footlist=@footlist,");
			strSql.Append("feedback=@feedback");
			strSql.Append(" where recid=@recid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "recid", DbType.Int32, model.recid);
			db.AddInParameter(dbCommand, "rectime", DbType.DateTime, model.rectime);
			db.AddInParameter(dbCommand, "expiretime", DbType.DateTime, model.expiretime);
			db.AddInParameter(dbCommand, "custid", DbType.Int32, model.custid);
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			db.AddInParameter(dbCommand, "agentid", DbType.Int32, model.agentid);
			db.AddInParameter(dbCommand, "tasklist", DbType.String, model.tasklist);
			db.AddInParameter(dbCommand, "footlist", DbType.String, model.footlist);
			db.AddInParameter(dbCommand, "feedback", DbType.String, model.feedback);
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
			strSql.Append("delete from tasklog ");
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
        public bool DeleteList(string recidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tasklog ");
            strSql.Append(" where recid in (" + recidlist + ")  ");
            var database = DatabaseFactory.CreateDatabase();
            int rows = database.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
		    return false;
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WZY.Model.tasklog GetModel(int recid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select recid,rectime,expiretime,custid,userid,agentid,tasklist,footlist,feedback from tasklog ");
			strSql.Append(" where recid=@recid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "recid", DbType.Int32,recid);
			WZY.Model.tasklog model=null;
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
		public WZY.Model.tasklog DataRowToModel(DataRow row)
		{
			WZY.Model.tasklog model=new WZY.Model.tasklog();
			if (row != null)
			{
				if(row["recid"]!=null && row["recid"].ToString()!="")
				{
					model.recid=int.Parse(row["recid"].ToString());
				}
				if(row["rectime"]!=null && row["rectime"].ToString()!="")
				{
					model.rectime=DateTime.Parse(row["rectime"].ToString());
				}
				if(row["expiretime"]!=null && row["expiretime"].ToString()!="")
				{
					model.expiretime=DateTime.Parse(row["expiretime"].ToString());
				}
				if(row["custid"]!=null && row["custid"].ToString()!="")
				{
					model.custid=int.Parse(row["custid"].ToString());
				}
				if(row["userid"]!=null && row["userid"].ToString()!="")
				{
					model.userid=int.Parse(row["userid"].ToString());
				}
				if(row["agentid"]!=null && row["agentid"].ToString()!="")
				{
					model.agentid=int.Parse(row["agentid"].ToString());
				}
				if(row["tasklist"]!=null)
				{
					model.tasklist=row["tasklist"].ToString();
				}
				if(row["footlist"]!=null)
				{
					model.footlist=row["footlist"].ToString();
				}
				if(row["feedback"]!=null)
				{
					model.feedback=row["feedback"].ToString();
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
			strSql.Append("select recid,rectime,expiretime,custid,userid,agentid,tasklist,footlist,feedback ");
			strSql.Append(" FROM tasklog ");
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
			strSql.Append(" recid,rectime,expiretime,custid,userid,agentid,tasklist,footlist,feedback ");
			strSql.Append(" FROM tasklog ");
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tasklog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
		public DataSet GetListByPage(string strWhere, string orderby, int pageindex, int pagesize)
        {
            //如果查询条件涉及关联表的条件，则需要把关联表也同时写到row函数里去
            //此处只用几个关联ID查询，因此简化
            int startIndex = pagesize * (pageindex - 1) + 1;
            int endIndex = startIndex + pagesize - 1;
			StringBuilder strSql=new StringBuilder();
		    strSql.Append("select ts.*,a.custname,b.displayname usera, b.deptid depta, c.displayname userb, c.deptid deptb from ( ");
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
			strSql.Append(")AS Row, T.*  from tasklog T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
		    strSql.Append(") ts ");
		    strSql.Append(" left join customer a on a.custid= ts.custid ");
		    strSql.Append(" left join sysuser b on b.uid=ts.userid ");
		    strSql.Append(" left join sysuser c on c.uid=ts.agentid ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "tasklog");
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
		public List<WZY.Model.tasklog> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select recid,rectime,expiretime,custid,userid,agentid,tasklist,footlist,feedback ");
			strSql.Append(" FROM tasklog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<WZY.Model.tasklog> list = new List<WZY.Model.tasklog>();
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
		public WZY.Model.tasklog ReaderBind(IDataReader dataReader)
		{
			WZY.Model.tasklog model=new WZY.Model.tasklog();
			object ojb; 
			ojb = dataReader["recid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.recid=(int)ojb;
			}
			ojb = dataReader["rectime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.rectime=(DateTime)ojb;
			}
			ojb = dataReader["expiretime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.expiretime=(DateTime)ojb;
			}
			ojb = dataReader["custid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.custid=(int)ojb;
			}
			ojb = dataReader["userid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.userid=(int)ojb;
			}
			ojb = dataReader["agentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.agentid=(int)ojb;
			}
			model.tasklist=dataReader["tasklist"].ToString();
			model.footlist=dataReader["footlist"].ToString();
			model.feedback=dataReader["feedback"].ToString();
			return model;
		}

		#endregion  Method
	}
}

