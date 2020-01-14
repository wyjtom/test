<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Querry.aspx.cs" Inherits="Login.Web.Unuser.Querry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mac地址查询</title>
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
       
    <script ></script>
</head>
<body>
    <ul class="nav">
	  <li><a href="Querry.aspx">Mac查询</a></li>
      <li><a href="Log.aspx">操作日志查询</a></li>
    </ul>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
    <a href="LogQuerry.aspx">查看操作日志</a>
</body>
</html>
