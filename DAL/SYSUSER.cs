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
    /// 数据访问类:SYSUSER
    /// </summary>
    public partial class SYSUSER
    {
        public SYSUSER()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            const string strsql = "select max(uid)+1 from sysuser";
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
        public bool Exists(int uid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sysuser where uid=@uid ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "uid", DbType.Int32, uid);
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
            return cmdresult != 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WZY.Model.SYSUSER model)
        {
            isUserNameExist(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sysuser(");
            strSql.Append("roleid,deptid,username,password,displayname,remark,pycode,stat)");

            strSql.Append(" values (");
            strSql.Append("@roleid,@deptid,@username,@password,@displayname,@remark,@pycode,@stat)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "roleid", DbType.Int32, model.roleid);
            db.AddInParameter(dbCommand, "deptid", DbType.Int32, model.deptid);
            db.AddInParameter(dbCommand, "username", DbType.AnsiString, model.username);
            db.AddInParameter(dbCommand, "password", DbType.AnsiString, model.password);
            db.AddInParameter(dbCommand, "displayname", DbType.String, model.displayname);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            db.AddInParameter(dbCommand, "pycode", DbType.AnsiString, char2pydll.toPinYin(model.displayname));
            db.AddInParameter(dbCommand, "stat", DbType.Int32, model.stat);
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
        public void Update(WZY.Model.SYSUSER model)
        {
            isUserNameExistWhenEdit(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sysuser set ");
            strSql.Append("roleid=@roleid,");
            strSql.Append("deptid=@deptid,");
            strSql.Append("username=@username,");
            strSql.Append("password=@password,");
            strSql.Append("displayname=@displayname,");
            strSql.Append("remark=@remark,");
            strSql.Append("pycode=@pycode,");
            strSql.Append("stat=@stat");
            strSql.Append(" where uid=@uid and uid!=0 ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
            db.AddInParameter(dbCommand, "roleid", DbType.Int32, model.roleid);
            db.AddInParameter(dbCommand, "deptid", DbType.Int32, model.deptid);
            db.AddInParameter(dbCommand, "username", DbType.AnsiString, model.username);
            db.AddInParameter(dbCommand, "password", DbType.AnsiString, model.password);
            db.AddInParameter(dbCommand, "displayname", DbType.String, model.displayname);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            db.AddInParameter(dbCommand, "pycode", DbType.AnsiString, char2pydll.toPinYin(model.displayname));
            db.AddInParameter(dbCommand, "stat", DbType.Int32, model.stat);
            db.ExecuteNonQuery(dbCommand);

        }

        private static void isUserNameExist(WZY.Model.SYSUSER model)
        {
            DataTable dt = new WZY.DAL.SYSUSER().GetList("username='" + model.username + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                throw new Exception("该用户名已被占用");
            }
        }
        private static void isUserNameExistWhenEdit(WZY.Model.SYSUSER model)
        {
            DataTable dt = new WZY.DAL.SYSUSER().GetList("username='" + model.username + "'").Tables[0];
            if (dt.Rows.Count > 0 && dt.Rows[0]["uid"].ToString() != model.uid.ToString())
            {
                throw new Exception("该用户名已被占用");
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int uid)
        {
            throw new Exception("系统不支持直接删除用户，请联系管理员");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sysuser ");
            strSql.Append(" where uid=@uid and uid!=0 ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "uid", DbType.Int32, uid);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WZY.Model.SYSUSER GetModel(int uid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select uid,roleid,deptid,username,password,displayname,pycode,remark,stat from sysuser ");
            strSql.Append(" where uid=@uid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "uid", DbType.Int32, uid);
            WZY.Model.SYSUSER model = null;
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
            strSql.Append("select uid,roleid,deptid,username,password,displayname,remark,pycode,stat ");
            strSql.Append(" FROM sysuser  where uid!=0 and stat != 99 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by uid ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet Login(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 uid,roleid,deptid,username,password,displayname,remark,pycode,stat ");
            strSql.Append(" FROM sysuser where stat != 99");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "sysuser");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "uid");
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
        public List<WZY.Model.SYSUSER> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select uid,roleid,deptid,username,password,displayname,remark,pycode,stat ");
            strSql.Append(" FROM sysuser where uid!=0 and stat!=99");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by uid ");
            List<WZY.Model.SYSUSER> list = new List<WZY.Model.SYSUSER>();
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
        public WZY.Model.SYSUSER ReaderBind(IDataReader dataReader)
        {
            WZY.Model.SYSUSER model = new WZY.Model.SYSUSER();
            object ojb = dataReader["uid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.uid = (int)ojb;
            }
            ojb = dataReader["roleid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.roleid = (int)ojb;
            }
            ojb = dataReader["deptid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.deptid = (int)ojb;
            }
            model.username = dataReader["username"].ToString();
            model.password = dataReader["password"].ToString();
            model.displayname = dataReader["displayname"].ToString();
            model.remark = dataReader["remark"].ToString();
            model.pycode = dataReader["pycode"].ToString();
            ojb = dataReader["stat"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.stat = (int)ojb;
            }
            return model;
        }

        #endregion  Method

        public void Delete(WZY.Model.SYSUSER model)
        {
            model = GetModel(model.uid);
            model.password = "987654";//reset password
            model.stat = 99;//set as deleted
            Update(model);
            //Delete(model.uid);
        }

        public DataSet GetPage(string strWhere, int pagesize, int pageindex)
        {
            string inwhere = "";
            if (strWhere.Trim() != "")
            {
                inwhere = " where uid!=0 and stat!=99 and " + strWhere;
                strWhere = " and uid!=0 and stat!=99 and " + strWhere;
            }
            int start = (pageindex - 1) * pagesize;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pagesize + " uid,roleid,deptid,username,password,displayname,remark,pycode,stat ");
            strSql.Append(" FROM sysuser ");
            strSql.Append(" where uid not in ( select top " + start + " uid from sysuser " + inwhere + " order by uid )");
            strSql.Append(strWhere+" order by uid ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }


        /// <summary>
        /// 更新用户密码
        /// </summary>
        public void Update(int uid, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sysuser set ");
            strSql.Append("password=@password");
            strSql.Append(" where uid=@uid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "uid", DbType.Int32, uid);
            db.AddInParameter(dbCommand, "password", DbType.AnsiString, password);
            db.ExecuteNonQuery(dbCommand);

        }
        public string getPwd(int uid)
        {
            string sql = "select top 1 password from sysuser where uid=" + uid;
            Database db = DatabaseFactory.CreateDatabase();
            object r = db.ExecuteScalar(CommandType.Text, sql);
            return r.ToString();
        }
        /// <summary>
        /// 获取用户姓名
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string GetUserDisplayNameByID(int uid)
        {
            string sql = "select top 1 displayname from sysuser where uid=" + uid;
            Database db = DatabaseFactory.CreateDatabase();
            object r = db.ExecuteScalar(CommandType.Text, sql);
            return r.ToString();
        }

        /// <summary>
        /// 获取记录条数
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public int GetRecordCount(string filter)
        {
            string sql = "select count(1) from sysuser where uid!=0 and stat!=99 ";
            if (!string.IsNullOrEmpty(filter.Trim())) sql += " and " + filter;
            var database = DatabaseFactory.CreateDatabase();
            object obj = database.ExecuteScalar(CommandType.Text, sql);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }

    }
}


