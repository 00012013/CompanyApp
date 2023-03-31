using CompanyManagementApp.Models;
using CompanyManagementApp.Models.Dto;

namespace CompanyManagementApp.Service
{
    public interface IEmployeeService
    {
        public void AddEmployee(AddEmployeeViewModel addEmployeeViewModel);

        public List<Employee> GetAllEmployees();

        public Employee GetEmployee(Guid id);

        public void UpdateEmployee(UpdateEmployee employee);

        public void DeleteEmployee(UpdateEmployee updateEmployee);

    }
}
