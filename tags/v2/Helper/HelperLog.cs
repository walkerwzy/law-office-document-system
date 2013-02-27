using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

namespace Helper
{

    public class HelperLog
    {
        public static object o = new object();

        internal static void write(string logpath, string content)
        {
            lock (o)
            {
                FileStream fs = new FileStream(logpath, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(content);
                sw.Close();
                fs.Close();
            }
        }
    }

    public enum LogType { Error = 1, Warning, Debug, Trace }

    /// <summary>
    ///log 的摘要说明
    /// </summary>
    public class log
    {
        public log()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region 公开的日志方法
        public static void debug(params string[] contents)
        {
            write(LogType.Debug, contents);
        }
        public static void error(params string[] contents)
        {
            write(LogType.Error, contents);
        }
        public static void trace(params string[] contents)
        {
            write(LogType.Trace, contents);
        }
        public static void warn(params string[] contents)
        {
            write(LogType.Warning, contents);
        }
        #endregion

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="type">日志类型</param>
        /// <param name="content">要写入的日志信息，每增加一个参数日志增加一行</param>
        private static void write(LogType type, params string[] contents)
        {
            //从配置文件取出路径地址
            string logpath = getConfigFile().Root.Descendants("logpath").SingleOrDefault().Value;
            string fileprefix = "";
            switch ((int)type)
            {
                case 2:
                    logpath += "warning/";
                    fileprefix = "wa_";
                    break;
                case 3:
                    logpath += "debug/";
                    fileprefix = "db_";
                    break;
                case 4:
                    logpath += "trace/";
                    fileprefix = "tc_";
                    break;
                case 1:
                default:
                    logpath += "error/";
                    fileprefix = "er_";
                    break;
            }

            //判断路径、文件是否存在，如不存在则生成相关资源
            //string dir = HttpContext.Current.Server.MapPath(logpath);
            string dir = logpath;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            //设置文件名
            string currtime = DateTime.Now.ToString("yyyyMM");
            logpath += fileprefix + currtime + ".log";
            //string filename = HttpContext.Current.Server.MapPath(logpath);
            string filename = logpath;
            if (!File.Exists(filename))
            {
                FileStream fs = File.Create(filename);
                fs.Close();
            }
            //格式化写入日志
            /*错误信息
             *日志时间,调用类名，方法名
             */
            string logstr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " ";
            for (int i = 0; i < contents.Length; i++)
            {
                logstr += contents[i] + "\r\n";
            }
            //添加反射信息
            string typename, methodname;
            getReflect(out typename, out methodname);
            if (!string.IsNullOrEmpty(typename) && !string.IsNullOrEmpty(methodname))
            {
                logstr += "Invoker: " + typename + "." + methodname + "()\r\n";
            }
            try
            {
                HelperLog.write(filename, logstr);
            }
            catch (Exception ex)
            {
                log.write(LogType.Error, ex.Message, "typename:Log", "methodname:write");
            }

        }

        //通过反射获取调用的类名和方法名
        private static void getReflect(out string typename, out string methodname)
        {
            typename = "";
            methodname = "";
            StackTrace sc = new StackTrace();
            foreach (StackFrame item in sc.GetFrames())
            {
                MethodBase m = item.GetMethod();
                Type t = m.ReflectedType;
                if (t.Namespace == "WZY.DAL")
                {
                    typename = t.FullName;
                    methodname = m.Name;
                    break;
                }
            }
        }


        public static XDocument getConfigFile()
        {
            if (Helper.HelperCache.GetCache("xmlconfig") == null)
            {
                string path = HttpContext.Current.Server.MapPath("~/configuration/site.xml");
                XDocument xdoc = XDocument.Load(path);
                Helper.HelperCache.Insert("xmlconfig", xdoc, path);
            }
            return Helper.HelperCache.GetCache("xmlconfig") as XDocument;
        }
    }

}
