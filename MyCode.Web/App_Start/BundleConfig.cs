using System.Web;
using System.Web.Optimization;

namespace MyCode.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/BasicJS").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/admin-lte/js/adminlte.min.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/BasicCSS").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/css/font-awesome.min.css",
                        "~/admin-lte/css/AdminLTE.min.css"                       
                        ));            
        }
    }
}
