using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;
using WebAPI.IoC;

[assembly: WebActivator.PostApplicationStartMethod(typeof(WebAPI.API.App_Start.SimpleInjectorInitializer), "Initialize")]
namespace WebAPI.API.App_Start
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}