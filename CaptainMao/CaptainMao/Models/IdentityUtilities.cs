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
    }
}