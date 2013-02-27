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
    /// 数据访问类:CONTRACT
    /// </summary>
    public partial class CONTRACT
    {
        public CONTRACT()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string c_no)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from contract where c_no=@c_no ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "c_no", DbType.AnsiString, c_no);
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
        /// 更新一条数据
        /// </summary>
        public void Update(WZY.Model.CONTRACT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update contract set ");
            strSql.Append("custid=@custid,");
            strSql.Append("c_no=@c_no,");
            strSql.Append("c_stime=@c_stime,");
            strSql.Append("c_fee=@c_fee,");
            strSql.Append("c_etime=@c_etime,");
            strSql.Append("username=@username,");
            strSql.Append("c_ctime=@c_ctime,");
            strSql.Append("remark=@remark");
            strSql.Append(" where c_no=@c_no ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "c_no", DbType.AnsiString, model.c_no);
            db.AddInParameter(dbCommand, "custid", DbType.Int32, model.custid);
            db.AddInParameter(dbCommand, "c_stime", DbType.DateTime, model.c_stime);
            db.AddInParameter(dbCommand, "c_fee", DbType.Decimal, model.c_fee);
            db.AddInParameter(dbCommand, "c_etime", DbType.DateTime, model.c_etime);
            db.AddInParameter(dbCommand, "c_ctime", DbType.Date, model.c_ctime);
            db.AddInParameter(dbCommand, "username", DbType.AnsiString, model.username);
            db.AddInParameter(dbCommand, "remark", DbType.AnsiString, model.remark);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string c_no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from contract ");
            strSql.Append(" where c_no=@c_no ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "c_no", DbType.AnsiString, c_no);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WZY.Model.CONTRACT GetModel(string c_no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select c_no,custid,c_stime,c_fee,c_etime,c_ctime,username,remark from contract ");
            strSql.Append(" where c_no=@c_no ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "c_no", DbType.AnsiString, c_no);
            WZY.Model.CONTRACT model = null;
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
            strSql.Append("select c_no,custid,c_stime,c_fee,c_etime,c_ctime,username,remark ");
            strSql.Append(" FROM contract ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "contract");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "c_no");
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
        public List<WZY.Model.CONTRACT> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select c_no,custid,c_stime,c_fee,c_etime,c_ctime,username,remark ");
            strSql.Append(" FROM contract ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<WZY.Model.CONTRACT> list = new List<WZY.Model.CONTRACT>();
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
        public WZY.Model.CONTRACT ReaderBind(IDataReader dataReader)
        {
            WZY.Model.CONTRACT model = new WZY.Model.CONTRACT();
            object ojb;
            model.c_no = dataReader["c_no"].ToString();
            model.username = dataReader["username"].ToString();
            ojb = dataReader["custid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.custid = (int)ojb;
            }
            ojb = dataReader["c_stime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.c_stime = (DateTime)ojb;
            }
            ojb = dataReader["c_fee"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.c_fee = (decimal)ojb;
            }
            ojb = dataReader["c_etime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.c_etime = (DateTime)ojb;
            }
            ojb = dataReader["c_ctime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.c_ctime = (DateTime)ojb;
            }
            model.remark = dataReader["remark"].ToString();
            return model;
        }

        #endregion  Method


        //生成合同序列号
        private string getSeqNo(int custid)
        {
            string prefix = "K";
            try
            {
                WZY.Model.CUSTOMER c = new WZY.DAL.CUSTOMER().GetModel(custid);
                if (c != null)
                {
                    WZY.Model.CATE_CUST m = new WZY.DAL.CATE_CUST().GetModel(c.cateid.Value);
                    if (m != null) prefix = m.prefix;
                }
            }
            catch
            { 
                //
            }
            string pre = prefix + DateTime.Now.ToString("yyMMdd");
            string temp = "";
            for (int i = 1; ; i++)
            {
                temp = i < 10 ? "0" + i : i + "";
                if (!Exists(pre + temp))
                {
                    pre = pre + temp;
                    break;
                }
            }
            return pre;
        }

        public void Delete(WZY.Model.CONTRACT model)
        {
            Delete(model.c_no);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(WZY.Model.CONTRACT model, int? uid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();

                try
                {
                    //添加记录
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into contract(");
                    strSql.Append("c_no,custid,c_stime,c_fee,c_etime,c_ctime,username,remark)");
                    strSql.Append(" values (");
                    strSql.Append("@c_no,@custid,@c_stime,@c_fee,@c_etime,@c_ctime,@username,@remark)");
                    DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                    db.AddInParameter(dbCommand, "c_no", DbType.AnsiString, getSeqNo(model.custid.Value));
                    db.AddInParameter(dbCommand, "custid", DbType.Int32, model.custid);
                    db.AddInParameter(dbCommand, "c_stime", DbType.DateTime, model.c_stime);
                    db.AddInParameter(dbCommand, "c_fee", DbType.Decimal, model.c_fee);
                    db.AddInParameter(dbCommand, "c_etime", DbType.DateTime, model.c_etime);
                    db.AddInParameter(dbCommand, "c_ctime", DbType.DateTime, model.c_ctime);
                    db.AddInParameter(dbCommand, "username", DbType.AnsiString, model.username);
                    db.AddInParameter(dbCommand, "remark", DbType.AnsiString, model.remark);
                    db.ExecuteNonQuery(dbCommand);

                    if (uid.HasValue)
                    {
                        //更改客户-用户关系
                        string sql = "update customer set uid=" + uid.Value + " where custid=" + model.custid;
                        db.ExecuteNonQuery(CommandType.Text, sql);
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    Helper.log.error("执行事务时出错：添加签约记录", ex.Message);//事务没起作用。。。
                    //throw new Exception(ex.Message);
                }
            }
        }

        private string updateSeqNo(string seq, int custid)
        {
            string prefix = "K";
            try
            {
                WZY.Model.CUSTOMER c = new WZY.DAL.CUSTOMER().GetModel(custid);
                if (c != null)
                {
                    WZY.Model.CATE_CUST m = new WZY.DAL.CATE_CUST().GetModel(c.cateid.Value);
                    if (m != null) prefix = m.prefix;
                }
            }
            catch
            {
                //
            }
            if (seq.IndexOf(prefix) > 0) return seq;
            string pre = prefix + DateTime.Now.ToString("yyMMdd");
            string temp = "";
            for (int i = 1; ; i++)
            {
                temp = i < 10 ? "0" + i : i + "";
                if (!Exists(pre + temp))
                {
                    pre = pre + temp;
                    break;
                }
            }
            return pre;
        }

        public int getCount(string sql)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object obj = db.ExecuteScalar(CommandType.Text, sql);
            int result;
            if (!int.TryParse(obj.ToString(), out result))
            {
                return 0;
            }
            return result;
        }

        public DataSet getExpiredDates(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select c.deptid, b.uid, b.custname, a.* from (select custid, MAX(c_etime) etime from lawdoc.dbo.contract group by custid) a ");
            strSql.Append(" left join customer b on b.custid=a.custid ");
            strSql.Append(" left join (select deptid, uid as usid from sysuser) c on c.usid=b.uid ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
    }
}

