using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Lunar;
using WZY.Model;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string result = "hello world";
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        CloseCaseInfo u = new CloseCaseInfo(33, "aa");
        result = serializer.Serialize(u);
        CloseCaseInfo m = serializer.Deserialize<CloseCaseInfo>(result);
        Response.Write(result);
        Response.End();
        //if (!IsPostBack)
        //{
        //    //Response.Write(DateTime.Now > DateTime.Now.AddDays(1));
        //    //Response.End();
        //    //Response.Write(Utility.getConfigFile().Root.Descendants("logpath").Single().Value);
        //    //Response.End();
        //    //Helper.HelperCache.Insert("aa", "abcdefg");
        //    //Response.Write(Helper.HelperCache.GetCache("aa") as string);
        //    //Response.Write(new Lunar.LunarDate().);
        //    //Response.End();

        //    int pagesize = 2;
        //    DataSet ds = new WZY.DAL.CASES().GetList("");
        //    int page;
        //    if (!int.TryParse(Request["page"], out page))
        //    {
        //        page = 1;
        //    }

        //    PagedDataSource ps = new PagedDataSource();
        //    ps.DataSource = ds.Tables[0].DefaultView;
        //    ps.AllowPaging = true;
        //    ps.PageSize = pagesize;
        //    if (page > ps.PageCount) page = 1;
        //    ps.CurrentPageIndex = page - 1;

        //    gv.DataSource = ps;
        //    gv.DataBind();

        //    //生成分页代码
        //    string url = Request.Url.ToString();

        //    lblpager.Text = Pager.getPagerstring(ps, url, 1, 7);

        //}
    }

    protected void up(object sender, EventArgs e)
    {
        string imgUrl = "";
        if (this.FileUpload_Img.HasFile)
        {
            if (imgUrl != "")
            {
                string filename = Server.MapPath("./") + "/" + imgUrl;
                if (File.Exists(filename))
                {
                    new FileInfo(filename).Delete();
                }
            }
            string p = FileUpload_Img.FileName;
            Response.Write(FileUpload_Img.FileName + "," + FileUpload_Img.PostedFile.FileName + "<br>");
            string s = System.IO.Path.GetDirectoryName(p);
            s = System.IO.Path.GetExtension(p);
            Response.Write(s + "<br />");
            s = System.IO.Path.GetFileName(p);
            Response.Write(s + "<br />");
            s = System.IO.Path.GetFileNameWithoutExtension(p);
            Response.Write(s + "<br />");
            s = System.IO.Path.GetFullPath(p);
            Response.Write(s + "<br />");
            s = System.IO.Path.GetPathRoot(p);
            Response.Write(s + "<br />");
            s = System.IO.Path.GetRandomFileName();
            Response.Write(s + "<br />");
            s = System.IO.Path.GetTempFileName();
            Response.Write(s + "<br />");
            s = System.IO.Path.GetTempPath();
            Response.Write(s + "<br />");
            s = System.IO.Path.IsPathRooted(p).ToString();
            Response.Write(s + "<br />");
            return;
            string extName = System.IO.Path.GetExtension(FileUpload_Img.FileName).ToLower(); //获取文件扩展名
            if (extName != ".gif" && extName != ".jpg" && extName != ".jpeg" && extName != ".bmp" && extName != ".png")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), DateTime.Now.ToString(), "alert('不支持的文件类型！');", true);
            }
            else
            {
                //创建相关文件夹
                if (!Directory.Exists(MapPath("~/UploadFiles/")))
                {
                    Directory.CreateDirectory(MapPath("~/UploadFiles/"));
                }
                if (!Directory.Exists(MapPath("~/UploadFiles/photos/")))
                {
                    Directory.CreateDirectory(MapPath("~/UploadFiles/photos/"));
                }
                DateTime now = DateTime.Now; //获取系统时间
                string photoName = now.Millisecond.ToString() + "_" + FileUpload_Img.PostedFile.ContentLength + "_" + FileUpload_Img.FileName; //重新为文件命名,时间毫秒部分+文件大小+上传文件名+扩展名
                // FileUpload_Img.PostedFile.SaveAs(Server.MapPath("UploadFiles/hospital/photos/" + photoName)); // 保存文件到路径,用Server.MapPath()取当前文件的绝对目录.在asp.net里"\"必须用""代替
                FileUpload_Img.PostedFile.SaveAs(Server.MapPath("UploadFiles\\hospital\\photos\\") + "\\" + photoName);
                imgUrl = "/UploadFiles/hospital/photos/" + photoName;
            }
        }
        //return imgUrl;

    }

    protected void down(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ClearHeaders();
        Response.Buffer = false;
        Response.ContentType = "application/octet-stream"; 
        FileInfo file = new FileInfo(@"D:\LawOfficeSystem\Documents\Upload\walker\110718104429_维医修改 - Copy (6).docx");
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(@"aabbcc.docx", System.Text.Encoding.UTF8));
        Response.AppendHeader("Content-Length", file.Length.ToString());
        Response.WriteFile(file.FullName);
        Response.Flush();
        Response.End();
    }
}