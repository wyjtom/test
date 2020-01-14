<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteForm.aspx.cs" Inherits="Login.Web.Operator.DeleteForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link  rel="stylesheet" href="../../CSS/Lead.css"/>
    <title>Mac地址删除</title>
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
    <form id="form1" runat="server" style="margin-left:50px;margin-bottom:50px">
        <div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  AllowPaging="True" PageSize="5" DataKeyNames="Id" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="编号" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="StartMac" HeaderText="起始地址" SortExpression="StartMac" />
                    <asp:BoundField DataField="EndMac" HeaderText="终止地址" SortExpression="EndMac" />
                    <asp:BoundField DataField="CusCode" HeaderText="客户编号（来源MES）" SortExpression="CusCode" />
                    <asp:BoundField DataField="MacType" HeaderText="Mac类型（蓝牙|WiFi）" SortExpression="MacType" />
                    <asp:BoundField DataField="ActionType" HeaderText="操作类型（新建|修改）" SortExpression="ActionType" />
                    <asp:BoundField DataField="Maker" HeaderText="操作者" SortExpression="Maker" />
                    <asp:BoundField DataField="OperationTime" HeaderText="操作时间" SortExpression="OperationTime" />
                    <asp:CommandField HeaderText="操作" ShowDeleteButton="True" ShowSelectButton="True" />
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
        <a href="LogQuerry.aspx">查看操作日志</a>
        <asp:Label ID="Label1" runat="server" ></asp:Label>

    </form>
</body>
</html>
