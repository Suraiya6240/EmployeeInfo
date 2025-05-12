using EmployeeInfo.Data;
using EmployeeInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInfo.Controllers
{
    public class DepartmentController : Controller
    {   
        private readonly EmployeeDbContext _Db;
        public DepartmentController(EmployeeDbContext db)
        {  _Db = db; }
        public async Task<IActionResult> Index()
        {
            var depList=await _Db.departments.ToListAsync();
            return View(depList);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            var depCD = new Department
            {
                DepartmentName = department.DepartmentName
            };
           await _Db.departments.AddAsync(depCD);
            await _Db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
         var deptEdit=await _Db.departments.FindAsync(id);
            return View(deptEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Department department) 
        {
         var deptUpdate =await _Db.departments.FindAsync(department.Id);
            if(deptUpdate != null)
            {
                deptUpdate.DepartmentName = department.DepartmentName;
            }
            _Db.departments.Update(deptUpdate);
            _Db.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var deptDelete =await _Db.departments.FindAsync(id);
            if(deptDelete != null)
            {
                _Db.departments.Remove(deptDelete);
                _Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
