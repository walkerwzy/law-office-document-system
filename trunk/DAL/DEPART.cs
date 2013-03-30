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
    /// 数据访问类:DEPART
    /// </summary>
    public partial class DEPART
    {
        public DEPART()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(deptid)+1 from depart";
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
        public bool Exists(int deptid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from depart where deptid=@deptid ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "deptid", DbType.Int32, deptid);
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
        public int Add(WZY.Model.DEPART model)
        {
            isNameExist(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into depart(");
            strSql.Append("deptname,seq,remark)");

            strSql.Append(" values (");
            strSql.Append("@deptname,@seq,@remark)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "deptname", DbType.String, model.deptname);
            db.AddInParameter(dbCommand, "seq", DbType.Int32, model.seq);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            int result;
            object obj = db.ExecuteScalar(dbCommand);
            Helper.HelperCache.RemoveCache("cache_dept");
            if (!int.TryParse(obj.ToString(), out result))
            {
                return 0;
            }
            return result;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(WZY.Model.DEPART model)
        {
            isNameExist(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update depart set ");
            strSql.Append("deptname=@deptname,");
            strSql.Append("seq=@seq,");
            strSql.Append("remark=@remark");
            strSql.Append(" where deptid=@deptid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "deptid", DbType.Int32, model.deptid);
            db.AddInParameter(dbCommand, "deptname", DbType.String, model.deptname);
            db.AddInParameter(dbCommand, "seq", DbType.Int32, model.seq);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            db.ExecuteNonQuery(dbCommand);

            Helper.HelperCache.RemoveCache("cache_dept");
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int deptid)
        {
            if (new WZY.DAL.SYSUSER().GetList(" deptid=" + deptid).Tables[0].Rows.Count > 0)
            {
                throw new Exception("有用户隶属于该部门，不允许删除");
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from depart ");
            strSql.Append(" where deptid=@deptid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "deptid", DbType.Int32, deptid);
            db.ExecuteNonQuery(dbCommand);

            Helper.HelperCache.RemoveCache("cache_dept");
        }

        public void Delete(WZY.Model.DEPART model)
        {
            Delete(model.deptid);
            Helper.HelperCache.RemoveCache("cache_dept");
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WZY.Model.DEPART GetModel(int deptid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select deptid,deptname,seq,remark from depart ");
            strSql.Append(" where deptid=@deptid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "deptid", DbType.Int32, deptid);
            WZY.Model.DEPART model = null;
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
            var cate = Helper.HelperCache.GetCache("cache_dept");
            if (cate == null)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select deptid,deptname,seq,remark ");
                strSql.Append(" FROM depart ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                Database db = DatabaseFactory.CreateDatabase();
                cate = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
                Helper.HelperCache.Insert("cache_dept", cate, 24);
            }
            return cate as DataSet;
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "depart");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "deptid");
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
        public List<WZY.Model.DEPART> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select deptid,deptname,seq,remark ");
            strSql.Append(" FROM depart ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<WZY.Model.DEPART> list = new List<WZY.Model.DEPART>();
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
        public WZY.Model.DEPART ReaderBind(IDataReader dataReader)
        {
            WZY.Model.DEPART model = new WZY.Model.DEPART();
            object ojb;
            ojb = dataReader["deptid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.deptid = (int)ojb;
            }
            model.deptname = dataReader["deptname"].ToString();
            ojb = dataReader["seq"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.seq = (int)ojb;
            }
            model.remark = dataReader["remark"].ToString();
            return model;
        }

        #endregion  Method


        private static void isNameExist(WZY.Model.DEPART model)
        {
            DataTable dt = new WZY.DAL.DEPART().GetList("deptname='" + model.deptname + "'").Tables[0];
            if (dt.Rows.Count > 0 && dt.Rows[0]["cateid"].ToString() != model.deptid.ToString())
            {
                throw new Exception("该类别已存在");
            }
        }
    }
}

