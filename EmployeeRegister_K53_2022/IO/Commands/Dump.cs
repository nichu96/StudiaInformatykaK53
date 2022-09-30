using EmployeeRegister_K53_2022.Models;
using System.Text.Json;

namespace EmployeeRegister_K53_2022.IO.Commands
{
    public class Dump : AddAnyModel<DumpPath>, ICommand
    {
        public string Label
        {
            get
            {
                return "dump";
            }
        }

        public void Run()
        {
            var DumpPath = LoadProperties();
            using (Stream stream = File.Open(DumpPath.Path, FileMode.Create))
            {
                DumpObject dumpObject = new DumpObject(Context.Employees, Context.Addresses);
                JsonSerializer.Serialize(stream, dumpObject);
                Console.WriteLine("Zapisano baze pracownikow");
            }
        }
    }
}