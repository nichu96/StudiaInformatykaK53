using EmployeeRegister_K53_2022.IO;

namespace EmployeeRegister_K53_2022.Models
{
    public class EditObject
    {
        [PropertyLabel(Label = "Id", Priority = 1)]
        public int Id { get; set; }
        [PropertyLabel(Label = "Key", Priority = 2)]
        public string Key { get; set; }
        [PropertyLabel(Label = "Value", Priority = 3)]
        public string Value { get; set; }
    }
}
