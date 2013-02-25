using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Xml.Linq;
using System.IO;

public partial class ajaxHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var act = string.IsNullOrEmpty(Request["act"]) ? "" : Request["act"];
            switch (act.ToLower())
            {
                case "customer":
                    getCustormer();
                    break;
                case "deldoc":
                    delFile();
                    break;
                case "delcasefile":
                    delCaseFile();
                    break;
                case "getuser":
                    getUser();
                    break;
                case "getyewu":
                    getYeWu();
                    break;
                case "getdoccate":
                    getDocCate();
                    break;
                case "getalldoccate":
                    getAllDocCate();
                    break;
                default:
                    break;
            }
        }
    }


    private void delFile()
    {
        Response.Clear();
        Response.ContentType = "text/plain";

        string msg = "-1";
        int id = Convert.ToInt32(Request["id"]);
        WZY.Model.DOCS docs = new WZY.DAL.DOCS().GetModel(id);
        if (docs != null)
        {
            try
            {
                //删除记录
                new WZY.DAL.DOCS().Delete(id);
                msg = "1";//记录被删除就返回成功

                XDocument xdoc = Utility.getConfigFile();
                string uploadpath = xdoc.Root.Descendants("uploadpath").SingleOrDefault().Value;
                string filename = uploadpath + docs.docpath;
                if (File.Exists(filename))
                {
                    //删除文件（先删记录可保证虽然文件没有被删除，但是记录上查不出来了）
                    new FileInfo(filename).Delete();
                }
                //删除所在案件的文档记录
                //暂不实现，因为案件的文档被删除，预览文档时会提示文件不存在，提醒用户补传文件
            }
            catch
            {

            }
        }
        Response.Write(msg);
        Response.End();
    }

    private void delCaseFile()
    {
        Response.Clear();
        Response.ContentType = "text/plain";

        string msg = "-1";
        int id = Convert.ToInt32(Request["id"]);
        int caseid = Convert.ToInt32(Request["caseid"]);
        string field = Request["field"];
        try
        {
            //删除案件中对应字段的记录（即update)
            new WZY.DAL.CASES().DeleteDoc(caseid, field);
        }
        catch
        {
            Helper.log.error("ajax更新案件：" + caseid + field + "字段失败");
        }
        finally
        {
            WZY.Model.DOCS docs = new WZY.DAL.DOCS().GetModel(id);
            if (docs != null)
            {
                //不管案件记录中的文档状态有没有成功更新，都开始删除文件，不报异常
                //删除文档表的记录
                new WZY.DAL.DOCS().Delete(id);
                msg = "1";//记录被删除就返回成功

                try
                {
                    XDocument xdoc = Utility.getConfigFile();
                    string uploadpath = xdoc.Root.Descendants("uploadpath").SingleOrDefault().Value;
                    string filename = uploadpath + docs.docpath;
                    if (File.Exists(filename))
                    {
                        //删除文件（先删记录可保证虽然文件没有被删除，但是记录上查不出来了）
                        new FileInfo(filename).Delete();
                    }
                }
                catch
                {
                    //不捕捉真实文件删除情况
                    msg = "1";
                }
            }
            else
            {
                msg = "1";//文件已不存在，直接标记删除
            }
        }
        Response.Write(msg);
        Response.End();
    }

    private void getCustormer()
    {

        Response.Clear();
        Response.ContentType = "text/plain";

        string q = Request["key"];
        string uid = Request["uid"];
        string filter = " 1=1 ";
        if (!string.IsNullOrEmpty(q))
        {
            filter += " and ( custname like '%" + q + "%' or pycode like '%" + q.ToUpper() + "%' )";
        }
        //if (!string.IsNullOrEmpty(uid))
        //{
        //    filter += " and uid=" + uid;
        //}
        StringBuilder r = new StringBuilder("[");
        DataTable dt = new WZY.DAL.CUSTOMER().GetList(filter).Tables[0];
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                r.Append("[\"" + dr["custid"].ToString() + "\",\"" + dr["custname"].ToString() + "\",\"" + dr["pycode"].ToString().ToUpper() + "\",\"\"],");
            }
        }
        string arr = r.ToString();
        arr = arr.TrimEnd(',');
        arr += "]";
        Response.Write(arr);
        Response.End();
    }

    private void getUser()
    {
        Response.Clear();
        Response.ContentType = "text/plain";

        string q = Request["key"];
        string filter = "";
        if (!string.IsNullOrEmpty(q))
        {
            filter = "  displayname like '%" + q + "%' or pycode like '%" + q.ToUpper() + "%' ";
        }
        StringBuilder r = new StringBuilder("[");
        DataTable dt = new WZY.DAL.SYSUSER().GetList(filter).Tables[0];
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                r.Append("[\"" + dr["uid"].ToString() + "\",\"" + dr["displayname"].ToString() + "\",\"" + dr["pycode"].ToString().ToUpper() + "\",\"\"],");
            }
        }
        string arr = r.ToString();
        arr = arr.TrimEnd(',');
        arr += "]";
        Response.Write(arr);
        Response.End();
    }

    /// <summary>
    /// 获取业务类型下的文档类型
    /// </summary>
    private void getDocCate()
    {
        Response.Clear();
        Response.ContentType = "application/json";

        string id = Request["id"];
        StringBuilder r = new StringBuilder("[");
        DataTable dt = new WZY.DAL.CATE_DOC().GetListByType(id).Tables[0];
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                r.Append("[{\"id\":\"" + dr["cateid"].ToString() + "\",\"name\":\"" + dr["catename"].ToString() + "\"}],");
            }
        }
        string arr = r.ToString();
        arr = arr.TrimEnd(',');
        arr += "]";
        Response.Write(arr);
        Response.End();
    }

    /// <summary>
    /// 获取文档类型
    /// </summary>
    private void getAllDocCate()
    {
        Response.Clear();
        Response.ContentType = "application/json";

        StringBuilder r = new StringBuilder("[");
        DataTable dt = new WZY.DAL.CATE_DOC().GetList(" 1=1 order by seq").Tables[0];
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                r.Append("{\"id\":\"" + dr["cateid"].ToString() + "\",\"name\":\"" + dr["catename"].ToString() + "\",\"typeid\":\"" + dr["typeid"].ToString() + "\"},");
            }
        }
        string arr = r.ToString();
        arr = arr.TrimEnd(',');
        arr += "]";
        Response.Write(arr);
        Response.End();
    }

    /// <summary>
    /// 获取所有业务类型
    /// </summary>
    private void getYeWu()
    {
        Response.Clear();
        Response.ContentType = "application/json";

        StringBuilder r = new StringBuilder("[");
        DataTable dt = new WZY.DAL.cate_yewu().GetList(" 1=1 order by cate_index ").Tables[0];
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                r.Append("{\"id\":\"" + dr["cate_id"].ToString() + "\",\"name\":\"" + dr["cate_name"].ToString() + "\"},");
            }
        }
        string arr = r.ToString();
        arr = arr.TrimEnd(',');
        arr += "]";
        Response.Write(arr);
        Response.End();
    }
}