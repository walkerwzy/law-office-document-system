using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class visit : validateUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (cfg.depart)
            {
                ddlrange.SelectedIndex = 1;
            }
            if (suser.roleid == 0 || suser.roleid == 2)
            {
                tools.addAdminOption(ddlrange);
            }
            bindData();
        }
    }

    private void bindData()
    {
        string filter = "1=1";

        if (!string.IsNullOrEmpty(txtpeople.Value.Trim()))
        {
            filter += " and displayname like '%" + txtpeople.Value.Trim() + "%' ";
        }
        if (!string.IsNullOrEmpty(txtsdate.Value.Trim()))
        {
            filter += " and time >= '" + txtsdate.Value.Trim() + "' ";
        }
        if (!string.IsNullOrEmpty(txtedate.Value.Trim()))
        {
            filter += " and time <='" + txtedate.Value.Trim() + "'";
        }

        //数据范围
        switch (ddlrange.SelectedIndex)
        {
            case 0:
                filter += " and uid=" + suser.uid;
                break;
            case 1:
                filter += " and deptid=" + suser.deptid.Value;
                break;
            case 2:
            default:
                break;
        }

        ods.SelectParameters[0].DefaultValue = filter;
        gridlist.DataSourceID = "ods";

        AspNetPager1.RecordCount = new WZY.DAL.VISIT().GetList(filter).Tables[0].Rows.Count;
        AspNetPager1.PageSize = cfg.pagesize;
    }
    protected void btnsearch(object sender, EventArgs e)
    {
        bindData();
    }
}