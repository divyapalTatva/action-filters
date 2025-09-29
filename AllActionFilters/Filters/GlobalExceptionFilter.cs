using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AllActionFilters.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var errorResponse = new
            {
                message = "An error occurred",
                detail = context.Exception.Message
            };

            context.Result = new JsonResult(errorResponse)
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}
