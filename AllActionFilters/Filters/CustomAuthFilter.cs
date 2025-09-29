using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AllActionFilters.Filters
{
    public class CustomAuthFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var headers = context.HttpContext.Request.Headers;

            if (!headers.ContainsKey("X-API-KEY") || headers["X-API-KEY"] != "secret123")
            {
                context.Result = new UnauthorizedObjectResult(new { error = "Invalid API Key" });
            }
        }
    }
}
