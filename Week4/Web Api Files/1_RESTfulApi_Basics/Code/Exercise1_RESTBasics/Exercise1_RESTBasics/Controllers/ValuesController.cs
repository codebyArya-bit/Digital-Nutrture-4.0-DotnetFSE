using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Exercise1_RESTBasics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() =>
            Ok(new[] { "value1", "value2" });

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id) =>
            Ok($"value {id}");

        [HttpPost]
        public ActionResult Post([FromBody] string value) =>
            CreatedAtAction(nameof(Get), new { id = 0 }, value);

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value) =>
            NoContent();

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) =>
            NoContent();
    }
}
