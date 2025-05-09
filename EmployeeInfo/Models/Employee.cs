using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeInfo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string ?Post { get; set; }
        public int? Phone { get; set; }
        public string? Address { get; set; }
        public string?Email { get; set; }
        public  DateTime Date { get; set; }
        public string? Image {  get; set; }
        [NotMapped]
        public IFormFile? ImgFile { get; set; }
        public ICollection<Employee> Employees { get; set; }


    }
}
