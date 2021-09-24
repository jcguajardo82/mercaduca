using System.Web;
using System.Web.Optimization;

namespace Inspinia_MVC5
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/Scripts/js").Include("~/Scripts/Site.js"));

            //css js boostrap
            bundles.Add(new StyleBundle("~/ContentBootstrap/css").Include("~/Content/bootstrap.min.css", "~/Content/Site.css"));
            bundles.Add(new ScriptBundle("~/ScriptBootstrap/js").Include("~/Scripts/bootstrap.min.js", "~/Scripts/jquery-2.1.1.min.js", "~/Scripts/Site.js"));

   
        }
    }
}
