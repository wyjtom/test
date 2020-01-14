<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="Login.Web.Operator.ManageUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link  rel="stylesheet" href="../../CSS/Lead.css"/>
    <title>用户管理</title>
</head>
<body>
     <ul class="nav">
	 <!-- <li><a href="/Web/Teleplate.aspx">Home</a></li>
       <li><a href="/Web/showdata.aspx">分页显示数据</a></li>
	  <li><a href="/Web/Vue.aspx">Vue测试</a></li>
        <li><a href="../TestJson.aspx">Josn测试</a></li>-->
	  <li><a href="AddForm.aspx">Mac增加</a></li>
	 <!-- <li><a href="DeleteForm.aspx">Mac删除</a></li>-->
	  <li><a href="UpdateForm.aspx">Mac更改</a></li>
	  <li><a href="QuerryForm.aspx">Mac查询</a></li>
      <li><a href="ShowInfo.aspx">测试结果</a></li>
      <li><a href="LogQuerry.aspx">操作日志</a></li>
      <li><a href="ManageUser.aspx">员工管理</a></li>
        
    </ul>

    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="314px">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="员工名" SortExpression="UserName" />
                <asp:BoundField DataField="Permission" HeaderText="权限" SortExpression="Permission" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>

        <div class="form-group">
            <br /><br />
            <asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label>
            <asp:TextBox ID="name" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label2" type="password" runat="server" Text="密 &nbsp;&nbsp;码"></asp:Label>
            <asp:TextBox ID="password" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label4" runat="server" BackColor="Red" ForeColor="Yellow"></asp:Label>
            <br />
            <asp:RadioButton ID="RaManager" runat="server" Text="管理员" GroupName="1" />
            <asp:RadioButton ID="RaEngineer" runat="server" Text="工程师" GroupName="1" />
            <asp:RadioButton ID="RaUser" runat="server" Text="一般用户" GroupName="1" />
            <br /><br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button runat="server" ID="Add" OnClick="Add_Click" Text="新增员工" />
            </div>
    </form>
</body>
</html>
