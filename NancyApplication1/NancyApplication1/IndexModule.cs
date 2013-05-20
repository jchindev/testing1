namespace NancyApplication1
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            //commentss
            Get["/"] = parameters =>
            {
                return View["index"];
            };
        }
    }
}