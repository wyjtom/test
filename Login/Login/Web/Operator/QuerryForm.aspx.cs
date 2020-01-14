using Login.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login.Web.Operator
{
    public partial class QuerryForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
        }


        protected void btnQuerryMac_Click(object sender, EventArgs e)
        {
            string startMac = this.txtMacStart.Text;
            string endMac = this.txtMacEnd.Text;
            string str = string.Format("select * from MESXPT_CusMACResource where StartMac='{0}' or EndMac='{1}'", this.txtMacStart.Text, this.txtMacEnd.Text);

            DataSet ds = DbHelper.ExecuteGetDateSet(str);
            if (ds.Tables.Count>0)
            {
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

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

        protected void btnAll_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}