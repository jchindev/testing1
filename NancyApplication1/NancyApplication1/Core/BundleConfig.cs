using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Transformers;

namespace TT.Web.Core
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var cssTransformer = new CssTransformer();
            var jsTransformer = new JsTransformer();
            var nullOrderer = new NullOrderer();

            var js = new ScriptBundle("~/bundles/js").Include(
                 "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/less.min.js",
                "~/Scripts/moment.js",
                "~/Scripts/main.js",
                "~/Scripts/jquery.quick.pagination.min.js",
                "~/Scripts/bootstrap-fileupload.min.js"
                );

            js.Transforms.Add(jsTransformer);
            js.Orderer = nullOrderer;

            bundles.Add(js);

            var css = new StyleBundle("~/bundles/css").Include(
                 "~/Content/less/bootstrap.less",
                "~/Content/styles.css",
                "~/Content/custom.css",
                "~/Content/bootstrap-fileupload.min.css"
                );
            css.Transforms.Add(cssTransformer);
            css.Orderer = nullOrderer;


            bundles.Add(css);

        }
    }
}