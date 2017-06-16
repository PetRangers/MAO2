using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.WebForm
{
    /// <summary>
    /// MerchandisePhoto 的摘要描述
    /// </summary>
    public class MerchandisePhoto : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string SearchID = "1";
            if (context.Request.QueryString["SearchID"] != null)
            {
                SearchID = context.Request.QueryString["SearchID"];
            }
        
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                string strCmd = "select Merchandise_Photo, Merchandise_Photo_Address from ShoppingNetwork.Merchandise Where Merchandise_ID = @ID";
                using (SqlCommand cmd = new SqlCommand(strCmd, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", SearchID);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr["Merchandise_Photo"].ToString() != "")
                        {
                            context.Response.ContentType = "image/gif";
                            context.Response.BinaryWrite((Byte[])dr["Merchandise_Photo"]);
                        }
                        else if (dr["Merchandise_Photo_Address"] != null)
                        {
                            context.Response.ContentType = "text/plain";
                            context.Response.Write(dr["Merchandise_Photo_Address"]);
                        }
                    }
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}