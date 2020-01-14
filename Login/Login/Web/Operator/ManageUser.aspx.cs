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
    public partial class ManageUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowEmployee();
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if (this.name.Text == "" || this.password.Text == "")
            {
                this.Label4.Text = "用户名或密码不能为空";
                return;
            }
            string Unser="";
            

            if (this.RaUser.Checked)
            {
                Unser = "Unuser";
            }
            else if(this.RaManager.Checked)
            {
                Unser = "Manager";
            }
            else if(this.RaEngineer.Checked)
            {
                Unser = "Engineer";
            }

            if(Unser!=""&&Unser!=null)
            {
                //string InsertStr = "insert into user_info(name,address,password)values('"+this.name.Text+;
                string InsertStr = string.Format("insert into MESXBS_USERTemp(UserName,Password,Permission)values('" + this.name.Text + "','" + this.password.Text + "','" + Unser + "')");
                int value = DbHelper.ExecuteCommand(InsertStr);
                if (value < 0)
                {
                    this.Label4.Text = "新增员工失败！";
                    return;
                }
                else
                {
                    this.Label4.Text = "新增员工成功！员工姓名：" + this.name.Text;

                }
            }
            else
            {
                this.Label4.Text = "您好，您忘记选择类型了!  请选择员工类型：普通员工、工程师、管理员";
                return;
            }
            
            this.name.Text = "";
            this.password.Text = "";
        }

        public void  ShowEmployee()
        {
            string str = "select * from MESXBS_USERTemp";
            DataTable databale = DbHelper.ExecuteSqlGetDataTable(str);
            if (databale.Rows.Count > 0)
            {
                this.GridView1.DataSource = databale;
                this.GridView1.DataBind();
            }
        }
    }
}