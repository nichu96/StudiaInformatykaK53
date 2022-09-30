namespace EmployeeRegister_K53_2022.IO
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyLabelAttribute: Attribute
    {
        public string Label { get; set; }
        public int Priority { get; set; }
    }
}
