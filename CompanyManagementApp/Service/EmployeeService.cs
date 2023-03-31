using CompanyManagementApp.Data;
using CompanyManagementApp.Models;
using CompanyManagementApp.Models.Dto;
using CompanyManagementApp.Repository;

namespace CompanyManagementApp.Service
{
    public class EmployeeService : IEmployeeService
    {

        // DI for repository intefaces and DbContext configuration class
        private readonly MVCDbConetext mVCDbConetext;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(MVCDbConetext mVCDbConetext, IEmployeeRepository employeeRepository)
        {
            this.mVCDbConetext = mVCDbConetext;
            this.employeeRepository = employeeRepository;
        }

        // creates employee
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

        // returns list of all employees
        public List<Employee> GetAllEmployees()
        {   
            return employeeRepository.GetAll();
        } 

        // returns employee by Id
        public Employee GetEmployee(Guid id)
        {   
            return employeeRepository.GetById(id);
        }

        // deletes employee
        public void DeleteEmployee(UpdateEmployee updateEmployee)
        {
            var employee = employeeRepository.GetById(updateEmployee.Id);
            
            if(employee != null)
            {
                employeeRepository.DeleteEmployee(employee);
            }
            
        }

        // updates employee
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
