namespace EmployeeRegister_K53_2022.Models
{
    [Serializable]
    public class DumpObject
    {
        public DumpObject(List<Employee> employees, List<Address> addresses)
        {
            Employees=employees;
            Addresses=addresses;
        }

        public  List<Employee> Employees { get; set; } = new List<Employee>();
        public  List<Address> Addresses { get; set; } = new List<Address>();
    }

}
