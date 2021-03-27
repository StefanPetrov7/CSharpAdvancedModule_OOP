namespace OnLine_Shop.Core
{
    public interface ICommandInterpreter
    {
        string ExecuteCommands(string[] data, IController controller);
    }
}
