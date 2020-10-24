using System.Web;
using System.Web.Optimization;

namespace RCS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/popper.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/swiper.min.js",
                        "~/Scripts/wow.min.js",
                        "~/Scripts/DataTables/dataTables.bootstrap{version}.min.js",
                        "~/Scripts/DataTables/jquery.dataTables.min.js",
                        "~/Scripts/bootbox.min.js",
                        "~/scripts/toastr.js",
                        "~/Scripts/main.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/all.min.css",
                      "~/Content/animate.min.css",
                      "~/Content/swiper.min.css",
                      "~/Content/DataTables/css/dataTables.bootstrap{version}.min.css",
                      "~/Content/DataTables/css/jquery.dataTables.min.css",
                      "~/content/toastr.css",
                      "~/Content/style.css"));
        }
    }
}
