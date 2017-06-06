using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.Article.Views.Article
{
    /// <summary>
    /// Upload 的摘要描述
    /// </summary>
    public class Upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpPostedFile uploads = context.Request.Files["upload"];
            string CKEditorFuncNum = context.Request["CKEditorFuncNum"];
            string file = System.IO.Path.GetFileName(uploads.FileName);
            var t = DateTime.Now+file;
            var filename = context.Server.MapPath(".") + "\\UploadImages\\" + file;
            uploads.SaveAs(filename);
            string url = "UploadImages/" + t;

            context.Response.Write("<script>window.parent.CKEDITOR.tools.callFunction(" + ",\"" + url + "\");</script>");
            context.Response.End();
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