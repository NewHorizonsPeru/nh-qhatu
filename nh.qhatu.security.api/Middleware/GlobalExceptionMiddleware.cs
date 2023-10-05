﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using nh.qhatu.security.api.Model;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace nh.qhatu.security.api.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception currentException)
        {
            httpContext.Response.ContentType = "application/json";

            var exceptionResponseModel = new ExceptionResponseModel();

            switch(currentException)
            {
                case ApplicationException ex:
                    exceptionResponseModel.StatusCode = (int) HttpStatusCode.BadRequest;
                    exceptionResponseModel.Message = ex.Message;
                    exceptionResponseModel.StackTrace = ex.StackTrace ?? string.Empty;
                    break;
                case NullReferenceException ex:
                    exceptionResponseModel.StatusCode = (int)HttpStatusCode.BadRequest;
                    exceptionResponseModel.Message = ex.Message;
                    exceptionResponseModel.StackTrace = ex.StackTrace ?? string.Empty;
                    break;
                default:
                    exceptionResponseModel.StatusCode = (int)HttpStatusCode.InternalServerError;
                    exceptionResponseModel.Message = "Error interno, vuelva a intentar en unos minutos.";
                    exceptionResponseModel.StackTrace = currentException.StackTrace ?? string.Empty;
                    break;
            }

            var jsonResult = JsonSerializer.Serialize(exceptionResponseModel);
            await httpContext.Response.WriteAsJsonAsync(jsonResult);
        }
    }
}
