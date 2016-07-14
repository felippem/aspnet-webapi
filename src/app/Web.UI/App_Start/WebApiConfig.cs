using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace Web.UI
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
                routeTemplate: "{version}/{controller}/{key}",
                defaults: new { key = RouteParameter.Optional }
            );
        }

        #endregion
    }
}
