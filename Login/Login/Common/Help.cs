using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Globalization;
using System.Data;
using Newtonsoft.Json;
using Login.model;
using static Login.model.Error;

namespace Login.Common
{
    public class Help
    {
        public static string UserLoginName="";

        /// <summary>
        /// 是否重新加入起始地址和终止地址
        /// </summary>
        public static bool IsNewStartMacAndEndMac = false;
        /// <summary>
        /// Mac地址加一
        /// </summary>
        /// <param name="CusMacCurr">当前信息表中最大Cusmac地址</param>
        /// <returns>返回新的Mac地址</returns>
        public static string AddOne(string CusMacCurr,string EndMacCur)
        {
            //获取最近加入的起始地址和终止地址
            /* string startmacAndendMac=Help.GetCurrentStartMacAndEndMac();
             string StartMacCur = startmacAndendMac.Split(',')[0].ToString();
             string EndMacCur = startmacAndendMac.Split(',')[1].ToString();
             List<string> listMac = new List<string>();

             if(MacAddrCompare(StartMacCur, EndMacCur)<=0)
             {
                 //去掉原Mac地址中多余字符
                 string[] strSplit = MaxCusMacCurrent.Split(new char[] { '\t', '\r', '\n', ':' }, StringSplitOptions.None);
                 //合并字符串
                 string strCon = strSplit.Aggregate<string>((str1, str2) => str1 + str2);
                 //转换为整形进行加一
                 BigInteger data = BigInteger.Parse(strCon, NumberStyles.HexNumber);
                 data = data + 1;
                 string datastr = data.ToString("X2");//转换为字符串
                 string nextMac = strCon.Substring(0, 2) + ":" + strCon.Substring(2, 2) + ":" + strCon.Substring(4, 2) + ":" + strCon.Substring(6, 2) + ":" + strCon.Substring(8, 2) + ":" + datastr.Substring(1, 2);
                 listMac.Add(nextMac);
             }*/

            string nextMac = "";
            if(Help.MacAddrCompare(CusMacCurr,EndMacCur)<0)
            {
               //  FindMaxCusMac();
               if(Vidate(CusMacCurr))
                {
                    CusMacCurr= FindMaxCusMac();

                    //第二次这时
                }
                try
                {
                    //去掉原Mac地址中多余字符
                    string[] strSplit = CusMacCurr.Split(new char[] { '\t', '\r', '\n', ':' }, StringSplitOptions.None);
                    //合并字符串
                    string strCon = strSplit.Aggregate<string>((str1, str2) => str1 + str2);
                    //转换为整形进行加一
                    BigInteger data = BigInteger.Parse(strCon, NumberStyles.HexNumber);
                    //long data = Convert.ToInt64(strCon);
                    data = data + 1;
                    //string datastr= string.Format("%12d", data);
                    string datastr = data.ToString("X2").PadLeft(12,'0');//转换为字符串
                    nextMac = datastr.Substring(0, 2) + ":" + datastr.Substring(2, 2) + ":" + datastr.Substring(4, 2) + ":" + datastr.Substring(6, 2) + ":" + datastr.Substring(8, 2) + ":" + datastr.Substring(10, 2);
                }
                catch
                {
                    nextMac = "生成新的CusMac地址异常";
                }
                finally
                {
                    
                }
               
            }
            else if(Help.MacAddrCompare(CusMacCurr, EndMacCur)==0)
            {
                nextMac = CusMacCurr;
            }
            else
            {
                nextMac = "资源已经使用完毕";
            }
            return nextMac;
        }

        /// <summary>
        /// 取出最近生成的Cusmac
        /// </summary>
        public static string FindMaxCusMac()
        {
            DataTable table = null;
            string CusMac = "";
            string sqlMaxCosMac = "select CusMac as CusMac from MESXPT_ModuleMiscInfo order by OperationTime desc ";
            table= DbHelper.ExecuteGetDateSet(sqlMaxCosMac).Tables[0];
            if (table.Rows.Count>0)
            {
               CusMac = table.Rows[0]["CusMac"].ToString();
            }
            
            return CusMac;


        }


