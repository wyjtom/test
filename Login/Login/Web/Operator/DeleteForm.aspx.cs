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
    public partial class DeleteForm : System.Web.UI.Page
    {

        public string id = "";
        public string StartMac = "";
        public string EndMac = "";
        public string TestStatus = "1";
        public string Operator = "";
        public string ActionType = "Complete";
        public string OperationTime = DateTime.Now.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            /*public System.Web.UI.WebControls.Button btnDelRow;
           btnDelRow.Attributes.Add("onclick", "return confirm('确定要删吗?');"); */
            string id = GridView1.DataKeys[e.RowIndex][0].ToString();
            string sql = "delete from MESXPT_CusMACResource where Id='" + id + "'";
            // Response.Write("<script language=javascript>alert('确定要删除吗？');</" + "script>");
            //Help.ShowConfirm("确定要删除吗？", "Yes", "No");
            /*string js = string.Format("document.getElementById('{0}').value=confirm('是否确认?');document.getElementById('{1}').click();", hid.ClientID, btnHid.ClientID);
            ClientScript.RegisterStartupScript(GetType(), "confirm", js, true);
            string result = hid.Value.ToLower() == "true" ? "是" : "否";
            if (result == "否") return;*/
            //this.GridView1.Attributes.Add("onclick", "javascript:if (confirm('确定要删除吗 ?')) { } else { return false; }");

            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "next step",
            //   "if(confirm('您所选的赠品小于赠送的数量,确认只选着这些赠品吗？'))" + this.Page.ClientScript.GetPostBackEventReference(this, "secondnext"), true);
            //return;
            
            if (DbHelper.ExecuteCommand(sql)>0)
            {
                Help.InsertLogTable(this.StartMac,this.EndMac,this.TestStatus,this.Operator,this.ActionType,this.OperationTime);
                this.Label1.Text = "删除成功！！，删除项的行号为：" + id;
            }
            GetData();
        }

        
        private void GetData()
        {
            DataSet ds = DbHelper.ExecuteGetDateSet("select*from MESXPT_CusMACResource");
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

        /* protected void Button1_Click(object sender, EventArgs e)
         {
             string inventoryIdStr = string.Empty;
             string inventoryQtyStr = string.Empty;
             if (GiftRepeater.Items.Count > 0)
             {
                 foreach (RepeaterItem item in GiftRepeater.Items)
                 {
                     string inventoryIdStr1 = string.Empty;
                     string inventoryQtyStr1 = string.Empty;
                     Repeater GiftSizeRepeater = item.FindControl("SelectSizeRepeater") as Repeater;
                     if (GiftSizeRepeater.Items.Count > 0)
                     {
                         foreach (RepeaterItem item1 in GiftSizeRepeater.Items)
                         {
                             int inventoryQty = 0;
                             int inventoryQty1 = 0;
                             HiddenField ProductQuentityHiddenField = item1.FindControl("ProductQuentityHiddenField") as HiddenField;
                             TextBox InventoryTextBox = item1.FindControl("InventoryTextBox") as TextBox;
                             HiddenField QtyHiddenField = item1.FindControl("QtyHiddenField") as HiddenField;
                             int.TryParse(QtyHiddenField.Value, out inventoryQty1);
                             if (!string.IsNullOrEmpty(InventoryTextBox.Text))
                             {
                                 if (!int.TryParse(InventoryTextBox.Text, out inventoryQty))
                                 {
                                     Label1.Text = "请确认您输入的赠品数量格式真确!";
                                     return;
                                 }
                                 if (inventoryQty > inventoryQty1)
                                 {
                                     Label1.Text = "您输入的某赠品数量大于当前库存,请重新选择或减少输入赠品数量!";
                                     return;
                                 }
                                 if (inventoryQty > 0)
                                 {
                                     inventoryIdStr1 = inventoryIdStr1 + ProductQuentityHiddenField.Value + ",";
                                     inventoryQtyStr1 = inventoryQtyStr1 + inventoryQty + ",";
                                 }
                             }
                         }
                     }
                     inventoryIdStr = inventoryIdStr + inventoryIdStr1;
                     inventoryQtyStr = inventoryQtyStr + inventoryQtyStr1;
                 }
             }
             if (!string.IsNullOrEmpty(inventoryIdStr))
             {
                 inventoryIdStr = inventoryIdStr.TrimEnd(',');
             }
             if (!string.IsNullOrEmpty(inventoryQtyStr))
             {
                 inventoryQtyStr = inventoryQtyStr.TrimEnd(',');
             }
             int giftcount = 0;
             int selectcount = 0;
             if (!string.IsNullOrEmpty(inventoryQtyStr))
             {
                 string[] arrs = inventoryQtyStr.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                 for (int i = 0; i < arrs.Length; i++)
                 {
                     selectcount = selectcount + int.Parse(arrs[i].ToString());
                 }
             }
             if (giftcount > selectcount)
             {
                 this.Page.ClientScript.RegisterStartupScript(this.GetType(), "next step",
                "if(confirm('您所选的赠品小于赠送的数量,确认只选着这些赠品吗？'))" + this.Page.ClientScript.GetPostBackEventReference(this, "secondnext"), true);
                 return;
             }
             if (giftcount < selectcount)
             {
                 Label1.Text = "你所选的赠品数量不允许大于赠送的数量!";
                 return;
             }
             string result = "0";
             if (result == "1")
             {
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Script", "CloseWithRefreshParent();", true);
             }
             else
             {
                 Label1.Text = "操作失败，请重新操作!";
                 return;
             }
         }*/


        /*protected void btnCallBack_Click(object sender, EventArgs e)
        {
            //do sth
            string js = string.Format("document.getElementById('{0}').value=confirm('是否确认?');document.getElementById('{1}').click();", hid.ClientID, btnHid.ClientID);
            ClientScript.RegisterStartupScript(GetType(), "confirm", js, true);
        }
        protected void btnHid_Click(object sender, EventArgs e)
        {
            string result = hid.Value.ToLower() == "true" ? "是" : "否";
            Response.Write(string.Format("您选择的是{0}", result));
        }
       */
        
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
             id= HttpUtility.HtmlDecode(row.Cells[0].Text);
             StartMac= HttpUtility.HtmlDecode(row.Cells[1].Text);
             EndMac = HttpUtility.HtmlDecode(row.Cells[2].Text);

           // string js = string.Format("document.getElementById('{0}').value=confirm('是否确认?');document.getElementById('{1}').click();", hid.ClientID, btnHid.ClientID);
        } 
    }
}