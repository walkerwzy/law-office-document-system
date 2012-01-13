using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Helper
{
	/// <summary>
	/// HelperDropdownlist
	/// </summary>
	public class HelperDropDownList
	{
		private static readonly int START_YEAR	= 2004;
		private static readonly int END_YEAR	= DateTime.Now.AddYears(1).Year;
		private static readonly int MONTH		= DateTime.Now.Month;

		private HelperDropDownList(){}

		public static string Read(DropDownList ddl)
		{
			if(ddl.SelectedIndex != -1) return ddl.SelectedItem.Value.ToString();
			else return "0";
		}

        public static string Read(DropDownList ddl,string getUnSelectedValue)
        {
            if (ddl.SelectedIndex != -1) return ddl.SelectedItem.Value.ToString();
            else return getUnSelectedValue;
        }

		public static string Read(DropDownList ddl,bool bText)
		{
			if(bText)
				return ddl.SelectedItem.Text;
			else
				return ddl.SelectedItem.Value.ToString();
		}

        public static void BindData(DropDownList ddl, DataTable dt, string name, string value, int selectedindex)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = name;
            ddl.DataValueField = value;
            ddl.SelectedIndex = selectedindex;
            ddl.DataBind();
        }

        public static void BindData(DropDownList ddl, DataTable dt, string name, string value, string selectedvalue)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = name;
            ddl.DataValueField = value;
            ddl.SelectedValue = selectedvalue;
            ddl.DataBind();
        }

        public static void BindData(DropDownList ddl, DataTable dt, string name, string value, int selectedindex, bool addBlank)
        {
            ddl.Items.Clear();
            ddl.DataSource = dt;
            ddl.DataTextField = name;
            ddl.DataValueField = value;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("请选择...", ""));
            ddl.SelectedIndex = 0;

        }
        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dt"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="selectedindex"></param>
        /// <param name="custDefaultText">第一项的显示名称，值为-1</param>
        public static void BindData(DropDownList ddl, DataTable dt, string name, string value, int selectedindex, string custDefaultText)
        {
            ddl.Items.Clear();
            ddl.DataSource = dt;
            ddl.DataTextField = name;
            ddl.DataValueField = value;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(custDefaultText, "-1"));
            ddl.SelectedIndex = 0;

        }
		public static void AddItem(DropDownList ddl,string text,string newvalue) 
		{
			ListItem listItem =new ListItem();
			listItem.Text = text;
			listItem.Value= newvalue;
			ddl.Items.Add(listItem);
		}

        public static void InsertItem(DropDownList ddl,int index, string text, string newvalue)
        {
            ListItem listItem = new ListItem();
            listItem.Text = text;
            listItem.Value = newvalue;
            ddl.Items.Insert(index, listItem);
        }

		public static void GetYearDropDownList(DropDownList ddl)
		{
			for(int tempInt=START_YEAR;tempInt<=END_YEAR;tempInt++)
			{
				AddItem(ddl,tempInt.ToString(),tempInt.ToString());
			}
			ddl.SelectedValue = DateTime.Now.Year.ToString();
		}

		public static void GetMonthDropDownList(DropDownList ddl)
		{
			for(int tempInt=1;tempInt<=12;tempInt++)
			{
				if(tempInt<10) AddItem(ddl,"0"+tempInt.ToString(),"0"+tempInt.ToString());
				else AddItem(ddl,tempInt.ToString(),tempInt.ToString());
			}
			if(MONTH<10) ddl.SelectedValue = "0"+MONTH.ToString();
			else ddl.SelectedValue = MONTH.ToString();
		}

        public static void SetSelectItem(DropDownList ddl, string selected)
        {
            ListItem item = ddl.Items.FindByValue(selected);
            ddl.ClearSelection();
            if (item != null)
            {
                item.Selected = true;
            }
            else
                ddl.SelectedIndex = -1;
        }
	}
}
