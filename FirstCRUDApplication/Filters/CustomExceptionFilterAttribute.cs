using Coffee.Filters.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Filters
{
    public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        ILogger _logger;
        
        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }
        
        public void OnException(ExceptionContext context)
        {
            string actionName = context.ActionDescriptor.DisplayName;
            string exceptionStack = context.Exception.StackTrace;
            string exceptionMessage = context.Exception.Message;

            _logger.LogError(new EventId(0),actionName,exceptionStack,exceptionMessage);

            switch (context.Exception.GetType().Name)
            {
                case nameof(InvalidRefreshTokenException):
                    CreateExceptionExceptionType(context, 400);
                    return;
                case nameof(InvalidCredentialsException):
                    CreateExceptionExceptionType(context,400);
                    return;
            }

            CreateExceptionExceptionType(context,500);
        }

        private void CreateExceptionExceptionType(ExceptionContext context, int statusCode)
        {
            context.Result = new ContentResult
            {
                Content = context.Exception.Message
            };
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = statusCode;
        }
    }
}
