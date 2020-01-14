<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestBoostrap.aspx.cs" Inherits="Login.Web.Test.TestBoostrap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <!--移动设备，device-width 可以确保它能正确呈现在不同设备上，initial-scale=1.0 确保网页加载时，以 1:1 的比例呈现，不会有任何的缩放-->
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="../../CSS/bootstrap.min.css"/> 
    <link rel="stylesheet" href="../../CSS/Mai.css" />
    <script src="../../JS/jquery-3.3.1.min.js"></script>
    <script src="../../JS/bootstrap.min.js"></script>
</head>
<body>
    <div>
  <div class="jumbotron">
    <h1>我的第一个 Bootstrap 页面</h1>
    <p>重置窗口大小，查看响应式效果！</p> 
  </div>
  <div class="row">
    <div class="col-sm-4">
      <h3>第一列</h3>
      <p>学的不仅是技术，更是梦想！</p>
      <p>再牛逼的梦想,也抵不住你傻逼似的坚持！</p>
    </div>
    <div class="col-sm-4">
      <h3>第二列</h3>
      <p>学的不仅是技术，更是梦想！</p>
      <p>再牛逼的梦想,也抵不住你傻逼似的坚持！</p>
    </div>
    <div class="col-sm-4">
      <h3>第三列</h3>        
      <p>学的不仅是技术，更是梦想！</p>
      <p>再牛逼的梦想,也抵不住你傻逼似的坚持！</p>
    </div>
  </div>
</div>

   <div>
       <form role="form" id="form1" runat="server">
        <div>

        </div>
    </form>
   </div>
    
</body>
</html>
