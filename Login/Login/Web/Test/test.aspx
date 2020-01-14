<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Login.Web.Test.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TreeView ID="TreeView1" runat="server">
            <Nodes>
                <asp:TreeNode Text="员工信息管理" Value="新建节点">
                    <asp:TreeNode Text="新建节点" Value="新建节点" NavigateUrl="~/Web/Operator/ManageUser.aspx"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Mac地址操作" Value="新建节点">
                    <asp:TreeNode Text="增加Mac地址" Value="增加Mac地址" NavigateUrl="~/Web/Operator/AddForm.aspx"></asp:TreeNode>
                    <asp:TreeNode Text="查询Mac地址" Value="查询Mac地址" NavigateUrl="~/Web/Operator/QuerryForm.aspx"></asp:TreeNode>
                    <asp:TreeNode Text="更改Mac地址" Value="更改Mac地址" NavigateUrl="~/Web/Operator/UpdateForm.aspx"></asp:TreeNode>
                    <asp:TreeNode Text="操作日志显示" Value="操作日志显示" NavigateUrl="~/Web/Operator/LogQuerry.aspx"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="测试记录" Value="新建节点">
                    <asp:TreeNode Text="测试结果" Value="测试结果" NavigateUrl="~/Web/Operator/ShowInfo.aspx"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
                <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>
    </form>
</body>
</html>
