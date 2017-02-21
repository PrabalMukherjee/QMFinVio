using System.Web;
using System.Web.Optimization;

namespace QMFinVioData
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/site.css",
					  "~/bower_components/angular-ui-grid/ui-grid.css",
                      "~/bower_components/angular-material/angular-material.css"));

			bundles.Add(new ScriptBundle("~/bundles/angular").Include(
					 "~/Scripts/angular.js",
					 "~/Scripts/angular-touch.js",
					 "~/Scripts/angular-animate.js",
                     "~/Scripts/angular-route.js",
                     "~/bower_components/angular-ui-grid/ui-grid.js",
                     "~/bower_components/angular-material/angular-material.js",
                     "~/bower_components/angular-aria/angular-aria.js",
                     "~/UI/mainApp.js",
                     "~/UI/services/searchComplains.js",
                     "~/UI/controllers/uiSearchController.js",
                     "~/UI/services/fvConstants.js"
                    ));
		}
	}
}
