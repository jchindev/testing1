using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using Nancy.ViewEngines.Razor;

namespace TT.Web.Core
{
    public abstract class TTRazorViewBase<T> : NancyRazorViewBase
    {
        public Nancy.ViewEngines.Razor.IHtmlString RenderBundleScript(params string[] paths)
        {
            return Html.Raw(Scripts.Render(paths).ToHtmlString());
        }

        public Nancy.ViewEngines.Razor.IHtmlString RenderBundleStyle(params string[] paths)
        {
            return Html.Raw(Styles.Render(paths).ToHtmlString());
        }

    }
}