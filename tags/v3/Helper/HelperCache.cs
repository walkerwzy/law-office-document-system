using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Helper
{
    public static class HelperCache
    {
        public static object GetCache(string key)
        {
            return HttpRuntime.Cache[key];
        }


        /// <summary>
        /// 添加对象到缓存
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="value">键值</param>
        public static void Insert(string key, object value)
        {
            HttpRuntime.Cache.Insert(key, value);
        }

        /// <summary>
        /// 添加对象到缓存
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="value">键值</param>
        /// <param name="denpendency">依赖项的文件名物理路径</param>
        public static void Insert(string key, object value, string denpendency)
        {
            HttpRuntime.Cache.Insert(key, value, new System.Web.Caching.CacheDependency(denpendency));
        }
    }
}
