using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Filters
{
    public class EmployeeExistsFilterAttribute : TypeFilterAttribute
    {
        public EmployeeExistsFilterAttribute() : base(typeof(ValidateEmployeeExistsFilter))
        {
        }
    }
}