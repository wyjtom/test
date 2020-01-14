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
    public partial class ShowInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            DataSet ds = DbHelper.ExecuteGetDateSet("select top(10)* from MESXPT_ModuleMiscInfo order by OperationTime desc ");
            GridView1.DataSource = ds.Tables[0].DefaultView;//设置gridview控件的数据源为创建的数据集ds
            GridView1.DataBind();
        }

        
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.GetData();
        }
    }
}