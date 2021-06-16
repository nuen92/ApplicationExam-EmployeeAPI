using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Models.Request
{
    public class CreateEmployee
    {
        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string LastName { get; set; }

        public string MiddleName { get; set; }
    }
}