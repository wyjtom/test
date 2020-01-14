using Login.Common;
using Login.HttpUtil;
using Login.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Login.Service
{
    /// <summary>
    /// WebService1 的摘要说明http://tempuri.org/
    /// </summary>
    [WebService(Namespace = "http://192.168.0.87:5200/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        Object locker = new object();

        private bool flag = false;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private Error error = new Error();

        /// <summary>
        ///正则表达式判定输入数据是否符合输入规则
        /// </summary>
        /// <param name="str_MacAddr"></param>
        /// <returns></returns>
        public bool IsMacAddr(string str_MacAddr)
        {

            //bool IsMacAddrFag = false;
            //string s = @"^([0-9a-fA-F]{2})(([/\s-][0-9a-fA-F]{2}){5})$";
            //Regex r = new Regex(s);
            //MatchCollection oCollection = r.Matches(str_MacAddr.Trim());
            //if (oCollection.Count > 0)
            //{
            //    //MessageBox.Show("MAC地址格式正确！");
            //    IsMacAddrFag = true;
            //}
            //else
            //{
            //    //MessageBox.Show("MAC地址格式不正确！");
            //    IsMacAddrFag = false;
            //}

            return true;

        }



        [WebMethod]
        public string UploadTestResult(string CusMac,string TestResult,string LabelContent)
        {
            Context.Response.ContentType = "text/json;charset=utf-8";
            string Json = "";
            if(IsMacAddr(CusMac))
            {
                if (CusMac == "" || CusMac == null || TestResult == "" || TestResult == null || LabelContent == "" || LabelContent == null)
                {
                    error.c = 1;
                    error.d.CusMac = "";
                    // error.m ="报错请求参数为空";
                    error.m = "Error reporting request parameter is empty";//报错请求参数为空
                    Json = JsonConvert.SerializeObject(error);
                    try
                    {
                        Context.Response.Write(Json);//**********
                        Context.Response.End();
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                    }
                }
                else
                {
                    string sql = "update MESXPT_ModuleMiscInfo set TestResult='" + TestResult + "',LabelContent='" + LabelContent + "' where CusMac='" + CusMac + "'";
                    if(DbHelper.ExecuteCommand(sql)>0)
                    {
                        error.c = 0;
                        error.d.CusMac = CusMac;
                        //error.m = "上传数据成功！！,上传的CusMac为"+CusMac+"TestResult为"+TestResult+"LabelContent为"+LabelContent;
                        error.m = "Upload data succeeded！！,Upload CusMac is:" + CusMac+"TestResult is:"+TestResult+"LabelContent is:"+LabelContent;
                        Json = JsonConvert.SerializeObject(error);
                        try
                        {
                            Context.Response.Write(Json);//**********
                            Context.Response.End();
                        }
                        catch (Exception ex)
                        {
                        }
                        finally
                        {
                        }
                    }
                }

            }
            else
            {
                error.c = 5;
                error.d.CusMac = "";
                //error.m = "CusMac地址格式不正确";
                error.m = "CusMac address format is incorrect";
                Json = JsonConvert.SerializeObject(error);
                try
                {
                    Context.Response.Write(Json);//**********
                    Context.Response.End();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                }
            }
            return Json;
        }

        private string GetCurrentTime()
        {
            return DateTime.Now.ToString();
        }

        /// <summary>
        /// 通过EspMac获取CusMac
        /// </summary>
        /// <param name="EspMac"></param>
        /// <returns></returns>

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetCusMacByEspMac(string EspMac)
        {
            string CusMac="";
            Context.Response.Clear();
            Context.Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
            // Context.Response.ContentType = "application/json;charset=utf-8";
            if(EspMac!=""&&EspMac!=null)
            {
                Context.Response.ContentType = "text/json;charset=utf-8";
                string str = string.Format("select CusMac from MESXPT_ModuleMiscInfo where EspMac='{0}'", EspMac);
                DataSet ds = DbHelper.ExecuteGetDateSet(str);
                if (ds.Tables.Count > 0)
                {
                    CusMac = ds.Tables[0].Rows[0]["CusMac"].ToString();
                }
                error.d.CusMac = CusMac;
                error.c = 0;
                //error.m = "通过EspMac查询所得的CusMac地址";
                error.m = "Cusmac address obtained by querying with espmac is:";

                
            }
            else
            {
                Context.Response.ContentType = "text/json;charset=utf-8";
                error.d.CusMac = "";
                error.c = 1;
                //error.m = "查询CusMac需要请求参数EspMac";
                error.m = "Query cusmac requires request parameter espmac";
            }

            string Json = JsonConvert.SerializeObject(error);
            try
            {
                Context.Response.Write(Json);//**********
                Context.Response.End();
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return Json;
            
        }

        public int Status()
        {
            return 1;
        }



        /// <summary>
        /// 上传测试并生成CusMac
        /// </summary>
        /// <param name="MesId"></param>
        /// <param name="EspMac"></param>
        /// <param name="BtMac"></param>
        /// <param name="ModuleVer"></param>
        /// <param name="ModuleType"></param>
        /// <returns></returns>

       [WebMethod]
       [ScriptMethod(UseHttpGet =true , ResponseFormat = ResponseFormat.Json)]
        public string GetCusMac(string MesId,string EspMac,string BtMac,string ModuleVer,string ModuleType)
        {
            
            string TestResult = "";
            string LabelContent = "";
            Context.Response.Clear();
            Context.Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
           // Context.Response.ContentType = "application/json;charset=utf-8";
            Context.Response.ContentType = "text/json;charset=utf-8";
            string CusMac = "";
            string Json = "";
            if(MesId==""||MesId==null || EspMac == "" || EspMac == null || BtMac == "" || BtMac == null|| ModuleVer == "" || ModuleVer == null ||   ModuleType == "" || ModuleType == null)
            {
                error.c = 1;
                error.d.CusMac = "";
               // error.m = "报错请求参数为空";
                error.m = "Error reporting request parameter is empty";
                Json = JsonConvert.SerializeObject(error);
                try
                {
                    Context.Response.Write(Json);//**********
                    Context.Response.End();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                }
                //return;
            }
            else
            {
                //lock(locker)
                //{
                //    InsertTestInfoAndReturnData(MesId, EspMac, BtMac, ModuleVer, TestResult, Status(), LabelContent, ModuleType);
                //}
                string str = string.Format("select CusMac from MESXPT_ModuleMiscInfo where EspMac='{0}'", EspMac);
                DataTable databale = DbHelper.ExecuteSqlGetDataTable(str);
                if (databale.Rows.Count <= 0)
                {
                    InsertTestInfoAndReturnData(MesId, EspMac, BtMac, ModuleVer, TestResult, Status(), LabelContent, ModuleType);
                    if (flag)
                    {
                        CusMac = "";
                    }
                    else
                    {
                        DataSet ds = DbHelper.ExecuteGetDateSet("select top(1) CusMac as CusMac from MESXPT_ModuleMiscInfo order by OperationTime desc");
                        CusMac = ds.Tables[0].Rows[0]["CusMac"].ToString();
                        error.d.CusMac = CusMac;
                    }
                    
                }
                else
                {
                    error.c = 0;
                    //error.m = "CusMac地址分配成功！！";
                    error.m = "Cusmac address assignment succeeded！！";
                    error.d.CusMac = databale.Rows[0]["CusMac"].ToString();
                }

                Json = JsonConvert.SerializeObject(error);
                try
                {
                    Context.Response.Write(Json);//**********
                    Context.Response.End();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                }


            }
            
            
            return Json;
            
        }



        
       
        public void InsertTestInfoAndReturnData(string MesId, string EspMac, string BtMac, string ModuleVer, string TestResult, int Status, string LabelContent, string ModuleType)
        {
            
          /*  string url=HttpContext.Current.Request.Url.ToString();//完整url   url= http://www.test.com/aaa/bbb.aspx?id=5&name=kelli
            string rawurl = HttpContext.Current.Request.RawUrl;//站点名+页名+参数 url= /aaa/bbb.aspx?id=5&name=kelli
            string rawurl2 = HttpContext.Current.Request.Url.AbsolutePath;//站点名+页名  url=aaa/bbb.aspx
            string urlHost = HttpContext.Current.Request.Url.Host;//域名   url=www.test.com
            string urlParam = HttpContext.Current.Request.Url.Query;//参数   url=?id=5&name=kelli



            //HttpContext.Current.Request.ServerVariables.getParameter();
            string strt = HttpContext.Current.Request.ServerVariables.AsParallel().ToString();
            HttpContext.Current.Request.ServerVariables.Get("User_Agent"); 
            string Clientstr = HttpContext.Current.Request.ServerVariables.Get("Http_Referer");
            string ClientPath = HttpContext.Current.Request.ServerVariables.Get("Path_Info").ToString();
            string ClientIp= HttpContext.Current.Request.ServerVariables.Get("Remote_Addr").ToString();
            string ClentHost=HttpContext.Current.Request.ServerVariables.Get("Remote_Host").ToString();
           string ClientBrowser= HttpContext.Current.Request.Browser.Browser.ToString();

            //string str= HttpContext.Current.Request.UserAgent.ToString();
            string str = HttpContext.Current.Request.ServerVariables.ToString();
           string str2= HttpContext.Current.User.Identity.Name.ToString();
           string str3= HttpContext.Current.Trace.ToString();
           string str4= HttpContext.Current.Timestamp.ToString();
          // string str5=HttpContext.Current.Session.ToString();
           string str6= HttpContext.Current.ApplicationInstance.Context.Request.RequestContext.HttpContext.Request.RequestContext.RouteData.Values.Count.ToString();
            //HttpSessionStateBase sessionStateBase= HttpSessionStateBase.ReferenceEquals.Session;
            string ip=HttpContext.Current.Request.UserHostAddress;//获取ip地址
            try
            {
                Stream s = HttpContext.Current.Request.InputStream;//获取json字符流
                //还原数据流
                byte[] b = new byte[s.Length];
                s.Read(b,0,(int)s.Length);
                string jsontext = Encoding.UTF8.GetString(b);
            }
            catch
            {

            }
            */


            //HttpContext.Current.Request.
            // HttpHelp httpHelp = new HttpHelp();
            // httpHelp.Listen();
            //string message = httpHelp.GetReciveData();
            // this.label1.Text = "客户端数据:" + message;
            // this.label2.Text = "客户端IP:" + httpHelp.GetIp();
            //this.label3.Text = "客户端IP:" + httpHelp.GetConnObj();
            //this.label4.Text = "客户端IP:" + httpHelp.GetExMessage();
            //this.label6.Text = "标志信息:" + httpHelp.GetFlag();
            // this.label6.Text = "标志信息:";



            //string ClientData=DealJsonData.GetJsonStr(message);
            //this.Label1.Text ="转换为Json"+ ClientData;
            // httpHelp.GetInfomation();
            /* //string url = "http://192.168.0.87:8088/Web/TestJson.aspx";*/
          //  MESXPT_ModuleMiscInfo mESXPT_ModuleMiscInfo = DealJsonData.AnalysisJsonStr(url);
           /* string MesId = HttpContext.Current.Request.Form["MesId"];
            string EspMac = HttpContext.Current.Request.Form["EspMac"];
            string BtMac = HttpContext.Current.Request.Form["BtMac"];
            string ModuleVer = HttpContext.Current.Request.Form["ModuleVer"];
            string TestResult = HttpContext.Current.Request.Form["TestResult"];
            int Status = 1;
            string LabelContent = HttpContext.Current.Request.Form["LabelContent"];
            string ModuleType = HttpContext.Current.Request.Form["ModuleType"];*/
            string OperationTime = DateTime.Now.ToString();


            /*string MesId = "MesID";
            string EspMac = "espmac";
            string BtMac = "btMac";
            string ModuleVer = "Ver";
            string TestResult = "成功";
            int Status = 1;
            string LabelContent = "05065656";
            string ModuleType = "WIFI";
            string OperationTime = DateTime.Now.ToString();*/

            //按时间排序获取最近的起始地址和终止地址
            string StartMacEndMac = Help.GetCurrentStartMacAndEndMac();
            string StartMacCur = StartMacEndMac.Split(',')[0];
            string EndMacCur = StartMacEndMac.Split(',')[1];
            //GetCusMac(StartMacCur);
            // 每次请求从最近的的起始地址开始加“1”分配，当累计到大于终止地址时表示mac资源分配结束
            //同时把数据插入数据库
            string NextCusMac = Help.AddOne(StartMacCur, EndMacCur);//新的CusMac地址
            if (NextCusMac == "" || NextCusMac == null || NextCusMac == "资源已经使用完毕")
            {
                error.c = 3;
               // error.m = "资源已经使用完毕";
                error.m = "The resource has been used";
                flag = true;
                //this.Label1.Text = "获取下一个新的NextCusMac地址失败，原因是资源已经使用完毕，请重新输入新的起始地址和终止地址进行分配新的资源！！";
                return;
            }

            if (NextCusMac == "生成新的CusMac地址异常")
            {
                flag = true;
                error.c = 2;
                //  error.m = "生成新的CusMac地址时产生异常请联系服务端！！";
                error.m = "When generating a new cusmac address, please contact the administrator!!";
                // this.Label1.Text = "获取下一个新的NextCusMac地址失败，原因是分配时出现异常，请联系管理员！！";
                return;
            }
            if (Help.Vidate(NextCusMac))
            {
              
                NextCusMac = Help.AddOne(NextCusMac, EndMacCur);
                // Help.FindMaxCusMac();

                //return;
            }

            string nowCusMac = Help.FindMaxCusMac();

           
            if (Help.IsNewStartMacAndEndMac)
            {
                string StartMacAndEndMac= Help.GetCurrentStartMacAndEndMac();
                nowCusMac = StartMacAndEndMac.Split(',')[0];
                EndMacCur= StartMacAndEndMac.Split(',')[1];
                Help.IsNewStartMacAndEndMac = false;
            }
            int compare= Help.MacAddrCompare(nowCusMac, EndMacCur);
            if (compare > 0||compare==0)
            {
                error.c = 1;
               // error.m = "资源使用完毕，请重联系服务端！！";
                error.m = "Cusmac address assignment failed, please contact the administrator !! ";
                flag = true;
                //.flag.Text = "资源已经分配结束，请请重新输入起始地址和终止地址添加！！！！！！！！！！，将给烧录端返回null";
                //Response.Write(null);
                return;
            }

            string[] newNexCusMac = NextCusMac.Split(':');
            NextCusMac = newNexCusMac[0] + newNexCusMac[1] + newNexCusMac[2] + newNexCusMac[3] + newNexCusMac[4] + newNexCusMac[5];

            if (Help.InsertInfoTable(NextCusMac, MesId, EspMac, BtMac, ModuleVer, TestResult, Status, LabelContent, ModuleType, OperationTime))
            {
                error.c = 0;
                // error.m = "正常，分配新的CusMac地址成功！！";
                error.m = "Normal, assign new cusmac address successfully!! ";
                // this.Label1.Text = "已向信息表插入一条新的数据（包含测试结果，新生成CusMac地址）可用的CusMac地址为:" + NextCusMac;
            }
            

            // HttpUtils.Post(url, CusMac, "");//发送Json字符串
            /* if (StartMac != "" && EndMac != "")
             {
                 if (MacAddrCompare(StartMac, EndMac) > 0)//起始地址大于终止地址不符合要求
                 {
                     this.labflag.Text = "起始地址大于终止地址,向信息插入数据出错";
                     return;
                 } 
                 else if(MacAddrCompare(StartMac, EndMac)==0)//起始地址等于终止地址时向信息表添加一条数据
                 {
                     if(Help.InsertInfoTable(GetCusCode(), MesId, EspMac, BtMac, ModuleVer, TestResult, Status, LabelContent, ModuleType, OperationTime))
                     {
                         this.labflag.Text = "起始地址等于终止地址，向信息表插入一条数据";
                     }

                 }
                 else if(MacAddrCompare(StartMac, EndMac)<0)
                 {
                     while(StartMac!=EndMac)
                     {
                         string CusMac = GetCusCode();

                         if (Help.InsertInfoTable(GetCusCode(), MesId, EspMac, BtMac, ModuleVer, TestResult, Status, LabelContent, ModuleType, OperationTime))
                         {
                             this.labflag.Text = "起始地址小于终止地址，信息表添加多条数据"; ;
                         }
                         if (MacAddrCompare(CusMac, EndMac) == 0) break;//临界条件表示


                     }

                 }


             }*/


        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "label7";

        }
    }
}
