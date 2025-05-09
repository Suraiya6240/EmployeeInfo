using EmployeeInfo.Data;
using EmployeeInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInfo.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeDbContext _context;
        public EmployeeRepo(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<Employee?> CreateEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee?> DeleteEmployee(int id)
        {
            var employeeDelete = await _context.Employees.FindAsync(id);
            if (employeeDelete != null)
            {
                _context.Employees.Remove(employeeDelete);
                await _context.SaveChangesAsync();
                return employeeDelete;
            }
            return null;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _context.Employees.FindAsync(id);

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> UpdateEmployee(Employee employee)
        {
            var ExEmployee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
            if (ExEmployee != null)
            {
                ExEmployee.Name = employee.Name;
                ExEmployee.Post = employee.Post;
                ExEmployee.Phone = employee.Phone;
                ExEmployee.Address = employee.Address;
                ExEmployee.Email = employee.Email;
                ExEmployee.Date = employee.Date;
                ExEmployee.Image = employee.Image;
                await _context.SaveChangesAsync();
                return ExEmployee;
            }
            return null;
        }
    }
}
