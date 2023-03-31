using CompanyManagementApp.Data;
using CompanyManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagementApp.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly MVCDbConetext mVCDbConetext;

        public DepartmentRepository(MVCDbConetext mVCDbConetext)
        {
            this.mVCDbConetext = mVCDbConetext;
        }

        public void CreateDepartment(Department department)
        {
            mVCDbConetext.Departments.
               Add(department);
            mVCDbConetext.SaveChanges();
        }

        public void DeleteDepartment(Department department)
        {
            mVCDbConetext.Departments.Remove(department);
            mVCDbConetext.SaveChanges();
        }

        public Task<Department> GetDepartment(Guid id)
        {
            return mVCDbConetext.Departments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Department GetDepartmentById(Guid id)
        {
            return mVCDbConetext.Departments.FirstOrDefault(x => x.Id == id);
        }

        public List<Department> GetDepartments()
        {
            return mVCDbConetext.Departments.ToList();
        }

        public Department GetDepartmentByName(string name)
        {
            return mVCDbConetext.Departments.FirstOrDefault(x => x.Name.Equals(name));
        }
    }
}
