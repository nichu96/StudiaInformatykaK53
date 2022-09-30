namespace EmployeeRegister_K53_2022.IO
{
    public class AddAnyModel<ModelType> where ModelType : new ()
    {
        public ModelType LoadProperties()
        {
            var model = new ModelType();
            var labeledProperties = 
                typeof(ModelType)
                    .GetProperties()
                    .Where(p => Attribute.IsDefined(p, typeof(PropertyLabelAttribute)))
                    .OrderBy(p => (Attribute.GetCustomAttribute(p, typeof(PropertyLabelAttribute)) as PropertyLabelAttribute).Priority);

            foreach (var property in labeledProperties)
            {
                PropertyLabelAttribute attribute = Attribute.GetCustomAttribute(property, typeof(PropertyLabelAttribute)) as PropertyLabelAttribute;
                while (true)
                {
                    Console.Write($"Type value of {attribute.Label}:");
                    var stringValue = Console.ReadLine();
                    try
                    {
                        var value = Convert.ChangeType(stringValue, property.PropertyType);
                        property.SetValue(model, value);
                        break;
                    }
                    catch (InvalidCastException ex)
                    {
                        Console.WriteLine($"While convertion attemnpt exception occured: {ex.Message}. Try again");
                    }
                }
            }
            return model;
        }
    }
}
