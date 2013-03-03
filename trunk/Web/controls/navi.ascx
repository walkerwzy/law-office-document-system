<%@ Control Language="C#" AutoEventWireup="true" CodeFile="navi.ascx.cs" Inherits="controls_navi" %>
		<div class="navbar navbar-inverse navbar-fixed-top">
			<div class="navbar-inner">
				<div class="container">
					<a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
			            <span class="icon-bar"></span>
			            <span class="icon-bar"></span>
			            <span class="icon-bar"></span>
			        </a>
			        <a href="/" class="brand">律所文档管理系统</a>
			        <div class="nav-collapse collapse">
			            <ul class="nav">
			              <li class="<%=getclassname("home") %>"><a href="/agendar.aspx">主页</a></li>
			              <li class="dropdown <%=getclassname("cases") %>">
			                <a href="#" class="dropdown-toggle" data-toggle="dropdown" data-trigger="hover">案件管理<b class="caret"></b></a>
			                <ul class="dropdown-menu">
                                <asp:Repeater runat="server" ID="rptcase">
                                    <ItemTemplate>
                                        <li><a href="/cases.aspx?casetype=<%# Eval("cateid") %>"><%# Eval("catename") %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <li class="divider"></li>
                                <li><a href="/cases.aspx">全部</a></li>
                            </ul>
			              </li>
			              <li class="dropdown <%=getclassname("docs") %>">
			                <a href="#" class="dropdown-toggle" data-toggle="dropdown">文档管理<b class="caret"></b></a>
			                <ul class="dropdown-menu">
                                <asp:Repeater runat="server" ID="rptdocs">
                                    <ItemTemplate>
                                        <li><a href="/docs.aspx?type=<%#Eval("cate_id") %>"><%#Eval("cate_name") %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <li class="divider"></li>
                                <li><a href="/docs.aspx">全部</a></li>
			                </ul>
			              </li>
			              <li class="dropdown <%=getclassname("clients") %>">
			                <a href="#" class="dropdown-toggle" data-toggle="dropdown">客户管理<b class="caret"></b></a>
			                <ul class="dropdown-menu">
                                <asp:Repeater runat="server" ID="rptclients">
                                    <ItemTemplate>
                                        <li><a href="clients.aspx?clienttype=<%#Eval("cateid") %>"><%#Eval("catename") %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <li class="divider"></li>
                                <li><a href="/clients.aspx">全部</a></li>
			                </ul>
			              </li>
			              <li class="<%=getclassname("notice") %>"><a href="/zongzhi.aspx">公告栏</a></li>
			            </ul>
                        <div class="pull-right"><a href="/logout.aspx" class="btn">退出登录</a></div>
			            <%--<form class="navbar-form pull-right">
			              <input class="span2" type="text" placeholder="Email">
			              <input class="span2" type="password" placeholder="Password">
			              <button type="submit" class="btn">Sign in</button>
			            </form>--%>
			        </div><!--/.nav-collapse -->
		        </div>
	        </div>
	     </div>