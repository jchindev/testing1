namespace TT.Web.Modules
{
    using System.Collections.Generic;
    using Nancy;
    using TT.BizLogic;
    using TT.BizLogic.Dto;
    using TT.Web.ViewModels;
    using System.Configuration;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            //commentss
            Get["/"] = parameters =>
            {
                var vids = new Videos();
                var testVid = new VideoDto { Angle = "front", Description = "awesome winner", Player = "Federer", Stroke = "forehand", YoutubeId = "asdfsnyew2" };
                //vids.AddVideo(testVid);


                //List<VideoDto> lstVids = vids.GetAll();

                var baseViewModel = new BaseViewModel();
                baseViewModel.BlogBaseURl = ConfigurationManager.AppSettings["BlogEngineBaseUrl"];


                return View["index", baseViewModel];
            };
        }
    }
}