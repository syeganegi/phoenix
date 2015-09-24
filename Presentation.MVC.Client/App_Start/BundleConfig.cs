// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Client
{
    using System.Web.Optimization;

    /// <summary>
    ///     The bundle config.
    /// </summary>
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        #region Public Methods and Operators

        /// <summary>The register bundles.</summary>
        /// <param name="bundles">The bundles.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/bundles/custom").Include("~/content/js/LoadVeryFirst.js", "~/content/js/custom.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/jquery").Include(
                    "~/content/js/jquery-1.8.3.min.js", 
                    "~/content/js/jquery-ui-1.9.2.custom.js", 
                    "~/content/js/less-1.3.1.min.js", 
                    "~/content/js/jquery.easytabs.min.js", 
                    "~/content/js/respond.min.js", 
                    "~/content/js/jquery.adipoli.min.js", 
                    "~/content/js/jquery.fancybox-1.3.4.pack.js", 
                    "~/content/js/jquery.isotope.min.js", 
                    "~/content/js/jquery.cleditor.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/content/js/jquery-ui-{version}.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/jqueryval").Include(
                    "~/content/js/jquery.unobtrusive*", "~/content/js/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/content/js/modernizr-*"));

            bundles.Add(
                new StyleBundle("~/Content/css/main").Include(
                    "~/Content/css/reset.css", 
                    "~/Content/css/grid.css", 
                    "~/Content/css/font.css", 
                    "~/Content/css/icon.css", 
                    "~/Content/css/fancybox.css", 
                    "~/Content/css/site.css", 
                    "~/Content/css/theme/default.css", 
                    "~/content/css/sasan.css", 
                    "~/content/css/jquery.cleditor.css"));

            BundleTable.EnableOptimizations = true;
        }

        #endregion
    }
}