using EmployeeInfo.Data;
using EmployeeInfo.Models;
using EmployeeInfo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInfo.Controllers
{
    public class AdminEmployeeController : Controller
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IImgRepo _imgRepo;
        
        public AdminEmployeeController(IEmployeeRepo employeeRepo, IImgRepo imgRepo)
        { _employeeRepo = employeeRepo;
          _imgRepo = imgRepo;
        }
        
        //employee list
        public async Task<IActionResult> Index()
        {
            var EmployeeList = await _employeeRepo.GetAllEmployees();
            return View(EmployeeList);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            var EmployeeData = new Employee
            {
                Name = employee.Name,
                Post = employee.Post,
                Phone = employee.Phone,
                Address = employee.Address,
                Email = employee.Email,
                Date = employee.Date,
                Image = employee.ImgFile != null ?await _imgRepo.Upload(employee.ImgFile) : null,

            };
            await _employeeRepo.CreateEmployee(EmployeeData);
            //await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Edit(int id)
        {
         var EmployeeEdit =await _employeeRepo.GetEmployeeById(id);
            if (EmployeeEdit != null)
            {
                var editEmployee = new Employee
                {
                    Id = EmployeeEdit.Id,
                    Name = EmployeeEdit.Name,
                    Post = EmployeeEdit.Post,
                    Phone = EmployeeEdit.Phone,
                    Address = EmployeeEdit.Address,
                    Email = EmployeeEdit.Email,
                    Date = EmployeeEdit.Date
                };
                return View(editEmployee);
            }
          return View(null);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            var EmployeeUpdate = new Employee
            //if (EmployeeUpdate != null)
            {
                Id = employee.Id,
                Name = employee.Name,
                Post = employee.Post,
                Phone = employee.Phone,
                Address = employee.Address,
                Email = employee.Email,
                Date = employee.Date,
                Image = employee.ImgFile != null ? await _imgRepo.Upload(employee.ImgFile) : null
                //_context.Employees.Update(EmployeeUpdate);
                //await _context.SaveChangesAsync();
            };
            var updateEmployee = await _employeeRepo.UpdateEmployee(EmployeeUpdate);
            if (updateEmployee != null)
            {
             return RedirectToAction("Index");
            }
               return RedirectToAction("Index");
         
          
        }
        public async Task<IActionResult> Delete(int id)
        {
            var EmployeeDelete = await _employeeRepo.DeleteEmployee(id);
            //if (EmployeeDelete != null)
            //{
            //    _context.Employees.Remove(EmployeeDelete);
            //    _context.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            return RedirectToAction("Index");
        }
    }
}
