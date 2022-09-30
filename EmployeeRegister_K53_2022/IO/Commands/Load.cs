using EmployeeRegister_K53_2022.Models;
using System.Text.Json;

namespace EmployeeRegister_K53_2022.IO.Commands
{
    public class Load : AddAnyModel<DumpPath>, ICommand
    {
        public string Label
        {
            get
            {
                return "load";
            }
        }

        public void Run()
        {
            var DumpPath = LoadProperties();
            using (Stream stream = File.Open(DumpPath.Path, FileMode.Open))
            {

               DumpObject dumpObject = JsonSerializer.Deserialize<DumpObject>(stream);
                if (dumpObject != null)
                {
                    Context.Employees = dumpObject.Employees;
                    Context.Addresses = dumpObject.Addresses;
                    Console.WriteLine("Wczytano baze pracownikow");
                }
            }
        }
    }
}