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
    using System.Linq;

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

                return View["strokes", viewModel];
            };

             Get["/upload"] = parameters =>
             {
                 var viewModel = new StrokesViewModel();

                 return View["upload", viewModel];
             };

             Post["/upload"] = parameters =>
             {
                 var viewModel = new StrokesViewModel();
                 var strokesDto = new StrokeDto();

                 var file = this.Request.Files.FirstOrDefault();

                 if (file != null)
                 {
                     strokesDto.UserId = 1;
                     strokesDto.StrokeVideo = file.Value;
                     strokesDto.StrokeType = (StrokeType)((int)Request.Form.StrokeType);
                     strokesDto.StrokeAngle = (StrokeAngle)((int)Request.Form.StrokeAngle);

                     var strokesBizObj = new Strokes();
                     strokesBizObj.UploadStroke(strokesDto);

                     viewModel.IsSuccessfulUpload = true;

                 }
                 else
                 {

                 }

                 return View["upload", viewModel];
             };

        }
    }
}