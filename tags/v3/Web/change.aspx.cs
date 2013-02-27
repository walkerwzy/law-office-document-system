using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class change : validateUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        DataTable depart = new WZY.DAL.DEPART().GetList("").Tables[0];
        rpt.DataSource = depart.DefaultView;
        rpt.DataBind();
    }

    protected void addSubNode(object sender, RepeaterItemEventArgs e)
    {
        WZY.DAL.SYSUSER bll = new WZY.DAL.SYSUSER();
        WZY.DAL.CUSTOMER cbll = new WZY.DAL.CUSTOMER();
        DataTable dt = null;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rpt = e.Item.FindControl("rpt1") as Repeater;
            DataRowView MyRow = (DataRowView)e.Item.DataItem;
            string strDeptCode = Convert.ToString(MyRow["deptid"]);
            dt = bll.GetList(" deptid=" + strDeptCode).Tables[0];
            if (dt.Rows.Count > 0)
            {
                List<string> uids = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    uids.Add(dr["uid"].ToString());
                }
                string ids = string.Join(",", uids.ToArray());
                dt = cbll.GetList(" uid in (" + ids + ") ").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    rpt.DataSource = dt.DefaultView;
                    rpt.DataBind();
                }
            }
        }
    }

    protected void changerela(object sender, EventArgs e)
    {
        string ids = Request["suser"];
        string uid = hiduid.Value;
        try
        {
            new WZY.DAL.CUSTOMER().changeRelationship(int.Parse(uid), ids);
            showDialogWithReload("操作成功");
        }
        catch (Exception ex)
        {
            alert("操作失败\n" + ex.Message);
        }
    }
}