using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
namespace WZY.DAL
{
	/// <summary>
	/// 数据访问类:office
	/// </summary>
	public partial class office
	{
		public office()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WZY.Model.office model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into office(");
			strSql.Append("zongzhi,zhanlue,zhidu,bak1,bak2,bak3)");

			strSql.Append(" values (");
			strSql.Append("@zongzhi,@zhanlue,@zhidu,@bak1,@bak2,@bak3)");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "zongzhi", DbType.String, model.zongzhi);
			db.AddInParameter(dbCommand, "zhanlue", DbType.String, model.zhanlue);
			db.AddInParameter(dbCommand, "zhidu", DbType.String, model.zhidu);
			db.AddInParameter(dbCommand, "bak1", DbType.String, model.bak1);
			db.AddInParameter(dbCommand, "bak2", DbType.String, model.bak2);
			db.AddInParameter(dbCommand, "bak3", DbType.String, model.bak3);
			db.ExecuteNonQuery(dbCommand);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WZY.Model.office model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update office set ");
			strSql.Append("zongzhi=@zongzhi,");
			strSql.Append("zhanlue=@zhanlue,");
			strSql.Append("zhidu=@zhidu,");
			strSql.Append("bak1=@bak1,");
			strSql.Append("bak2=@bak2,");
			strSql.Append("bak3=@bak3");
            //strSql.Append(" where ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "zongzhi", DbType.String, model.zongzhi);
			db.AddInParameter(dbCommand, "zhanlue", DbType.String, model.zhanlue);
			db.AddInParameter(dbCommand, "zhidu", DbType.String, model.zhidu);
			db.AddInParameter(dbCommand, "bak1", DbType.String, model.bak1);
			db.AddInParameter(dbCommand, "bak2", DbType.String, model.bak2);
			db.AddInParameter(dbCommand, "bak3", DbType.String, model.bak3);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        //public void Delete()
        //{
        //    //该表无主键信息，请自定义主键/条件字段
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("delete from office ");
        //    strSql.Append(" where ");
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
        //    db.ExecuteNonQuery(dbCommand);

        //}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WZY.Model.office GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 zongzhi,zhanlue,zhidu,bak1,bak2,bak3 from office ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			WZY.Model.office model=null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select zongzhi,zhanlue,zhidu,bak1,bak2,bak3 ");
			strSql.Append(" FROM office ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "office");
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
		public List<WZY.Model.office> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select zongzhi,zhanlue,zhidu,bak1,bak2,bak3 ");
			strSql.Append(" FROM office ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<WZY.Model.office> list = new List<WZY.Model.office>();
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
		public WZY.Model.office ReaderBind(IDataReader dataReader)
		{
			WZY.Model.office model=new WZY.Model.office();
			model.zongzhi=dataReader["zongzhi"].ToString();
			model.zhanlue=dataReader["zhanlue"].ToString();
			model.zhidu=dataReader["zhidu"].ToString();
			model.bak1=dataReader["bak1"].ToString();
			model.bak2=dataReader["bak2"].ToString();
			model.bak3=dataReader["bak3"].ToString();
			return model;
		}

		#endregion  Method
	}
}

