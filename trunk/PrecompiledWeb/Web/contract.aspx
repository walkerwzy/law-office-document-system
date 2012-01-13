<%@ page language="C#" autoeventwireup="true" inherits="contract, App_Web_j3cfvcxm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/public.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <link href="/js/autoComplete/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body{overflow-x:hidden;height:auto;background:#fff;}
        fieldset{margin:10px; padding:10px; position:relative;}
        li{height:24px; line-height:24px;}
        #innerlist{padding:0 10px;}
        th{background:#f3f3f3; color:#1E5494; font-weight:400;}
        #gridlist .tinput{border:1px solid #ccc; width:100px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>&nbsp;
        <asp:HiddenField runat="server"  ID="hidcustid" />
        <asp:HiddenField runat="server" ID="hiduid" />
        <fieldset>
            <legend>操作</legend>
            <ul>
                <li><span>　签约人：<asp:TextBox runat="server" ID="txtuid" class="tinput" Width="200px" autocomplete="off"></asp:TextBox></span>
                <span>签约客户：</span><asp:Label runat="server" CssClass="tinput" Width="224px" ID="txtcustid" style="border:none; overflow:visible; white-space:nowrap;"></asp:Label></li>
                <li><span>签约日期：<asp:TextBox ID="txtstime" runat="server" Width="200px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" CssClass="tinput Wdate"></asp:TextBox></span>
                <span>到期日期：<asp:TextBox ID="txtetime" runat="server" Width="200px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" CssClass="tinput Wdate"></asp:TextBox></span></li>
                <li><span>签约金额：</span><asp:TextBox ID="txtfee" runat="server" Width="200px" class="tinput"></asp:TextBox>
                <span>付款日期：</span><asp:TextBox ID="txtctime" runat="server" Width="200px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" CssClass="tinput Wdate"></asp:TextBox></li>
                <li><span>备　　注：</span><asp:TextBox ID="txtremark" runat="server" Width="465px" MaxLength="100" class="tinput"></asp:TextBox></li>
                <li><asp:Button runat="server" ID="btnadd" OnClick="btnadds" Text="添加" CssClass="btn1" OnClientClick="return checkadd();" /></li>
            </ul>
        </fieldset>
        <div id="innerlist">
            <asp:GridView ID="gridlist" runat="server" AutoGenerateColumns="false" CssClass="table1 detailtb" Width="100%" DataSourceID="ods" EnableModelValidation="True"  EmptyDataText="未查找到签约记录！" DataKeyNames="c_no,custid" >
                <Columns>
                    <asp:BoundField DataField="c_no" HeaderText="合同编号" SortExpression="c_no" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="65px" ReadOnly="true" /> 
		            <%--<asp:BoundField DataField="custid" HeaderText="custid" SortExpression="custid" ItemStyle-HorizontalAlign="Center"  />--%> 
		            <asp:BoundField DataField="username" HeaderText="签约人" SortExpression="username" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="65px" ReadOnly="true" /> 
		            <asp:BoundField DataField="c_stime" HeaderText="签约日期" SortExpression="c_stime" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:d}" ItemStyle-Width="65px" ReadOnly="true"  /> 
		            <asp:BoundField DataField="c_fee" HeaderText="签约金额" SortExpression="c_fee" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="60px" ReadOnly="true" /> 
		            <asp:BoundField DataField="c_etime" HeaderText="到期日期" SortExpression="c_etime" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:d}"  ItemStyle-Width="65px" ReadOnly="true" /> 
		            <%--<asp:BoundField DataField="c_ctime" HeaderText="付款日期"  ItemStyle-HorizontalAlign="Center" DataFormatString="{0:d}"  ItemStyle-Width="65px" /> --%>
                    <asp:TemplateField HeaderText="付款日期" ItemStyle-Width="90px" HeaderStyle-Width="90px">
                        <ItemTemplate>
                            <%# (Eval("c_ctime")==null||Eval("c_ctime")==DBNull.Value)?"":Convert.ToDateTime(Eval("c_ctime")).ToString("yyyy-MM-dd") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="txtcctime" Text='<%# Bind("c_ctime") %>' CssClass="tinput Wdate" Width="100px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
		            <asp:BoundField DataField="remark" HeaderText="备注" SortExpression="remark" ItemStyle-HorizontalAlign="Center" ReadOnly="true"  /> 
                    <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" HeaderStyle-Width="80px">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbtnedit" CommandName="Edit">编辑</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lbtndel" CommandName="Delete" OnClientClick="return confirm('确认删除？');">删除</asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton runat="server" ID="lbtnupdate" CommandName="Update">保存</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lbtncancel" CommandName="Cancel" CausesValidation="false">取消</asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
        <asp:ObjectDataSource ID="ods" runat="server" DeleteMethod="Delete" UpdateMethod="Update"  
        SelectMethod="GetList" TypeName="WZY.DAL.CONTRACT" 
        DataObjectTypeName="WZY.Model.CONTRACT">
            <DeleteParameters>
                <asp:Parameter Name="c_no" Type="String" />
            </DeleteParameters>
            <SelectParameters>
                <asp:Parameter Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    <br />
    </form>
</body>
<script src="/js/ca/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
<script src="/js/autoComplete/autoComplete.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("#txtuid").autoCmpt({ url: "ajaxHandler.aspx?act=getuser", width: 200, hidden: $("#hiduid")});
    });
    var thisdg = frameElement.lhgDG;
    thisdg.addBtn('btnClose', '取消', function () { top.popAction(false); thisdg.cancel(); });
    function checkadd() {
//        if ($.trim($("#txtcustid").val()) == "") { alert("请选择客户"); return false; } else { $("#hidcustid").val($.trim($("#txtcustid").attr("qid"))); var hust = $("#hidcustid").val(); if (hust == "" || hust == "-1") { alert("无效的客户，请重新选择"); return false; } }
        if ($.trim($("#txtuid").val()) == "") { alert("请选择签约人"); return false; } else { $("#hiduid").val($.trim($("#txtuid").attr("qid"))); var hust = $("#hiduid").val(); if (hust == "" || hust == "-1") { alert("无效的签约人，请重新选择"); return false; } }
        if ($.trim($("#txtstime").val()) == "") { alert("签约时间不能为空"); return false; }
        if ($.trim($("#txtetime").val()) == "") { alert("到期时间不能为空"); return false; }
        if ($.trim($("#txtfee").val()) == "") { alert("签约金额请输入数字"); return false; }
        if (!/^[0-9\]+\.?[0-9]*$/.test($.trim($("#txtfee").val()))) { alert('签约金额请输入数字'); return false;  }
        return true;
    }
</script>
</html>
