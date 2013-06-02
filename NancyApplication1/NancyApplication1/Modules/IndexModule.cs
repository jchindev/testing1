namespace TT.Web.Modules
{
    using System.Collections.Generic;
    using Nancy;
    using TT.BizLogic;
    using TT.BizLogic.Dto;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            //commentss
            Get["/"] = parameters =>
            {
                var vids = new Videos();
                var testVid = new VideoDto { Angle = "front", Description = "awesome winner", Player = "Federer", Stroke = "forehand", YoutubeId = "asdfsnyew2" };
               // vids.AddVideo(testVid);


                List<VideoDto> lstVids = vids.GetAll();

                return View["index"];
            };
        }
    }
}