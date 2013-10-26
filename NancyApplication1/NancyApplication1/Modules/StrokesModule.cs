namespace TT.Web.Modules
{
    using System.Collections.Generic;
    using Nancy;
    using TT.BizLogic;
    using TT.BizLogic.Dto;
    using TT.Web.ViewModels;
    using System.Configuration;
    using Common;
    using Nancy.LightningCache.Extensions;
    using System;

    public class StrokesModule : NancyModule
    {
        public StrokesModule() : base("/strokes")
        {
            //commentss
            Get["/forehand"] = parameters =>
            {
                var viewModel = new StrokesViewModel();

                return View["strokes", viewModel];
            };

             Get["/backhand"] = parameters =>
            {
                var viewModel = new StrokesViewModel();

                return View["strokes", viewModel];
            };

             Get["/serve"] = parameters =>
            {
                var viewModel = new StrokesViewModel();

                viewModel.UserStrokeUrl = "https://tennisvids.blob.core.windows.net/serves/WP_20130706_003.mp4";

                return View["strokes", viewModel];
            };
        }
    }
}