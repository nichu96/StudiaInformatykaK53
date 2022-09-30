using EmployeeRegister_K53_2022.Models;

namespace EmployeeRegister_K53_2022.IO.Commands
{
    public class AddEmployee : AddAnyModel<Employee>, ICommand
    {
        public string Label 
        { 
            get 
            {
                return "add employee"; 
            } 
        }

        public void Run()
        {
            var employee = LoadProperties();
            var address = (new AddAnyModel<Address>()).LoadProperties();
            Context.Employees.Add(employee);
            Context.Addresses.Add(address);
        }
    }
}
