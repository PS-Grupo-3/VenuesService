using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading;

namespace Infrastructure.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is HttpException httpEx)
            {
                context.Result = new ObjectResult(new ApiError { Message = httpEx.Message })
                {
                    StatusCode = httpEx.StatusCode
                };
                context.ExceptionHandled = true;
            }
        }
    }
}