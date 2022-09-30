using EmployeeRegister_K53_2022.Models;
using System.Text.Json;

namespace EmployeeRegister_K53_2022.IO.Commands
{
    public class List: ICommand
    {
        public string Label
        {
            get
            {
                return "list";
            }
        }

        public void Run()
        {
            foreach (var employee in Context.Employees)
            {
                var address = Context.Addresses.Find(a => a.EmployeeId == employee.Id);
                var employeeAddress = new
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Age = employee.Age,
                    Sex = employee.Sex,
                    Address = new
                    {
                        PostalCode = address.PostalCode,
                        City = address.City,
                        Street = address.Street,
                        HomeNo = address.HomeNo,
                    }
                };
                string json = JsonSerializer.Serialize(employeeAddress, new JsonSerializerOptions {WriteIndented = true });
                Console.WriteLine(json);
            }
        }
    }
}