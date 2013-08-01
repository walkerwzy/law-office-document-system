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
    /// 数据访问类:CASES
    /// </summary>
    public partial class CASES
    {
        public CASES()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(caseid)+1 from cases";
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
        public bool Exists(int caseid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from cases where caseid=@caseid ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "caseid", DbType.Int32, caseid);
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
        public int Add(WZY.Model.CASES model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into cases(");
            strSql.Append("caseno,cateid,custid,uid,lawid,xieban,juzheng,yuangao,beigao,anyou,shouan,court,dijiaotime,faguan,faguantel,office,kaiting,panjuetime,fee,detail,analysis,evidence,opinion,quote,qisu,taolun,result,resultreport,tiwen,dabian,remark)");
            strSql.Append(" values (");
            strSql.Append("'" + getSeqNo(model.cateid.Value) + "',@cateid,@custid,@uid,@lawid,@xieban,@juzheng,@yuangao,@beigao,@anyou,@shouan,@court,@dijiaotime,@faguan,@faguantel,@office,@kaiting,@panjuetime,@fee,@detail,@analysis,@evidence,@opinion,@quote,@qisu,@taolun,@result,@resultreport,@tiwen,@dabian,@remark)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
            db.AddInParameter(dbCommand, "lawid", DbType.Int32, model.lawid);
            db.AddInParameter(dbCommand, "xieban", DbType.Int32, model.xieban);
            db.AddInParameter(dbCommand, "juzheng", DbType.DateTime, model.juzheng);
            db.AddInParameter(dbCommand, "cateid", DbType.Int32, model.cateid);
            db.AddInParameter(dbCommand, "custid", DbType.Int32, model.custid);
            db.AddInParameter(dbCommand, "yuangao", DbType.String, model.yuangao);
            db.AddInParameter(dbCommand, "beigao", DbType.String, model.beigao);
            db.AddInParameter(dbCommand, "anyou", DbType.String, model.anyou);
            db.AddInParameter(dbCommand, "court", DbType.String, model.court);
            db.AddInParameter(dbCommand, "shouan", DbType.DateTime, model.shouan);
            db.AddInParameter(dbCommand, "dijiaotime", DbType.DateTime, model.dijiaotime);
            db.AddInParameter(dbCommand, "faguan", DbType.String, model.faguan);
            db.AddInParameter(dbCommand, "faguantel", DbType.AnsiString, model.faguantel);
            db.AddInParameter(dbCommand, "office", DbType.AnsiString, model.office);
            db.AddInParameter(dbCommand, "kaiting", DbType.DateTime, model.kaiting);
            db.AddInParameter(dbCommand, "panjuetime", DbType.DateTime, model.panjuetime);
            db.AddInParameter(dbCommand, "fee", DbType.Decimal, model.fee);
            db.AddInParameter(dbCommand, "detail", DbType.Int32, model.detail);
            db.AddInParameter(dbCommand, "analysis", DbType.Int32, model.analysis);
            db.AddInParameter(dbCommand, "evidence", DbType.Int32, model.evidence);
            db.AddInParameter(dbCommand, "opinion", DbType.Int32, model.opinion);
            db.AddInParameter(dbCommand, "quote", DbType.Int32, model.quote);
            db.AddInParameter(dbCommand, "qisu", DbType.Int32, model.qisu);
            db.AddInParameter(dbCommand, "taolun", DbType.Int32, model.taolun);
            db.AddInParameter(dbCommand, "result", DbType.Int32, model.result);
            db.AddInParameter(dbCommand, "resultreport", DbType.Int32, model.resultreport);
            db.AddInParameter(dbCommand, "tiwen", DbType.Int32, model.tiwen);
            db.AddInParameter(dbCommand, "dabian", DbType.Int32, model.dabian);
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
        public void Update(WZY.Model.CASES model)
        {
            //暂不提供更新uid
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update cases set ");
            strSql.Append("lawid=@lawid,");
            strSql.Append("xieban=@xieban,");
            strSql.Append("juzheng=@juzheng,");
            strSql.Append("caseno=@caseno,");
            strSql.Append("cateid=@cateid,");
            strSql.Append("custid=@custid,");
            strSql.Append("yuangao=@yuangao,");
            strSql.Append("beigao=@beigao,");
            strSql.Append("anyou=@anyou,");
            strSql.Append("shouan=@shouan,");
            strSql.Append("court=@court,");
            strSql.Append("dijiaotime=@dijiaotime,");
            strSql.Append("faguan=@faguan,");
            strSql.Append("faguantel=@faguantel,");
            strSql.Append("office=@office,");
            strSql.Append("kaiting=@kaiting,");
            strSql.Append("panjuetime=@panjuetime,");
            strSql.Append("fee=@fee,");
            strSql.Append("detail=@detail,");
            strSql.Append("analysis=@analysis,");
            strSql.Append("evidence=@evidence,");
            strSql.Append("opinion=@opinion,");
            strSql.Append("quote=@quote,");
            strSql.Append("qisu=@qisu,");
            strSql.Append("taolun=@taolun,");
            strSql.Append("result=@result,");
            strSql.Append("resultreport=@resultreport,");
            strSql.Append("tiwen=@tiwen,");
            strSql.Append("dabian=@dabian,");
            strSql.Append("remark=@remark");
            strSql.Append(" where caseid=@caseid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
            db.AddInParameter(dbCommand, "lawid", DbType.Int32, model.lawid);
            db.AddInParameter(dbCommand, "xieban", DbType.Int32, model.xieban);
            db.AddInParameter(dbCommand, "juzheng", DbType.DateTime, model.juzheng);
            db.AddInParameter(dbCommand, "caseno", DbType.String, updateSeqNo(model.caseno, model.cateid.Value));
            db.AddInParameter(dbCommand, "caseid", DbType.Int32, model.caseid);
            db.AddInParameter(dbCommand, "cateid", DbType.Int32, model.cateid);
            db.AddInParameter(dbCommand, "custid", DbType.Int32, model.custid);
            db.AddInParameter(dbCommand, "yuangao", DbType.String, model.yuangao);
            db.AddInParameter(dbCommand, "beigao", DbType.String, model.beigao);
            db.AddInParameter(dbCommand, "anyou", DbType.String, model.anyou);
            db.AddInParameter(dbCommand, "shouan", DbType.DateTime, model.shouan);
            db.AddInParameter(dbCommand, "court", DbType.String, model.court);
            db.AddInParameter(dbCommand, "dijiaotime", DbType.DateTime, model.dijiaotime);
            db.AddInParameter(dbCommand, "faguan", DbType.String, model.faguan);
            db.AddInParameter(dbCommand, "faguantel", DbType.AnsiString, model.faguantel);
            db.AddInParameter(dbCommand, "office", DbType.AnsiString, model.office);
            db.AddInParameter(dbCommand, "kaiting", DbType.DateTime, model.kaiting);
            db.AddInParameter(dbCommand, "panjuetime", DbType.DateTime, model.panjuetime);
            db.AddInParameter(dbCommand, "fee", DbType.Decimal, model.fee);
            db.AddInParameter(dbCommand, "detail", DbType.Int32, model.detail);
            db.AddInParameter(dbCommand, "analysis", DbType.Int32, model.analysis);
            db.AddInParameter(dbCommand, "evidence", DbType.Int32, model.evidence);
            db.AddInParameter(dbCommand, "opinion", DbType.Int32, model.opinion);
            db.AddInParameter(dbCommand, "quote", DbType.Int32, model.quote);
            db.AddInParameter(dbCommand, "qisu", DbType.Int32, model.qisu);
            db.AddInParameter(dbCommand, "taolun", DbType.Int32, model.taolun);
            db.AddInParameter(dbCommand, "result", DbType.Int32, model.result);
            db.AddInParameter(dbCommand, "resultreport", DbType.Int32, model.resultreport);
            db.AddInParameter(dbCommand, "tiwen", DbType.Int32, model.tiwen);
            db.AddInParameter(dbCommand, "dabian", DbType.Int32, model.dabian);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int caseid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from cases ");
            strSql.Append(" where caseid=@caseid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "caseid", DbType.Int32, caseid);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WZY.Model.CASES GetModel(int caseid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select caseid,caseno,cateid,custid,uid,lawid,xieban,juzheng,yuangao,beigao,anyou,shouan,court,dijiaotime,faguan,faguantel,office,kaiting,panjuetime,fee,detail,analysis,evidence,opinion,quote,qisu,taolun,result,resultreport,tiwen,dabian,remark from cases ");
            strSql.Append(" where caseid=@caseid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "caseid", DbType.Int32, caseid);
            WZY.Model.CASES model = null;
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
            strSql.Append("select caseno,caseid,cateid,chargedeptid,custid,uid,displayname,lawid,lawname,deptid,custname,xieban,juzheng,yuangao,beigao,anyou,court,shouan,dijiaotime,faguan,faguantel,office,kaiting,panjuetime,fee,detail,analysis,evidence,opinion,quote,qisu,taolun,result,resultreport,tiwen,dabian,remark ");
            strSql.Append(" FROM cases ");
            strSql.Append(" left join (select custid as id,cateid as custcateid, custname, pycode from customer) as a on a.id=cases.custid ");
            strSql.Append(" left join (select uid as userid, displayname from sysuser) as b on b.userid=cases.uid ");//上传人
            strSql.Append(" left join (select uid as lawerid, deptid, username, displayname as lawname from sysuser) as d on d.lawerid=cases.lawid ");//承办律师
            strSql.Append("left join (select deptid as chargedeptid,cateid as cateid2 from cate_cust) as c on c.cateid2=a.custcateid ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListPager(string strWhere, int pagesize, int pageindex, string orderby, string orderdirection)
        {
            //如果查询条件涉及关联表的条件，则需要把关联表也同时写到row函数里去
            int start = pagesize*(pageindex - 1) + 1;
            int end = start + pagesize - 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(
                "select caseno,caseid,cateid,chargedeptid,custid,uid,displayname,lawid,lawname,deptid,custname,xieban,juzheng,yuangao,beigao,anyou,court,shouan,dijiaotime,faguan,faguantel,office,kaiting,panjuetime,fee,detail,analysis,evidence,opinion,quote,qisu,taolun,result,resultreport,tiwen,dabian,remark");
            strSql.Append(" from (");
            //分页数据开始
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby + (orderdirection.ToLower() == "desc" ? " desc" : ""));
            }
            else
            {
                strSql.Append("order by T.caseid desc");
            }
            strSql.Append(")AS Row, T.*  from ");
            strSql.Append("(select source2.* from cases source2");
            strSql.Append(" left join (select custid as id,cateid as custcateid, custname, pycode from customer) as a on a.id=source2.custid ");
            strSql.Append(" left join (select uid as userid, displayname from sysuser) as b on b.userid=source2.uid ");//上传人
            strSql.Append(" left join (select uid as lawerid, deptid, username, displayname as lawname from sysuser) as d on d.lawerid=source2.lawid ");//承办律师
            strSql.Append(" left join (select deptid as chargedeptid,cateid as cateid2 from cate_cust) as c on c.cateid2=a.custcateid ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(") T  ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", start, end);
            //分页数据结束
            strSql.Append(") source ");
            strSql.Append(" left join (select custid as id,cateid as custcateid, custname, pycode from customer) as a on a.id=source.custid ");
            strSql.Append(" left join (select uid as userid, displayname from sysuser) as b on b.userid=source.uid ");//上传人
            strSql.Append(" left join (select uid as lawerid, deptid, username, displayname as lawname from sysuser) as d on d.lawerid=source.lawid ");//承办律师
            strSql.Append(" left join (select deptid as chargedeptid,cateid as cateid2 from cate_cust) as c on c.cateid2=a.custcateid ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }

            var database = DatabaseFactory.CreateDatabase();
            return database.ExecuteDataSet(CommandType.Text, strSql.ToString());


            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select caseno,caseid,cateid,chargedeptid,custid,uid,displayname,lawid,lawname,deptid,custname,yuangao,beigao,anyou,court,shouan,dijiaotime,faguan,faguantel,office,kaiting,panjuetime,fee,detail,analysis,evidence,opinion,quote,qisu,taolun,result,resultreport,tiwen,dabian,remark ");
            //strSql.Append(" FROM cases ");
            //strSql.Append(" left join (select custid as id,cateid as custcateid, custname, pycode from customer) as a on a.id=cases.custid ");
            //strSql.Append(" left join (select uid as userid, displayname from sysuser) as b on b.userid=cases.uid ");//上传人
            //strSql.Append(" left join (select uid as lawerid, deptid, username, displayname as lawname from sysuser) as d on d.lawerid=cases.lawid ");//承办律师
            //strSql.Append("left join (select deptid as chargedeptid,cateid as cateid2 from cate_cust) as c on c.cateid2=a.custcateid ");
            //if (strWhere.Trim() != "")
            //{
            //    strSql.Append(" where " + strWhere);
            //}
            //Database db = DatabaseFactory.CreateDatabase();
            //return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "cases");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "caseid");
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
        public List<WZY.Model.CASES> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select caseno,caseid,cateid,custid,uid,lawid,xieban,juzheng,yuangao,beigao,anyou,shouan,court,dijiaotime,faguan,faguantel,office,kaiting,panjuetime,fee,detail,analysis,evidence,opinion,quote,qisu,taolun,result,resultreport,tiwen,dabian,remark ");
            strSql.Append(" FROM cases ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<WZY.Model.CASES> list = new List<WZY.Model.CASES>();
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
        public WZY.Model.CASES ReaderBind(IDataReader dataReader)
        {
            WZY.Model.CASES model = new WZY.Model.CASES();
            object ojb;
            model.caseno = dataReader["caseno"].ToString();
            ojb = dataReader["caseid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.caseid = (int)ojb;
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
            ojb = dataReader["uid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.uid = (int)ojb;
            }
            ojb = dataReader["lawid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.lawid = (int)ojb;
            }
            ojb = dataReader["xieban"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.xieban = (int)ojb;
            }
            model.yuangao = dataReader["yuangao"].ToString();
            model.beigao = dataReader["beigao"].ToString();
            model.anyou = dataReader["anyou"].ToString();
            model.court = dataReader["court"].ToString();
            ojb = dataReader["shouan"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.shouan = (DateTime)ojb;
            }
            ojb = dataReader["dijiaotime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.dijiaotime = (DateTime)ojb;
            }
            ojb = dataReader["juzheng"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.juzheng = (DateTime)ojb;
            }
            model.faguan = dataReader["faguan"].ToString();
            model.faguantel = dataReader["faguantel"].ToString();
            model.office = dataReader["office"].ToString();
            ojb = dataReader["kaiting"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.kaiting = (DateTime)ojb;
            }
            ojb = dataReader["panjuetime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.panjuetime = (DateTime)ojb;
            }
            ojb = dataReader["fee"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.fee = (decimal)ojb;
            }
            ojb = dataReader["detail"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.detail = (int)ojb;
            }
            ojb = dataReader["analysis"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.analysis = (int)ojb;
            }
            ojb = dataReader["evidence"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.evidence = (int)ojb;
            }
            ojb = dataReader["opinion"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.opinion = (int)ojb;
            }
            ojb = dataReader["quote"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.quote = (int)ojb;
            }
            ojb = dataReader["result"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.result = (int)ojb;
            }
            ojb = dataReader["resultreport"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.resultreport = (int)ojb;
            }
            ojb = dataReader["qisu"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.qisu = (int)ojb;
            }
            ojb = dataReader["taolun"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.taolun = (int)ojb;
            }
            ojb = dataReader["tiwen"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.tiwen = (int)ojb;
            }
            ojb = dataReader["dabian"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.dabian = (int)ojb;
            }
            model.remark = dataReader["remark"].ToString();
            return model;
        }

        #endregion  Method


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string caseno)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from cases where caseno=@caseno ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "caseno", DbType.String, caseno);
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
        /// 删除多条数据
        /// </summary>
        public void Delete(string ids)
        {
            string sql = "delete from cases where caseid in (" + ids + ")";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.ExecuteNonQuery(dbCommand);

        }


        /// <summary>
        /// 更新案件某个的文件的状态
        /// </summary>
        public void Update(int caseid, string field, int docid)
        {
            //暂不提供更新uid
            string strSql = "update cases set " + field + "=" + docid;
            strSql += " where caseid=@caseid ";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 删除案件的某个文件的记录（其实还是update，不过值一定是-1）
        /// </summary>
        public void DeleteDoc(int caseid, string field)
        {
            //暂不提供更新uid
            string strSql = "update cases set " + field + "=-1";
            strSql += " where caseid=" + caseid;
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            db.ExecuteNonQuery(dbCommand);

        }

        public int GetRecordCount(string filter)
        {

            StringBuilder strSql = new StringBuilder();
            //strSql.Append(
            //    "select caseno,caseid,cateid,chargedeptid,custid,uid,displayname,lawid,lawname,deptid,custname,yuangao,beigao,anyou,court,shouan,dijiaotime,faguan,faguantel,office,kaiting,panjuetime,fee,detail,analysis,evidence,opinion,quote,qisu,taolun,result,resultreport,tiwen,dabian,remark");
            //strSql.Append(" from (");
            //分页数据开始
            strSql.Append("SELECT count(1) FROM cases ");
            strSql.Append(" left join (select custid as id,cateid as custcateid, custname, pycode from customer) as a on a.id=cases.custid ");
            strSql.Append(" left join (select uid as userid, displayname from sysuser) as b on b.userid=cases.uid ");//上传人
            strSql.Append(" left join (select uid as lawerid, deptid, username, displayname as lawname from sysuser) as d on d.lawerid=cases.lawid ");//承办律师
            strSql.Append(" left join (select deptid as chargedeptid,cateid as cateid2 from cate_cust) as c on c.cateid2=a.custcateid ");
            if (!string.IsNullOrEmpty(filter))
            {
                strSql.Append("where " + filter);
            }

            //string sql = "select count(1) from cases ";
            //if (!string.IsNullOrEmpty(filter.Trim())) sql += " where " + filter;
            var database = DatabaseFactory.CreateDatabase();
            object obj = database.ExecuteScalar(CommandType.Text, strSql.ToString());
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }

        //生成案件序列号
        private string getSeqNo(int cateid)
        {
            string prefix = "A";
            try
            {
                WZY.Model.CATE_CASE m = new WZY.DAL.CATE_CASE().GetModel(cateid);
                if (m != null) prefix = m.prefix;
            }
            catch { }
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
        private string updateSeqNo(string seq, int cateid)
        {
            string prefix = "A";
            try
            {
                WZY.Model.CATE_CASE m = new WZY.DAL.CATE_CASE().GetModel(cateid);
                if (m != null) prefix = m.prefix;
            }
            catch { }
            if (seq.IndexOf(prefix) >= 0) return seq;
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
    }

}

