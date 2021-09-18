using Books.Domain.Core.Common;
using Books.Domain.Core.Validator;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate request;
        private readonly ILogger<ErrorMiddleware> logger;
        private readonly IWebHostEnvironment env;

        public ErrorMiddleware(RequestDelegate request, ILogger<ErrorMiddleware> logger,
            IWebHostEnvironment env)
        {
            this.request = request;
            this.logger = logger;
            this.env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await request(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                APIError error = null;
                HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
                if (ex is ValidationException validationException)
                {
                    var details = validationException.Errors.SelectMany(err => {
                        APIValidation apiValidator = (APIValidation)err.FormattedMessagePlaceholderValues?.FirstOrDefault(x => x.Value is APIValidation).Value;
                        if (apiValidator is null)
                        {
                            return null;
                        }
                        return apiValidator.Details.Select(x => new APIErrorDetails(x.propertyName, x.errorMessage));
                    }).Distinct();
                    error = new((int)HttpStatusCode.BadRequest, details);
                    statusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    var detail = env.IsDevelopment() ?
                        new APIErrorDetails(ex.Message, ex.StackTrace?.ToString()) :
                        new APIErrorDetails(ex.Message, null);
                    error = new(context.Response.StatusCode, new List<APIErrorDetails> { detail });
                }
                var errorText = JsonSerializer.Serialize(error);
                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(errorText, Encoding.UTF8).ConfigureAwait(false);
            }
        }
    }
}
