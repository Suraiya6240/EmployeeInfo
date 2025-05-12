using EmployeeInfo.Models;
using EmployeeInfo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeInfo.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDeptRepo _deptRepo;
        public DepartmentController(IDeptRepo deptRepo)
        {
            _deptRepo = deptRepo;
        }
        public async Task<IActionResult> Index()
        {
            var depList = await _deptRepo.GetAllDepartment();
            return View(depList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            await _deptRepo.CreateDepartment(department);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var deptEdit = await _deptRepo.GetDepartmentById(id);
            return View(deptEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Department department)
        {
            var deptUpdate = await _deptRepo.UpdateDepartment(department);
            if (deptUpdate != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var deptDelete = await _deptRepo.Delete(id);
            if (deptDelete != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
