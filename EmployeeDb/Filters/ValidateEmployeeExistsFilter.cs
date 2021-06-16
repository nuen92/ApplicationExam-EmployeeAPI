using EmployeeService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Filters
{
    public class ValidateEmployeeExistsFilter : IActionFilter
    {
        private readonly IEmployeeService employeeService;

        public ValidateEmployeeExistsFilter(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Console.WriteLine("ValidateEmployeeExistsFilter Executing.");
            var employeeId = (int)context.ActionArguments["employeeId"];
            var isExists = employeeService.IsEmployeeExists(employeeId);
            if (!isExists)
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}