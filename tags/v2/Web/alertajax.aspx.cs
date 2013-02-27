using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Lunar;

public partial class alertajax : validateUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string act = string.IsNullOrEmpty(Request["act"]) ? "" : Request["act"].ToLower();
        switch (act)
        {
            case "agendar":
                agendar();
                break;
            case "kaiting":
                kaiting();
                break;
            case "birthday":
                birthday();
                break;
            case "xuyue":
                xuyue();
                break;
            case "movedate":
                updateAgendar();
                break;
            case "updateagendar":
                updateAgendar();
                break;
            case "addagendar":
                addAgendar();
                break;
            case "delagendar":
                delAgendar();
                break;
            default:
                BigThing();
                break;
        }
    }

    private void BigThing()
    {
        Response.Clear();
        Response.ContentType = "text/plain";

        islogin();

        string msg = "";

        int predays = int.Parse(Utility.getConfigFile().Root.Descendants("predays").SingleOrDefault().Value);
        //重大事件
        string sql = " alerttime>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and alerttime <= '" + DateTime.Now.AddDays(predays).ToString("yyyy-MM-dd") + "' and (uid=" + suser.uid + " or isprivate=0)";
        DataTable dt = new WZY.DAL.alert().GetList(sql).Tables[0];
        if (dt.Rows.Count > 0)
        {
            msg += " <a href='warn.aspx' target='rightframe'>重大事件</a>(" + dt.Rows.Count + ")";
        }

        //客户生日
        //公历生日
        sql = "uid=" + suser.uid + " and ((lunar1<>1 and ownerbirth>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and ownerbirth<= '" + DateTime.Now.AddDays(predays).ToString("yyyy-MM-dd") + "')";
        sql += " or (lunar2<>1 and chargebirth>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and chargebirth <= '" + DateTime.Now.AddDays(predays).ToString("yyyy-MM-dd") + "')";
        //农历生日
        Lunar.Lunar today = LunarApi.GetLunarDate(DateTime.Today);
        Lunar.Lunar lastday = LunarApi.GetLunarDate(DateTime.Today.AddDays(predays));
        sql += " or (lunar1=1 and ownerbirth>='" + string.Format("{0}-{1}-{2}", today.Year, today.Month, today.Day) + "' and ownerbirth<= '" + string.Format("{0}-{1}-{2}", lastday.Year, lastday.Month, lastday.Day) + "')";
        sql += " or (lunar2=1 and chargebirth>='" + string.Format("{0}-{1}-{2}", today.Year, today.Month, today.Day) + "' and chargebirth <= '" + string.Format("{0}-{1}-{2}", lastday.Year, lastday.Month, lastday.Day) + "') )";
        dt = new WZY.DAL.CUSTOMER().GetListPure(sql).Tables[0];
        if (dt.Rows.Count > 0)
        {
            msg += " <a href='clients.aspx?usedate=yes' target='rightframe'>客户生日</a>(" + dt.Rows.Count + ")";
        }
        //开庭
        sql = "kaiting>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and kaiting<= '" + DateTime.Now.AddDays(predays).ToString("yyyy-MM-dd") + "'";
        dt = new WZY.DAL.CASES().GetList(sql).Tables[0];
        if (dt.Rows.Count > 0)
        {
            msg += " <a href='cases.aspx?usedate=yes' target='rightframe'>近期开庭</a>(" + dt.Rows.Count + ")";
        }
        //客户到期
        sql = "select count(a.custid) from contract a left join (select c.custid,c.uid,c.custname, d.deptid from customer c left join sysuser d on d.uid=c.uid) b on b.custid=a.custid where c_etime>=getdate() and c_etime<='" + DateTime.Now.AddDays(predays).ToString("yyyy-MM-dd") + "'";
        sql += " and b.deptid=" + suser.deptid;
        int r = new WZY.DAL.CONTRACT().getCount(sql);
        if (r > 0)
        {
            msg += " <a href='clients.aspx?usecontract=yes' target='rightframe'>合同即将到期</a>(" + r + ")";
        }
        if (string.IsNullOrEmpty(msg)) msg = "无提醒";
        Response.Write(msg);
        Response.End();
    }

    private void islogin()
    {

        string[] userdata = Helper.HelperSession.GetAuthenticatedUserData("|");
        if (userdata.Length < 2)
        {
            Response.Write("无提醒");
            Response.End();
        }
    }

    //日程
    private void agendar()
    {
        Response.Clear();
        Response.ContentType = "text/plain";
        islogin();
        StringBuilder msg = new StringBuilder();
        DateTime dtstart = tools.ConvertIntDateTime(Convert.ToInt64(Request["start"]));
        DateTime dtend = tools.ConvertIntDateTime(Convert.ToInt64(Request["end"]));
        string sql = " (alerttime>='" + dtstart.ToString("yyyy-MM-dd") + "' and alerttime<='" + dtend.ToString("yyyy-MM-dd") + "') and (isprivate=0 or (isprivate=1 and uid=" + suser.uid + "))";
        List<WZY.Model.alert> result = new WZY.DAL.alert().GetListArray(sql);
        msg.Append("[");
        if (result.Count > 0)
        {
            bool isfirst = true;
            foreach (WZY.Model.alert item in result)
            {
                if (!isfirst)
                {
                    msg.Append(",");
                }
                else
                {
                    isfirst = false;
                }
                msg.Append("{\"id\":\"" + item.id + "\",\"title\":\"" + item.cont + "\",\"start\":\"" + item.alerttime.Value.ToString("yyyy-MM-dd") + "\",\"description\":\"" + item.cont + "\",\"p\":" + item.isprivate.Value + ",\"cp\":" + (item.uid.Value == suser.uid ? 1 : 0) + "}");
            }
        }
        msg.Append("]");
        Response.Write(msg.ToString());
        Response.End();
    }
    //开庭
    private void kaiting()
    {
        Response.Clear();
        Response.ContentType = "text/plain";
        islogin();
        StringBuilder msg = new StringBuilder();
        DateTime dtstart = tools.ConvertIntDateTime(Convert.ToInt64(Request["start"]));
        DateTime dtend = tools.ConvertIntDateTime(Convert.ToInt64(Request["end"]));
        string sql = "kaiting>='" + dtstart.ToString("yyyy-MM-dd") + "' and kaiting<= '" + dtend.ToString("yyyy-MM-dd") + "'";
        List<WZY.Model.CASES> result = new WZY.DAL.CASES().GetListArray(sql);
        msg.Append("[");
        if (result.Count > 0)
        {
            bool isfirst = true;
            foreach (WZY.Model.CASES item in result)
            {
                if (!isfirst)
                {
                    msg.Append(",");
                }
                else
                {
                    isfirst = false;
                }
                msg.Append("{\"title\":\"有案件开庭\",\"start\":\"" + item.kaiting.Value.ToString("yyyy-MM-dd") + "\",\"description\":\"" + item.yuangao + "\",\"url\":\"cases.aspx?caseid=" + item.caseid + "\",\"editable\":false}");
            }
        }
        msg.Append("]");
        Response.Write(msg.ToString());
        Response.End();

    }
    //生日
    private void birthday()
    {
        Response.Clear();
        Response.ContentType = "text/plain";
        islogin();
        StringBuilder msg = new StringBuilder();
        DateTime dtstart = tools.ConvertIntDateTime(Convert.ToInt64(Request["start"]));
        DateTime dtend = tools.ConvertIntDateTime(Convert.ToInt64(Request["end"]));
        //公历生日-法人
        string sql = "uid=" + suser.uid + " and (lunar1<>1 and ownerbirth>='" + dtstart.ToString("yyyy-MM-dd") + "' and ownerbirth<= '" + dtend.ToString("yyyy-MM-dd") + "')";
        msg.Append("[");
        WZY.DAL.CUSTOMER bll = new WZY.DAL.CUSTOMER();
        List<WZY.Model.CUSTOMER> result = bll.GetListArray(sql);
        if (result.Count > 0)
        {
            bool isfirst = true;
            foreach (WZY.Model.CUSTOMER item in result)
            {
                if (!isfirst)
                {
                    msg.Append(",");
                }
                else
                {
                    isfirst = false;
                }
                msg.Append("{\"title\":\"" + item.owner + "生日\",\"start\":\"" + item.ownerbirth.Value.ToString("yyyy-MM-dd") + "\",\"description\":\"单位：" + item.custname + "\",\"url\":\"clients.aspx?custid=" + item.custid + "\",\"editable\":false}");
            }
        }
        //公历生日-负责人
        sql = " uid=" + suser.uid + " and  (lunar2<>1 and chargebirth>='" + dtstart.ToString("yyyy-MM-dd") + "' and chargebirth <= '" + dtend.ToString("yyyy-MM-dd") + "')";
        result.Clear();
        result = bll.GetListArray(sql);
        if (result.Count > 0)
        {
            foreach (WZY.Model.CUSTOMER item in result)
            {
                if (msg.ToString() != "[")
                {
                    msg.Append(",");
                }
                msg.Append("{\"title\":\"" + item.charge + "生日\",\"start\":\"" + item.chargebirth.Value.ToString("yyyy-MM-dd") + "\",\"description\":\"单位：" + item.custname + "\",\"url\":\"clients.aspx?custid=" + item.custid + "\",\"editable\":false}");
            }
        }
        Lunar.Lunar today = LunarApi.GetLunarDate(dtstart);
        Lunar.Lunar lastday = LunarApi.GetLunarDate(dtend);
        //农历生日-法人
        sql = " uid=" + suser.uid + " and (lunar1=1 and ownerbirth>='" + string.Format("{0}-{1}-{2}", today.Year, today.Month, today.Day) + "' and ownerbirth<= '" + string.Format("{0}-{1}-{2}", lastday.Year, lastday.Month, lastday.Day) + "')";
        result.Clear();
        result = bll.GetListArray(sql);
        if (result.Count > 0)
        {
            foreach (WZY.Model.CUSTOMER item in result)
            {
                if (msg.ToString() != "[")
                {
                    msg.Append(",");
                }
                msg.Append("{\"title\":\"" + item.owner + "生日\",\"start\":\"" + LunarToSolar(item.ownerbirth.Value, dtstart, dtend) + "\",\"description\":\"单位：" + item.custname + "\",\"url\":\"clients.aspx?custid=" + item.custid + "\",\"editable\":false}");
            }
        }
        //农历生日-负责人
        sql = " uid=" + suser.uid + " and (lunar2=1 and chargebirth>='" + string.Format("{0}-{1}-{2}", today.Year, today.Month, today.Day) + "' and chargebirth <= '" + string.Format("{0}-{1}-{2}", lastday.Year, lastday.Month, lastday.Day) + "')";
        result.Clear();
        result = bll.GetListArray(sql);
        if (result.Count > 0)
        {
            foreach (WZY.Model.CUSTOMER item in result)
            {
                if (msg.ToString() != "[")
                {
                    msg.Append(",");
                }
                msg.Append("{\"title\":\"" + item.charge + "生日\",\"start\":\"" + LunarToSolar(item.chargebirth.Value, dtstart, dtend) + "\",\"description\":\"单位：" + item.custname + "\",\"url\":\"clients.aspx?custid=" + item.custid + "\",\"editable\":false}");
            }
        }
        msg.Append("]");
        Response.Write(msg.ToString());
        Response.End();

    }
    //客户到期
    private void xuyue()
    {
        Response.Clear();
        Response.ContentType = "text/plain";
        islogin();
        StringBuilder msg = new StringBuilder();
        DateTime dtstart = tools.ConvertIntDateTime(Convert.ToInt64(Request["start"]));
        DateTime dtend = tools.ConvertIntDateTime(Convert.ToInt64(Request["end"]));
        string sql = "etime>='" + dtstart.ToString("yyyy-MM-dd") + "' and etime<= '" + dtend.ToString("yyyy-MM-dd") + "'";
        sql += " and (uid=" + suser.uid + " or deptid=" + suser.deptid + ")";
        DataTable dt = new WZY.DAL.CONTRACT().getExpiredDates(sql).Tables[0];
        msg.Append("[");
        if (dt.Rows.Count > 0)
        {
            bool isfirst = true;
            foreach (DataRow dr in dt.Rows)
            {
                if (!isfirst)
                {
                    msg.Append(",");
                }
                else
                {
                    isfirst = false;
                }
                msg.Append("{\"title\":\"有客户协议到期\",\"start\":\"" + Convert.ToDateTime(dr["etime"]).ToString("yyyy-MM-dd") + "\",\"description\":\"单位：" + dr["custname"].ToString() + "\",\"url\":\"clients.aspx?custid=" + dr["custid"].ToString() + "\",\"editable\":false}");
            }
        }
        msg.Append("]");
        Response.Write(msg.ToString());
        Response.End();

    }

    //更改日程安排
    private void updateAgendar()
    {
        Response.Clear();
        Response.ContentType = "text/plain";
        string msg = "1|";
        try
        {
            long id = Convert.ToInt64(Request.QueryString["id"]);
            WZY.DAL.alert bll = new WZY.DAL.alert();
            WZY.Model.alert model = bll.GetModel(id);
            if (!string.IsNullOrEmpty(Request.QueryString["todate"]))
            {
                model.alerttime = tools.ConvertMMIntDateTime(Convert.ToInt64(Request.QueryString["todate"]));//js普通getTime得到的是毫秒值
            }
            else
            {
                //不是更新日期，那么就是更新内容，二者必居其一，否则是错误调用
                model.cont = Server.UrlDecode(Request.QueryString["cont"]).Replace("\"", "\\\""); ;
                model.isprivate = (int?)Convert.ToInt32(Request.QueryString["isp"]);
            }
            bll.Update(model);
            msg += "1";
        }
        catch (Exception ex)
        {
            msg = "0| " + ex.Message.Replace("'", "").Replace("\"", "");
        }
        Response.Write(msg);
        Response.End();
    }

    //新增日程安排
    private void addAgendar()
    {
        Response.Clear();
        Response.ContentType = "text/plain";
        string msg = "1|";
        try
        {
            WZY.DAL.alert bll = new WZY.DAL.alert();
            WZY.Model.alert model = new WZY.Model.alert();
            model.alerttime = tools.ConvertMMIntDateTime(Convert.ToInt64(Request.QueryString["start"]));//js普通getTime得到的是毫秒值
            model.cont = Server.UrlDecode(Request.QueryString["cont"]).Replace("\"", "\\\"");
            model.uid = suser.uid;
            model.isprivate = (int?)Convert.ToInt32(Request.QueryString["isp"]);
            int id = bll.Add(model);
            msg += id;
        }
        catch (Exception ex)
        {
            msg = "-1| " + ex.Message.Replace("'", "").Replace("\"", "");
        }
        Response.Write(msg);
        Response.End();
    }

    //删除日程安排
    private void delAgendar()
    {
        Response.Clear();
        Response.ContentType = "text/plain";
        string msg = "1";
        try
        {
            long id = Convert.ToInt64(Request.QueryString["id"]);
            WZY.DAL.alert bll = new WZY.DAL.alert();
            bll.Delete(id);
        }
        catch (Exception ex)
        {
            msg = "error: " + ex.Message.Replace("'", "").Replace("\"", "");
        }
        Response.Write(msg);
        Response.End();
    }


    /// <summary>
    /// 农历转公历
    /// 其实就是穷举
    /// </summary>
    /// <param name="lunar">农历日期</param>
    /// <param name="start">起始公历日期</param>
    /// <param name="end">终止公历日期</param>
    /// <returns></returns>
    private string LunarToSolar(DateTime lunar, DateTime start, DateTime end)
    {
        while (start <= end)
        {
            Lunar.Lunar today = LunarApi.GetLunarDate(start);
            DateTime todaytolunar = Convert.ToDateTime(string.Format("{0}-{1}-{2}", today.Year, today.Month, today.Day));
            if (todaytolunar.ToString("yyyy-MM-dd") == lunar.ToString("yyyy-MM-dd")) return start.ToString("yyyy-MM-dd");
            start = start.AddDays(1);
        }
        return "";
    }
}