using Login.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login.Web.Operator
{
    public partial class UpdateForm : System.Web.UI.Page
    {
         string startMac = "";
         string endMac = "";
         string Id = "";

        public string GetCurrentTime()
        {
            return DateTime.Now.ToString();
        }

        public string GetOperator()
        {
            return Help.UserLoginName;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
        }

        protected void btnUpdataMac_Click(object sender, EventArgs e)
        {
            string startMac = this.txtMacStart.Text;
            string endMac = this.txtMacEnd.Text;
            string[] strStart = startMac.Split(':');
            string[] strEnd = endMac.Split(':');

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

            string sqlQueryInfo = string.Format("select Id from MESXPT_ModuleMiscInfo where CusMac='{0}' or CusMac='{1}'", startMac, endMac);
            if (DbHelper.ExecuteSqlGetDataTable(sqlQueryInfo).Rows.Count > 0)
            {
                this.labflag.Text = "您所输入的起始地址和终止地址已经存，请确认";
                return;
            }
            else
            {
                this.labflag.Text = "";
            }

            if (IsMacAddr(startMac)==false||IsMacAddr(endMac)==false)
            {
                this.labflag.Text = "您所输入的起始地址或者终止地址不符合要求！！";
                return;
            }
            //string Id = GridView1.DataKeys[e.RowIndex][0].ToString();//取出修改行的主键值
            //string startMac = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).ToString();
            //string endMac = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).ToString();
            //将用户更新的数据修改数据库
            this.labflag.Text = "";
            SqlConnection con = new SqlConnection();        //定义数据库连接对象
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RemoteConn"].ConnectionString;  //定义数据库连接字符串
            string sql = "update MESXPT_CusMACResource set StartMac='" + startMac + "',EndMac='" + endMac + "',Maker='" +this.GetOperator() + "',OperationTime='" +this. GetCurrentTime() + "' where Id='" + this.GetId() + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            GetData();
            Log();
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

        public void Log()
        {
            if (Help.InsertLogTable(getUsedStartMac(), getUsedEndMac(), getTestStatus(), getOperator(), getLogActionType(), this.getCurrent()))
            {
                this.labflag.Text = "数据更改成功！！操作日志保存到日志表成功";
            }
            else
            {
                this.labflag.Text = "操作日志保存到日志表失败！！，请联系管理员";
            }
        }

        private string getCurrent()
        {
            return DateTime.Now.ToString();
        }

        private string getLogActionType()
        {
            return "Aplied";
        }

        private string getOperator()
        {
            return Help.UserLoginName;
        }

        private string getTestStatus()
        {
            return "";
        }

        private string getUsedEndMac()
        {
            return this.txtMacEnd.Text;
        }

        private string getUsedStartMac()
        {
            return this.txtMacStart.Text;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }


        /// <summary>
        /// 选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            this.Id = HttpUtility.HtmlDecode(row.Cells[0].Text);//取出修改行的主键值
            this.startMac=this.txtMacStart.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);
            this.endMac=this.txtMacEnd.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
        }

        public string GetMacStart()
        {
            //GridViewRow row = GridView1.SelectedRow;
            //return HttpUtility.HtmlDecode(row.Cells[1].Text);
           return this.txtMacStart.Text;
        }


        public string GetMacEnd()
        {
            return this.txtMacEnd.Text;
            //GridViewRow row = GridView1.SelectedRow;
            //return HttpUtility.HtmlDecode(row.Cells[2].Text);
        }

        public string GetId()
        {
            GridViewRow row = GridView1.SelectedRow;
            return HttpUtility.HtmlDecode(row.Cells[0].Text);
        }
        /// <summary>
        /// 获取数据库数据
        /// </summary>
        protected void GetData()
        {
            DataSet ds = DbHelper.ExecuteGetDateSet("select*from MESXPT_CusMACResource");
            GridView1.DataSource = ds.Tables[0].DefaultView;//设置gridview控件的数据源为创建的数据集ds
            GridView1.DataBind();                           //绑定数据库表中数据

        }

        

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            

        }

    }
}