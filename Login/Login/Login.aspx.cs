using Login.Common;
using Login.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Login
{

    public partial class Login : System.Web.UI.Page
    {
        public User_info user_Info;

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string userid = "";
            if (this.TextBox1.Text==""||this.TextBox2.Text=="")
            {
                this.Label3.Text = "用户名或密码不能为空";
                return;
            }
            string str = string.Format("select Id from MESXBS_USERTemp where UserName='{0}' and Password='{1}'", this.TextBox1.Text, this.TextBox2.Text);
            DataTable databale = DbHelper.ExecuteSqlGetDataTable(str);
            Help.UserLoginName =username;
            //a权限验证
            
            if (databale.Rows.Count > 0)
            {
                userid = databale.Rows[0]["Id"].ToString();
                string sqlPermission =string.Format("select Permission from MESXBS_USERTemp where Id='{0}'",userid);
                DataTable databale2 = DbHelper.ExecuteSqlGetDataTable(sqlPermission);
                string PerMissionCurrentuser= databale2.Rows[0]["Permission"].ToString();//当前用户的权限
                if (PerMissionCurrentuser != "" && PerMissionCurrentuser != null && PerMissionCurrentuser == "Unuser")
                {
                    Response.Redirect("/Web/UnUser2.aspx");
                }
                else if(PerMissionCurrentuser != "" && PerMissionCurrentuser != null && PerMissionCurrentuser == "Manager")
                {
                    Response.Redirect("/Web/Manager.aspx");
                }
                else if(PerMissionCurrentuser != "" && PerMissionCurrentuser != null && PerMissionCurrentuser == "Engineer")
                {
                    Response.Redirect("/Web/Engineer.aspx");
                }
                else
                {
                    this.Label3.Text = "权限出错，请联系管理员！！";
                }
               
            }
            else
            {
                Response.Redirect("/Web/Error.aspx");
            }
        }





    }
}