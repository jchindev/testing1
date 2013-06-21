using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Net;
using System.Text;

namespace TT.BizLogic
{
    public class BingSearch
    {
        public IEnumerable<SearchResultType> Search<SearchResultType>(string searchTerm, int maxNumResults = 10)
        {
            // Create a Bing container.

            string rootUri = "https://api.datamarket.azure.com/Bing/Search";

            var bingContainer = new BingSearchContainer(new Uri(rootUri));

            // Replace this value with your account key.

            var accountKey = "iSQBkXDEeiJ2/tgd7OYgrtN1XbHiLCRUmzPzU9wW0MI";

            // Configure bingContainer to use your credentials.

            bingContainer.Credentials = new NetworkCredential(accountKey, accountKey);

            DataServiceQuery<SearchResultType> query = null;

            if (typeof(SearchResultType) == new ImageResult().GetType())
            {
                query = bingContainer.Image(searchTerm, null, null, null, null, null, null) as DataServiceQuery<SearchResultType>;
            }

            if (typeof(SearchResultType) == new NewsResult().GetType())
            {
                query = bingContainer.News(searchTerm, null, "en-US", "Moderate", null, null, null, "rt_Sports", "Date") as DataServiceQuery<SearchResultType>;
            }

            if (typeof(SearchResultType) == new WebResult().GetType())
            {
                query = bingContainer.Web(searchTerm, null, null, "en-US", "Moderate", null, null, null) as DataServiceQuery<SearchResultType>;
            }

            if (typeof(SearchResultType) == new VideoResult().GetType())
            {
                query = bingContainer.Video(searchTerm, null, "en-US", "Moderate", null, null, null, "Date") as DataServiceQuery<SearchResultType>;
            }

            if (query == null)
            {
                return null;
            }


            return query.Execute();
        }

        public List<VideoResult>  GetVideoSearchResults()
        {
            var lstVids = new List<VideoResult>();

            //tried limiting search results via Bing API, but damn thing won't listen with
            // query.AddQueryOption("$top", string.Concat("\'", System.Uri.EscapeDataString("10"), "\'"));
            //so have to limit results at application (this) layer
            var vidResults = Search<VideoResult>("atp world tour tennis").Take(10);

            foreach (var vid in vidResults)
            {
                if (vid.MediaUrl.Contains("www.youtube.com"))
                {
                    var embeddedURl = vid.MediaUrl.Replace("watch?v=", "embed/");
                    var vidWithEmbedUrl = new VideoResult { MediaUrl = embeddedURl, Title = vid.Title };
                    lstVids.Add(vidWithEmbedUrl);
                    continue;
                }

                if (vid.MediaUrl.Contains("www.dailymotion.com"))
                {
                    var embeddedURl = vid.MediaUrl.Replace("video/", "embed/video/");
                    var vidWithEmbedUrl = new VideoResult { MediaUrl = embeddedURl, Title = vid.Title };
                    lstVids.Add(vidWithEmbedUrl);
                    continue;
                }
               
            }

            return lstVids;
        }
	}      
}
