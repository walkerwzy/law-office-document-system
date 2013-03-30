using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

/// <summary>
///Pager 的摘要说明
/// </summary>
public class Pager
{
    public Pager()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }


    public static string getPagerstring(PagedDataSource ps, string url, string onclick, int? position, int? pagedisplay)
    {
        //TODO:带有onclick事件的分页逻辑
        return "";
    }

    /// <summary>
    /// 分页字符串
    /// </summary>
    /// <param name="ps">分页数据源</param>
    /// <param name="url">请求地址</param>
    /// <param name="position">页码位置，默认为左，置右请设为1</param>
    /// <param name="pagedisplay">分页按钮个数，默认5个</param>
    /// <returns></returns>
    public static string getPagerstring(PagedDataSource ps, string url, int? position, int? pagedisplay)
    {
        string pagestr = "";
        int display = 5;
        int recordCount = ps.DataSourceCount;
        int pageSize = ps.PageSize;
        int pageCount = ps.PageCount;
        int currentPage = ps.CurrentPageIndex + 1;
        int pageposition = 0;

        //记录条数大于每页条数才出现分页项
        if (recordCount > pageSize)
        {
            #region 初始化
            Regex reg = new Regex(@"(.*)(&page=\d+)(.*)");//匹配page不是第一个参数
            Regex reg2 = new Regex(@"(.*)(\?page=\d+)(.*)");//匹配page是第一个参数
            //去掉“page=”的字样，把它加到末尾，方便拼字符串，所以URL分页务必以page=为传送页码的标志
            if (reg.IsMatch(url))
            {
                url = reg.Replace(url, "$1" + "$3");
                url += "&page=";
            }
            else if (reg2.IsMatch(url))
            {
                string urlparam = reg2.Replace(url, "$3");
                if (!string.IsNullOrEmpty(urlparam))
                {
                    urlparam = "?" + urlparam.Substring(1);//去掉后续参数的第一个“＆”符号
                    url = reg2.Replace(url, "$1" + urlparam + "&page=");
                }
                else
                {
                    url = reg2.Replace(url, "$1" + "?page=");
                }
            }
            else
            {
                url += "?page=";
            }

            //保证美观，分页按钮始终有奇数个
            if (pagedisplay.HasValue)
            {
                display = (int)pagedisplay;
                display = (display % 2 == 1) ? display : display + 1;
            }

            //判断起止页码
            int from, to;

            int offset = (display + 1) / 2 - 1;
            if (display > pageCount)
            {  //总页数比预计页数少，全数列出
                from = 1;
                to = pageCount;
            }
            else
            {
                from = currentPage - offset;//当前页前面显示offset页
                to = from + display - 1;
                if (from < 1)
                {//前面不足offset页，从1顺数
                    from = 1;
                    to = display;
                }
                else if (to > pageCount)
                {//尾页超出范围，则从末页倒数
                    from = pageCount - display + 1;
                    to = pageCount;
                }
            }

            #endregion

            #region 生成分页字符串

            //包在<span>标签内
            pagestr = "<span class=\"pager\">";

            //最前页
            if (!ps.IsFirstPage)
            {
                pagestr += "<a href=\"" + url + "1\">第一页</a>";
            }

            //上一页
            if (currentPage > 1)
            {
                pagestr += "<a href=\"" + url + (currentPage - 1) + "\">上一页</a>";
            }

            //前翻N页
            if (from - 1 > 0)
            {
                pagestr += "<a href=\"" + url + (from - 1) + "\">...</a>";
            }

            //循环产生页码
            int i;
            for (i = from; i <= to; i++)
            {
                string curclass = i == currentPage ? " class=\"curpage\" " : "";
                pagestr += "<a href=\"" + url + i + "\"" + curclass + ">" + i + "</a>";
            }


            //后翻N页
            if (i <= pageCount)
            {
                pagestr += "<a href=\"" + url + i + "\">...</a>";
            }

            //下一页
            if (currentPage < pageCount)
            {
                pagestr += "<a href=\"" + url + (currentPage + 1) + "\">下一页</a>";
            }

            //最后页
            if (!ps.IsLastPage)
            {
                pagestr += "<a href=\"" + url + pageCount + "\">最后页</a>";
            }

            pagestr += "</span>";

            #endregion
        }

        #region 统计、位置
        //分页统计字串
        string pagestat = "<span class=\"pagestatic\">共 <b>" + recordCount + "</b> 条记录&nbsp; <b>" + currentPage + "</b> / <b>" + pageCount + "</b></span>";

        //页码位置
        if (position.HasValue)
        {
            pageposition = (int)position;
        }
        const string wrap = "<table class=\"pagertable\" border=\"0\" width=\"100%\"><tr>";
        if (pageposition == 0)
        {
            pagestr = wrap + "<td>" + pagestr + "</td><td width=\"150\" class=\"righttext\">" + pagestat + "</td></tr></table>";
        }
        else
        {
            pagestr = wrap + "<td width=\"150\">" + pagestat + "</td><td class=\"righttext\">" + pagestr + "</td></tr></table>";
        }
        #endregion

        return pagestr;
    }

}
