<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="Login.Web.Welcom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link  rel="stylesheet" href="../CSS/Lead.css"/>
    <title>登录成功</title>
     
</head>
<body>
    <h3>登录成功，欢迎访问</h3>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <p>标签式的导航菜单</p>
    <ul class="nav">
	 <!-- <li><a href="/Web/Teleplate.aspx">Home</a></li>
       <li><a href="/Web/showdata.aspx">分页显示数据</a></li>
	  <li><a href="/Web/Vue.aspx">Vue测试</a></li>
        <li><a href="../TestJson.aspx">Josn测试</a></li>-->
	  <li><a href="Operator/AddForm.aspx">Mac增加</a></li>
	 <!-- <li><a href="DeleteForm.aspx">Mac删除</a></li>-->
	  <li><a href="Operator/UpdateForm.aspx">Mac更改</a></li>
	  <li><a href="Operator/QuerryForm.aspx">Mac查询</a></li>
      <li><a href="Operator/ShowInfo.aspx">测试结果</a></li>
      <li><a href="Operator/LogQuerry.aspx">操作日志</a></li>
      <li><a href="Operator/ManageUser.aspx">员工管理</a></li>
        
    </ul>

    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
