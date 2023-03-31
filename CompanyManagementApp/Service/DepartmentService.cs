using CompanyManagementApp.Data;
using CompanyManagementApp.Models;
using CompanyManagementApp.Models.Dto;
using CompanyManagementApp.Repository;

namespace CompanyManagementApp.Service
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IDepartmentRepository departmentRepository;
        private readonly MVCDbConetext mVCDbConetext;

        public DepartmentService(IDepartmentRepository departmentRepository, MVCDbConetext mVCDbConetext)
        {
            this.departmentRepository = departmentRepository;
            this.mVCDbConetext = mVCDbConetext;
        }

        public List<Department> GetAllDepartments()
        {
            return departmentRepository.GetDepartments(); 
        }

        public void AddDepartment(AddDepartment addDepartment)
        {
            var departments = departmentRepository.GetDepartmentByName(addDepartment.Name);

            if (departments == null) {
                var department = new Department()
                {
                    Id = Guid.NewGuid(),
                    Name = addDepartment.Name
                };
                departmentRepository.CreateDepartment(department);
            }
           
        }

        public void CreateFirstDepartments()
        {
            var departments = GetAllDepartments();
            if ( departments.Count == 0)
            {
                AddDepartment(new AddDepartment("It department"));
                AddDepartment(new AddDepartment("Accounting department"));
                AddDepartment(new AddDepartment("HR department"));
            }
           
        }

        public async Task<Department> GetDepartmentById(Guid id)
        {
            Task<Department> department = departmentRepository.GetDepartment(id);

            var dep = await department;
            return dep;
        }

        public void UpdateDepartment(UpdateDepartment updateDepartment)
        {

            var dbDepartment = departmentRepository.GetDepartmentById(updateDepartment.Id);

            if (dbDepartment != null)
            {
                dbDepartment.Name = updateDepartment.Name;
                mVCDbConetext.SaveChanges();
            }
        }

        public Department GetDepartment(Guid id)
        {
            return departmentRepository.GetDepartmentById(id);
        }

        public void DeleteDepartment(Department department)
        {
            if(department != null)
            {
                departmentRepository.DeleteDepartment(department);
            }
        }
    }
}
