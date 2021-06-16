using EmployeeData;
using EmployeeService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Service
{
    public class EmpService : IEmployeeService
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmpService(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            return await employeeRepo.AddEmployeeAsync(employee);
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            return await employeeRepo.DeleteEmployeeAsync(id);
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await employeeRepo.GetEmployeeAsync(id);
        }

        public IQueryable<Employee> GetAllAsync()
        {
            return employeeRepo.GetAll();
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            return await employeeRepo.UpdateEmployeeAsync(employee);
        }

        public bool IsEmployeeExists(int id)
        {
            return employeeRepo.GetAll().ToList().Where(e => e.Id == id).Any();
        }
    }
}