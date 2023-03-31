using CompanyManagementApp.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using CompanyManagementApp.Service;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CompanyManagementApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IDepartmentService departmentService;
        
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService, IDepartmentService departmentService) {
            this.employeeService = employeeService;
            this.departmentService = departmentService;
        }


        [HttpGet]
        public IActionResult Add()
        {
            var departments = departmentService.GetAllDepartments();

            var model = new AddEmployeeViewModel();
            model.DepartmentsSelectList = new List<SelectListItem>();

            foreach(var department in departments)
            {
                model.DepartmentsSelectList.Add(new SelectListItem { Text = department.Name, Value = department.Id.ToString()});
            }

            return View(model);
        }

        // Get employee list

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = employeeService.GetAllEmployees();
            return View(employees);
        }

        // Add employee 

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            employeeService.AddEmployee(addEmployeeRequest);
            return RedirectToAction("Index");
        }

        // Get Employee by Id

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var employee = employeeService.GetEmployee(id);

            if (employee != null)
            {
                var emp = new UpdateEmployee()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    DateOfBirth = employee.DateOfBirth,
                    DepartmentId = employee.DepartmentId,
                    Department = employee.Department
                };
                var departments = departmentService.GetAllDepartments();
               
                emp.DepartmentsSelectList = new List<SelectListItem>();

                foreach (var department in departments)
                {
                    emp.DepartmentsSelectList.Add(new SelectListItem { Text = department.Name, Value = department.Id.ToString() });
                }
                return await Task.Run(() => View("View",emp));
            }

            return RedirectToAction("Index");

        }

        // Update Employee 

        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployee updateEmployee)
        {
            employeeService.UpdateEmployee(updateEmployee);
            return RedirectToAction("Index");
        }

        // Delete Employee

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployee updateEmployee)
        {
            employeeService.DeleteEmployee(updateEmployee);
            return RedirectToAction("Index");

        }
    }
}
