using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace WebAPI.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.Indent = true;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Routes.MapHttpRoute(
                name: "defaultapi",
                routeTemplate: "{version}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "0",
                routeTemplate: "{version}/subsidiary/establishment/{establishmentId}",
                defaults: new { controller = "Subsidiary", action = "ListBy" });
        }
    }
}
