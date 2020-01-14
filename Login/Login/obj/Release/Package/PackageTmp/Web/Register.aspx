<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Login.Web.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>注册</title>
</head>
<body>
    <form id="form1" runat="server" style="margin-left:500px;margin-top:200px;width:500px; background-color:beige">
        <div class="form-group">
            <br /><br /><br /><br /><br />
            <asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label>
            <asp:TextBox ID="name" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label2" type="password" runat="server" Text="密 &nbsp;&nbsp;码"></asp:Label>
            <asp:TextBox ID="password" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label4" runat="server"></asp:Label>
            <br /><br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button runat="server" ID="Regist" OnClick="Regist_Click1" Text="注册账号" />
            <p><span style="color:red;">注意：注册成功后将进入首页面，请记住密码便于下次登录</span></p>
            </div>
    </form>
</body>
</html>
