using CompanyManagementApp.Models.Dto;
using CompanyManagementApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyManagementApp.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentsController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult Add()
        {

            var model = new AddDepartment();

            return View(model);
        }

        // Get department list

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var departments = departmentService.GetAllDepartments();
            return View(departments);
        }

        // Add department

        [HttpPost]
        public async Task<IActionResult> Add(AddDepartment addDepartment)
        {
            departmentService.AddDepartment(addDepartment);
            return RedirectToAction("Index");
        }

        // Get Department by Id

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {

            var department = departmentService.GetDepartment(id);

            if (department != null)
            {
                var dep = new UpdateDepartment()
                {
                    Id = department.Id,
                    Name = department.Name
                };
                return await Task.Run(() => View("View", dep));
            }

            return RedirectToAction("Index");

        }


        // Update Employee 

        [HttpPost]
        public async Task<IActionResult> View(UpdateDepartment updateDepartment)
        {
            departmentService.UpdateDepartment(updateDepartment);   
            return RedirectToAction("Index");
        }

        // Delete Employee

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var dep = departmentService.GetDepartment(id);
            departmentService.DeleteDepartment(dep);
            return RedirectToAction("Index");

        }
    }
}
