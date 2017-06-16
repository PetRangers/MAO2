using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.WebForm
{
    /// <summary>
    /// ImageReader 的摘要描述
    /// </summary>
    public class ImageReader : IHttpHandler
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
                string strCmd = "select BytesImage from Adoption Where AdoptionID = @ID";
                using (SqlCommand cmd = new SqlCommand(strCmd, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", SearchID);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        context.Response.ContentType = "image/gif";
                        context.Response.BinaryWrite((Byte[])dr[0]);
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