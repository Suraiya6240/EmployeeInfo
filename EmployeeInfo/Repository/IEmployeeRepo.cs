using EmployeeInfo.Models;

namespace EmployeeInfo.Repository
{
    public interface IEmployeeRepo
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee?> GetEmployeeById(int id);
        Task<Employee?> CreateEmployee(Employee employee);
        Task<Employee?> UpdateEmployee(Employee employee);
        Task<Employee?> DeleteEmployee(int id);
        Task<IEnumerable<Employee>> GetAllEmployees();
    }
}