// Controllers/ValuesController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Exercise2_SwaggerAndPostman.Controllers
{
    [ApiController]
    [Route("api/emp")]
    public class ValuesController : ControllerBase
    {
        // GET api/emp
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() =>
            Ok(new[] { "value1", "value2" });

        // GET api/emp/AllEmployees
        [HttpGet("AllEmployees")]
        public ActionResult<IEnumerable<string>> GetAll() =>
            Ok(new[] { "Alice", "Bob" });

        // POST api/emp
        [HttpPost]
        public ActionResult Post([FromBody] string value) =>
            CreatedAtAction(nameof(Get), new { id = 0 }, value);

        // PUT api/emp/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value) =>
            NoContent();

        // DELETE api/emp/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) =>
            NoContent();
    }
}
