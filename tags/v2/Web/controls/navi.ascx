<%@ Control Language="C#" AutoEventWireup="true" CodeFile="navi.ascx.cs" Inherits="controls_navi" %>
		<div class="navbar navbar-inverse">
			<div class="navbar-inner">
				<div class="container">
					<a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
			            <span class="icon-bar"></span>
			            <span class="icon-bar"></span>
			            <span class="icon-bar"></span>
			        </a>
			        <a href="" class="brand">律所文档管理系统</a>
			        <div class="nav-collapse collapse">
			            <ul class="nav">
			              <li class="active"><a href="/docs.aspx">主页</a></li>
			              <li class="dropdown">
			                <a href="#" class="dropdown-toggle" data-toggle="dropdown">案件管理<b class="caret"></b></a>
			                <ul class="dropdown-menu">
                                <asp:Repeater runat="server" ID="rptcase">
                                    <ItemTemplate>
                                        <li><a href="/"</li>
                                    </ItemTemplate>
                                </asp:Repeater>
			                </ul>
			              </li>
			              <li class="dropdown">
			                <a href="#" class="dropdown-toggle" data-toggle="dropdown">文档管理<b class="caret"></b></a>
			                <ul class="dropdown-menu">
			                  <li><a href="#">常年业务</a></li>
			                  <li><a href="#">诉讼业务</a></li>
			                  <li><a href="#">专项服务</a></li>
			                </ul>
			              </li>
			              <li class="dropdown">
			                <a href="#" class="dropdown-toggle" data-toggle="dropdown">客户管理<b class="caret"></b></a>
			                <ul class="dropdown-menu">
			                  <li><a href="#">常年业务</a></li>
			                  <li><a href="#">诉讼业务</a></li>
			                  <li><a href="#">专项服务</a></li>
			                </ul>
			              </li>
			              <li><a href="#">公告栏</a></li>
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