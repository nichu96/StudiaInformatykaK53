using EmployeeRegister_K53_2022.IO;

namespace EmployeeRegister_K53_2022.Models
{
    public class FindObject
    {
        [PropertyLabel(Label = "Key", Priority = 1)]
        public string Key { get; set; }
        [PropertyLabel(Label = "Value", Priority = 2)]
        public string Value { get; set; }
    }
}
