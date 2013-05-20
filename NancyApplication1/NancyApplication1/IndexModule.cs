namespace NancyApplication1
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            //comment
            Get["/"] = parameters =>
            {
                return View["index"];
            };
        }
    }
}