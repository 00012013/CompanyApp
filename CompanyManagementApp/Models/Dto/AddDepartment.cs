namespace CompanyManagementApp.Models.Dto
{
    public class AddDepartment
    {
        public string Name { get; set; }


        public AddDepartment(string name)
        {
            Name = name;
        }

        public AddDepartment()
        {
        }
    }
}
