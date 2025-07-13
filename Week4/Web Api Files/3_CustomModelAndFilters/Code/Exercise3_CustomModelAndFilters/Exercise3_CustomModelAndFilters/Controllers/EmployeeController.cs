using Exercise3_CustomModelAndFilters.Filters;
using Exercise3_CustomModelAndFilters.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exercise3_CustomModelAndFilters.Controllers
{
    [ApiController]
    [Route("api/employee")]
    [ServiceFilter(typeof(CustomAuthFilter))]            // apply your auth filter
    public class EmployeeController : ControllerBase
    {
        // seed data
        private static List<Employee> GetStandardEmployeeList() => new()
        {
            new Employee {
                Id = 1,
                Name = "Alice",
                Salary = 50000,
                Permanent = true,
                Department = new Department { Id = 1, Name = "HR" },
                Skills = new List<Skill> {
                    new Skill { Id = 1, Name = "Communication" },
                    new Skill { Id = 2, Name = "Recruitment" }
                },
                DateOfBirth = new DateTime(1990, 1, 1)
            },
            new Employee {
                Id = 2,
                Name = "Bob",
                Salary = 60000,
                Permanent = false,
                Department = new Department { Id = 2, Name = "IT" },
                Skills = new List<Skill> {
                    new Skill { Id = 3, Name = "C#" },
                    new Skill { Id = 4, Name = "ASP.NET Core" }
                },
                DateOfBirth = new DateTime(1988, 6, 15)
            }
        };

        // GET all (allow anonymous)
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> Get()
        {
            throw new InvalidOperationException("Test exception for filter");
        }

        // GET by ID
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Employee> Get(int id)
        {
            var emp = GetStandardEmployeeList().FirstOrDefault(e => e.Id == id);
            return emp != null ? Ok(emp) : NotFound();
        }

        // POST create
        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Employee> Post([FromBody] Employee emp)
        {
            if (emp == null) return BadRequest("Employee is required");

            var list = GetStandardEmployeeList();
            emp.Id = list.Max(e => e.Id) + 1;
            list.Add(emp);

            return CreatedAtAction(nameof(Get), new { id = emp.Id }, emp);
        }

        // PUT update
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, [FromBody] Employee emp)
        {
            if (emp == null) return BadRequest("Employee is required");

            var list = GetStandardEmployeeList();
            var existing = list.FirstOrDefault(e => e.Id == id);
            if (existing == null) return NotFound();

            // apply updates
            existing.Name = emp.Name;
            existing.Salary = emp.Salary;
            existing.Permanent = emp.Permanent;
            existing.Department = emp.Department;
            existing.Skills = emp.Skills;
            existing.DateOfBirth = emp.DateOfBirth;

            return NoContent();
        }

        // DELETE remove
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            var list = GetStandardEmployeeList();
            var existing = list.FirstOrDefault(e => e.Id == id);
            if (existing == null) return NotFound();

            list.Remove(existing);
            return NoContent();
        }
    }
}
