using AllActionFilters.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllActionFilters.Controllers.ForActions
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensitiveDataController : ControllerBase
    {
        [HttpGet]
        [ServiceFilter(typeof(CustomAuthFilter))]
        //[ServiceFilter(typeof(ResultLogFilter))]
        public IActionResult GetData([FromHeader(Name = "X-API-KEY")] string specificHeader) => Ok(new { message = "Secure Data" });

        [HttpGet("throw")]
        [ServiceFilter(typeof(GlobalExceptionFilter))]
        public IActionResult ThrowException()
        {
            try
            {
                int x = 0;
                int y = 5 / x;

                return Ok("You will never see this");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
