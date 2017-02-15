using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.Application.AutoMapper;

namespace WebAPI.API
{
    public class Global : HttpApplication
    {
        #region Events

        public void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
        }

        #endregion
    }
}