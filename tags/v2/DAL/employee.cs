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
    /// Data access:employee
    /// </summary>
    public partial class employee
    {
        public employee()
        { }
        #region  Method



        /// <summary>
        /// Add a record
        /// </summary>
        public void Add(WZY.Model.employee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into employee(");
            strSql.Append("uid,cert,gender,nation,birthday,hukou,family,intime,formtime,summary,remark,photo,baoxian,lizhi)");

            strSql.Append(" values (");
            strSql.Append("@uid,@cert,@gender,@nation,@birthday,@hukou,@family,@intime,@formtime,@summary,@remark,@photo,@baoxian,@lizhi)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
            db.AddInParameter(dbCommand, "cert", DbType.AnsiString, model.cert);
            db.AddInParameter(dbCommand, "gender", DbType.Byte, model.gender);
            db.AddInParameter(dbCommand, "nation", DbType.AnsiString, model.nation);
            db.AddInParameter(dbCommand, "birthday", DbType.DateTime, model.birthday);
            db.AddInParameter(dbCommand, "hukou", DbType.AnsiString, model.hukou);
            db.AddInParameter(dbCommand, "family", DbType.String, model.family);
            db.AddInParameter(dbCommand, "intime", DbType.DateTime, model.intime);
            db.AddInParameter(dbCommand, "formtime", DbType.DateTime, model.formtime);
            db.AddInParameter(dbCommand, "summary", DbType.String, model.summary);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            db.AddInParameter(dbCommand, "photo", DbType.AnsiString, model.photo);
            db.AddInParameter(dbCommand, "baoxian", DbType.DateTime, model.baoxian);
            db.AddInParameter(dbCommand, "lizhi", DbType.DateTime, model.lizhi);
            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// Update a record
        /// </summary>
        public void Update(WZY.Model.employee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update employee set ");
            //strSql.Append("uid=@uid,");
            strSql.Append("cert=@cert,");
            strSql.Append("gender=@gender,");
            strSql.Append("nation=@nation,");
            strSql.Append("birthday=@birthday,");
            strSql.Append("hukou=@hukou,");
            strSql.Append("family=@family,");
            strSql.Append("intime=@intime,");
            strSql.Append("formtime=@formtime,");
            strSql.Append("summary=@summary,");
            strSql.Append("remark=@remark,");
            strSql.Append("photo=@photo,");
            strSql.Append("baoxian=@baoxian,");
            strSql.Append("lizhi=@lizhi");
            strSql.Append(" where uid=@uid");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
            db.AddInParameter(dbCommand, "cert", DbType.AnsiString, model.cert);
            db.AddInParameter(dbCommand, "gender", DbType.Byte, model.gender);
            db.AddInParameter(dbCommand, "nation", DbType.AnsiString, model.nation);
            db.AddInParameter(dbCommand, "birthday", DbType.DateTime, model.birthday);
            db.AddInParameter(dbCommand, "hukou", DbType.AnsiString, model.hukou);
            db.AddInParameter(dbCommand, "family", DbType.String, model.family);
            db.AddInParameter(dbCommand, "intime", DbType.DateTime, model.intime);
            db.AddInParameter(dbCommand, "formtime", DbType.DateTime, model.formtime);
            db.AddInParameter(dbCommand, "summary", DbType.String, model.summary);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            db.AddInParameter(dbCommand, "photo", DbType.AnsiString, model.photo);
            db.AddInParameter(dbCommand, "baoxian", DbType.DateTime, model.baoxian);
            db.AddInParameter(dbCommand, "lizhi", DbType.DateTime, model.lizhi);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// Delete a record
        /// </summary>
        public void Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from employee ");
            strSql.Append(" where ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// Get an object entity
        /// </summary>
        public WZY.Model.employee GetModel(string uid)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select uid,cert,gender,nation,birthday,hukou,family,intime,formtime,summary,remark,photo,baoxian,lizhi from employee ");
            strSql.Append(" where uid=" + uid);
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            WZY.Model.employee model = null;
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
        /// Query data list
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select uid,cert,gender,nation,birthday,hukou,family,intime,formtime,summary,remark,photo,baoxian,lizhi ");
            strSql.Append(" FROM employee ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /*
        /// <summary>
        /// Paging data list
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "employee");
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
        public List<WZY.Model.employee> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select uid,cert,gender,nation,birthday,hukou,family,intime,formtime,summary,remark,photo,baoxian,lizhi ");
            strSql.Append(" FROM employee ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<WZY.Model.employee> list = new List<WZY.Model.employee>();
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
        public WZY.Model.employee ReaderBind(IDataReader dataReader)
        {
            WZY.Model.employee model = new WZY.Model.employee();
            object ojb;
            ojb = dataReader["uid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.uid = (int)ojb;
            }
            model.cert = dataReader["cert"].ToString();
            ojb = dataReader["gender"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.gender = int.Parse(ojb.ToString());
            }
            model.nation = dataReader["nation"].ToString();
            ojb = dataReader["birthday"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.birthday = (DateTime)ojb;
            }
            model.hukou = dataReader["hukou"].ToString();
            model.family = dataReader["family"].ToString();
            ojb = dataReader["intime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.intime = (DateTime)ojb;
            }
            ojb = dataReader["formtime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.formtime = (DateTime)ojb;
            }
            model.summary = dataReader["summary"].ToString();
            model.remark = dataReader["remark"].ToString();
            model.photo = dataReader["photo"].ToString();
            ojb = dataReader["baoxian"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.baoxian = (DateTime)ojb;
            }
            ojb = dataReader["lizhi"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.lizhi = (DateTime)ojb;
            }
            return model;
        }

        #endregion  Method
    }
}

