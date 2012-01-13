using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class warn : validateUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    private void bind()
    {
        string predays = Utility.getConfigFile().Root.Descendants("predays").SingleOrDefault().Value;
        string sql = " alerttime>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and alerttime <= '" + DateTime.Now.AddDays(int.Parse(predays)).ToString("yyyy-MM-dd") + "'";
        sql += " and (uid="+suser.uid+" or isprivate=0)";
        ods.SelectParameters[0].DefaultValue = sql;
        gridlist.DataSourceID = "ods";
    }
}