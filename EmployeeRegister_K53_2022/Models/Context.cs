namespace EmployeeRegister_K53_2022.Models
{
    [Serializable]
        public class Context  
    {
        public static List<Employee> Employees { get; set; } = new List<Employee>();
        public static List<Address> Addresses { get; set; } = new List<Address>();
    }
}
