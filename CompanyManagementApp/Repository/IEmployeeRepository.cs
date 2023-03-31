using CompanyManagementApp.Models;

namespace CompanyManagementApp.Repository
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAll();

        public Employee GetById(Guid id);

        public void CreateEmployee(Employee employee);

        public void UpdateEmployee(Employee employee);
    
        public void DeleteEmployee(Employee employee);
    }
}
