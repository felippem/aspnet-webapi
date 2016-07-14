﻿using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Web.UI.AutoMapper;
using WebAPI.Infra.IoC;

namespace Web.UI
{
    public class Global : HttpApplication
    {
        #region Events

        public void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();

            IoC.Init();
            GlobalConfiguration.Configuration.DependencyResolver = new IoCDependencyResolver();
        }

        #endregion
    }
}