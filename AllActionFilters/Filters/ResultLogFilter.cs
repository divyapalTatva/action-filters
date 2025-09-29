using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AllActionFilters.Filters
{
    public class ResultLogFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                context.Result = new ObjectResult(new
                {
                    success = true,
                    data = objectResult.Value
                })
                {
                    StatusCode = objectResult.StatusCode
                };
            }
        }

        public void OnResultExecuted(ResultExecutedContext context) { }
    }
}
