using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeRepo(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            var item = await _employeeContext.Employees.FindAsync(id);
            _employeeContext.Employees.Remove(item);
            return await _employeeContext.SaveChangesAsync();
        }

        public IQueryable<Employee> GetAll()
        {
            return _employeeContext.Employees;
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _employeeContext.Employees.FindAsync(id);
        }

        public async Task<int> AddEmployeeAsync(Employee item)
        {
            _employeeContext.Employees.Add(item);
            return await _employeeContext.SaveChangesAsync();
        }

        public async Task<int> UpdateEmployeeAsync(Employee item)
        {
            var employeeToUpdate = await _employeeContext.Employees.FindAsync(item.Id);
            employeeToUpdate.FirstName = item.FirstName;
            employeeToUpdate.MiddleName = item.MiddleName;
            employeeToUpdate.LastName = item.LastName;
            employeeToUpdate.ModifiedBy = item.ModifiedBy;
            employeeToUpdate.ModifiedDate = item.ModifiedDate;
            _employeeContext.Employees.Update(employeeToUpdate);
            return await _employeeContext.SaveChangesAsync();
        }
    }
}