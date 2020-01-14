using Login.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login.Web
{
    public partial class TestJson : System.Web.UI.Page
    {
        public string GetJson(DataSet dataSet)
        {
            string Json = JsonConvert.SerializeObject(dataSet);
            //this.TextBox1.Text = Json;
            // SendJons(Json);
           
            return Json;//new HttpResponse(Json);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = DbHelper.ExecuteGetDateSet("select*from book");
            Response.Write(GetJson(ds));
        }

        public static string CulMac()
        {
            //return long.t
            return "";
        }
    }
}