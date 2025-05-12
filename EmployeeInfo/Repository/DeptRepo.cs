using EmployeeInfo.Data;
using EmployeeInfo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace EmployeeInfo.Repository
{
    public class DeptRepo : IDeptRepo
    {
        private readonly EmployeeDbContext _Context;
        public DeptRepo(EmployeeDbContext Context)
        {
            _Context = Context;
        }

        public async Task<Department?> CreateDepartment(Department department)
        {
            await _Context.departments.AddAsync(department);
            await _Context.SaveChangesAsync();
            return department;
        }

        public async Task<Department?> Delete(int id)
        {
            var DepartmentDelete = await _Context.departments.FindAsync(id);
            if (DepartmentDelete != null)
            {
                _Context.departments.Remove(DepartmentDelete);
                await _Context.SaveChangesAsync();
                return DepartmentDelete;
            }
            return null;
        }

        public async Task<IEnumerable<Department>> GetAllDepartment()
        {
            return await _Context.departments.ToListAsync();
        }

        public async Task<Department?> GetDepartmentById(int id)
        {
            return await _Context.departments.FindAsync(id);
        }

        public async Task<Department?> UpdateDepartment(Department department)
        {
            var deptUpdate = await _Context.departments.FindAsync(department.Id);
            if (deptUpdate != null)
            {
                deptUpdate.DepartmentName = department.DepartmentName;
                await _Context.SaveChangesAsync();
                return deptUpdate;
            }
            return null;
        }
    }
}
