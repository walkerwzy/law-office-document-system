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
    /// 数据访问类:settings
    /// </summary>
    public partial class settings
    {
        public settings()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(WZY.Model.settings model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into settings(");
            strSql.Append("uid,pagesize,depart)");

            strSql.Append(" values (");
            strSql.Append("@uid,@pagesize,@depart)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
            db.AddInParameter(dbCommand, "pagesize", DbType.Int32, model.pagesize);
            db.AddInParameter(dbCommand, "depart", DbType.Int32, model.depart);
            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(WZY.Model.settings model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update settings set ");
            strSql.Append("uid=@uid,");
            strSql.Append("pagesize=@pagesize,");
            strSql.Append("depart=@depart");
            strSql.Append(" where uid=@uid");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
            db.AddInParameter(dbCommand, "pagesize", DbType.Int32, model.pagesize);
            db.AddInParameter(dbCommand, "depart", DbType.Int32, model.depart);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from settings ");
            strSql.Append(" where ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WZY.Model.settings GetModel(int uid)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select uid,pagesize,depart from settings ");
            strSql.Append(" where uid=" + uid);
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            WZY.Model.settings model = null;
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
            strSql.Append("select uid,pagesize,depart ");
            strSql.Append(" FROM settings ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "settings");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
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
        public List<WZY.Model.settings> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select uid,pagesize,depart ");
            strSql.Append(" FROM settings ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<WZY.Model.settings> list = new List<WZY.Model.settings>();
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
        public WZY.Model.settings ReaderBind(IDataReader dataReader)
        {
            WZY.Model.settings model = new WZY.Model.settings();
            object ojb;
            ojb = dataReader["uid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.uid = (int)ojb;
            }
            ojb = dataReader["pagesize"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.pagesize = (int)ojb;
            }
            ojb = dataReader["depart"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.depart = (int)ojb;
            }
            return model;
        }

        #endregion  Method
    }
}

