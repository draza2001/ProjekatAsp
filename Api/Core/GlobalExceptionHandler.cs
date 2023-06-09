using Microsoft.AspNetCore.Http;
using ProjekatASP.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Newtonsoft.Json;

namespace Api.Core
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception e)
            {
                httpContext.Response.ContentType = "application/json";
                object response = null;
                var statusCode = StatusCodes.Status500InternalServerError;
                var date = DateTime.UtcNow;
                switch (e)
                {
                    case UnauthorizedUseCaseExceptiion _:
                        statusCode = StatusCodes.Status403Forbidden;
                        response = new
                        {
                            message = "You are not allowed to execute this operation",
                            date = DateTime.UtcNow
                };

                        break;
                    case EntityNotFoundException _:
                        statusCode = StatusCodes.Status422UnprocessableEntity;
                        response = new
                        {
                            message = "Resource not found",
                            date = DateTime.UtcNow
                        };
                        break;
                    case ValidationException  validationException:
                        statusCode = StatusCodes.Status422UnprocessableEntity;
                        response = new
                        {
                            message = "Failed due to validation errors.",
                            date = DateTime.UtcNow,
                            errors = validationException.Errors.Select(x=>new 
                            { 
                                x.PropertyName,
                                x.ErrorMessage
                            })
                        };
                        break;
                    case DeletedException _:
                        statusCode = StatusCodes.Status406NotAcceptable;
                        response = new
                        {
                            message = "Entity already deleted.",
                            date = DateTime.UtcNow
                        };
                        break;
                    case CredentialsException _:
                        statusCode = StatusCodes.Status404NotFound;
                        response = new
                        {
                            message = "User not found.",
                            date = DateTime.UtcNow
                        };
                        break;

                }
                httpContext.Response.StatusCode = statusCode;
                if (response != null)
                {
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    return;
                }
                await Task.FromResult(httpContext.Response);
            }
        }
    }
}
