using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Login.Common;
using Login.model;

namespace Login.Control
{
    public class AddMacHelp
    {

        /// <summary>
        /// 插入数据表MESXPT_ModuleMiscInfo（综合测试信息表）
        /// </summary>
        /// <param name="StartMac"></param>
        /// <param name="EndMac"></param>
        public void InsertMESXPT_ModuleMiscInfo(string StartMac,string EndMac)
        {
           /* string url = "http://192.168.0.87:8088/Web/TestJson.aspx";
            MESXPT_ModuleMiscInfo mESXPT_ModuleMiscInfo = DealJsonDasta.AnalysisJsonStr(url);
            string CusMac = GetCusMac();
            string MesId = mESXPT_ModuleMiscInfo.MesId1;
            string EspMac = mESXPT_ModuleMiscInfo.EspMac1;
            string BtMac = mESXPT_ModuleMiscInfo.EspMac1;
            string ModuleVer = mESXPT_ModuleMiscInfo.ModuleVer1;
            string TestResult = mESXPT_ModuleMiscInfo.TestResult1;
            int Status = mESXPT_ModuleMiscInfo.Status1;
            string LabelContent = mESXPT_ModuleMiscInfo.LabelContent1;
            string ModuleType = mESXPT_ModuleMiscInfo.ModuleType1;
            string OperationTime = DateTime.Now.ToString();

            if (StartMac!=""&&EndMac!="")
            {
                string insertIntoInfo =string.Format("insert into MESXPT_ModuleMiscInfo" +
                "(CusMac,MesID,EspMac,BtMac,ModuleVer,TestResult,Status,LabelContent,ModuleType,OperatioTime)" +
                "values('" + CusMac + "','" + MesId + "','" + EspMac + "','" + BtMac + "','" + ModuleVer + "','" + TestResult + "','" + Status + "','" + LabelContent + "','" + ModuleType + "','" + OperationTime + "')");
            }
            */
            
        }



        /// <summary>
        /// 生成CusMac地址
        /// </summary>
        /// <param name="StartMac"></param>
        /// <param name="EndMac"></param>
        /// <returns></returns>
        public string GetCusMac(string StartMac,string EndMac)
        {
            string CusMacValue = "";
           if(StartMac==EndMac)
            {
                CusMacValue = StartMac;
            }
            else
            {
                CusMacValue = StartMac + 1;
            }

            //string sqlMaxCusMac = "select max(CusMac) from MESXPT_ModuleMiscInfo ";
            return CusMacValue;
        }

        public string GetEspMac()
        {
            return "";
        }

        public string GetMesId()
        {

            return "";
        }

        public string BtMac()
        {
            return "";
        }
        
    }
}