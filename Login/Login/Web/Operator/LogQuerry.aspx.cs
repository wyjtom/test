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
    public partial class LogQuerry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetData();
        }

        protected void btnLogQuerry_Click(object sender, EventArgs e)
        {
            string startMac = this.txtMacStart.Text;
            string endMac = this.txtMacEnd.Text;
            string str = string.Format("select * from MESXPT_CusMACOpLog where UsedStartMac='{0}' or UsedEndMac='{1}'", startMac, endMac);
            DataTable databale = DbHelper.ExecuteSqlGetDataTable(str);

            if (databale.Rows.Count > 0)
            {
                this.GridView1.DataSource = databale;
            }
        }
        private void GetData()
        {
            DataSet ds = DbHelper.ExecuteGetDateSet("select*from MESXPT_CusMACOpLog order by OperationTime desc");
            GridView1.DataSource = ds.Tables[0].DefaultView;//设置gridview控件的数据源为创建的数据集ds
            GridView1.DataBind();
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.GetData();
        }

    }

        
 
}