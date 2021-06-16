using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData
{
    public interface IEmployeeRepo
    {
        IQueryable<Employee> GetAll();

        Task<int> AddEmployeeAsync(Employee item);

        Task<int> DeleteEmployeeAsync(int id);

        Task<int> UpdateEmployeeAsync(Employee item);

        Task<Employee> GetEmployeeAsync(int id);
    }
}