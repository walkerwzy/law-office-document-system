<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>湖南炜弘律师事务所管理系统</title>
    <link href="/css/index.css" rel="stylesheet" type="text/css" />
    <link href="/css/public.css" rel="stylesheet" type="text/css" />
    <link href="/css/nav.css" rel="stylesheet" type="text/css" />
	<style type="text/css">
	</style>
    <script src="/js/ca/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
     <script type="text/javascript">
         //浏览器大小改变事件
         window.onresize = setWH;
         function setWH() {
             $(".left_4").height($(window).height() - 198);
             $("#rightframe").height(function () { return $(window).height() - $(this).offset().top });
         }
         //设置导航菜单版本
         var svision = getCookie("svision");
         //刷新前保存当前页面网址
         //~ onbeforeunload = function () {setCookie("lastpage", $("#rightframe")[0].contentWindow.location.href, 1);}
         //页面加载时
         $(function () {
             //恢复刷新前的页面
             //$("#rightframe").attr("src", getCookie("lastpage") || "/serverinfo.aspx");//方法1
             //方法2
             //             var lastnaviindex = Number(getCookie("lastnaviindex") || NaN);
             //             if (lastnaviindex == NaN) lastnaviindex = -1;
             //             if (lastnaviindex != -1) {
             //                 if (lastnaviindex >= 0) {
             //                     var curli = $(".tree li").eq(lastnaviindex).addClass("curli").parents("li");
             //                     $("#rightframe").attr("src", $(".curli a").attr("href"));
             //                     setTimeout(function () { if (curli.length > 0) curli.click(); }, 300);
             //                 } else {
             //                     var cura = $(".tree2 a").eq(-lastnaviindex - 2).addClass("curli");
             //                     $("#rightframe").attr("src", cura.attr("href"));
             //                 }
             //             }
             //             setCookie("lastpage", "", 0);
             //不再记住最后菜单，改为直接展开第一个菜单
             $(".openmenu").find("a:first").css("background-image", " url(images/down.gif)").end().find("ul").slideDown();
             setWH();
             //注册菜单行为
             $(".tree li").click(function (e) {
                 var obj = $(this);
                 if (obj.is(".pmenu")) {//有子菜单
                     var ul = $("ul", obj).eq(0);
                     var arrobj = $("a", obj).eq(0);
                     if (ul.is(":hidden")) {
                         ul.slideDown();
                         setTimeout(function () { arrobj.css({ backgroundImage: "url(images/down.gif)" }); }, 0);
                     }
                     else {
                         ul.slideUp();
                         setTimeout(function () { arrobj.css({ backgroundImage: "url(images/right.gif)" }); }, 0);
                     }
                 } else {
                     $(".curli").removeClass("curli");
                     obj.addClass("curli");
                     $(".grayli").removeClass("grayli");
                     if (getCookie("theme") == "gray") { obj.addClass("grayli"); }
                     //                     if (!obj.is(".notrace")) setCookie("lastnaviindex", $(".tree li").index(obj), 1);
                 }
                 e.stopPropagation();
             })
             //三个焦点菜单行为
             $(".tree2 a").click(function () {
                 $(".curli").removeClass("curli");
                 $(this).addClass("curli");
                 $(".grayli").removeClass("grayli");
                 //让cookie出现-2,-3,-4等表示是焦点菜单引发的
                 //                 i = -2 - $(".tree2 a").index(this);
                 //                 setCookie("lastnaviindex", i);
             });
             //侧边栏
             $("#opArea").click(function () {
                 var obj = $("img", this);
                 if (obj.attr("status") == undefined) obj.attr("status", "open");
                 if (obj.attr("status") == "open") {
                     $("#left").css("width", "5px");
                     obj.attr("src", "images/expand.gif");
                     obj.attr("status", "close");
                     $("#topmenu").show();
                     setCookie("svision", 2);
                 } else {
                     $("#left").css("width", "184px");
                     obj.attr("src", "images/collapse.gif");
                     obj.attr("status", "open");
                     $("#topmenu").hide();
                     setCookie("svision", 1);
                 }
             });
             //切换主题
             $("#theme-gray").click(function () { setCookie("theme", "gray", 3650); setTheme("gray"); });
             $("#theme-blue").click(function () { setCookie("theme", "", 0); setTheme(""); });
             //设置主题
             setTheme(getCookie("theme"));

             //加载提醒
             $.get("alertajax.aspx", { t: new Date().getMilliseconds() }, function (d) {
                 if (d != "无提醒") {
                     $("#alertdiv").html(d + "<span class='xspan'></span>").show();
                 }
             });
             //关闭提醒
             $(".xspan").live("click", function () { $("#alertdiv").hide(); });
             //高亮横向导航条
             $("#navMenu a").click(function () {
                 if ($(this).attr("href").indexOf("void") >= 0) return;
                 var pli = $(this).parents(".menulv1");
                 $(".curnav").removeClass("curnav");
                 pli.addClass("curnav");
             });
             if (svision == "2") $("#opArea").click();
         });
		//设置主题的主方法
		function setTheme(path){
		    path += "/";
		    if (path == "/") path = "";
			//图片
			$(".left_3").css({background:"url(../images/"+path+"hos_bg4.gif)"});
			$(".left_4").css({background:"url(../images/"+path+"hos_bg2.gif)"});
			$(".left_5").css({background:"url(../images/"+path+"hos_bg3.gif)"});
			$(".left_6").css({background:"url(../images/"+path+"hos_bg5.gif)"});
			$("#left .im").css({background:"url(../images/"+path+"hos_bg1.gif)"});
			$(".right_1").css({background:"url(../images/"+path+"hos_bg6.gif)"});
			//颜色
			if(path!=""){$(".curli").addClass("grayli");}
			else{$(".curli").removeClass("grayli");}
			//子窗体主题
			try{$("#rightframe")[0].contentWindow.setTheme();}
			catch(err){}
		}
         //操作弹出层
         /*
         *@act:bool, true:open pop layer; false:close pop layer
         */
         function popAction(act) {
             if (act) $(".floatdiv").css("display", "block");
             else $(".floatdiv").css("display", "none");
         }
         //取cookie值
         function getCookie(name) {
             var arr = document.cookie.match(new RegExp("(^|;\\s*)" + name + "=([^;]*)(;|$)"));
             if (arr != null) return unescape(decodeURI(arr[2])); return "";
         }
         //设置cookie
         function setCookie(c_name, value, expiredays) {
             var exdate = new Date();
             exdate.setDate(exdate.getDate() + expiredays);
             document.cookie = c_name + "=" + escape(value) + ((expiredays == null) ? "" : ";expires=" + exdate.toUTCString());
         }
         /*nav*/
         sfHover = function () {
             var sfEls = document.getElementById("navMenu").getElementsByTagName("LI");
             for (var i = 0; i < sfEls.length; i++) {
                 sfEls[i].onmouseover = function () {
                     this.className += " sfhover";
                 }
                 sfEls[i].onmouseout = function () {
                     this.className = this.className.replace(new RegExp(" sfhover\\b"), "");
                 }
             }
         }
         if (window.attachEvent) window.attachEvent("onload", sfHover);
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="spm" runat="server"></asp:ScriptManager>
     <div id="top">
        <div class="top_cli">
        <div id="topnavi">
            当前用户：<asp:Label runat="server" ID="lbluser"></asp:Label>|
             <asp:LinkButton runat="server" ID="lbtnlotout" Text="退出登录" PostBackUrl="~/logout.aspx" CausesValidation="false"></asp:LinkButton>|
            <asp:LinkButton runat="server" ID="lbtnclearcache" Text="清除缓存" OnClick="clearcache" CausesValidation="false"></asp:LinkButton>|
            <%--<asp:LinkButton runat="server" ID="lbtnshutdown" Text="关闭服务器" OnClick="shutdownserver" CausesValidation="false"></asp:LinkButton>|--%>
            <span id="opArea"><asp:LinkButton runat="server" ID="lbtnsidepanel" CausesValidation="false" onClientClick="return false;">侧边栏<img src="images/collapse.gif" alt="" status="open" /></asp:LinkButton></span>
	       <span id="themepanel"><a href="javascript:void(0);" title="灰色主题"><span id="theme-gray">&nbsp;</span></a><a href="javascript:void(0);" title="蓝色主题"><span id="theme-blue">&nbsp;</span></a></span>
           <asp:Label runat="server" ID="lbltime"></asp:Label>
	</div>
        <!--横向导航-->
            <div id="topmenu">
                <div id="navMenu">
					<ul class="menu1">
                        <li class="menulv1 curnav">
                            <a hidefocus href="javascript:void(0);">行政办公</a>
                                <ul>
                                    <li><a hidefocus href="zongzhi.aspx" target="rightframe">公告栏</a></li>
                                    <li><a hidefocus href="zhanlue.aspx" target="rightframe">本所战略</a></li>
                                    <li><a hidefocus href="zhidus.aspx" target="rightframe">规章制度</a></li>
                            </ul>
                        </li>
                        <li class="menulv1"><a hidefocus href="javascript:void(0);">业务中心</a>
                        <ul>
                            <li><a hidefocus href="cases.aspx" target="rightframe">案件管理</a></li>
                            <li><a hidefocus href="docs.aspx" target="rightframe">文档管理</a></li>
                            <li><a hidefocus href="clients.aspx" target="rightframe">客户管理</a></li>
                        </ul>
                        </li>
                        <li class="menulv1"><a hidefocus href="javascript:void(0);">事件管理</a>
                            <ul>
                                <li><a hidefocus href="warn.aspx" target="rightframe">重大事件</a></li>
                                <li><a hidefocus href="agendar.html" target="rightframe">日程安排</a></li>
                            </ul>
                        </li>
                        <li class="menulv1"><a hidefocus href="visit.aspx" target="rightframe">拜访记录</a></li>
                        <li class="menulv1"><a hidefocus href="javascript:void(0);">事务所数据</a>
                            <ul>
                                <li><a hidefocus href="depart.aspx" target="rightframe">部门管理</a></li>
                                <li><a hidefocus href="roles.aspx" target="rightframe">角色管理</a></li>
                                <li><a hidefocus href="users.aspx" target="rightframe">用户管理</a></li>
                            </ul>
                        </li>
                        <li class="menulv1"><a hidefocus href="javascript:void(0);" target="rightframe">基础数据</a>
                            <ul>
                                <li><a hidefocus href="cate_cust.aspx" target="rightframe">客户类别管理</a></li>
                                <li><a hidefocus href="cate_doc.aspx" target="rightframe">文档类别管理</a></li>
                                <li><a hidefocus href="cate_case.aspx" target="rightframe">案件类别管理</a></li>
                            </ul>
                        </li>
                        <li class="menulv1"><a hidefocus href="javascript:void(0);">系统管理</a>
                            <ul>
                                <li><a hidefocus href="personal.aspx" target="rightframe">个人设置</a></li>
                                <li class="notrace"><a hidefocus href="resetpwd.aspx" target="rightframe">修改密码</a></li>
                                <li><a hidefocus href="path.aspx" target="rightframe">路径设置</a></li>
                                <li><a hidefocus href="db.aspx" target="rightframe">数据库备份</a></li>
                            </ul>
                        </li>
                    </ul>
					</div>
            </div>
        <!---横向导航结束-->
        <div id="alertdiv"></div>
        <asp:UpdatePanel ID="udp01" runat="server">
            <Triggers><asp:AsyncPostBackTrigger ControlID="lbtnclearcache" /></Triggers>
        </asp:UpdatePanel></div>
    </div>
    <table cellpadding="0" cellspacing="0" style="width:100%; height: 100%;" class="grayimg">
        <tr>
            <td style="width:auto; height: 100%;" valign="top">
                <div id="left">
                    <div class="im"></div>
                    <div class="left_5">
                        <ul class="tree2">
                            <li><a hidefocus href="cases.aspx" target="rightframe" class="lh">案件管理</a></li>
                            <li><a hidefocus href="docs.aspx" target="rightframe">文档管理</a></li>
                            <li><a hidefocus href="clients.aspx" target="rightframe">客户管理</a></li>
                        </ul>
                   </div>
                    <div class="left_4">
                        <ul class="tree">
                            <!--li下的a标签加lh的class可强调该菜单-->
                            <%--<li><a hidefocus href="cases.aspx" target="rightframe">案件管理</a></li>
                            <li><a hidefocus href="docs.aspx" target="rightframe">文档管理</a></li>
                            <li><a hidefocus href="clients.aspx" target="rightframe">客户管理</a></li>--%>
                            <li class="pmenu openmenu">
                                <a hidefocus href="javascript:void(0);">行政办公</a>
                                    <ul>
                                        <li class="curli"><a hidefocus href="zongzhi.aspx" target="rightframe">公告栏</a></li>
                                        <li><a hidefocus href="zhanlue.aspx" target="rightframe">本所战略</a></li>
                                        <li><a hidefocus href="zhidus.aspx" target="rightframe">规章制度</a></li>
                                </ul>
                            </li>
                            <li class="pmenu"><a hidefocus href="javascript:void(0);">事件管理</a>
                                <ul>
                                    <li><a hidefocus href="warn.aspx" target="rightframe">重大事件</a></li>
                                    <li><a hidefocus href="agendar.html" target="rightframe">日程安排</a></li>
                                </ul>
                            </li>
                            <li><a hidefocus href="visit.aspx" target="rightframe"style="background:url(images/right.gif) 11px 9px no-repeat;">　拜访记录</a></li>
                            <li class="pmenu"><a hidefocus href="javascript:void(0);">事务所数据</a>
                                <ul>
                                    <li><a hidefocus href="depart.aspx" target="rightframe">部门管理</a></li>
                                    <li><a hidefocus href="roles.aspx" target="rightframe">角色管理</a></li>
                                    <li><a hidefocus href="users.aspx" target="rightframe">用户管理</a></li>
                                </ul>
                            </li>
                            <li class="pmenu"><a hidefocus href="javascript:void(0);" target="rightframe">基础数据</a>
                                <ul>
                                    <li><a hidefocus href="cate_cust.aspx" target="rightframe">客户类别管理</a></li>
                                    <li><a hidefocus href="cate_doc.aspx" target="rightframe">文档类别管理</a></li>
                                    <li><a hidefocus href="cate_case.aspx" target="rightframe">案件类别管理</a></li>
                                    <%--<li><a hidefocus href="logs.aspx" target="rightframe">日志管理</a></li>--%>
                                </ul>
                            </li>
                            <li class="pmenu"><a hidefocus href="javascript:void(0);">系统管理</a>
                                <ul>
                                    <li><a hidefocus href="personal.aspx" target="rightframe">个人设置</a></li>
                                    <%--<li><a hidefocus href="account.aspx" target="rightframe">账号设置</a></li>--%>
                                    <li class="notrace"><a hidefocus href="resetpwd.aspx" target="rightframe">修改密码</a></li>
                                    <li><a hidefocus href="path.aspx" target="rightframe">路径设置</a></li>
                                    <li><a hidefocus href="db.aspx" target="rightframe">数据库备份</a></li>
                                    <%--<li><a hidefocus href="version.aspx" target="rightframe">版本说明</a></li>--%>
                                </ul>
                            </li>
                            <li><a hidefocus href="serverinfo.aspx" target="rightframe">　系统信息</a></li>
                            <%--<li class="pmenu"><a hidefocus href="javascript:void(0);">父菜单</a>
                                <ul>
                                    <li><a hidefocus href="list.html" target="rightframe">子菜单</a></li>
                                    <li><a hidefocus target="rightframe">子菜单</a></li>
                                    <li class="pmenu"><a hidefocus="" href="javascript:void(0);">子菜单</a>
                                        <ul>
                                            <li><a hidefocus target="rightframe">三级菜单</a></li>
                                            <li><a hidefocus target="rightframe">三级菜单</a></li>
                                        </ul>
                                    </li>
                                    <li class="pmenu">
                                        <a hidefocus href="javascript:void(0);">子菜单</a>
                                        <ul>
                                            <li><a hidefocus href="about:blank" target="rightframe">三级菜单</a></li>
                                            <li><a hidefocus href="about:blank" target="rightframe">三级菜单</a></li>
                                        </ul>
                                    </li>
                                </ul>
                            </li>--%>
                            <li class="notrace"><a hidefocus href="logout.aspx">　退出登录</a></li>
                        </ul>
                    </div>
                    <div class="left_3"></div>
                    <div class="left_6"></div>
                </div>
            </td>
            <td style="width:100%; height: 100%;" valign="top">
                     <div class="right_1">
                    </div>
                 <iframe  style="height:100%;width:100%;" id="rightframe" name="rightframe"  src="zongzhi.aspx" border="0" frameborder="0" scrolling="no"> 浏览器不支持嵌入式框架，或被配置为不显示嵌入式框架。</iframe>
            </td>
        </tr>
    </table>
    </form>
    <!--ajax弹出层开始-->
    <div id="float_bg" class="floatdiv"></div>
    <div id="float_cont" class="floatdiv"><div><img src="images/loading46.gif" /><a href="javascript:popAction();" id="ajaxclose">关闭</a></div></div>
    <!--ajax弹层结束-->
</body>
</html>
