using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CaptainMao.Areas.WebForm
{
    public partial class WebUserCancel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string OrderID = "";
            if (Request.QueryString["OrderID"] != null)
            {
                OrderID =Request.QueryString["OrderID"];
            }
            else
            {
                Response.Redirect("~/Areas/WebForm/WebFormUser.aspx");
            }


            string strConn = ConfigurationManager.ConnectionStrings["MaoWebformConnectionString"].ConnectionString;
            using (SqlConnection Conn = new SqlConnection(strConn))
            {
                string strCmd = "UPDATE [ShoppingNetwork].[Order] SET [Order_Fitness] = 0 where Order_ID = @ID";
                using (SqlCommand Cmd = new SqlCommand(strCmd, Conn))
                {
                    Cmd.CommandType = System.Data.CommandType.Text;
                    Cmd.Parameters.AddWithValue("@ID", OrderID);
                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                    Conn.Close();

                }
            }


            Response.Redirect("~/Areas/WebForm/WebFormUser.aspx");
        }
    }
}