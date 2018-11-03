using System.Web;
using System.Web.Optimization;

namespace E_CommerceSite
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

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
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Template/css").Include(
                      "~/Template/css/util.css",
                      "~/Template/css/main.css"));
            bundles.Add(new StyleBundle("~/Template/vendor").Include(
                      "~/Template/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Template/vendor/animate/animate.css",
                      "~/Template/vendor/css-hamburgers/hamburgers.min.css",
                      "~/Template/vendor/animsition/css/animsition.min.css",
                      "~/Template/vendor/select2/select2.min.css",
                      "~/Template/vendor/daterangepicker/daterangepicker.css",
                      "~/Template/vendor/slick/slick.css",
                      "~/Template/vendor/lightbox2/css/lightbox.min.css"));
            bundles.Add(new StyleBundle("~/Template/fonts").Include(
                      "~/Template/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                      "~/Template/fonts/themify/themify-icons.css",
                      "~/Template/fonts/Linearicons-Free-v1.0.0/icon-font.min.css",
                      "~/Template/fonts/elegant-font/html-css/style.css"));
            bundles.Add(new StyleBundle("~/Template/images").Include(
                      "~/Template/images/icons/favicon.png"));
        }
    }
}
