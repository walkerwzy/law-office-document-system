using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Xml.Linq;

public partial class ProcessFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string docno = Request["d"];
                WZY.Model.DOCS docs = new WZY.DAL.DOCS().GetModel(Convert.ToInt32(docno));
                if (docs == null)
                {
                    Response.Write("文件不存在");
                    return;
                }
                XDocument xdoc = Utility.getConfigFile();
                string uploadpath = xdoc.Root.Descendants("uploadpath").SingleOrDefault().Value;
                string filename = uploadpath + docs.docpath;
                if (!File.Exists(filename))
                {
                    Response.Write("文件不存在");
                    return;
                }
                if (Request["act"] == "download")
                {
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.Buffer = false;
                    Response.ContentType = "application/octet-stream";
                    FileInfo file = new FileInfo(filename);
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(Path.GetFileName(filename)));
                    Response.AppendHeader("Content-Length", file.Length.ToString());
                    Response.WriteFile(file.FullName);
                    Response.Flush();
                    Response.End();
                    return;
                }
                else
                {
                    //生成临时文件夹+文件名
                    //string tempname = System.IO.Path.GetRandomFileName();
                    //tempname = tempname.Substring(0, tempname.IndexOf('.'));
                    //string folder = "~/Temp/Prev/" + DateTime.Now.ToString("yyyyMM") + "/";
                    //string tempath = folder + DateTime.Now.ToString("mmssfff") + tempname + ".html";

                    //不再每次浏览都生成临时文件，假如临时文件存在，直接输出
                    string tempname = Path.GetFileNameWithoutExtension(filename);
                    string folder = "~/Temp/Prev/" + DateTime.Now.ToString("yyyyMM") + "/";
                    string tempath = folder + tempname + ".html";
                    if (File.Exists(Server.MapPath(tempath)))
                    {
                        Response.Redirect(tempath);
                        Response.End();
                        return;
                    }
                    if (!Directory.Exists(Server.MapPath(folder)))
                    {
                        Directory.CreateDirectory(Server.MapPath(folder));
                    }
                    try
                    {
                        if (Helper.HelperOffice.GenerationWordHTML(filename, Server.MapPath(tempath)))
                        {
                            //Response.Redirect(tempath);
                            Response.Write("正在生成预览....<script>location.href='" + tempath.TrimStart('~') + "';</script>");
                            return;
                        }
                        else
                        {
                            Response.Write("预览失败，<a href='ProcessFile.aspx?act=download&d=" + docno + "'>点此下载</a>");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Helper.log.error("预览文件失败，详细信息：" + ex.Message+"\n文件路径：" + tempath);
                        Response.Write("预览失败,<a href='javascript:location.href=location.href;'>点此重试</a><br/>"+ex.Message);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.log.error("预览文件失败，详细信息：" + ex.Message);
                Response.Write("发生错误：" + ex.Message);
                Response.Write("<br /><a href='javascript:location.href=location.href;'>点此重试</a>");
                Response.End();
            }
        }
    }
}