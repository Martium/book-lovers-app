using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Martium.BookLovers.Api.Contracts.Errors;
using Microsoft.AspNetCore.Http;

namespace Martium.BookLovers.Api.Host.Errors
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
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
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            ApiError error;

            switch (exception)
            {
                case BadRequestException badRequestException:
                    context.Response.StatusCode = (int)badRequestException.StatusCode;
                    error = new ApiError
                    {
                        Reason = badRequestException.Reason,
                        Message = badRequestException.Message
                    };
                    break;
                case NotFoundException notFoundException:
                    context.Response.StatusCode = (int)notFoundException.StatusCode;
                    error = new ApiError
                    {
                        Reason = notFoundException.Reason,
                        Message = notFoundException.Message
                    };
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    error = new ApiError
                    {
                        Reason = "internalServerError",
                        Message = "Internal server error occured."
                    };
                    break;
            }

            return context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }
    }
}
