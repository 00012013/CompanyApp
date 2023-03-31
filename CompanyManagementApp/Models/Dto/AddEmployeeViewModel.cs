using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyManagementApp.Models.Dto
{
    public class AddEmployeeViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public long Salary { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Guid DepartmentId { get; set; }

        public List<SelectListItem> DepartmentsSelectList { get; set; }
    }
}
