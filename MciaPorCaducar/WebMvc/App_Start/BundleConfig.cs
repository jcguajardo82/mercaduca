using System.Web;
using System.Web.Optimization;

namespace Inspinia_MVC5
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Opera 

            bundles.Add(new StyleBundle("~/OperaContent/css").Include("~/OperaContent/Site.css"));

            //css js boostrap
            bundles.Add(new StyleBundle("~/OperaContentBootstrap/css").Include("~/OperaContent/bootstrap.min.css", "~/OperaContent/Site.css"));
            bundles.Add(new ScriptBundle("~/OperaScriptBootstrap/js").Include("~/OperaScripts/bootstrap.min.js", "~/OperaScripts/jquery-2.1.1.min.js", "~/OperaScripts/Site.js"));

            bundles.Add(new ScriptBundle("~/OperaScripts/js").Include("~/OperaScripts/OperaReglasNegocio.js"));

            #endregion

            bundles.Add(new StyleBundle("~/ContentSite/css").Include("~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/ContentSiteChrome/css").Include("~/Content/SiteChrome.css"));

            bundles.Add(new ScriptBundle("~/ScriptsSite/js").Include("~/Scripts/Site.js"));

            bundles.Add(new ScriptBundle("~/ScriptsSite2/js").Include("~/Scripts/Site.js"));

            bundles.Add(new ScriptBundle("~/ReglasNegocio/js").Include("~/Scripts/ReglasNegocio.js"));

            #region otros navegadores
            // CSS style (bootstrap/inspinia) 
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/animate.css",
                      "~/Content/style.css"));

            // Font Awesome icons
            bundles.Add(new StyleBundle("~/font-awesome/css").Include(
                      "~/fonts/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform()));

            // jQuery 
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.1.min.js"));

            // Bootstrap 
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            // Inspinia script 
            bundles.Add(new ScriptBundle("~/bundles/inspinia").Include(
                      "~/Scripts/plugins/metisMenu/metisMenu.min.js",
                      "~/Scripts/plugins/pace/pace.min.js",
                      "~/Scripts/app/inspinia.js"));

            // SlimScroll 
            bundles.Add(new ScriptBundle("~/plugins/slimScroll").Include(
                      "~/Scripts/plugins/slimscroll/jquery.slimscroll.min.js"));

            // BootBox 
            bundles.Add(new ScriptBundle("~/plugins/bootbox").Include(
                      "~/Scripts/bootbox.min.js"));
            #endregion
        }
    }
}
