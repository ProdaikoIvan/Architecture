using System.Web.Optimization;

namespace WebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Content/Scripts/jquery/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Content/Scripts/bootstrap.min.js",
                "~/Content/Scripts/bootstrap-datepicker.min.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/Css/bootstrap.min.css",
                "~/Content/Css/sticky-footer.css",
                "~/Content/Css/bootstrap-datepicker.min.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}