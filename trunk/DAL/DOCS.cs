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
    /// 数据访问类:DOCS
    /// </summary>
    public partial class DOCS
    {
        public DOCS()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(docid)+1 from docs";
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
        public bool Exists(int docid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from docs where docid=@docid ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "docid", DbType.Int32, docid);
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
        public int Add(WZY.Model.DOCS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into docs(");
            strSql.Append("uid,typeid,cateid,custid,docname,docpath,uptime,remark)");
            strSql.Append(" values (");
            strSql.Append("@uid,@typeid,@cateid,@custid,@docname,@docpath,@uptime,@remark)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
            db.AddInParameter(dbCommand, "typeid", DbType.Int32, model.typeid);
            db.AddInParameter(dbCommand, "cateid", DbType.Int32, model.cateid);
            db.AddInParameter(dbCommand, "custid", DbType.Int32, model.custid);
            db.AddInParameter(dbCommand, "docname", DbType.String, model.docname);
            db.AddInParameter(dbCommand, "docpath", DbType.String, model.docpath);
            db.AddInParameter(dbCommand, "uptime", DbType.DateTime, model.uptime);
            db.AddInParameter(dbCommand, "remark", DbType.AnsiString, model.remark);
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
        public void Update(WZY.Model.DOCS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update docs set ");
            strSql.Append("uid=@uid,");
            strSql.Append("typeid=@typeeid,");
            strSql.Append("cateid=@cateid,");
            strSql.Append("custid=@custid,");
            strSql.Append("docname=@docname,");
            strSql.Append("docpath=@docpath,");
            strSql.Append("uptime=@uptime,");
            strSql.Append("remark=@remark");
            strSql.Append(" where docid=@docid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "docid", DbType.Int32, model.docid);
            db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
            db.AddInParameter(dbCommand, "typeid", DbType.Int32, model.typeid);
            db.AddInParameter(dbCommand, "cateid", DbType.Int32, model.cateid);
            db.AddInParameter(dbCommand, "custid", DbType.Int32, model.custid);
            db.AddInParameter(dbCommand, "docname", DbType.String, model.docname);
            db.AddInParameter(dbCommand, "docpath", DbType.String, model.docpath);
            db.AddInParameter(dbCommand, "uptime", DbType.DateTime, model.uptime);
            db.AddInParameter(dbCommand, "remark", DbType.AnsiString, model.remark);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int docid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from docs ");
            strSql.Append(" where docid=@docid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "docid", DbType.Int32, docid);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WZY.Model.DOCS GetModel(int docid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select docid,uid,typeid,cateid,custid,docname,docpath,uptime,remark from docs ");
            strSql.Append(" where docid=@docid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "docid", DbType.Int32, docid);
            WZY.Model.DOCS model = null;
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
            strSql.Append("select docid,uid,displayname,deptid,typeid,cateid,custid,custname,docname,docpath,uptime,remark ");
            strSql.Append(" FROM docs ");
            strSql.Append(" left join (select uid as userid, displayname,deptid from sysuser) a on a.userid=docs.uid ");
            strSql.Append(" left join (select custid as cusid, custname from customer) b on b.cusid=docs.custid ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "docs");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "docid");
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
        public List<WZY.Model.DOCS> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select docid,uid,cateid,custid,docname,docpath,uptime,remark ");
            strSql.Append(" FROM docs ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<WZY.Model.DOCS> list = new List<WZY.Model.DOCS>();
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
        public WZY.Model.DOCS ReaderBind(IDataReader dataReader)
        {
            WZY.Model.DOCS model = new WZY.Model.DOCS();
            object ojb;
            ojb = dataReader["docid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.docid = (int)ojb;
            }
            ojb = dataReader["uid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.uid = (int)ojb;
            }
            ojb = dataReader["cateid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.cateid = (int)ojb;
            }
            ojb = dataReader["custid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.custid = (int)ojb;
            }
            model.docname = dataReader["docname"].ToString();
            model.docpath = dataReader["docpath"].ToString();
            ojb = dataReader["uptime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.uptime = (DateTime)ojb;
            }
            model.remark = dataReader["remark"].ToString();
            return model;
        }

        #endregion  Method

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
            strSql.Append("select top " + pagesize + " docid,uid,displayname,deptid,typeid,cateid,custid,custname,docname,docpath,uptime,remark ");
            strSql.Append(" FROM docs ");
            strSql.Append(" left join (select uid as userid, displayname,deptid from sysuser) a on a.userid=docs.uid ");
            strSql.Append(" left join (select custid as cusid, custname from customer) b on b.cusid=docs.custid ");
            strSql.Append(" where docid not in ( select top " + start + " docid from docs " + inwhere + " )");
            strSql.Append(strWhere);
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
    }
}

