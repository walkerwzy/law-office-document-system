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
    /// 数据访问类:SYSROLE
    /// </summary>
    public partial class SYSROLE
    {
        public SYSROLE()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(roleid)+1 from sysrole";
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
        public bool Exists(int roleid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sysrole where roleid=@roleid ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "roleid", DbType.Int32, roleid);
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
        public int Add(WZY.Model.SYSROLE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sysrole(");
            strSql.Append("rolename,displayname,remark)");

            strSql.Append(" values (");
            strSql.Append("@rolename,@displayname,@remark)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "rolename", DbType.String, model.rolename);
            db.AddInParameter(dbCommand, "displayname", DbType.String, model.displayname);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            int result;
            object obj = db.ExecuteScalar(dbCommand);
            Helper.HelperCache.RemoveCache("cache_sysrole");
            if (!int.TryParse(obj.ToString(), out result))
            {
                return 0;
            }
            return result;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(WZY.Model.SYSROLE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sysrole set ");
            strSql.Append("rolename=@rolename,");
            strSql.Append("displayname=@displayname,");
            strSql.Append("remark=@remark");
            strSql.Append(" where roleid=@roleid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "roleid", DbType.Int32, model.roleid);
            db.AddInParameter(dbCommand, "rolename", DbType.String, model.rolename);
            db.AddInParameter(dbCommand, "displayname", DbType.String, model.displayname);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            db.ExecuteNonQuery(dbCommand);

            Helper.HelperCache.RemoveCache("cache_sysrole");
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int roleid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sysrole ");
            strSql.Append(" where roleid=@roleid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "roleid", DbType.Int32, roleid);
            db.ExecuteNonQuery(dbCommand);

            Helper.HelperCache.RemoveCache("cache_sysrole");
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WZY.Model.SYSROLE GetModel(int roleid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select roleid,rolename,displayname,remark from sysrole ");
            strSql.Append(" where roleid=@roleid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "roleid", DbType.Int32, roleid);
            WZY.Model.SYSROLE model = null;
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
            //字典数据，先查缓存
            var cate = Helper.HelperCache.GetCache("cache_sysrole");
            if (cate == null)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select roleid,rolename,displayname,remark ");
                strSql.Append(" FROM sysrole ");
                //if (strWhere.Trim() != "")
                //{
                //    strSql.Append(" where " + strWhere);
                //}
                Database db = DatabaseFactory.CreateDatabase();
                cate = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
                Helper.HelperCache.Insert("cache_sysrole", cate, 24);
            }
            return Utility.FilterData(cate as DataSet, strWhere);
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "sysrole");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "roleid");
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
        public List<WZY.Model.SYSROLE> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select roleid,rolename,displayname,remark ");
            strSql.Append(" FROM sysrole ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<WZY.Model.SYSROLE> list = new List<WZY.Model.SYSROLE>();
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
        public WZY.Model.SYSROLE ReaderBind(IDataReader dataReader)
        {
            WZY.Model.SYSROLE model = new WZY.Model.SYSROLE();
            object ojb;
            ojb = dataReader["roleid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.roleid = (int)ojb;
            }
            model.rolename = dataReader["rolename"].ToString();
            model.displayname = dataReader["displayname"].ToString();
            model.remark = dataReader["remark"].ToString();
            return model;
        }

        #endregion  Method
    }
}

