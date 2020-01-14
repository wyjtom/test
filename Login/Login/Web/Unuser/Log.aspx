<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Log.aspx.cs" Inherits="Login.Web.Unuser.Log" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    title>测试日志界面</title>
    <style>
        * {
            margin: 0px;
            padding: 0px;
        }

        .nav {
            list-style: none; /* 去除无序列表的每条记录的标识 */
        }

        ul {
            width: 1000px;
            height: 30px;
            background-color: #550;
            overflow: hidden;
            margin: 50px auto; /* 元素水平居中 */
        }

        li {
            float: left;
            width: 100px;
        }

        a {
            text-decoration: none;
            color: white;
            font-weight: bold;
            padding: 5px 0; /* 增加内边距，将li元素的高度撑起来，li元素已经设置漂浮，其高度只能通过子元素来撑起来 */
            text-align: center;
            display: block; /* 设置成块元素之后,可以设置宽高,将漂浮的块元素li撑起来*/
            width: 100%;
        }

        .nav li a:hover {
            background-color: deepskyblue; /*设置整个元素的背景 */
            color: darkred; /*设置的是标签内容(这里是文字)的颜色 */
        }
    </style>
</head>
<body>
    <ul class="nav">
	  <li><a href="Querry.aspx">Mac查询</a></li>
      <li><a href="Log.aspx">操作日志查询</a></li>
    </ul>
    <form id="form1" runat="server" style="margin-left:50px">
        <<div style="background-color:cornsilk">
            <h1>测试log查询界面</h1>
         <asp:Label ID="Label1" runat="server" Text="输入提示：MAC起始地址&lt;=MAC结束地址   "></asp:Label><br /><br/>
        &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="MAC地址输入格式如：D0:73:D5:FE:25:7A"></asp:Label><br />
        <asp:Label ID="Label3" runat="server" Text="MAC开始地址:"></asp:Label>
        <asp:TextBox ID="txtMacStart" runat="server" Height="25px" Width="189px"></asp:TextBox><br /><br/>
        <asp:Label ID="Label4" runat="server" Text="MAC结束地址:"></asp:Label>
        <asp:TextBox ID="txtMacEnd" runat="server" Height="25px" style="margin-right: 0px" Width="190px"></asp:TextBox>
            <asp:Label ID="labflag" runat="server" BackColor="Red" ForeColor="Yellow"></asp:Label>
            <br /><br/>
        <asp:Button ID="btnLogQuerry" OnClick="btnLogQuerry_Click" runat="server" Text="查询" Height="30px" Width="113px" />
        </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False" DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="UsedEndMac" HeaderText="已使用的终止地址" SortExpression="UsedEndMac" />
                <asp:BoundField DataField="UsedStartMac" HeaderText="已使用的起始地址" SortExpression="UsedStartMac" />
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
    </form>
</body>
</html>

