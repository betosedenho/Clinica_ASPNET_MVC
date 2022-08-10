using System.Web;
using System.Web.Optimization;

namespace Clinica.Site.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
						"~/Scripts/bootstrap.min.js",
						"~/Scripts/jquery.ui.widget.js",
						"~/Scripts/load-image.all.min.js",
						"~/Scripts/canvas-to-blob.min.js",
						"~/Scripts/jquery.iframe-transport.js",
						"~/Scripts/jquery.fileupload.js",
						"~/Scripts/jquery.fileupload-process.js",
						"~/Scripts/jquery.fileupload-image.js",
						"~/Scripts/validator.js",
						"~/Scripts/respond.js",
						"~/Scripts/jquery.custom.js",
						"~/Scripts/jquery-mask.js",
                        "~/Scripts/jquery-ui.js"));

			bundles.Add(new ScriptBundle("~/bundles/fileupload").Include(
						"~/bundles/jquery",
						"~/bundles/bootstrap",
						"~/Scripts/fileupload.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
						"~/css/font-awesome.min.css",
						"~/Content/pingendo.css",
						"~/Content/Site.css",
                        "~/Content/jquery-ui.css"));
        }
    }
}
