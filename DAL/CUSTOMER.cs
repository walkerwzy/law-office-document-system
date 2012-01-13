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
    /// 数据访问类:CUSTOMER
    /// </summary>
    public partial class CUSTOMER
    {
        public CUSTOMER()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(custid)+1 from customer";
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
        public bool Exists(string custno)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from customer where custno=@custno");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "custno", DbType.String, custno);
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
        public int Add(WZY.Model.CUSTOMER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into customer(");
            strSql.Append("cateid,uid,custno,recno,custname,pycode,address,tel,fax,post,email,contact,contel,owner,ownertel,ownerqq,charge,chargetel,chargeqq,summary,ownerbirth,lunar1,chargebirth,lunar2,remark)");

            strSql.Append(" values (");
            strSql.Append("@cateid,@uid,@custno,@recno,@custname,@pycode,@address,@tel,@fax,@post,@email,@contact,@contel,@owner,@ownertel,@ownerqq,@charge,@chargetel,@chargeqq,@summary,@ownerbirth,@lunar1,@chargebirth,@lunar2,@remark)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "cateid", DbType.Int32, model.cateid);
            db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
            db.AddInParameter(dbCommand, "custno", DbType.String, getSeqNo());
            db.AddInParameter(dbCommand, "recno", DbType.Int32, getMaxRecNo());
            db.AddInParameter(dbCommand, "custname", DbType.String, model.custname);
            db.AddInParameter(dbCommand, "pycode", DbType.AnsiString, model.pycode);
            db.AddInParameter(dbCommand, "address", DbType.String, model.address);
            db.AddInParameter(dbCommand, "tel", DbType.AnsiString, model.tel);
            db.AddInParameter(dbCommand, "fax", DbType.AnsiString, model.fax);
            db.AddInParameter(dbCommand, "post", DbType.AnsiString, model.post);
            db.AddInParameter(dbCommand, "email", DbType.AnsiString, model.email);
            db.AddInParameter(dbCommand, "contact", DbType.AnsiString, model.contact);
            db.AddInParameter(dbCommand, "contel", DbType.AnsiString, model.contel);
            db.AddInParameter(dbCommand, "owner", DbType.String, model.owner);
            db.AddInParameter(dbCommand, "ownertel", DbType.AnsiString, model.ownertel);
            db.AddInParameter(dbCommand, "ownerqq", DbType.AnsiString, model.ownerqq);
            db.AddInParameter(dbCommand, "charge", DbType.String, model.charge);
            db.AddInParameter(dbCommand, "chargetel", DbType.AnsiString, model.chargetel);
            db.AddInParameter(dbCommand, "chargeqq", DbType.AnsiString, model.chargeqq);
            db.AddInParameter(dbCommand, "summary", DbType.String, model.summary);
            db.AddInParameter(dbCommand, "ownerbirth", DbType.DateTime, model.ownerbirth);
            db.AddInParameter(dbCommand, "lunar1", DbType.Int32, model.lunar1);
            db.AddInParameter(dbCommand, "chargebirth", DbType.DateTime, model.chargebirth);
            db.AddInParameter(dbCommand, "lunar2", DbType.Int32, model.lunar2);
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
        public void Update(WZY.Model.CUSTOMER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update customer set ");
            strSql.Append("cateid=@cateid,");
            strSql.Append("uid=@uid,");
            strSql.Append("custno=@custno,");
            strSql.Append("recno=@recno,");
            strSql.Append("custname=@custname,");
            strSql.Append("pycode=@pycode,");
            strSql.Append("address=@address,");
            strSql.Append("tel=@tel,");
            strSql.Append("fax=@fax,");
            strSql.Append("post=@post,");
            strSql.Append("email=@email,");
            strSql.Append("contact=@contact,");
            strSql.Append("contel=@contel,");
            strSql.Append("owner=@owner,");
            strSql.Append("ownertel=@ownertel,");
            strSql.Append("ownerqq=@ownerqq,");
            strSql.Append("charge=@charge,");
            strSql.Append("chargetel=@chargetel,");
            strSql.Append("chargeqq=@chargeqq,");
            strSql.Append("summary=@summary,");
            strSql.Append("ownerbirth=@ownerbirth,");
            strSql.Append("lunar1=@lunar1,");
            strSql.Append("chargebirth=@chargebirth,");
            strSql.Append("lunar2=@lunar2,");
            strSql.Append("remark=@remark");
            strSql.Append(" where custid=@custid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "custid", DbType.Int32, model.custid);
            db.AddInParameter(dbCommand, "uid", DbType.Int32, model.uid);
            db.AddInParameter(dbCommand, "cateid", DbType.Int32, model.cateid);
            db.AddInParameter(dbCommand, "custno", DbType.String, model.custno);
            db.AddInParameter(dbCommand, "recno", DbType.Int32, model.recno);
            db.AddInParameter(dbCommand, "custname", DbType.String, model.custname);
            db.AddInParameter(dbCommand, "pycode", DbType.AnsiString, model.pycode);
            db.AddInParameter(dbCommand, "address", DbType.String, model.address);
            db.AddInParameter(dbCommand, "tel", DbType.AnsiString, model.tel);
            db.AddInParameter(dbCommand, "fax", DbType.AnsiString, model.fax);
            db.AddInParameter(dbCommand, "post", DbType.AnsiString, model.post);
            db.AddInParameter(dbCommand, "email", DbType.AnsiString, model.email);
            db.AddInParameter(dbCommand, "contact", DbType.AnsiString, model.contact);
            db.AddInParameter(dbCommand, "contel", DbType.AnsiString, model.contel);
            db.AddInParameter(dbCommand, "owner", DbType.String, model.owner);
            db.AddInParameter(dbCommand, "ownertel", DbType.AnsiString, model.ownertel);
            db.AddInParameter(dbCommand, "ownerqq", DbType.AnsiString, model.ownerqq);
            db.AddInParameter(dbCommand, "charge", DbType.String, model.charge);
            db.AddInParameter(dbCommand, "chargetel", DbType.AnsiString, model.chargetel);
            db.AddInParameter(dbCommand, "chargeqq", DbType.AnsiString, model.chargeqq);
            db.AddInParameter(dbCommand, "summary", DbType.String, model.summary);
            db.AddInParameter(dbCommand, "ownerbirth", DbType.DateTime, model.ownerbirth);
            db.AddInParameter(dbCommand, "lunar1", DbType.Int32, model.lunar1);
            db.AddInParameter(dbCommand, "chargebirth", DbType.DateTime, model.chargebirth);
            db.AddInParameter(dbCommand, "lunar2", DbType.Int32, model.lunar2);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int custid)
        {
            if (new CASES().GetList("custid=" + custid).Tables[0].Rows.Count > 0)
            {
                throw new Exception("该用户有关联案件，为了案件资料完整，不允许删除");
            }
            if (new DOCS().GetList("custid=" + custid).Tables[0].Rows.Count > 0)
            {
                throw new Exception("请先删除与该客户关联的文档");
            }
            WZY.Model.CUSTOMER c = new WZY.DAL.CUSTOMER().GetModel(custid);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from customer ");
            strSql.Append(" where custid=@custid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "custid", DbType.Int32, custid);
            db.ExecuteNonQuery(dbCommand);
            try
            {
                //重新排序号
                if (c == null) return;
                reorder(c.recno);

                //删除所有关联文档

                //删除所有合同记录

                //删除所有拜访记录
            }
            catch (Exception ex)
            {
                Helper.log.error("删除客户后进行的附加操作失败", ex.Message);
            }

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WZY.Model.CUSTOMER GetModel(int custid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select custid,uid,custno,recno,cateid,custname,pycode,address,tel,fax,post,email,contact,contel,owner,ownertel,ownerqq,charge,chargetel,chargeqq,summary,ownerbirth,lunar1,chargebirth,lunar2,remark from customer ");
            strSql.Append(" where custid=@custid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "custid", DbType.Int32, custid);
            WZY.Model.CUSTOMER model = null;
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
            strSql.Append("select custid,custno,recno,catename,uid,displayname,deptid,cateid,custname,pycode,address,tel,fax,post,email,contact,contel,owner,ownertel,ownerqq,charge,chargetel,chargeqq,summary,ownerbirth,lunar1,chargebirth,lunar2,remark,c_stime,c_etime,c_fee,c_ctime ");
            strSql.Append(" FROM customer ");
            strSql.Append(" left join(select uid as usid, displayname,deptid from sysuser) a on a.usid=customer.uid ");
            strSql.Append(" left join (select cateid cid, catename from cate_cust) b on b.cid=customer.cateid ");
            strSql.Append(" left join (");
            strSql.Append(" select clientid,c_stime,c_fee,c_etime,c_ctime from");
            strSql.Append(" (select MAX(c_stime) m,custid as clientid from contract group by custid) g ");
            strSql.Append(" left join contract c on c.custid=g.clientid and g.m=c.c_stime) c on c.clientid=customer.custid ");
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
        public DataSet GetListPure(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select custid,custno,recno,cateid,uid,custname,pycode,address,tel,fax,post,email,contact,contel,owner,ownertel,ownerqq,charge,chargetel,chargeqq,summary,remark,ownerbirth,lunar1,chargebirth,lunar2 ");
            strSql.Append(" from customer ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "customer");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "custid");
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
        public List<WZY.Model.CUSTOMER> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select custid,uid,custno,recno,cateid,custname,pycode,address,tel,fax,post,email,contact,contel,owner,ownertel,ownerqq,charge,chargetel,chargeqq,summary,ownerbirth,lunar1,chargebirth,lunar2,remark ");
            strSql.Append(" FROM customer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<WZY.Model.CUSTOMER> list = new List<WZY.Model.CUSTOMER>();
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
        public WZY.Model.CUSTOMER ReaderBind(IDataReader dataReader)
        {
            WZY.Model.CUSTOMER model = new WZY.Model.CUSTOMER();
            object ojb;
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
            ojb = dataReader["cateid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.cateid = (int)ojb;
            }
            ojb = dataReader["lunar1"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.lunar1 = Int32.Parse(ojb.ToString());
            }
            ojb = dataReader["lunar2"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.lunar2 = Int32.Parse(ojb.ToString());
            }
            ojb = dataReader["recno"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.recno = Int32.Parse(ojb.ToString());
            }
            model.custno = dataReader["custno"].ToString();
            model.custname = dataReader["custname"].ToString();
            model.pycode = dataReader["pycode"].ToString();
            model.address = dataReader["address"].ToString();
            model.tel = dataReader["tel"].ToString();
            model.fax = dataReader["fax"].ToString();
            model.post = dataReader["post"].ToString();
            model.email = dataReader["email"].ToString();
            model.owner = dataReader["owner"].ToString();
            model.ownertel = dataReader["ownertel"].ToString();
            model.ownerqq = dataReader["ownerqq"].ToString();
            model.charge = dataReader["charge"].ToString();
            model.chargetel = dataReader["chargetel"].ToString();
            model.chargeqq = dataReader["chargeqq"].ToString();
            model.summary = dataReader["summary"].ToString();
            model.remark = dataReader["remark"].ToString();
            model.contact = dataReader["contact"].ToString();
            model.contel= dataReader["contel"].ToString();
            ojb = dataReader["ownerbirth"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ownerbirth = (DateTime)ojb;
            }
            ojb = dataReader["chargebirth"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.chargebirth = (DateTime)ojb;
            }
            return model;
        }

        #endregion  Method

        public void Delete(WZY.Model.CUSTOMER model)
        {
            Delete(model.custid);
        }


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
            strSql.Append("select top " + pagesize + " custid,recno,catename,uid,custno,displayname,deptid,cateid,custname,pycode,address,tel,fax,post,email,contact,contel,owner,ownertel,ownerqq,charge,chargetel,chargeqq,summary,ownerbirth,lunar1,chargebirth,lunar2,remark,c_stime,c_etime,c_fee,c_ctime  ");
            strSql.Append(" FROM customer ");
            strSql.Append(" left join(select uid as usid, displayname,deptid from sysuser) a on a.usid=customer.uid ");
            strSql.Append(" left join (select cateid cid, catename from cate_cust) b on b.cid=customer.cateid ");
            strSql.Append(" left join (");
            strSql.Append(" select clientid,c_stime,c_fee,c_etime,c_ctime from");
            strSql.Append(" (select MAX(c_stime) m,custid as clientid from contract group by custid) g ");
            strSql.Append(" left join contract c on c.custid=g.clientid and g.m=c.c_stime) c on c.clientid=customer.custid ");
            strSql.Append(" where custid not in ( select top " + start + " custid from customer " + inwhere + " order by custid desc )");
            strSql.Append(strWhere);
            strSql.Append(" order by custid desc");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 更改用户-客户关系
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="custid"></param>
        public void changeRelationship(int uid, int custid)
        {
            string sql = "update customer set  uid=" + uid + " where custid=" + custid;
            Database db = DatabaseFactory.CreateDatabase();
            db.ExecuteNonQuery(CommandType.Text, sql);
        }
        /// <summary>
        /// 批量更改用户-客户关系
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="custid"></param>
        public void changeRelationship(int uid, string custid)
        {
            try
            {
                string sql = "update customer set  uid=" + uid + " where custid in (" + custid + ")";
                Database db = DatabaseFactory.CreateDatabase();
                db.ExecuteNonQuery(CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                Helper.log.error("更改客户所属时失败", ex.Message);
                throw new Exception(ex.Message);
            }
        }
        //生成客户编号
        private string getSeqNo()
        {
            string prefix = "E";
            string pre = prefix + DateTime.Now.ToString("yy");
            string temp = "";
            for (int i = 1; ; i++)
            {
                temp = i.ToString().PadLeft(3, '0');
                if (!Exists(pre + temp))
                {
                    pre = pre + temp;
                    break;
                }
            }
            return pre;
        }

        //生成最大的排序编号（特殊需求）
        private int getMaxRecNo()
        {
            string strsql = "select max(recno)+1 from customer";
            Database db = DatabaseFactory.CreateDatabase();
            object obj = db.ExecuteScalar(CommandType.Text, strsql);
            if (obj != null && obj != DBNull.Value)
            {
                return int.Parse(obj.ToString());
            }
            return 1;
        }

        //删除某条记录后，把其后的所有记录都重新排序
        private void reorder(int recno)
        {
            string strsql = "update customer set recno=recno-1 where recno>" + recno;
            Database db = DatabaseFactory.CreateDatabase();
            db.ExecuteNonQuery(CommandType.Text, strsql);
        }

        //客户名称是否存在
        public bool isNameExists(string custname)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from customer where custname=@custname");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "custname", DbType.String, custname);
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
    }
}

