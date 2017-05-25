using System.Web;
using System.Web.Optimization;

namespace Login
{
    public class BundleConfig
    {
        // 如需「搭配」的詳細資訊，請瀏覽 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/jquery-{version}.js", 
                        "~/Scripts/bootstrap.js", 
                        "~/Scripts/modernizr-2.6.2.js",
                        "~/js/JavaScript.js"));

            bundles.Add(new StyleBundle("~/css").Include(
                      "~/css/reset.css",
                      "~/Content/bootstrap.css",
                      "~/css/StyleSheet_Master.css"
                      ));

            

        }
    }
}
