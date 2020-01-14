<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showdata.aspx.cs" Inherits="Login.Web.showdata" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>信息表</title>
</head>
<body>
    <h3>分页显示图书信息</h3>
    <form id="form1" runat="server" style="margin-left:500px;margin-top:20px;width:1000px;" >
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Height="25px" Width="553px"></asp:TextBox>
        </p>
        <div>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
            <asp:GridView AllowPaging="True" PageSize="5"  OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="bookid" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" style="margin-bottom: 0px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="bookid" HeaderText="图书编号" ReadOnly="True" SortExpression="bookid" />
                    <asp:BoundField DataField="bookname" HeaderText="图书名称" SortExpression="bookname" />
                    <asp:BoundField DataField="bookaddress" HeaderText="图书出版地" SortExpression="bookaddress" />
                    <asp:CommandField EditText="修改" HeaderText="图书操作" NewText="新增" ShowDeleteButton="True" ShowSelectButton="True" InsertText="" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Test_wyjConnectionString %>" SelectCommand="SELECT * FROM [book]"></asp:SqlDataSource>
        <br /><br />
        <asp:Label ID="Label1" runat="server" BackColor="#990000" Font-Bold="True" ForeColor="White" Text="图书编号"></asp:Label>
        <asp:TextBox ID="txtBookId" runat="server" Height="19px"></asp:TextBox>
        <asp:Label ID="Label4" runat="server"></asp:Label>
        <br /><br />
        <asp:Label ID="Label2" runat="server" BackColor="#990000" Font-Bold="True" ForeColor="White" Text="图书名称"></asp:Label>
        <asp:TextBox ID="txtBookName" runat="server"></asp:TextBox>
        <br />
        
        <br />
        <asp:Label ID="Label3" runat="server" BackColor="#990000" Font-Bold="True" ForeColor="White" Text="图书出处"></asp:Label>
        <asp:TextBox ID="txtBookAddress" runat="server"  ></asp:TextBox><br /><br />
        <asp:Button ID="Button1" runat="server" BackColor="#999999" Width="100px" Height="30px" Font-Size="Large"  ForeColor="#ff3399" Text="新增" OnClick="Button1_Click" />
    </form>
</body>
</html>
