/*
 * Date : 2012-03-30 23:03:11
 * Copyright (c) 2013 by Walker Wang
 */
var src = $("script:last").attr("src");
$(function () {
    //IE升级
    if ($("#ieupgrade").length > 0) {
        //var cont = "IE用户请下载插件以支持本站功能正常使用：";
        //cont += "<a href='/js/ieupgrade.msi' class='btn btn-primary'><i class='icon-download-alt icon-white'></i>&nbsp;下载ieupgrade.msi</a>";
        //cont += "<br/><br/><p class='text-center'><code class='text-error'>下载安装完毕后请重启浏览器！</code></p>";
        //malert(cont);
        location.href = '/upgrade.html';
    }
    //取type参数，给注册表格事件用
    var args = (/type=([^#&]+).*/i.exec(src) || ["", "single"])[1];
    //设置主题
    setTheme();
    //选择记录、行选择
    $(".GVcbx").click(function (e) {
        e.stopPropagation();
        if (args == "single") {
            $(".GVcbx").not(this).attr("checked", false);
            var tr = $(this).parents("tr").eq(0);
            tr.toggleClass("selected warning");
            $(".selected").not(tr).removeClass("selected warning");
        } else {
            var tr = $(this).parents("tr").eq(0);
            var o = $(this);
            setTimeout(function () {
                if (o.attr("checked")) { $(".selected").not(tr).removeClass("selected warning"); tr.addClass("selected warning multiselected"); } else tr.removeClass("selected warning multiselected");
                $("#cbxall").prop("checked", $(".GVcbx").not(":checked").length == 0);
            }, 0);
        }
    });
    var m; //行点击事件延时标志
    $("#gridlist tr").click(function () { var o = this; m = setTimeout(function () { $(".GVcbx", o).click(); }, 200); });
    $("#gridlist tr").dblclick(function () {
        clearTimeout(m); //一旦监测到双击事件，取消单击延时事件
        var o = $(this);
        var c = $(".GVcbx", this);
        o.toggleClass("selected");
        c.attr("checked", !(c.attr("checked")));
        $(".selected").not(o).removeClass("selected warning");
        $(".GVcbx").not(c).attr("checked", false);
        if (c.attr("checked")) detail();
    });
    //注册全选
    if (args != "single") $("#cbxall").click(function () { var thistable = $("#gridlist"); if ($(this).prop("checked")) { $(".GVcbx", thistable).prop("checked", true); $("tr", thistable).addClass("multiselected").last().addClass("selected"); } else { $(".GVcbx", thistable).prop("checked", false); $("tr", thistable).removeClass("selected warning multiselected"); } });
    //表格浮动提示
    $(".nodetail").mouseenter(function (e) { $("#divdetail").hide().find(".popover-content"); }).find("a").mouseover(function (e) { e.stopPropagation(); });
    $(".detailtb td").not(".nodetail").mouseenter(function (e) {
        var td = $(this);
        var d = $(this).parent("tr").find(":hidden").val() || "";
        if (d != "") {
            var dvd = $("#divdetail"); dvd.find(".popover-content").html(d).end().show('fast', function () { $(this).css({ left: td.offset().left + td.width(), top: function () { return td.offset().top - $('.popover').height() / 2 + td.height() / 2; } }); });
            var fh = $(window).height() - e.pageY - dvd.height(); if (fh < 0) dvd.css({ top: $(window).height() - dvd.height() - 13 }); $(".popover").show();
        } else $("#divdetail").hide();
    })
    .closest("table").mouseleave(function () { $("#divdetail").hide(); });
    $("#divdetail").mouseenter(function () { $(this).show(); }).mouseleave(function () { $(this).hide().find(".popover-content").html(''); });
    $(".table1").find("a").click(function (e) { e.stopPropagation(); }).end().find(":input").click(function (e) { e.stopPropagation(); });
    //点击单元格内的文本框，变成文本域
    $(".cellTextArea :input").live("focusin", function () { $(this).addClass("byellow").css({ height: 100 }); }).live("focusout", function () { $(this).css({ height: 18 }).removeClass("byellow"); });

    //bootstrap控件
    //响应导航菜单的更换皮肤命令
    $(".changeTheme li a").click(function() {
        setTheme($(this).text());
    });
    renderPager();
});
//固定gridview头部
function fixheader() {
    $("<table/>", { "class": "table1" }).appendTo($("#fixheader")).append($("#gridlist tr:first"));
    $("#fixheader .table1").width(function () { return $("#gridlist").width(); });
}
//设置主题颜色
//支持手动设置theme或从cookie读取cookie
function setTheme(theme) {
    if (!theme) { //不传theme即从cookie设置cookie
        theme = getCookie('theme');
        if (!theme) setCookie('theme', 'default', 360);
        theme = getCookie("theme");
    } else setCookie('theme', theme, 360);
    theme = "/css/bootstrap/" + theme + "/bootstrap.min.css";
    $("#btstyle").attr('href', theme);
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

//bootstrap modal
function malert(cont, title) {
    var m = $("#alertModal");
    if (m.length == 0) {
        m = $('<div id="alertModal" class="modal hide fade" tabindex="-1"><div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button><h3 class="modal-title">Modal header</h3></div><div class="modal-body"></div><div class="modal-footer"><button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">确定</button></div></div>')
            .appendTo($('body'));
    }
    $('.modal-title', m).text(title || '提示');
    $('.modal-body', m).html(cont);
    m.modal('show');
}

function mconfirm(cont, title, callback) {
    var m = $("#confirmModal");
    if (m.length == 0) {
        m = $('<div id="confirmModal" class="modal hide fade" tabindex="-1"><div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button><h3 class="modal-title">Modal header</h3></div><div class="modal-body"></div><div class="modal-footer"><a href="#" class="btn" data-dismiss="modal" aria-hidden="true">取消</a><a href="#" class="btn btn-primary btnok">确定</a></div></div>')
            .appendTo($('body'));
    }
    $('.modal-title', m).text(title || '警告');
    $('.modal-body', m).html(cont);
    if (callback != undefined) {
        $('.btnok', m).off('click').on('click', function() {
            console.log(1);
            callback();
        });
    }
    m.modal('show');
}

function renderPager() {
    var container = $('#AspNetPager1 div').eq(0).addClass('btn-group');
    container.find('a').add('span', container).addClass('btn').css({ 'margin-right': 0});
    container.find('span').addClass('disabled');
}

//移除无权限的菜单
function adminAction(role) {
    role = parseInt(role);
    if (role != 0 && role != 1) $(".admin-action").remove();
}