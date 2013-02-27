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
    /// 数据访问类:CATE_DOC
    /// </summary>
    public partial class CATE_DOC
    {
        public CATE_DOC()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(cateid)+1 from cate_doc";
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
        public bool Exists(int cateid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from cate_doc where cateid=@cateid ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "cateid", DbType.Int32, cateid);
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
        public int Add(WZY.Model.CATE_DOC model)
        {
            isNameExist(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into cate_doc(");
            strSql.Append("catename,seq,remark)");

            strSql.Append(" values (");
            strSql.Append("@catename,@seq,@remark)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "catename", DbType.String, model.catename);
            db.AddInParameter(dbCommand, "seq", DbType.Int32, model.seq);
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
        public void Update(WZY.Model.CATE_DOC model)
        {
            isNameExist(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update cate_doc set ");
            strSql.Append("catename=@catename,");
            strSql.Append("seq=@seq,");
            strSql.Append("remark=@remark");
            strSql.Append(" where cateid=@cateid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "cateid", DbType.Int32, model.cateid);
            db.AddInParameter(dbCommand, "catename", DbType.String, model.catename);
            db.AddInParameter(dbCommand, "seq", DbType.Int32, model.seq);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int cateid)
        {
            if (checkSpecial(cateid)) throw new Exception("系统属性，不允许删除");
            if (new DOCS().GetList("cateid=" + cateid).Tables[0].Rows.Count > 0)
            {
                throw new Exception("该类别下有文档，不能删除");
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from cate_doc ");
            strSql.Append(" where cateid=@cateid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "cateid", DbType.Int32, cateid);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WZY.Model.CATE_DOC GetModel(int cateid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select cateid,catename,seq,remark from cate_doc ");
            strSql.Append(" where cateid=@cateid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "cateid", DbType.Int32, cateid);
            WZY.Model.CATE_DOC model = null;
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
            strSql.Append("select cate_doc.cateid cateid, typeid, catename,seq,remark ");
            strSql.Append(" FROM cate_doc ");
            strSql.Append(" left join yewudoc on yewudoc.cateid=cate_doc.cateid ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "cate_doc");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "cateid");
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
        public List<WZY.Model.CATE_DOC> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select cateid,catename,seq,remark ");
            strSql.Append(" FROM cate_doc ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<WZY.Model.CATE_DOC> list = new List<WZY.Model.CATE_DOC>();
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
        public WZY.Model.CATE_DOC ReaderBind(IDataReader dataReader)
        {
            WZY.Model.CATE_DOC model = new WZY.Model.CATE_DOC();
            object ojb;
            ojb = dataReader["cateid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.cateid = (int)ojb;
            }
            model.catename = dataReader["catename"].ToString();
            ojb = dataReader["seq"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.seq = (int)ojb;
            }
            model.remark = dataReader["remark"].ToString();
            return model;
        }

        #endregion  Method

        public void Delete(WZY.Model.CATE_DOC model)
        {
            Delete(model.cateid);
        }
        private static void isNameExist(WZY.Model.CATE_DOC model)
        {
            DataTable dt = new WZY.DAL.CATE_DOC().GetList("catename='" + model.catename + "'").Tables[0];
            if (dt.Rows.Count > 0 && dt.Rows[0]["cateid"].ToString() != model.cateid.ToString())
            {
                throw new Exception("该类别已存在");
            }
        }

        private bool checkSpecial(int cateid)
        {
            return cateid == 7;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByType(string typeid)
        {
            return GetList(" typeid=" + typeid + " order by seq");
        }
    }
}

