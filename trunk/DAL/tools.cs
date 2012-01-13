using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace WZY.DAL
{
    public static class tools
    {
        public static string toMD5(this string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
        }
        public static string ToBase64(this string srcStr)
        {
            byte[] b = System.Text.Encoding.UTF8.GetBytes(srcStr);
            return Convert.ToBase64String(b);
        }

        public static string FromBase64(this string base64str)
        {
            byte[] b = Convert.FromBase64String(base64str);
            return System.Text.Encoding.UTF8.GetString(b);
        }

        public static void beckupDB(string path)
        {
            string filename = System.IO.Path.Combine(path, DateTime.Now.ToString("yyyy_MM_dd_HHmmss_fff") + ".bak");
            string SqlStr2 = "backup database lawdoc  to disk='" + filename + "'";
            try
            {
                if (File.Exists(filename))
                {
                    throw new Exception("同名文件已存在，请稍候再试");
                }
                Database db = DatabaseFactory.CreateDatabase();
                db.ExecuteNonQuery(CommandType.Text, SqlStr2);
            }
            catch (Exception ex)
            {
                Helper.log.error("备份数据库失败", ex.Message);
                throw new Exception("备份数据库失败");
            }
        }

        public static void recoveryDB(string filename)
        {
            string SqlStr2 = "use master  restore database lawdoc from disk='" + filename + "' WITH REPLACE";
            Database db = DatabaseFactory.CreateDatabase();
            try
            {
                db.ExecuteNonQuery(CommandType.Text, SqlStr2);
            }
            catch
            {
                try
                {
                    string path = Utility.getConfigFile().Root.Descendants("dbpath").SingleOrDefault().Value;
                    filename = System.IO.Path.Combine(path, filename);
                    SqlStr2 = "use master  restore database lawdoc from disk='" + filename + "' WITH REPLACE";
                    db.ExecuteNonQuery(CommandType.Text, SqlStr2);
                }
                catch (Exception ee)
                {
                    Helper.log.error("恢复数据库失败", SqlStr2, ee.Message);
                    throw new Exception("恢复数据库失败");
                }
            }
        }
    }
}
