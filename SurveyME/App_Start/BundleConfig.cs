using System.Web;
using System.Web.Optimization;

namespace SurveyME
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/fontawesome").Include(
                "~/Scripts/fontawesome/all.js",
                "~/Scripts/fontawesome/brands.js",
                "~/Scripts/fontawesome/conflict-detection.js",
                "~/Scripts/fontawesome/fontawesome.js",
                "~/Scripts/fontawesome/regular.js",
                "~/Scripts/fontawesome/solid.js",
                "~/Scripts/fontawesome/v4-shims.js"));

            bundles.Add(new Bundle("~/bundles/myloader").Include(
                "~/Scripts/myloader"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Custom_CSS/Custom_CSS.css",
                      "~/Content/Custom_CSS/myloader.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                      "~/Content/fontawesome.css",
                      "~/Content/brands.css",
                      "~/Content/regular.css",
                      "~/Content/solid.css",
                      "~/Content/v4-shims.css"));

            bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
                      "~/Content/themes/base/all.css",
                      "~/Content/themes/base/menu.css",
                      "~/Content/themes/base/selectmenu.css",
                      "~/Content/themes/base/selectable.css",
                      "~/Content/themes/base/autocomplete.css"));
        }
    }
}
