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
    /// 数据访问类:VISIT
    /// </summary>
    public partial class VISIT
    {
        public VISIT()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(recid)+1 from visit";
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
            strSql.Append("select count(1) from visit where recid=@recid ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "recid", DbType.Int32, recid);
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
        public int Add(WZY.Model.VISIT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into visit(");
            strSql.Append("uid,custid,reason,time,result,remark)");

            strSql.Append(" values (");
            strSql.Append("@uid,@custid,@reason,@time,@result,@remark)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
            db.AddInParameter(dbCommand, "custid", DbType.Int32, model.custid);
            db.AddInParameter(dbCommand, "reason", DbType.String, model.reason);
            db.AddInParameter(dbCommand, "time", DbType.DateTime, model.time);
            db.AddInParameter(dbCommand, "result", DbType.String, model.result);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            int result;
            object obj = db.ExecuteScalar(dbCommand);
            if (!int.TryParse(obj.ToString(), out result))
            {
                return 0;
            }
            return result;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(WZY.Model.VISIT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update visit set ");
            strSql.Append("uid=@uid,");
            strSql.Append("custid=@custid,");
            strSql.Append("reason=@reason,");
            strSql.Append("time=@time,");
            strSql.Append("result=@result,");
            strSql.Append("remark=@remark");
            strSql.Append(" where recid=@recid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "recid", DbType.Int32, model.recid);
            db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
            db.AddInParameter(dbCommand, "custid", DbType.Int32, model.custid);
            db.AddInParameter(dbCommand, "reason", DbType.String, model.reason);
            db.AddInParameter(dbCommand, "time", DbType.DateTime, model.time);
            db.AddInParameter(dbCommand, "result", DbType.String, model.result);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int recid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from visit ");
            strSql.Append(" where recid=@recid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "recid", DbType.Int32, recid);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WZY.Model.VISIT GetModel(int recid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select recid,uid,custid,reason,time,result,remark from visit ");
            strSql.Append(" where recid=@recid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "recid", DbType.Int32, recid);
            WZY.Model.VISIT model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select recid,uid,custid,displayname,custname,reason,time,result,remark from visit ");
            strSql.Append("left join ( select uid usid,displayname,deptid from sysuser) a on a.usid=visit.uid ");
            strSql.Append("left join (select custid as cid, custname from customer) b on b.cid=visit.custid ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "visit");
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
        public List<WZY.Model.VISIT> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select recid,uid,custid,reason,time,result,remark from visit ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<WZY.Model.VISIT> list = new List<WZY.Model.VISIT>();
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
        public WZY.Model.VISIT ReaderBind(IDataReader dataReader)
        {
            WZY.Model.VISIT model = new WZY.Model.VISIT();
            object ojb;
            ojb = dataReader["recid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.recid = (int)ojb;
            }
            ojb = dataReader["uid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.uid = (int)ojb;
            }
            ojb = dataReader["custid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.custid = (int)ojb;
            }
            model.reason = dataReader["reason"].ToString();
            ojb = dataReader["time"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.time = (DateTime)ojb;
            }
            model.result = dataReader["result"].ToString();
            model.remark = dataReader["remark"].ToString();
            return model;
        }

        #endregion  Method

        /// <summary>
        /// 删除一组数据
        /// </summary>
        public void Delete(string ids)
        {
            string sql = "delete from visit  where recid in (" + ids + ")";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.ExecuteNonQuery(dbCommand);

        }


        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataSet GetPage(string strWhere, int pagesize, int pageindex)
        {
            string inwhere = "";
            if (strWhere.Trim() != "")
            {
                inwhere = " where " + strWhere;
                strWhere = " and " + strWhere;
            }
            int start = (pageindex - 1) * pagesize;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pagesize + " recid,uid,custid,displayname,deptid,custname,reason,time,result,remark from visit ");
            strSql.Append("left join ( select uid usid,displayname,deptid from sysuser) a on a.usid=visit.uid ");
            strSql.Append("left join (select custid as cid, custname from customer) b on b.cid=visit.custid ");
            strSql.Append(" where recid not in ( select top " + start + " recid from visit " + inwhere + " order by recid desc )");
            strSql.Append(strWhere);
            strSql.Append(" order by recid desc");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        public void Delete(WZY.Model.VISIT model)
        {
            Delete(model.recid);
        }
    }
}

