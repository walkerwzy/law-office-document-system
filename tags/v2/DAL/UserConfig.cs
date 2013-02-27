using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WZY.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace WZY.DAL
{
    public class UserConfig
    {
        public UserConfig()
        {

        }

        public WZY.Model.UserConfig getModel(int uid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DataSet ds = db.ExecuteDataSet(CommandType.Text, "select top 1 * from settings where uid=" + uid);
            if (ds.Tables[0].Rows.Count==0)
            {
                return null;
            }
            DataRow dr = ds.Tables[0].Rows[0];
            WZY.Model.UserConfig model=new Model.UserConfig ();
            int ps = 20;
            int.TryParse(dr["pagesize"].ToString(), out ps);
            model.pagesize = ps;
            return model;

        }
    }
}
