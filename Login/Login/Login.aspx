<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login.Login" %>

<!DOCTYPE html><!--浏览器兼容问题-->
<html>
  <head>
	<meta charset="utf-8"> 
    <title>登录实例</title>
    <!-- 包含头部信息用于适应不同设备 -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- 包含 bootstrap 样式表 -->
    <link rel="stylesheet" href="CSS/bootstrap.min.css">
  </head>

  <body>
      <p id="demo"></p>
      <script>
          //function Person(first, last, age) {
          //    this.firstName = first;
          //    this.lastName = last;
          //    this.age == age;
          //}

          //var my = new Person("san", "zhang", "9");
          //document.getElementById("demo").innerHTML = my.lastName + my.firstName + my.age;
         
      </script>
      <script>
          //var number = 128;
          //document.write(number+"<br>");
          //document.write(number.toString(16)+"<br>");
          //document.write(number.toString(8)+"<br>");
          //document.write(number.toString(2) + "<br>");
          //var str = "f,j,s,af,sa,g,ag,s,ag,o,od";
          //var test= str.indexOf("good");
          //document.writeln(test);
          //var test1 = str.split(",");
          //document.writeln(test1[2]);
      </script>
        <form id="form1" runat="server" style="margin-left:500px;margin-top:200px;width:312px ; background-color:beige; height: 204px;">
        <!--   <label>用户名:</label>
          <input type="text" id="stuname"/><br />
          <label>密 &nbsp;&nbsp;码:</label> 
          <input type="password" id="stupassword"/>
          <asp:Button ID="Button1" runat="server" Text="Button" />-->
     <!-- <div class="container"><!--确保居中和最大宽度--->
         <!-- <div class="col-md-3 col-push-9">
              <label>用户名:</label>
              <input type="text" id="stuname"/><br />
              <label>密 &nbsp;&nbsp;码:</label> 
              <input type="password" id="stupassword"/>
          </div>
          <div class="col-md-9 col-pull-3">
              <code> &lt;内联元素hha &gt;</code>

              <pre>
                  &lt;article &gt;
                  &lt;h1 &gt;
                  你好
                  &lt;/h1&gt;
                  &lt;/article&gt;
              </pre>

          </div>
          <div class="container">
              <p>使用var元素表示变量</p>
              <p>
                  <var>x</var>=<var>a</var>+<var>b</var>
              </p>
  
          </div>

          <div>
              <table class="table-bordered table table-hover">
                  <caption>边框表格布局</caption>
                  <thead>
                   <tr>
                      <th>#</th>
                      <th>姓名</th>
                  </tr>
                  </thead>
                      

                  <tbody>
                  <tr>
                      <td>001</td>
                      <td>张三</td>
                  </tr>
                  <tr>
                      <td onclick="Btn">002</td>
                      <td>Tom</td>
                  </tr>
                  </tbody>
                  
              </table>
          </div>

          <div>
              <form role="form">
                  <div class="form-group">
                      <label for="name">名称</label>
                      <input type="text" class="form-control" id="name" placeholder="请输入名称" />
                  </div>
                  <div class="form-group">
                      <span class="glyphicon glyphicon-envelope"></span>
                      <label for="inputfile">邮箱</label>
                      <input type="file" id="inputfile"/>
                  </div>
                  <div class="checkbox">
                      <label>
                          <input type="checkbox"/>请打勾
                      </label>
                  </div>

                  <div class="radio">
                      <label>
                          <input type="radio" value="option1" checked/>
                      </label>
                       <label>
                          <input type="radio" value="option2"/>
                      </label>
                  </div>

                  <select id="Select1" name="D1">
                  <option>1</option>
                  <option>1</option>
                  <option>1</option>
                  <option>1</option>
                 </select>
                  <button type="submit" class="btn btn-default">提交</button>
              </form>
          </div>
          
         
      </div>


      <label id="lable1"></label>

   <div class="container">
      <h2>表格</h2>
      <p>创建响应式表格 (将在小于768px的小型设备下水平滚动)。另外：添加交替单元格的背景色：</p>      
      <div class="table-responsive">          
       <table class="table table-striped table-bordered">
         <thead>
           <tr>
             <th>#</th>
             <th>Name</th>
             <th>Street</th>
           </tr>
         </thead>
         <tbody>
           <tr>
             <td>1</td>
             <td>Anna Awesome</td>
             <td>Broome Street</td>
           </tr>
           <tr>
             <td>2</td>
             <td>Debbie Dallas</td>
             <td>Houston Street</td>
           </tr>
           <tr>
             <td>3</td>
             <td>John Doe</td>
             <td>Madison Street</td>
           </tr>
         </tbody>
       </table>
      </div>

      <h2>图像</h2>
      <p>创建响应式图片(将扩展到父元素)。 另外：图片以椭圆型展示：</p>            
      <img src="cinqueterre.jpg" class="img-responsive img-circle" alt="Cinque Terre" width="304" height="236"> 
      
      <h2>图标</h2>
      <p>插入图标:</p>      
      <p>云图标: <span class="glyphicon glyphicon-cloud"></span></p>      
      <p>信件图标: <span class="glyphicon glyphicon-envelope"></span></p>            
      <p>搜索图标: <span class="glyphicon glyphicon-search"></span></p>
      <p>打印图标: <span class="glyphicon glyphicon-print"></span></p>      
      <p>下载图标：<span class="glyphicon glyphicon-download"></span></p>     
    </div>  -->

    <!-- JavaScript 放置在文档最后面可以使页面加载速度更快 -->
    <!-- 可选: 包含 jQuery 库 -->
    <script src="JS/jquery-3.3.1.min.js"></script>
    <!-- 可选: 合并了 Bootstrap JavaScript 插件 -->
    <script src="JS/bootstrap.min.js"></script>
             <asp:Panel ID="Panel1" runat="server" Height="200px">
             <div class="form-group">
              <asp:Label ID="Label1"  runat="server" Text="用户名"></asp:Label>
              <asp:TextBox ID="TextBox1"  runat="server"></asp:TextBox>
              <br /><br />
             </div>
              
             <div class="form-group">
               <asp:Label ID="Label2" runat="server" Text="密&nbsp;&nbsp;&nbsp;码 "></asp:Label>
              <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
              <br />
             </div>
             
             &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="登录" Width="112px" />
              <asp:Label ID="Label3" runat="server" BackColor="Red" ForeColor="Yellow"></asp:Label><br /><br /><br />
             
                 <br />
               <!--<a href="Web/Register.aspx"><span style="color:red;">请先单击注册账号</span></a>-->
          </asp:Panel>
           
      </form>
      
  </body>

</html>
