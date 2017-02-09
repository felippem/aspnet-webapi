using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace WebAPI.UI.API
{
    public static class WebApiConfig
    {
        #region Methods

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

            config.Routes.MapHttpRoute(
                name: "1",
                routeTemplate: "{version}/subsidiary/{id}/establishment",
                defaults: new { controller = "Subsidiary", action = "AddEstablishment" });
        }

        #endregion
    }
}
