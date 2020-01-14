using Login.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Login.HttpUtil;

namespace Login.Web.Test
{
    public partial class GetCusMac : System.Web.UI.Page
    {
        /// <summary>
        /// 插入数据表MESXPT_ModuleMiscInfo（综合测试信息表）,收到测试端请求后解析数据、生成新的CusMac地址，并把新的CusMac地址和请求信息插入到数据库
        /// </summary>

      //  private string url = HttpUtils.GetClientUrl();
        public void InsertMESXPT_ModuleMiscInfo()
        {
            HttpHelp httpHelp = new HttpHelp();
            httpHelp.Listen();
            string message= httpHelp.GetReciveData();
            this.Label1.Text = "客户端数据:"+message;
            this.Label2.Text = "客户端IP:" + httpHelp.GetIp();
            this.Label3.Text = "客户端IP:" + httpHelp.GetConnObj();
            this.Label4.Text = "客户端IP:" + httpHelp.GetExMessage();
            this.Label6.Text = "标志信息:" + httpHelp.GetFlag();
            //string ClientData=DealJsonData.GetJsonStr(message);
            //this.Label1.Text ="转换为Json"+ ClientData;
            // httpHelp.GetInfomation();
            /* //string url = "http://192.168.0.87:8088/Web/TestJson.aspx";
             MESXPT_ModuleMiscInfo mESXPT_ModuleMiscInfo = DealJsonData.AnalysisJsonStr(url);
             string MesId = mESXPT_ModuleMiscInfo.MesId1;
             string EspMac = mESXPT_ModuleMiscInfo.EspMac1;
             string BtMac = mESXPT_ModuleMiscInfo.EspMac1;
             string ModuleVer = mESXPT_ModuleMiscInfo.ModuleVer1;
             string TestResult = mESXPT_ModuleMiscInfo.TestResult1;
             int Status = mESXPT_ModuleMiscInfo.Status1;
             string LabelContent = mESXPT_ModuleMiscInfo.LabelContent1;
             string ModuleType = mESXPT_ModuleMiscInfo.ModuleType1;
             string OperationTime = DateTime.Now.ToString();*/
            string MesId = "MesID";
            string EspMac = "espmac";
            string BtMac = "btMac";
            string ModuleVer = "Ver";
            string TestResult = "成功";
            int Status = 1;
            string LabelContent = "05065656";
            string ModuleType = "WIFI";
            string OperationTime = DateTime.Now.ToString();

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
                //this.Label1.Text = "获取下一个新的NextCusMac地址失败，原因是资源已经使用完毕，请重新输入新的起始地址和终止地址进行分配新的资源！！";
                return;
            }

            if (NextCusMac == "生成新的CusMac地址异常")
            {
               // this.Label1.Text = "获取下一个新的NextCusMac地址失败，原因是分配时出现异常，请联系管理员！！";
                return;
            }
            if (Help.Vidate(NextCusMac))
            {
                //this.Label1.Text = "该新的CusMac地址已经被分配过！！，已经存在，请确认！！";
                NextCusMac = Help.AddOne(NextCusMac, EndMacCur);
                // Help.FindMaxCusMac();

                //return;
            }

            string nowCusMac = Help.FindMaxCusMac(); 
            if(Help.MacAddrCompare(nowCusMac,EndMacCur)==0)
            {
                this.flag.Text = "资源已经分配结束，请请重新输入起始地址和终止地址添加！！！！！！！！！！，将给烧录端返回null";
                Response.Write(null);
                return;
            }
            

            if (Help.InsertInfoTable(NextCusMac, MesId, EspMac, BtMac, ModuleVer, TestResult, Status, LabelContent, ModuleType, OperationTime))
            {
               // this.Label1.Text = "已向信息表插入一条新的数据（包含测试结果，新生成CusMac地址）可用的CusMac地址为:" + NextCusMac;
            }

            string CusMac = Help.GetCurCusMacJson();//转换为Json
            this.flag.Text = "返回给烧录客户端的CusMac地址为"+CusMac;
            Response.Write(CusMac);//
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



        protected void Page_Load(object sender, EventArgs e)
        {
            //string url = "";
            InsertMESXPT_ModuleMiscInfo();
        }
    }
}