using CompanyManagementApp.Data;
using CompanyManagementApp.Models;
using CompanyManagementApp.Models.Dto;
using CompanyManagementApp.Repository;

namespace CompanyManagementApp.Service
{
    public class DepartmentService : IDepartmentService
    {

        // DI for repository intefaces 

        private readonly IDepartmentRepository departmentRepository;
        private readonly MVCDbConetext mVCDbConetext;

        public DepartmentService(IDepartmentRepository departmentRepository, MVCDbConetext mVCDbConetext)
        {
            this.departmentRepository = departmentRepository;
            this.mVCDbConetext = mVCDbConetext;
        }

        // returns list of all departments
        public List<Department> GetAllDepartments()
        {
            return departmentRepository.GetDepartments(); 
        }

        // creates department
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

        // Creates departmetn if no departments in database
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

        // returns department by Id
        public async Task<Department> GetDepartmentById(Guid id)
        {
            Task<Department> department = departmentRepository.GetDepartment(id);

            var dep = await department;
            return dep;
        }
        // Updates department
        public void UpdateDepartment(UpdateDepartment updateDepartment)
        {

            var dbDepartment = departmentRepository.GetDepartmentByName(updateDepartment.Name);

            if (dbDepartment != null)
            {
                dbDepartment.Name = updateDepartment.Name;
                mVCDbConetext.SaveChanges();
            }
        }
        // returns department by Id
        public Department GetDepartment(Guid id)
        {
            return departmentRepository.GetDepartmentById(id);
        }
        // Deletes department 
        public void DeleteDepartment(Department department)
        {
            if(department != null)
            {
                departmentRepository.DeleteDepartment(department);
            }
        }
    }
}
