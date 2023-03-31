namespace CompanyManagementApp.Models
{
    public class Department
    {

        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }

        public Department(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Department()
        {
        }
    }
}
