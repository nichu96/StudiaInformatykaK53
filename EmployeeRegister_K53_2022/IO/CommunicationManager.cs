using System.Reflection;

namespace EmployeeRegister_K53_2022.IO
{
    public class CommunicationManager
    {
        public void MainLoop()
        {
            // initialization
            Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

            var types = Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .Where(type => typeof(ICommand).IsAssignableFrom(type) && !type.IsInterface);

            foreach (var type in types)
            {
                ICommand command = (ICommand)Activator.CreateInstance(type);
                commands[command.Label] = command;
            }

            while (true)
            {
                Console.Write("Commands: ");
                foreach (var c in commands.Keys)
                {
                    Console.Write(c+", ");
                }
                Console.Write(System.Environment.NewLine+"#");

                var command = Console.ReadLine().ToLower();
                commands[command].Run();
            }
        }
    }
}
