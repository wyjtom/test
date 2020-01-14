using Login.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login.Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        protected void Regist_Click1(object sender, EventArgs e)
        {
            if (this.name.Text == "" || this.password.Text == "")
            {
                this.Label4.Text = "用户名或密码不能为空";
                return;
            }
            string Unser = "Unuser";
            //string InsertStr = "insert into user_info(name,address,password)values('"+this.name.Text+;
            string InsertStr = string.Format("insert into MESXBS_USERTemp(UserName,Password,Permission)values('" + this.name.Text + "','" + this.password.Text + "','" + Unser + "')");
            int value = DbHelper.ExecuteCommand(InsertStr);
            if (value < 0)
            {

                return;
            }
            else
            {
                string str = string.Format("select UserName from MESXBS_USERTemp where UserName='{0}' and Password='{1}'", this.name.Text, this.password.Text);
                DataTable databale = DbHelper.ExecuteSqlGetDataTable(str);

                if (databale.Rows.Count > 0)
                {
                    
                    Response.Redirect("/Web/Unuser.aspx");
                }
                else
                {
                    Response.Redirect("/Web/RegisterError.aspx");
                }
            }
        }
    }
}