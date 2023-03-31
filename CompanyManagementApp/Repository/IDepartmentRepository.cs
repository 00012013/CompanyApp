using CompanyManagementApp.Models;
using CompanyManagementApp.Models.Dto;

namespace CompanyManagementApp.Repository
{
    public interface IDepartmentRepository
    {
        public Task<Department> GetDepartment(Guid id);

        public Department GetDepartmentById(Guid id);

        public List<Department> GetDepartments();

        public void DeleteDepartment(Department department);

        public void CreateDepartment(Department department);

        public Department GetDepartmentByName(string name);

    }
}
