using System.Web;
using System.Web.Optimization;

namespace CraftStore
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Don't want the 300+MB server memmory load and 7MB+ client load
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-2.1.1.min.js",
                "~/Scripts/jquery-ui.min-1.11.1.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/three.min.js",
                "~/Scripts/site.js",
                "~/Scripts/respond.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/scriptsMJGLight").Include(
                "~/Scripts/jquery-2.1.1.min.js",
                "~/Scripts/jquery-ui.min-1.11.1.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/three.min.js",
                "~/Scripts/jquery.easing.1.3.js",
                "~/Scripts/jquery-animate-css-rotate-scale.js",
                "~/Scripts/jquery-css-transform.js",
                "~/Scripts/isotope.pkgd.min.js",
                "~/Scripts/modernizr-2.8.3.js",
                "~/Scripts/site.js",
                "~/Scripts/captcha.js",
                "~/Scripts/respond.min.js"));

            //"~/Scripts/MJGLight/jquery.cookie.js",

            bundles.Add(new ScriptBundle("~/bundles/scriptsMJG").Include(
                "~/Scripts/jquery-2.1.1.min.js",
                "~/Scripts/jquery-ui.min-1.11.1.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/jquery.easing.1.3.js",
                "~/Scripts/backstrech.js",
                "~/Scripts/detectmobilebrowser.js",
                "~/Scripts/owl.carousel.min.js",
                "~/Scripts/lightbox.min.js",
                "~/Scripts/wow.js",
                "~/Scripts/functions.min.js",
                "~/Scripts/initialise-functions.js",
                "~/Scripts/three.min.js",
                "~/Scripts/site.js",
                "~/Scripts/captcha.js",
                "~/Scripts/respond.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/pagefx").Include(
                "~/Scripts/masonry.pkgd.min.js",
                "~/Scripts/jquery.zoom.min.js",
                "~/Scripts/AnimOnScroll.js",
                "~/Scripts/classie.js",
                "~/Scripts/imagesloaded.js",
                "~/Scripts/util.js"));

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                "~/Scripts/util.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            // "Single Responsibility" design - keep parts for any tools separate to include when you need them
            bundles.Add(new ScriptBundle("~/bundles/wow").Include(
                "~/Content/wow/wowslider.js",
                "~/Content/wow/script.js"
            ));

            // "Single Responsibility" design - keep parts for any tools separate to include when you need them
            bundles.Add(new StyleBundle("~/Content/wow").Include(
                      "~/Content/wow/style.css"
                //          "~/Content/wow/style.mod.css"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/site.css",
                "~/Content/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/cssMJG").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/bootstrap-theme.min.css",
                "~/Content/owl.carousel.css",
                "~/Content/owl.theme.css",
                "~/Content/owl.transitions.css",
                "~/Content/animate.css",
                "~/Content/font-awesome.min.css",
                "~/Content/lightbox.css",
                "~/Content/styles.css",
                "~/Content/custom.css"));


            bundles.Add(new StyleBundle("~/Content/cssMJGLight").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/MJGLight/bootstrap-responsive.css",
                "~/Content/font-awesome.min.css",
                "~/Content/MJGLight/font-awesome-ie7.min.css",
                "~/Content/MJGLight/isotope.css",
                "~/Content/MJGLight/style.css",
                "~/Content/MJGLight/style-bgd-kinda-jean.css",
                "~/Content/MJGLight/style-color-SteelBlue.css"
                ));
            bundles.Add(new StyleBundle("~/Content/cssShoppingCart").Include(
                "~/Content/themes/base/all.css",
                "~/Content/ShoppingCart/ShoppingCart.css"));

        }
    }
}
