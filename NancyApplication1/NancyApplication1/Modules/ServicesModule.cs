namespace TT.Web.Modules
{
    using System.Collections.Generic;
    using Nancy;
    using TT.BizLogic;
    using TT.BizLogic.Dto;
    using TT.Web.ViewModels;
    using System.Configuration;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using System.Net;
    using Nancy.LightningCache.Extensions;
    using System;

    public class ServicesModule : NancyModule
    {
        public ServicesModule():base("/services")
        {
            Get["/news"] = _ =>
            {
                using (var client = new WebClient())
                {
                    var url = string.Format("{0}?apikey={1}", AppSetting.EspnHeadlinesUrl, AppSetting.EspnApiKey);

                    var textData = client.DownloadString(url);
                    return Response.AsText(textData).AsCacheable(DateTime.Now.AddHours(4));
                }
            };

            Get["/news/CachedResponse"] = _ =>
            {
                /*cache response*/
                return Response.AsText("hello").AsCacheable(DateTime.Now.AddSeconds(3000));
            };
        }
    }
}