<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnUser2.aspx.cs" Inherits="Login.Web.UnUser2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link  rel="stylesheet" href="../CSS/Lead.css"/>
    <title>登录成功，欢迎访问</title>
    
</head>
<body>
    <h3>登录成功，欢迎访问</h3>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <p>标签式的导航菜单</p>
    <ul class="nav">
	  <li><a href="Unuser/Querry.aspx">Mac查询</a></li>
      <li><a href="Unuser/Log.aspx">操作日志查询</a></li>
    </ul>

    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>

