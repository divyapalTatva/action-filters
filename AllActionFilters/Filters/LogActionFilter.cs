using Microsoft.AspNetCore.Mvc.Filters;

namespace AllActionFilters.Filters
{
    public class LogActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"API {context.HttpContext.Request.Path} started at {DateTime.Now}");
            var resultContext = await next();
            Console.WriteLine($"API {context.HttpContext.Request.Path} ended at {DateTime.Now}");
        }

    }
}
