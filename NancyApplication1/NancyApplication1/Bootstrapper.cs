namespace TT.Web
{
    using System.Web.Optimization;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.LightningCache.Extensions;
    using Nancy.Routing;
    using Nancy.TinyIoc;
    using TT.Web.Core;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            //container.Register<WebApplicationService>().AsSingleton();
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            /*enable lightningcache, vary by url params id,query,take and skip*/
            this.EnableLightningCache(container.Resolve<IRouteResolver>(), ApplicationPipelines, new[] { "id", "query", "take", "skip" });

        }
    }
}