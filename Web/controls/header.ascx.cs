﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_header : System.Web.UI.UserControl
{
    public string mytitle { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(mytitle))
        {
            mytitle = "主页";
        }
    }
}