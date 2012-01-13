using System;
using System.Web.UI.WebControls;

namespace Helper
{
	/// <summary>
	/// HelperTable
	/// </summary>
	public class HelperTable
	{
		private HelperTable(){}

		public static Table GetTable(string css)
		{
			return GetTable(0,0,css);
		}

		public static Table GetTable(int width,int height,string css)
		{
			Table table = new Table();
			if(width > 0) table.Width = width;
			if(height> 0) table.Height= height;
			if(css.Length>0) table.CssClass = css;
			return table;
		}

		public static Table GetTable(int widthPercent,string css)
		{
			Table table = new Table();
			table.Width	= Unit.Percentage(widthPercent);
			if(css.Length>0) table.CssClass = css;
			return table;
		}

		public static TableRow GetTableRow()
		{
			TableRow tableRow = new TableRow();
			return tableRow;
		}

		public static TableRow GetTableRow(string css)
		{
			TableRow tableRow = new TableRow();
			tableRow.CssClass = css;
			return tableRow;
		}

		public static TableCell GetTableCell()
		{
			TableCell tableCell = new TableCell();
			return tableCell;
		}

		public static TableCell GetTableCell(string text)
		{
			TableCell tableCell = new TableCell();
			tableCell.Text = text;
			return tableCell;
		}

		public static TableCell GetTableCell(string text, string css)
		{
			TableCell tableCell = new TableCell();
			tableCell.Text = text;
			tableCell.CssClass = css;
			return tableCell;
		}

		public static TableCell GetTableCell(string text,HorizontalAlign align)
		{
			TableCell tableCell = new TableCell();
			tableCell.Text = text;
			tableCell.HorizontalAlign = align;
			return tableCell;
		}

		public static TableCell GetMoneyTableCell(long money)
		{
			TableCell tableCell = new TableCell();
			string tempText = money.ToString("###,###");
			if (tempText != string.Empty) tableCell.Text = tempText;
			else tableCell.Text = "0";
			tableCell.HorizontalAlign = HorizontalAlign.Right;
			return tableCell;
		}

		public static TableRow GetTableRowSingle(string text,string css,int colSpan)
		{
			TableRow tableRow = new TableRow();
			tableRow.CssClass = css;
			TableCell tableCell = GetTableCell(text);
			tableCell.ColumnSpan = colSpan;
			tableRow.Cells.Add(tableCell);
			return tableRow;
		}

		public static void RowClickToShowModal(TableRow tableRow,string url,string urlParm,string urlParmValue,string title,string css,string cssover)
		{
			tableRow.Attributes.Add("onmouseover","RowItem_Active(this,'"+cssover+"');this.style.cursor='hand';");
			tableRow.Attributes.Add("onmouseout","RowItem_InActive(this,'"+css+"');");
			tableRow.Attributes.Add("onclick","javascript:window.showModalDialog('"+url+"?"+urlParm+"="+urlParmValue+"&temp="+Guid.NewGuid()+"',null,'dialogHeight:500px; dialogWidth:950px; edge: Raised; center: Yes; help: no; resizable: no; status: no;');window.document.forms[0].submit();");
			if(title != string.Empty) tableRow.Attributes.Add("title",title);
		}

		public static void RowClick(TableRow tableRow,string url,string urlParmValue)
		{
			tableRow.Attributes.Add("onmouseover","OnItem_Active(this);this.style.cursor='hand';");
			tableRow.Attributes.Add("onmouseout","OnItem_InActive(this);");
			tableRow.Attributes.Add("onclick","javascript:window.location ='"+url+urlParmValue+"';");
		}
	}
}
