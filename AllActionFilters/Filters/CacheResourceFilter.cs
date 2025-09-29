using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AllActionFilters.Filters
{
    public class CacheResourceFilter : IResourceFilter
    {
        private static readonly Dictionary<string, IActionResult> _cache = new();

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("In CacheFilter");
            var key = context.HttpContext.Request.Path;
            if (_cache.TryGetValue(key, out var cachedResult))
            {
                Console.WriteLine("In CacheFilter - Key Found");
                context.Result = cachedResult;
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var key = context.HttpContext.Request.Path;
            if (!_cache.ContainsKey(key))
            {
                Console.WriteLine("In CacheFilter - Set Key");
                _cache[key] = context.Result!;
            }
        }
    }
}
