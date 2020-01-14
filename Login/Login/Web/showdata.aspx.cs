using Login.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login.Web
{
    

    public partial class showdata : System.Web.UI.Page
    {

        //public HttpResponseMessage
        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public string GetJson(DataSet dataSet)
        {
            string Json = JsonConvert.SerializeObject(dataSet);
            this.TextBox1.Text = Json;
           // SendJons(Json);
            return Json;//new HttpResponse(Json);
        }

        /// <summary>
        /// 发送Json
        /// </summary>
        public void SendJons(string strJson)
        {
            HttpUtils.Post("http://localhost:52918/Web/TestJson.aspx", strJson,"");
            Response.Redirect("TestJson.aspx");
        }


        /// <summary>
        /// 获取数据库数据
        /// </summary>
        protected void GetData()
        {
            DataSet ds = DbHelper.ExecuteGetDateSet("select*from book");
            GetJson(ds);
            GridView1.DataSource = ds.Tables[0].DefaultView;//设置gridview控件的数据源为创建的数据集ds
            GridView1.DataBind();                           //绑定数据库表中数据

        }

        /// <summary>
        /// 页面加载初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
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

        /// <summary>
        /// 选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            this.txtBookId.Text = HttpUtility.HtmlDecode(row.Cells[0].Text);
            this.txtBookName.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);
            this.txtBookAddress.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string bookid = GridView1.DataKeys[e.RowIndex][0].ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RemoteConn"].ConnectionString;
            string sql = "delete from book where bookid='" + bookid + "'";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            // cmd.Parameters.AddWithValue("@bookid", bookid);
            sqlCommand.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            GetData();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.SelectedIndex = e.NewEditIndex;//实现编辑功能
            GetData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string bookId = GridView1.DataKeys[e.RowIndex][0].ToString();//取出修改行的主键值
            string bookName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).ToString();
            string bookAddress = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).ToString();
            //将用户更新的数据修改数据库
            SqlConnection con = new SqlConnection();        //定义数据库连接对象
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RemoteConn"].ConnectionString;  //定义数据库连接字符串
            string sql = "update book set bookname='"+bookName+"',bookaddress='"+bookAddress+"' where bookid='"+bookId+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            GetData();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetData();
        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.txtBookAddress.Text == "" || this.txtBookId.Text == "" || this.txtBookName.Text == "")
            {
                this.Label4.Text = "图书信息不能为空";
                return;
            }
               
            string InsertStr = string.Format("insert into book(bookid,bookname,bookaddress)values('" + this.txtBookId.Text + "','" + this.txtBookName.Text + "','" + this.txtBookAddress.Text + "')");
            int value = DbHelper.ExecuteCommand(InsertStr);
            if (value > 0)
            {
                this.Label4.Text = "新增成功";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet ds = DbHelper.ExecuteGetDateSet("select*from book");
            GetJson(ds);
        }
    }
}