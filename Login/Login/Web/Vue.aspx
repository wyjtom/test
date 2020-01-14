<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vue.aspx.cs" Inherits="Login.Web.Vue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>vue测试</title>
    <script src="../JS/vue.min.js"></script>
    <style>
        .class1{
            background:#444;
            color:red;
        }
    </style>
</head>
    
<body>

    <form id="form1" runat="server">
        <div id="app">
            <p>{{message}}</p>
            
        </div>

        <div id="vue_det">
            <p>{{url}}</p>
            <p>{{details()}}</p>
        </div>

        <div id="inputHtml">
            <div v-html="message"></div>
        </div>
        <script>
            var vm= new Vue({
            el: '#app',
            data: {
                message:'Hello Vue.js2!'
            }
            })
            
    </script>
        <script>
            var datavalue = {site:"百度",url:"www.baidu.com",alexa:10000}
            var vm = new Vue({
                el: '#vue_det',
                data: datavalue,
                //data: {
                //    site: "百度",
                //    url: "www.baidu.com",
                //    alexa:"10000"
                //},
                methods: {
                    details: function () {
                        return this.site + "-学的不仅仅是技术。更是梦想" + this.url + this.alexa
                    }
                }

            })
            document.write(vm.site == datavalue.site)
            vm.site = "搜狗"
            document.write(datavalue.site)
            datavalue.alexa = 90000
            document.write(vm.alexa)

           // document.writeln(vm.data == datavalue)
           // document.writeln(vm.$el == document.getElementById('vue_det'))
        </script>

        <script>
            //输出html标签
            new Vue({
                el: '#inputHtml',
                data: {
                    message:'<h1>你好，输出html便签和文本</h1>'
                }
            })
        </script>

        
        <div id="htmlProperty">
            <label for="r1">修改颜色</label>
            <input type="checkbox" v-model="use" id="r1"/><br /><br />
            <div v-bind:class="{'class1':use}">
            v-bind:class指令
        </div>
        </div>
       <script>
           //html属性值
           document.write("<h3>html属性值</h3>")
            new Vue({
                el: '#htmlProperty',
                data: {
                    use: false
                }
            })
        </script>

         <div id="biaodashi">
             {{9+9+1}}
             {{9+9}}
            {{5+5+5}}<br>
	{{ ok ? 'YES' : 'NO' }}<br>
	{{ message.split('').reverse().join('') }}
            <div v-bind:id="'list-' + id">百度</div>
        </div>
        <script>
            //表达式
            document.write("<h3>表达式：</h3>");
            new Vue({
                el: '#biaodashi',
                data: {
                    ok: true,
                    message: 'baidu',
                    id:1
                }
            })
        </script>
       
        <div id="vif">
            <p v-if="seen">现在你看到我了</p>
            <p v-else>你看不到我</p>
            <template v-if="ok">
              <h1>菜鸟教程</h1>
             <p>学的不仅是技术，更是梦想！</p>
            <p>哈哈哈，打字辛苦啊！！！</p>

            </template>
        </div>
        <script>
            //v-if指令
            document.write("<h3>vif指令</h3>");
            new Vue({
                el:'#vif',
                data: {
                    seen: true,
                    ok: true
                }
            })
        </script>

        <div id="parameter">
            <pre><a v-bind:href="url">百度</a></pre>
        </div>
        <script>
            //参数
            document.write("<h3>参数</h3>")
            new Vue({
                    el: '#parameter',
                    data: {
                        url: 'http://www.baidu.com'
                    }
                })
        </script>

        <div id="vmodel">
            <p>{{message}}</p>
            <input  v-model="message"/>
        </div>
        <script>
            //v-model实现数据双向绑定
            document.write("<h3>v-model实现数据双向绑定</h3>")
            new Vue({
                el: '#vmodel',
                data: {
                    message:'vmodel实现数据双向绑定'

                }
            })
        </script>

        <div id="von">
            <p>{{message}}</p>
            <button v-on:click="reverMessage">字符反转</button>
        </div>
        <script>
            document.write("<h3>v-on监听器</h3>")
            new Vue({
                el: '#von',
                data: {
                    message:'baidu!'
                },
                methods: {
                    reverMessage: function () {
                        this.message = this.message.split('').reverse().join('')
                        alert("你好");
                    }
                }
            })
        </script>


        <div id="filter">
            {{message|capitalize}}
        </div>
        <script>
            //过滤器
            document.write("<h3>过滤器（可串行）</h3>")
            new Vue({
                el: '#filter',
                data:{
                    message:'baidu'
                },
                filters: {
                    capitalize: function (value) {
                        if (!value) return ''
                        value = value.toString()
                        return value.charAt(0).toUpperCase() + value.slice(1)
                    }
                }
            })
        </script>

        
        <div id="vfor1">
            <ol>
               <li v-for="site in sites">
             {{ site.name }}
    </li>
            </ol>
        </div>
        <script>
            document.write("<h3>vfor访问对象数组</h3>")
            new Vue({
                el: '#vfor1',
                data: {
                    sites: [
                        { name: '百度' },
                        { name: '搜狗' },
                        { name: '淘宝' } 
                    ]
                }
            })
            
        </script>
        <div id="vfor2">
            <ul>
                <li v-for="(value,key,index) in object">
                    {{index}}.{{key}}:{{value}}
                </li>
            </ul>
        </div>
        <script>
            document.write("<h3>vfor访问对象属性</h3>")
            new Vue({
                el: '#vfor2',
                data: {
                    object: {
                        name: '百度',
                        url: 'http://www.baidu.com',
                        slogan:'百度一下'
                    }
                }
            })
        </script>

        <div id="vfor3">
            <ul>
                <li v-for="n in 10">
                    {{n}}
                </li>
            </ul>
        </div>
        <script>
            document.write("<h3>vfor迭代数字</h3>")
            new Vue({
                el: '#vfor3'
            })
        </script>

        <div id="computed">
            <p>原始字符串：{{message}}</p>
            <p>计算后反转字符串{{reverseMessage}}</p>
        </div>

        <script>
            document.write("<h3>computed使用方法</h3>")
            var vm = new Vue({
                el: '#computed',
                data: {
                    message:'baidu'
                },
                computed: {
                    //计算属性的getter
                    reverseMessage: function () {
                        return this.message.split('').reverse().join('')
                    }

                }
            })
        </script>
        <div id="watch">
            <p>计数器：{{counter}}</p>
            <button @click="counter++">点击</button>
        </div>
        <script>
            document.write("<h3>监听属性watch响应数据的变化</h3>")
            var vm=new Vue({
                el: '#watch',
                data: {
                    counter:1
                }
            })
            vm.$watch('counter', function (nval, oval){
                alert('计数器数字的变化：' + oval + '变为' + nval);
            })
        </script>
        <div id="watch2">
            千米：<input type="text" v-model="kilomters"/>
            米：<input type="text" v-model="meters"/>
        </div>
        <p id="info"></p>
        <script>
            document.write("<h3>watch升级学习</h3>")
            var vm = new Vue({
                el: '#watch2',
                data: {
                    kilomters: 0,
                    meters: 0
                },
                methods: {

                },
                computed:{

                },
                watch: {
                    kilomters: function (val) {
                        this.kilomters = val;
                        this.meters = this.kilomters*1000
                    },

                    meters: function (val) {
                        this.kilomters = val / 1000
                        this.meters = val
                    }
                    
                }
            })


            vm.$watch('kilometers', function (newValue, oldValue) {
                document.getElementById("info").innerHTML="修改前值为: " + oldValue + "，修改后值为: " + newValue;
            })



        </script>


        <hr />
        <h1>v-bind样式绑定</h1>
        <div id="vbind">
            <div v-bind:class="{active:isActive,'text-error':flag}"></div>
        </div>
        <style>
            .active{
                width:100px;
                height:100px;
                background:green;
            }
            .text-error{
                background:yellow;
            }
        </style>
        <script>
            new Vue({
                el: '#vbind',
                data: {
                    isActive: true,
                    flag: true
                }
            })
        </script>









    </form>

</body>
</html>
