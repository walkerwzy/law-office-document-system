using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Security.Principal;
using System.Data;

namespace WZY.DAL
{
    /// <summary>
    ///scoPrincipal 的摘要说明
    /// </summary>
    public class myPrincipal : IPrincipal
    {
        private int _returncode;
        public int returncode { get { return _returncode; } }

        public IIdentity Identity { get; set; }

        public myPrincipal(string userid, string pwd)
        {
            Identity = new myIdentity(userid, pwd,out _returncode);
        }
        //已登录的验证
        public myPrincipal(int userid)
        {
            Identity = new myIdentity(userid);
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }

    public class myIdentity : IIdentity
    {
        public string username { get; private set; }
        public string password { get; private set; }

        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Name { get; set; }//保存主键

        public myIdentity(string userid, string pwd, out int returncode)
        {
            username = userid;
            password = pwd;
            AuthenticationType = "";
            IsAuthenticated = isauth(out returncode);
        }
        //已登录的验证，用主键来实例化
        public myIdentity(int userid)
        {
            AuthenticationType = "";
            IsAuthenticated = true;
            Name = userid.ToString();
        }

        private bool isauth(out int returncode)
        {
            AuthenticationType = "";
            int userid;
            IsAuthenticated = login(out returncode, out userid);

            Name = userid.ToString();
            return true;
        }

        //0：用户不存在 1：成功 2：密码错误 3：账号锁定 4：账号异常
        private bool login(out int msgcode, out int uid)
        {
            uid = -1;
            WZY.DAL.SYSUSER bll = new WZY.DAL.SYSUSER();
            DataSet ds = bll.GetList(" username='" + username + "' ");
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                msgcode = 0;
                return false;
            }
            ds = new WZY.DAL.SYSUSER().GetList(" username='" + username + "' and password='" + password + "' ");
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                msgcode = 2;
                return false;
            }
            DataRow dr = ds.Tables[0].Rows[0];
            if (dr["stat"].ToString() != "1")
            {
                msgcode = 3;
                return false;
            }
            if (!int.TryParse(dr["uid"].ToString(), out uid))
            {
                msgcode = 4;
                return false;
            }
            msgcode = 1;
            return true;
        }
    }

}