      public static string GetCurCusMacJson()
        {
            InfoCusMac info = new InfoCusMac();
            DataSet ds = DbHelper.ExecuteGetDateSet("select top(1) CusMac as CusMac from MESXPT_ModuleMiscInfo order by OperationTime desc");
            string CusMac = ds.Tables[0].Rows[0]["CusMac"].ToString();
           // info.CusMac1 = CusMac;
            string Json = JsonConvert.SerializeObject(info);
            return Json;//n
        }

        /// <summary>
        /// 验证新的Cusmac地址是否已在数据表中信息表
        /// </summary>
        /// <param name="NexCusmac">新的CusMac地址</param>
        /// <returns></returns>
        public static bool Vidate(string NexCusmac)
        {
            bool flag = false;
            // string str = string.Format("select name from user_info where name='{0}' and password='{1}'", this.TextBox1.Text, this.TextBox2.Text);
            //验证该新生成的数据是否已在信息表中
            string sqlVidate = string.Format("select Id from MESXPT_ModuleMiscInfo where CusMac='{0}'", NexCusmac);
            if(DbHelper.ExecuteGetDateSet(sqlVidate).Tables[0].Rows.Count>0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 弹框功能
        /// </summary>
        /// <param name="strMsg"></param>
        /// <param name="strUrl_Yes"></param>
        /// <param name="strUrl_No"></param>
        public static void ShowConfirm(string strMsg, string strUrl_Yes, string strUrl_No)
        {
            
            System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'>if ( window.confirm('" + strMsg + "')) { };</script>");
        }


        /// <summary>
        /// 判断StartAddr Mac地址比endAddr Mac地址小
        /// </summary>
        /// <param name="StartAddr"></param>
        /// <param name="EndAddr"></param>
        /// <returns></returns>
        public static int MacAddrCompare(string StartAddr, string EndAddr)
        {


            int result = 255;
            result = string.Compare(StartAddr, EndAddr);
            //result值为“0”表示等，小于零表示 StartAddr < EndAddr，大于零表示 StartAddr > EndAddr


            return result;

        }


        /// <summary>
        /// 获取数据表MESXPT_ModuleMiscInfo中最大Cusmac地址
        /// </summary>
        /// <returns></returns>
        public static string SelectMaxCusMac()
        {
            string MaxCusMac = "";
            string sqlMaxCusMac = "select max(CusMac) as CusMac from MESXPT_ModuleMiscInfo";
            if (DbHelper.ExecuteGetDateSet(sqlMaxCusMac).Tables[0].Rows.Count > 0)
            {
                MaxCusMac = DbHelper.ExecuteGetDateSet(sqlMaxCusMac).Tables[0].Rows[0]["CusMac"].ToString();
                //for(int i=0;i< table.Rows.Count;i++)
                //{
                //    MaxCusMac = table.Rows[i]["CusMac"].ToString();
                //}
            }
            return MaxCusMac;
        }


        /// <summary>
        /// 往信息表MESXPT_ModuleMiscInfo插入数据(测试结果，MESID，EspMac,Btmac等数据)
        /// </summary>
        /// <param name="StartMac"></param>
        /// <param name="MesId"></param>
        /// <param name="EspMac"></param>
        /// <param name="BtMac"></param>
        /// <param name="ModuleVer"></param>
        /// <param name="TestResult"></param>
        /// <param name="Status"></param>
        /// <param name="LabelContent"></param>
        /// <param name="ModuleType"></param>
        /// <param name="OperationTime"></param>
        /// <returns></returns>
        public static bool InsertInfoTable(string CusMac,string MesId,string EspMac,string BtMac,string ModuleVer,string TestResult,int Status,string LabelContent,string ModuleType,string OperationTime)
        {
            bool flag = false;
            string insertIntoInfo = string.Format("insert into MESXPT_ModuleMiscInfo" +
               "(CusMac,MesID,EspMac,BtMac,ModuleVer,TestResult,Status,LabelContent,ModuleType,OperationTime)" +
               "values('" + CusMac + "','" + MesId + "','" + EspMac + "','" + BtMac + "','" + ModuleVer + "','" + TestResult + "','" + Status + "','" + LabelContent + "','" + ModuleType + "','" + OperationTime + "')");
            if (DbHelper.ExecuteCommand(insertIntoInfo) > 0)
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 向资源表MESXPT_CusMACResource插入数据，（包含界面输入的起始地址，终止地址等）
        /// </summary>
        /// <param name="StartMac"></param>
        /// <param name="EndMac"></param>
        /// <param name="CusCode"></param>
        /// <param name="MacType"></param>
        /// <param name="ActionType"></param>
        /// <param name="Maker"></param>
        /// <param name="OperationTime"></param>
        /// <returns></returns>
        public static bool InertSourceTable(string StartMac,string EndMac,string CusCode,string MacType,string ActionType,string Maker,string OperationTime)
        {
            bool flag = false;
            string sqlInsertMacResource = string.Format("insert into MESXPT_CusMACResource" +
                "(StartMac,EndMac,CusCode,MACType,ActionType,Maker,OperationTime)" +
                "values('" + StartMac + "','" + EndMac + "','" + CusCode + "','" + MacType + "','" + ActionType + "','" + Maker + "','" + OperationTime + "')");
            if (DbHelper.ExecuteCommand(sqlInsertMacResource) > 0)
            {
                flag = true;
            }
                return flag;
        }


        /// <summary>
        /// 向日志表MESXPT_CusMACOpLog中记录操作日志信息（已经使用的Mac地址）
        /// </summary>
        /// <param name="UsedStartMac"></param>
        /// <param name="UsedEndMac"></param>
        /// <param name="TestStatus"></param>
        /// <param name="Operator"></param>
        /// <param name="AcionType"></param>
        /// <param name="OperationTime"></param>
        /// <returns></returns>
        public static bool InsertLogTable(string UsedStartMac,string UsedEndMac,string TestStatus,string Operator,string AcionType,string OperationTime)
        {
            bool flag = false;
            string sqlInsertCusMACOpLog = string.Format("insert into MESXPT_CusMACOpLog" +
                    "(UsedStartMac,UsedEndMac,TestStatus,Operator,ActionType,OperationTime)" +
                    "values('" + UsedStartMac + "','" + UsedEndMac + "','" + TestStatus + "','" + Operator + "','" + AcionType + "','" + OperationTime + "')");
            if (DbHelper.ExecuteCommand(sqlInsertCusMACOpLog) > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 根据时间排序从资源表MESXPT_CusMACResource中获取最近加入的起始地址和终止地址
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentStartMacAndEndMac()
        {
            string StartMacAndEndMac = "";
            DataTable table = null;
            string sqlSelectCurrentMac = "select top 1 macsource.Id,macsource.StartMac as StartMacCur,macsource.EndMac as EndMacCur from dbo.MESXPT_CusMACResource macsource order by macsource.OperationTime desc";
            table = DbHelper.ExecuteGetDateSet(sqlSelectCurrentMac).Tables[0];
            if (table.Rows.Count > 0)
            {
               //DataTable table = DbHelper.ExecuteGetDateSet(sqlSelectCurrentMac).Tables[0];
                StartMacAndEndMac = table.Rows[0]["StartMacCur"].ToString() +","+ table.Rows[0]["EndMacCur"].ToString();
                //for(int i=0;i< table.Rows.Count;i++)
                //{
                //    MaxCusMac = table.Rows[i]["CusMac"].ToString();
                //}
            }
            return StartMacAndEndMac;
            
        }



  
       
    }
}