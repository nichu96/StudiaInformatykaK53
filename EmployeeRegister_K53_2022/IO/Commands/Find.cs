using EmployeeRegister_K53_2022.Models;
using System.Text.Json;

namespace EmployeeRegister_K53_2022.IO.Commands
{
    public class Find : AddAnyModel<FindObject>, ICommand
    {
        public string Label
        {
            get
            {
                return "find";
            }
        }

        public void Run()
        {
            var findObject = LoadProperties();
            var employeesObject = Context.Employees.Select(e => new
            {
                e.Id,
                e.FirstName,
                e.LastName,
                e.Age,
                e.Sex,
                Address = Context.Addresses.Find(a => a.EmployeeId == e.Id)
            }).ToList();
            var temp = typeof(Employee).GetProperty(findObject.Key);
            if (temp == null)
            {
                var temp2 = typeof(Address).GetProperty(findObject.Key);
                if (temp2 != null)
                {
                    employeesObject.ForEach(e =>
                    {
                     var elemAddress = e.Address.GetType().GetProperty(findObject.Key).GetValue(e.Address, null).ToString();
                     bool isMatched = temp2.PropertyType.Equals(typeof(int)) ? elemAddress.Equals(findObject.Value) : elemAddress.StartsWith(findObject.Value, StringComparison.OrdinalIgnoreCase);
                        if (isMatched)
                        {
                            string json = JsonSerializer.Serialize(e, new JsonSerializerOptions { WriteIndented = true });
                            Console.WriteLine(json);
                        }
                    });
                }
            }
            else
            {
                employeesObject.ForEach(e =>
                {
                    var elem = e.GetType().GetProperty(findObject.Key).GetValue(e, null).ToString();
                    bool isMatched = temp.PropertyType.Equals(typeof(int)) ? elem.Equals(findObject.Value): elem.StartsWith(findObject.Value, StringComparison.OrdinalIgnoreCase);   
                    if (isMatched)
                    {
                        string json = JsonSerializer.Serialize(e, new JsonSerializerOptions { WriteIndented = true });
                        Console.WriteLine(json);
                   }
                });
            }
        }
    }
}
