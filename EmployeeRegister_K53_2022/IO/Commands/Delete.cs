using EmployeeRegister_K53_2022.Models;

namespace EmployeeRegister_K53_2022.IO.Commands
{
    public class Delete : AddAnyModel<EmployeeID>, ICommand
    {
        public string Label
        {
            get
            {
                return "delete";
            }
        }

        public void Run()
        {
            var employeeID = LoadProperties();
            Employee employee = Context.Employees.Find(e => e.Id == employeeID.EmployeeId);
            if (employee != null)
            {
                Context.Employees.Remove(employee);
                Address address = Context.Addresses.Find(e => e.EmployeeId == employeeID.EmployeeId);
                Context.Addresses.Remove(address);
                Console.WriteLine("Uzytkownik o ID "+employeeID.EmployeeId+ " zostal usuniety");
            }
            else { Console.WriteLine("Taki pracownik nie istnieje");}
        }
    }
}
