using CompanyManagementApp.Data;
using CompanyManagementApp.Models;
using CompanyManagementApp.Models.Dto;
using CompanyManagementApp.Repository;

namespace CompanyManagementApp.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly MVCDbConetext mVCDbConetext;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(MVCDbConetext mVCDbConetext, IEmployeeRepository employeeRepository)
        {
            this.mVCDbConetext = mVCDbConetext;
            this.employeeRepository = employeeRepository;
        }

        public void AddEmployee(AddEmployeeViewModel addEmployeeRequest)
        {

            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
                DepartmentId = addEmployeeRequest.DepartmentId
            };
             employeeRepository.CreateEmployee(employee);
        }

        public List<Employee> GetAllEmployees()
        {   
            return employeeRepository.GetAll();
        } 

        public Employee GetEmployee(Guid id)
        {   
            return employeeRepository.GetById(id);
        }

        public void DeleteEmployee(UpdateEmployee updateEmployee)
        {
            var employee = employeeRepository.GetById(updateEmployee.Id);
            
            if(employee != null)
            {
                employeeRepository.DeleteEmployee(employee);
            }
            
        }

        public void UpdateEmployee(UpdateEmployee updateEmployee)
        {
            var dbEmployee = employeeRepository.GetById(updateEmployee.Id);

            if(dbEmployee != null) {
                dbEmployee.Name = updateEmployee.Name;
                dbEmployee.Email = updateEmployee.Email;
                dbEmployee.Salary = updateEmployee.Salary;
                dbEmployee.DateOfBirth = updateEmployee.DateOfBirth;
                dbEmployee.DepartmentId = updateEmployee.DepartmentId;
                mVCDbConetext.SaveChanges();
            }
        }

    }
}
