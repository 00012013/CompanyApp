using CompanyManagementApp.Models;
using CompanyManagementApp.Models.Dto;

namespace CompanyManagementApp.Service
{
    public interface IDepartmentService
    {
        public List<Department> GetAllDepartments();

        public void CreateFirstDepartments();

        public Task<Department> GetDepartmentById(Guid id);

        public Department GetDepartment(Guid id);

        public void AddDepartment(AddDepartment addDepartment);

        public void UpdateDepartment(UpdateDepartment updateDepartment);

        public void DeleteDepartment(Department department);
    }   
}
