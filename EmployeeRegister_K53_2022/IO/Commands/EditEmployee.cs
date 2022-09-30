using EmployeeRegister_K53_2022.Models;

namespace EmployeeRegister_K53_2022.IO.Commands
{
    public class EditEmployee : AddAnyModel<EditObject>, ICommand
    {
        public string Label
        {
            get
            {
                return "edit employee";
            }
        }

        public void Run()
        {
            var editObject = LoadProperties();
            if (editObject.Key == "Id" || editObject.Key == "EmployeeId")
            {
                Console.WriteLine("Id nie moze byc zmienione");
                return;
            }
            var employee = Context.Employees.Find(e => e.Id == editObject.Id);
            var address = Context.Addresses.Find(e => e.EmployeeId == editObject.Id);
            if (employee == null)
            {
                Console.WriteLine("Pracownik nie istnieje");
                return;
            }
            if (typeof(Employee).GetProperty(editObject.Key) == null)
            {
                if (typeof(Address).GetProperty(editObject.Key) != null)
                {
                    var value = Convert.ChangeType(editObject.Value, typeof(Address).GetProperty(editObject.Key).PropertyType);
                    typeof(Address).GetProperty(editObject.Key).SetValue(address, value);
                }
                else Console.WriteLine("Podany klucz nie istnieje w rekordzie");
            }
            else
            {
                var value = Convert.ChangeType(editObject.Value, typeof(Employee).GetProperty(editObject.Key).PropertyType);
                typeof(Employee).GetProperty(editObject.Key).SetValue(employee, value); 
            }
        }
    }
}