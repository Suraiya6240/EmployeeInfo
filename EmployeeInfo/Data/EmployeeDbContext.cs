using EmployeeInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInfo.Data
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
  
    }
}
