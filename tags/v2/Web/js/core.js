/*!
 * Date : 2011-07-31 11:03:11
 * Copyright (c) 2011 by Walker Wang
 */
var src=$("script:last").attr("src");
$(function () {
    //取type参数，给注册表格事件用
    var args = (/type=([^#&]+).*/i.exec(src) || ["", "single"])[1];
    setWidthHeight();
    fixheader();
    //隐藏浮层
    parent.popAction(false);
    //选择记录、行选择
    $(".GVcbx").click(function (e) {
        if (args == "single") {
            $(".GVcbx").not(this).attr("checked", false);
            var tr = $(this).parents("tr").eq(0);
            tr.toggleClass("selected");
            $(".selected").not(tr).removeClass("selected");
        } else {
            var tr = $(this).parents("tr").eq(0);
            var o = $(this);
            setTimeout(function () {
                if (o.attr("checked")) { $(".selected").not(tr).removeClass("selected"); tr.addClass("selected multiselected"); } else tr.removeClass("selected multiselected");
                $("#cbxall").prop("checked", $(".GVcbx").not(":checked").length == 0);
            }, 0);
        }
        e.stopPropagation();
    });
    var m; //行点击事件延时标志
    $("#gridlist tr").click(function () { var o = this; m = setTimeout(function () { $(".GVcbx", o).click(); }, 200); });
    $("#gridlist tr").dblclick(function () {
        clearTimeout(m); //一旦监测到双击事件，取消单击延时事件
        var o = $(this);
        var c = $(".GVcbx", this);
        o.toggleClass("selected");
        c.attr("checked", !(c.attr("checked")));
        $(".selected").not(o).removeClass("selected");
        $(".GVcbx").not(c).attr("checked", false);
        if (c.attr("checked")) detail();
    });
    //注册全选
    if (args != "single") $("#cbxall").click(function () { var thistable = $("#gridlist"); if ($(this).prop("checked")) { $(".GVcbx", thistable).prop("checked", true); $("tr", thistable).addClass("multiselected").last().addClass("selected"); } else { $(".GVcbx", thistable).prop("checked", false); $("tr", thistable).removeClass("selected multiselected"); } });
    //注册横滚事件
    $("#rightcontent").scroll(function () { var left = 0 - this.scrollLeft; $("#fixheader").css({ marginLeft: left }); });
    //浏览器大小改变事件
    window.onresize = setWidthHeight;
    //表格浮动提示
    $(".nodetail").mouseenter(function (e) { $("#divdetail").html("").hide(); }).find("a").mouseover(function (e) { e.stopPropagation(); });
    $(".detailtb td").not(".nodetail").mouseenter(function (e) { var d = $(this).parent("tr").find(":hidden").val() || ""; if (d != "") { var dvd = $("#divdetail"); dvd.html(d).css({ left: e.pageX, top: e.pageY }).show(); var fh = $(window).height() - e.pageY - dvd.height(); if (fh < 0) dvd.css({ top: $(window).height() - dvd.height() - 13 }); } else $("#divdetail").hide(); })
    .closest("table").mouseleave(function () { $("#divdetail").hide(); });
    $("#divdetail").mouseenter(function () { $(this).show(); }).mouseleave(function () { $(this).html("").hide()});
    $(".table1").find("a").click(function (e) { e.stopPropagation(); }).end().find(":input").click(function (e) { e.stopPropagation(); });
    //点击单元格内的文本框，变成文本域
    $(".cellTextArea :input").live("focusin", function () { $(this).addClass("byellow").css({ height: 100 }); }).live("focusout", function () { $(this).css({ height: 18 }).removeClass("byellow"); });
    setTheme();
});
//动态设定宽高
function setWidthHeight() { var top = $("#rightcontent").position().top + 25; $("#rightcontent").height($(window).height() - top); }
//固定gridview头部
function fixheader() {
    $("<table/>", { "class": "table1" }).appendTo($("#fixheader")).append($("#gridlist tr:first"));
    $("#fixheader .table1").width(function () { return $("#gridlist").width(); });
}
//设置主题颜色
function setTheme(){	
	if(top.getCookie("theme")=="gray") $(".toolbar").addClass("themegray");
	else $(".toolbar").removeClass("themegray");
}
function cprint() {
    $(".div_top").add(".divpager").add(":checkbox").hide();
    $("#fixheader tr:first").clone().prependTo($("#gridlist"));
    $("td span").each(function (i, m) { var o = $(m); o.data("ot", o.text()); o.text(o.attr("title")); });
    window.print();
    $("td span").each(function (i, m) { var o = $(m); o.text(o.data("ot")); });
    $("#gridlist tr:first").remove();
    $(".div_top").add(".divpager").add(":checkbox").show();
}