using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;
using CursoDotNet.CrossCutting.Contracts.Services;
using CursoDotNet.API.Models;

namespace CursoDotNet.API.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;
        private const string JsonContentType = "application/json";

        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception exception)
            {
                var httpStatusCode = ConfigurateExceptionTypes(exception);

                // set http status code and content type
                httpContext.Response.StatusCode = httpStatusCode;
                httpContext.Response.ContentType = JsonContentType;

                _logger.LogError($"Exception {httpStatusCode}: {exception.Message}");

                // writes / returns error model to the response
                await httpContext.Response.WriteAsync(
                    JsonConvert.SerializeObject(new ErrorDetails
                    {
                        StatusCode = httpStatusCode,
                        Message = exception.Message
                    }));

                httpContext.Response.Headers.Clear();
            }

        }

        private static int ConfigurateExceptionTypes(Exception exception)
        {
            int httpStatusCode;

            // Exception type To Http Status configuration 
            switch (exception)
            {
                case var _ when exception is ValidationException:
                    httpStatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    httpStatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            return httpStatusCode;
        }

    }
}
