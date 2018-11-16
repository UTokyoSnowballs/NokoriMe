using System.Web;
using System.Web.Optimization;

namespace SleepMakeSense
{
    public class BundleConfig
    {
        // For more information about the bundle , http:? //go.microsoft.com/fwlink/ Please refer to the LinkId = 301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Development and the learning , use the development version of Modernizr. Then , ready for production
            // Can Once , http: using the build tool in the //modernizr.com, choose the only test required .
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Contentcss/css").Include(
                      "~/CSSfiles/Layout.css",
                      "~/CSSfiles/Site.css",
                      "~/CSSfiles/font-awesome.css"));

            ;
        }
    }
}
