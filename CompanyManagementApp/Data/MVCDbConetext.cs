using CompanyManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagementApp.Data
{
    public class MVCDbConetext : DbContext
    {

        public MVCDbConetext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
