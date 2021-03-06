﻿using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using WebAPI.API.Models;

namespace WebAPI.API.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext == null)
                return;

            if (actionExecutedContext.Exception != null)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse<ResultViewModel>(new ResultViewModel()
                {
                    Message = actionExecutedContext.Exception.Message,
                    Code = (int)HttpStatusCode.InternalServerError
                });

                actionExecutedContext.Response.StatusCode = HttpStatusCode.InternalServerError;
            }
        }
    }
}