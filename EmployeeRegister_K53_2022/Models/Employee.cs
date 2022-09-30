using EmployeeRegister_K53_2022.IO;

namespace EmployeeRegister_K53_2022.Models
{
    [Serializable]
    public class Employee
    {
        private static int UniqueId = 0;

        public Employee()
        {
            Id = ++UniqueId;
        }

        public int Id { get; set; }
        [PropertyLabel(Label = "first name", Priority = 1)]
        public string FirstName { get; set; }
        [PropertyLabel(Label = "last name", Priority = 2)]
        public string LastName { get; set; }
        [PropertyLabel(Label = "age", Priority = 3)]
        public int Age { get; set; }
        [PropertyLabel(Label = "sex", Priority = 4)]
        public char Sex { get; set; }
    }
}
