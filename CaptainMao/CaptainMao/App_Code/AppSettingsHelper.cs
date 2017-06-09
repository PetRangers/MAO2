using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CaptainMao.App_Code
{
    public class AppSettingsHelper
    {
        public static string WebUrlWWW = WebConfigurationManager.AppSettings["WebUrlWWW"];
    }
}