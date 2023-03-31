using CompanyManagementApp.Data;
using CompanyManagementApp.Models;
using CompanyManagementApp.Service;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagementApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MVCDbConetext mVCDbConetext;

        public EmployeeRepository(MVCDbConetext mVCDbConetext)
        {
            this.mVCDbConetext = mVCDbConetext;
        }

        public void CreateEmployee(Employee employee)
        {
            mVCDbConetext.Employees.Add(employee);
            mVCDbConetext.SaveChanges();   
        }

        public void DeleteEmployee(Employee employee)
        {
            mVCDbConetext.Employees.Remove(employee);
            mVCDbConetext.SaveChanges();
          
        }

        public List<Employee> GetAll()
        {
            return mVCDbConetext.Employees.Include(e => e.Department).ToList();;
        }

        public Employee GetById(Guid id)
        {
           return mVCDbConetext.Employees.Include(e => e.Department).FirstOrDefault(x => x.Id == id);
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
