<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogQuerry.aspx.cs" Inherits="Login.Web.Operator.LogQuerry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link  rel="stylesheet" href="../../CSS/Lead.css"/>
    <title>操作日志界面</title>
    
</head>
<body style="height: 667px">
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
        
    </ul>
    <form id="form1" runat="server" style="margin-left:50px;height:100px">
        <<div style="background-color:cornsilk; height: 448px;">
            <h1>操作查询界面</h1>
         <asp:Label ID="Label1" runat="server" Text="输入提示：MAC起始地址&lt;=MAC结束地址   "></asp:Label><br /><br/>
        &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="MAC地址输入格式如：D0:73:D5:FE:25:7A"></asp:Label><br />
        <asp:Label ID="Label3" runat="server" Text="MAC开始地址:"></asp:Label>
        <asp:TextBox ID="txtMacStart" runat="server" Height="25px" Width="189px"></asp:TextBox><br /><br/>
        <asp:Label ID="Label4" runat="server" Text="MAC结束地址:"></asp:Label>
        <asp:TextBox ID="txtMacEnd" runat="server" Height="25px" style="margin-right: 0px" Width="190px"></asp:TextBox>
            <asp:Label ID="labflag" runat="server" BackColor="Red" ForeColor="Yellow"></asp:Label>
            <br /><br/>
        <asp:Button ID="btnLogQuerry" OnClick="btnLogQuerry_Click" runat="server" Text="查询" Height="30px" Width="113px" />
            <br />
            <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False" DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="UsedEndMac" HeaderText="终止地址" SortExpression="UsedEndMac" />
                <asp:BoundField DataField="UsedStartMac" HeaderText="起始地址" SortExpression="UsedStartMac" />
                <asp:BoundField DataField="Maker" HeaderText="操作者" SortExpression="Maker" />
                <asp:BoundField DataField="ActionType" HeaderText="操作类型" SortExpression="ActionType" />
                <asp:BoundField DataField="OperationTime" HeaderText="操作时间" SortExpression="OperationTime" />
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
        </div>
    </form>
</body>
</html>
