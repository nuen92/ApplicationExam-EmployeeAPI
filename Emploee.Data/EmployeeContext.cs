using Microsoft.EntityFrameworkCore;

namespace EmployeeData
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost;Database=EmployeeDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}
    }
}