using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.Base
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate request)
        {
            this._next = request;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExpection(httpContext, ex);
            }
        }

        private async Task HandleExpection(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = (int)(HttpStatusCode.InternalServerError);
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync("{\"data\":\"" + exception.Message + "\",\"status\":false}");
        }
    }
}
