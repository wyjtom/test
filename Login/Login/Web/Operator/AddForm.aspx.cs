using Login.Common;
using Login.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login.Web.Operator
{
    public partial class AddForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSumitMac_Click(object sender, EventArgs e)
        {
            string MacStart = this.txtMacStart.Text.ToUpper() ;
            string MacEnd = this.txtMacEnd.Text.ToUpper();

            if (MacStart==""|| MacEnd == "")
            {
                this.labflag.Text = "请输入Mac起始地址和终止地址";
                return;
            }
            else
            {
                this.labflag.Text = "";
            }

            if(MacStart.Length<12||MacEnd.Length<12)
            {
                this.labflag.Text = "请输入长度为12位的Mac起始地址和终止地址";
                return;
            }
            else
            {
                this.labflag.Text = "";
            }

            string str1 = MacStart.Substring(0, 2) + ":" + MacStart.Substring(2, 2) + ":" + MacStart.Substring(4, 2) + ":" + MacStart.Substring(6, 2) + ":" + MacStart.Substring(8, 2)+":"+MacStart.Substring(10,2);
            string str2 = MacEnd.Substring(0, 2) + ":" + MacEnd.Substring(2, 2) + ":" + MacEnd.Substring(4, 2) + ":" + MacEnd.Substring(6, 2) + ":" + MacEnd.Substring(8, 2) + ":" + MacEnd.Substring(10, 2);


            string[] strStart = str1.Split(':');
            string[] strEnd = str2.Split(':');

            if (strStart[0] != "D0" || strStart[1] != "73" || strStart[2] != "D5")
            {
                this.labflag.Text = "您所输入的起始Mac地址不符合规定，规定前面几位为D0:73:D5";
                return;
            }
            else
            {
                this.labflag.Text = "";
            }

            if (strEnd[0] != "D0" || strEnd[1] != "73" || strEnd[2] != "D5")
            {
                this.labflag.Text = "您所输入的终止Mac地址不符合规定，规定前面几位为D0:73:D5";
                return;
            }
            else
            {
                this.labflag.Text = "";
            }


            //string str = string.Format("select name from user_info where name='{0}' and password='{1}'", this.TextBox1.Text, this.TextBox2.Text);
            string sqlQuery = string.Format("select Id from MESXPT_CusMACResource where StartMac='{0}' or EndMac='{1}'", MacStart, MacEnd);
            if (DbHelper.ExecuteSqlGetDataTable(sqlQuery).Rows.Count>0)
            {
                this.labflag.Text = "您所输入的起始地址和终止地址已经存，请确认";
                return;
            }
            else
            {
                this.labflag.Text = "";
            }
            string sqlQueryInfo = string.Format("select Id from MESXPT_ModuleMiscInfo where CusMac='{0}' or CusMac='{1}'", MacStart, MacEnd);
            if (DbHelper.ExecuteSqlGetDataTable(sqlQueryInfo).Rows.Count > 0)
            {
                this.labflag.Text = "您所输入的起始地址和终止地址已经存，请确认";
                return;
            }
            else
            {
                this.labflag.Text = "";
            }


            if (this.IsMacAddr(str1) ==false||this.IsMacAddr(str2)==false)
            {
                this.labflag.Text = "您所输入的起始地址和终止地址格式错误，请按照正确的格式输入！！";
                return;
            }
            else
            {
                this.labflag.Text = "";
            }

            if (MacAddrCompare(MacStart, MacEnd)>0)
            {
                this.labflag.Text = "您所输入的起始地址大于终止地址，请确认！！！";
                return;
            }
            else
            {
                this.labflag.Text = "";
            }
            //InsertMESXPT_ModuleMiscInfo(MacStart,MacEnd);//信息表（MesId,Result等等数据）
            //将数据持久化到资源表
            if(Help.InertSourceTable(MacStart, MacEnd, this.getCusCodeFromMes(), this.getResourceMacType(), this.getResourceActionType(), this.getMaker(), this.getCurrent()))
            {
                this.labflag.Text = "数据保存到资源表成功";
                Help.IsNewStartMacAndEndMac = true;
                //操作日志记录
                if(Help.InsertLogTable(getUsedStartMac(), getUsedEndMac(), getTestStatus(), getOperator(), getLogActionType(), this.getCurrent()))
                {
                    this.labflag.Text = "操作日志保存到日志表成功";
                }
                else
                {
                    this.labflag.Text = "操作日志保存到日志表失败！！，请联系管理员";
                }
            }
            else
            {
                this.labflag.Text = "数据持久化到资源表失败，请联系系统管理员！！";
            }

        }
        
        
        public string getLogActionType()
        {
            return "Aplied";
        }

        public string getOperator()
        {
            return "";
        }

        /// <summary>
        /// 根据测试结果判断是否使用过，如果成功使用就把该CusMac插入日志表
        /// </summary>
        /// <returns></returns>
       public string GetUsedCusMac()
        {
            return "";
        }

        public string getTestStatus()
        {
            return "";
        }


        public string getUsedEndMac()
        {
            return this.txtMacStart.Text.ToUpper();
        }

        public string getUsedStartMac()
        {
            return this.txtMacEnd.Text.ToUpper();
        }

        public string getCurrent()
        {
            return DateTime.Now.ToString();
        }

        public string getMaker()
        {
            return Help.UserLoginName;
        }
        public string getResourceActionType()
        {
            return "New";
        }
        public string getResourceMacType()
        {
            return "WIFI";
        }

        /// <summary>
        /// 得到新的CusMac地址，该数据需要返回给测试客户端
        /// </summary>
        /// <returns>获取下一个Cusmac地址</returns>
        public string GetCusMac(string StartMacCur,string EndMacCur)
        {
            string NewCusMac = "";
           // string MaxCusMaxCurrent = Help.SelectMaxCusMac();//获取信息表中最大的CusMac地址
            NewCusMac = Help.AddOne(StartMacCur, EndMacCur);
            return NewCusMac;
        }

        /// <summary>
        /// 该数据从MES系统中获取
        /// </summary>
        /// <returns></returns>
       public string getCusCodeFromMes()
        {
            return"";
        }

        
        /// <summary>
        /// 判断StartAddr Mac地址比endAddr Mac地址小
        /// </summary>
        /// <param name="StartAddr"></param>
        /// <param name="EndAddr"></param>
        /// <returns></returns>
        public int MacAddrCompare(string StartAddr, string EndAddr)
        {


            int result = 255;
            result = string.Compare(StartAddr, EndAddr);
            //result值为“0”表示等，小于零表示 StartAddr < EndAddr，大于零表示 StartAddr > EndAddr


            return result;

        }


        /// <summary>
        ///正则表达式判定输入数据是否符合输入规则
        /// </summary>
        /// <param name="str_MacAddr"></param>
        /// <returns></returns>
        public bool IsMacAddr(string str_MacAddr)
        {

            bool IsMacAddrFag = false;
            string s = @"^([0-9a-fA-F]{2})(([/\s:-][0-9a-fA-F]{2}){5})$";
            Regex r = new Regex(s);
            MatchCollection oCollection = r.Matches(str_MacAddr.Trim());
            if (oCollection.Count > 0)
            {
                //MessageBox.Show("MAC地址格式正确！");
                IsMacAddrFag = true;
            }
            else
            {
                //MessageBox.Show("MAC地址格式不正确！");
                IsMacAddrFag = false;
            }

            return IsMacAddrFag;

        }
        

        protected void btnTest_Click(object sender, EventArgs e)
        {
            //InsertMESXPT_ModuleMiscInfo();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}