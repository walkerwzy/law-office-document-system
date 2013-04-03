<%@ Page Language="C#" AutoEventWireup="true" CodeFile="agendar.aspx.cs" Inherits="agendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
<link href="/css/main.css?v=1" rel="stylesheet" type="text/css" />--%>
    <walker:header ID="myheader" runat="server" mytitle="主页" />
<link href="js/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css" />
<link href="js/fullcalendar/fullcalendar.print.css" rel="stylesheet" type="text/css" media="print" />
    <style type="text/css">
        #fixheader{height:0;}
        #calendar{margin:15px;}
        .fc-grid th{height:24px; line-height:24px;}
        .fc-day-number{font-family:"Lucida Grande",Helvetica,Arial,Verdana,sans-serif; font-size:14px;}
        .fc-event-inner{font-size:12px; padding:2px 0;}
        .cred, .cred div{background:#a11; border-color:#a11;}
        .cgreen, .cgreen div{background:Green; border-color:Green;}
        .cgray, .cgray div{background:Gray; border-color:Gray;}
        .corange, .orange div{background:#ec870e; border-color:#ec870e;}
        .cpurple, .cpurple div{background:#f3a;border-color:#d2a;}
        .cyellow, .cyellow div{background:#ff3;border-color:#ff3; color:#333;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <walker:navi ID="mynavi" runat="server" menu="home" />
    <div class="div_top container">
        <div class="breadcrumb">
            当前位置&nbsp;&nbsp;>&nbsp;&nbsp;主页
        </div>
        <div id='calendar'></div>
    </div>
    <div style="display:none;" id="agendarform">
    <style type="text/css">
        #a-detail{margin:20px;}
        #a-detail li{ vertical-align:top; list-style:none;}
        #txtcont{width:400px;height:100px;resize:none;}
    </style>
    <ul id="a-detail">
        <li>事件内容：<textarea id="txtcont" class="tinput"></textarea></li>
        <li>不公开：<input type="checkbox" id="cbxprivate"/>&nbsp;<span class="tgray muted">不公开的日程只有本人能查看</span></li>
    </ul>
    </div>
    </form>
    
    <script src="js/fullcalendar/jquery-ui-1.8.23.custom.min.js" type="text/javascript"></script>
    <script src="js/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
    <script src="js/fullcalendar/gcal.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var date = new Date();
            var d = date.getDate();
            var m = date.getMonth();
            var y = date.getFullYear();
            var time = date.getTime();

            var evs = [
             //{ url: 'https://www.google.com/calendar/feeds/china__zh_cn%40holiday.calendar.google.com/public/basic', className: "cgreen cgoogle" },
             { url: 'alertajax.aspx?act=agendar', className: 'clickable' },
             { url: 'alertajax.aspx?act=kaiting', className: 'cred' },
             { url: 'alertajax.aspx?act=birthday', className: 'cgray' },
             { url: 'alertajax.aspx?act=xuyue', className: 'corange' },
             { url: 'alertajax.aspx?act=docs', className: 'cyellow' }
            ];
            $('#calendar').fullCalendar({
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,basicWeek,basicDay'
                },
                editable: true,
                disableResizing: true,
                eventSources: evs,
                //viewDisplay: function (view) {
                //    //console.log(view.start);
                //},
                dayClick: function (date, allDay, jsEvent, view) {
                    agendar(date);
                },
                eventClick: function (event, jsevent, view) {
                    if ($(this).is(".cgoogle")) { jsevent.stopPropagation(); return false; }
                    if (!$(this).is(".clickable")) jsevent.stopPropagation();
                    else agendar(event, true);
                },
                eventRender: function (event, element) {
                    //浮动显示出自定义的description属性
                    element.attr("title", event.description);
                },
                eventDrop: function (event, dayDelta, minuteDelta, allDay, revertFunc) {
                    var move = $.get('alertajax.aspx?act=movedate', { todate: event.start.getTime(), t: new Date().getTime(), id: event.id });
                    $.when(move).done(function (d) { var f = d.split('|'); if (f[0] != "1") { alert(f[1]); revertFunc(); } })
                    .fail(function (jXHR, errtype, errmsg) { alert('移动日程失败，原因：' + errmsg); });
                },
                monthNames: ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'],
                dayNamesShort: ['星期天', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六'],
                titleFormat: { month: 'yyyy年 MMMM' },
                buttonText: {
                    today: '今天',
                    month: '月视图',
                    week: '周视图',
                    day: '日视图'
                }
            });
        });
        /*
        *@e: 日程event对象
        *@isedit:为真时，e参数为当前日期对象
        */
        function agendar(e, isedit) {
            var title = "添加日程";
            $("#txtcont").val("").focus();
            $("#cbxprivate").prop("checked", true).prop("disabled", false);
            if (isedit) {
                title = "编辑日程";
                $("#txtcont").val(e.title);
                $("#cbxprivate").prop("checked", e.p == 1).prop("disabled", e.cp == 0);
            }
            var dlg = new $.dialog({ id: "dg02", title: title, html: $("#a-detail")[0], resize: false, width: 480, height: 280, cover: true, rang: true, cancelBtn: true, maxBtn: false });
            dlg.ShowDialog();
            if (isedit) {
                dlg.addBtn('dbtndel', '删除', function () {
                    if (!confirm("日程删除后不可恢复，确定删除？")) return;
                    $.get("alertajax.aspx", { act: 'delagendar', id: e.id, t: new Date().getTime() }, function (d) {
                        if (d == "1") {
                            $("#calendar").fullCalendar("removeEvents", e.id);
                        } else alert(d);
                        dlg.cancel();
                    });
                });
            }
            dlg.addBtn('dbtnOK', "确定", function () {
                var cont = encodeURI($("#txtcont", top.document).val());
                var isp = $("#cbxisprivate", top.document).prop("checked") ? 1 : 0;
                var act = "addagendar";
                var id = -1;
                var start = "";
                if (isedit) {
                    act = "updateagendar";
                    id = e.id;
                } else start = e.getTime();
                $.get("alertajax.aspx", { act: act, cont: cont, isp: isp, id: id, start: start, t: new Date().getTime() }, function (d) {
                    f = d.split('|'); //如果操作是添加，则添加后生成的id存在f[1]里
                    var nt = decodeURI(cont);
                    if (f[0] != "0") {
                        if (isedit) {
                            e.title = nt;
                            $('#calendar').fullCalendar('updateEvent', e);
                        } else {
                            //$('#calendar').fullCalendar('addEventSource', [{ id: f[1], title: nt, description: nt, start: e}]);此两次效果相同
                            $('#calendar').fullCalendar('renderEvent', { id: f[1], title: nt, description: nt, start: e });
                        }
                    }
                    else alert(d);
                    dlg.cancel();
                });
            });
        }
    </script>
</body>
</html>
