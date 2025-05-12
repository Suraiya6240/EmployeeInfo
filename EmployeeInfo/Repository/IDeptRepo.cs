using EmployeeInfo.Models;

namespace EmployeeInfo.Repository
{
    public interface IDeptRepo
    {
        Task<IEnumerable<Department>> GetAllDepartment();
        Task<Department?> GetDepartmentById(int id);
        Task<Department?> CreateDepartment(Department department);
        Task<Department?> UpdateDepartment(Department department);
        Task<Department?> Delete(int id);

    }
}
