using AllActionFilters.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllActionFilters.Controllers.ForActions
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultiDataController : ControllerBase
    {
        public IDictionary<string, MultiDto> KeyValuePairs;

        public MultiDataController() 
        {
            this.KeyValuePairs = new Dictionary<string, MultiDto>
            {
                { "1", new MultiDto { Age = 21, Name = "Alice", Birthday = "21/07/1995" } },
                { "2", new MultiDto { Age = 25, Name = "Bob",   Birthday = "12/03/1998" } },
                { "3", new MultiDto { Age = 27, Name = "Charlie", Birthday = "05/11/1996" } },
                { "4", new MultiDto { Age = 30, Name = "David", Birthday = "15/08/1993" } },
                { "5", new MultiDto { Age = 35, Name = "Eve",   Birthday = "09/01/1988" } }
            };
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(CacheResourceFilter))]
        public IActionResult GetData([FromRoute] string id)
        {
            Console.WriteLine("In GetData", id);
            if (this.KeyValuePairs.ContainsKey(id))
            {
                Console.WriteLine("In GetData - ContainsKey");
                return Ok(this.KeyValuePairs[id]);
            }
            Console.WriteLine("In GetData - Key Not Found");
            return NotFound();
        }

        [HttpPost("extra-ops")]
        [ServiceFilter(typeof(LogActionFilter))]
        public async Task<IActionResult> ExtraOpe()
        {
            // Simulate long-running operation
            await Task.Delay(3000); // 3 seconds delay

            return Ok();
        }

    }

    public class MultiDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthday { get; set; }
    }
}
