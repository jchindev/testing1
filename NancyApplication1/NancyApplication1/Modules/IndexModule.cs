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

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            //commentss
            Get["/"] = parameters =>
            {
                //var vids = new Videos();
                //var testVid = new VideoDto { Angle = "front", Description = "awesome winner", Player = "Federer", Stroke = "forehand", YoutubeId = "asdfsnyew2" };
                //vids.AddVideo(testVid);


                //List<VideoDto> lstVids = vids.GetAll();
                var newsMode = new ValueLookUp().Get("EspnNewsMode");

                var viewModel = new IndexViewModel();
                viewModel.BlogBaseURl = AppSetting.BlogEngineBaseUrl;

                if (newsMode == "server")
                {
                    viewModel.EspnNewsURl = "/services/news";
                }
                else
	            {
                    string clientOnlyUrl = string.Format("{0}?apikey={1}&callback=JSON_CALLBACK", AppSetting.EspnHeadlinesUrl, AppSetting.EspnApiKey);
                    viewModel.EspnNewsURl = clientOnlyUrl;

	            }

                //getting bing search results
                var bing = new BingSearch();
                viewModel.VideoResults = bing.GetVideoSearchResults();

                //return View["index", viewModel].AsCacheable(DateTime.Now.AddSeconds(30));
                return View["index", viewModel];
            };
        }
    }
}