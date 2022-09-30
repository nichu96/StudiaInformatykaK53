namespace EmployeeRegister_K53_2022.IO
{
    public interface ICommand
    {
        public string Label { get; }

        public void Run();
    }
}
