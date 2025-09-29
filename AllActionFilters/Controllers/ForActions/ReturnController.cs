using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllActionFilters.Controllers.ForActions
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnController : ControllerBase
    { 

        // IActionResult return
        [HttpGet("IActionResult/{id}")]
        public IActionResult GetUserActionResult(int id)
        {
            if (id <= 0) return BadRequest("Invalid ID");

            var user = new UserDto { Id = id, Name = "Bob" };
            return Ok(user); // 200 OK with JSON
        }

        // ActionResult<T> return (strongly typed)
        [HttpGet("ActionResult-t/{id}")]
        public ActionResult<UserDto> GetUserActionResultT(int id)
        {
            if (id <= 0) return BadRequest("Invalid ID");

            var user = new UserDto { Id = id, Name = "Charlie" };
            return user; // automatically wrapped in Ok(user)
        }

        // Async IActionResult
        [HttpGet("async-IActionResult/{id}")]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            await Task.Delay(500); // simulate async operation
            if (id <= 0) return BadRequest("Invalid ID");

            var user = new UserDto { Id = id, Name = "David" };
            return Ok(user);
        }

        // Async ActionResult<T>
        [HttpGet("async-ActionResult-t/{id}")]
        public async Task<ActionResult<UserDto>> GetUserAsyncT(int id)
        {
            await Task.Delay(500); // simulate async operation
            if (id <= 0) return NotFound();

            return new UserDto { Id = id, Name = "Eve" };
        }

        // Simple DTO return
        [HttpGet("dto/{id}")]
        public UserDto GetUserDirect(int id)
        {
            return new UserDto { Id = id, Name = "Alice" };
        }

        // JsonResult
        [HttpGet("json/{id}")]
        public JsonResult GetJson(int id)
        {
            return new JsonResult(new { Id = id, Name = "Frank" });
        }

        // ContentResult
        [HttpGet("content/{id}")]
        public ContentResult GetContent(int id)
        {
            return Content($"User ID: {id}, Name: Grace", "text/plain");
        }

        // StatusCodeResult
        [HttpGet("status/{id}")]
        public IActionResult GetStatusCode(int id)
        {
            if (id <= 0) return StatusCode(400); // Bad Request
            return StatusCode(204); // No Content
        }

        // FileResult
        [HttpGet("file")]
        public IActionResult GetFile()
        {
            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes("Hello File!");
            return File(fileBytes, "text/plain", "demo.txt");
        }
    }


    // Sample DTO
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
