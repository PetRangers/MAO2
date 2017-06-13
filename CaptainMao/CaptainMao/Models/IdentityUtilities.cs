using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaptainMao.Models
{
    public class IdentityUtilities
    {
        //將傳入的圖檔轉為binary的方法
        public static byte[] LoadUploadedFile(HttpPostedFileBase uploadedFile)
        {
            var buf = new byte[uploadedFile.InputStream.Length];
            uploadedFile.InputStream.Read(buf, 0, (int)uploadedFile.InputStream.Length);
            return buf;
        }

        //取得登入者IP的方法
        public static string GetIP(bool CheckForward = false)
        {
            string ip = null;
            if (CheckForward)
            {
                ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }

            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            { // Using X-Forwarded-For last address
                ip = ip.Split(',')
                       .Last()
                       .Trim();
            }

            return ip;
        }
        
    }
}