<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddForm.aspx.cs" Inherits="Login.Web.Operator.AddForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link  rel="stylesheet" href="../../CSS/Lead.css"/>
    <title>Mac地址添加</title>
</head>
<body style="height: 392px">
    
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
        <li><a href="../../Service/WebService1.asmx">数据测试</a></li>
        
    </ul>

    <label style="color:red">注意：已使用的起始地址和终止地址，添加时您不允许输入与以下一样的起始地址和终止地址！！</label>
    <form id="form1" runat="server" style="margin-left:50px;margin-top:20px">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="2" DataSourceID="SqlDataSource1">
         <Columns>
             <asp:BoundField DataField="StartMac" HeaderText="起始地址" SortExpression="StartMac" />
             <asp:BoundField DataField="EndMac" HeaderText="终止地址" SortExpression="EndMac" />
             <asp:BoundField DataField="Maker" HeaderText="操作者" SortExpression="Maker" />
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
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RemoteConn %>" SelectCommand="SELECT [StartMac], [EndMac], [Maker], [OperationTime] FROM [MESXPT_CusMACResource]"></asp:SqlDataSource>
        <div style="background-color:cornsilk; height: 379px; margin:50px auto">
            <h1>MAC地址添加界面</h1>
         <asp:Label ID="Label1" runat="server" Text="输入提示：MAC起始地址&lt;=MAC结束地址   "></asp:Label><br /><br/>
        &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="MAC地址输入格式如：D073D5XXXXXX，前面D073D5固定不变"></asp:Label><br />
          
            <br/><br /><br/><br/>
        <asp:Label ID="Label3" runat="server" Text="MAC开始地址:"></asp:Label>
        <asp:TextBox ID="txtMacStart" runat="server" Height="25px" Width="189px"></asp:TextBox><br /><br/>
        <asp:Label ID="Label4" runat="server" Text="MAC结束地址:"></asp:Label>
        <asp:TextBox ID="txtMacEnd" runat="server" Height="25px" style="margin-right: 0px" Width="187px"></asp:TextBox>
            
            <br /><br/>
        <asp:Button ID="btnSumitMac" OnClick="btnSumitMac_Click" runat="server" Text="提交" Height="30px" Width="113px" /><br/><br/>
            <asp:Label ID="labflag" runat="server" BackColor="Red" ForeColor="Yellow"></asp:Label>
        
            <br />
            <br />
        </div>
    </form>
</body>
</html>
