<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowInfo.aspx.cs" Inherits="Login.Web.Operator.ShowInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link  rel="stylesheet" href="../../CSS/Lead.css"/>
    <title></title>
    
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
        
    </ul>
    <form id="form1" runat="server" style="margin-left:20px;margin-top:20px">
        <asp:GridView ID="GridView1" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging1"  runat="server" AutoGenerateColumns="False" Height="191px" Width="1088px">
            <Columns>
                <asp:BoundField DataField="CusMac" HeaderText="CusMac地址" SortExpression="CusMac" />
                <asp:BoundField DataField="MesId" HeaderText="MesId" SortExpression="MesId" />
                <asp:BoundField DataField="EspMac" HeaderText="EspMac" SortExpression="EspMac" />
                <asp:BoundField DataField="BtMac" HeaderText="BtMac" SortExpression="BtMac" />
                <asp:BoundField DataField="ModuleType" HeaderText="模块类型（WIFI、蓝牙）" SortExpression="ModuleType" />
                <asp:BoundField DataField="ModuleVer" HeaderText="ModuleVer" SortExpression="ModuleVer" />
                <asp:BoundField DataField="Status" HeaderText="状态" SortExpression="Status" />
                <asp:BoundField DataField="TestResult" HeaderText="测试结果" SortExpression="TestResult" />
                <asp:BoundField DataField="LabelContent" HeaderText="标签内容" />
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
        <div>
        </div>
    </form>
</body>
</html>
