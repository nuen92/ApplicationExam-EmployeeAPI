using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeData;

namespace EmployeeService.Interface
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeAsync(int id);

        IQueryable<Employee> GetAllAsync();

        Task<int> AddEmployeeAsync(Employee item);

        Task<int> UpdateEmployeeAsync(Employee item);

        Task<int> DeleteEmployeeAsync(int id);

        bool IsEmployeeExists(int id);
    }
}