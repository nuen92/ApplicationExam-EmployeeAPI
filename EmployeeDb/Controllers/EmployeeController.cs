using EmployeeAPI.Filters;
using EmployeeAPI.Models.Request;
using EmployeeData;
using EmployeeService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeDb.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly ILogger<EmployeeController> logger;

        public EmployeeController(IEmployeeService employeeService,
            ILogger<EmployeeController> logger
            )
        {
            this.employeeService = employeeService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<int> GetAll()
        {
            logger.LogInformation("Getting all employees.");
            var result = employeeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [EmployeeExistsFilter]
        [Route("{employeeId}")]
        public async Task<ActionResult<Employee>> Get(int employeeId)
        {
            var result = await employeeService.GetEmployeeAsync(employeeId);
            logger.LogInformation("Employee: " + JsonSerializer.Serialize(result));

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Post([FromBody] CreateEmployee createEmployee)
        {
            var employee = new Employee
            {
                Id = 0,
                FirstName = createEmployee.FirstName,
                LastName = createEmployee.LastName,
                MiddleName = createEmployee.MiddleName,
                CreatedDate = DateTime.Now
            };
            var result = await employeeService.AddEmployeeAsync(employee);

            if (result < 1)
            {
                return BadRequest();
            }

            logger.LogInformation("Item Added: " + JsonSerializer.Serialize(employee));
            return Ok(employee);
        }

        [HttpPut]
        [EmployeeExistsFilter]
        [Route("{employeeId}")]
        public async Task<IActionResult> Put(int employeeId, [FromBody] UpdateEmployee updateEmployee)
        {
            var itemDetails = await employeeService.GetEmployeeAsync(employeeId);

            var updatedEmployee = new Employee
            {
                Id = itemDetails.Id,
                FirstName = updateEmployee.FirstName,
                LastName = updateEmployee.LastName,
                ModifiedDate = DateTime.Now
            };
            var result = await employeeService.UpdateEmployeeAsync(updatedEmployee);

            if (result < 1)
            {
                return NotFound();
            }

            logger.LogInformation("Employee Updated: " + JsonSerializer.Serialize(updatedEmployee));
            return Ok();
        }

        [HttpDelete]
        [EmployeeExistsFilter]
        [Route("{employeeId}")]
        public async Task<ActionResult> Delete(int employeeId)
        {
            var result = await employeeService.DeleteEmployeeAsync(employeeId);
            if (result < 1)
            {
                return NotFound();
            }
            logger.LogInformation("Deleted Employee Id: " + employeeId.ToString());
            return Ok();
        }
    }
}