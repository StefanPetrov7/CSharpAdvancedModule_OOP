using System.Collections.Generic;
using System.Linq;
using CosmosX.Core.Contracts;

namespace CosmosX.Core
{
    public class CommandParser : ICommandParser
    {
        private const string CommandNameSuffix = " Command";

        private readonly IManager reactorManager;

        public CommandParser(IManager reactorManager)
        {
            this.reactorManager = reactorManager;
        }

        public string Parse(IList<string> arguments)
        {
            string command = arguments[0] + CommandNameSuffix;

            string[] commandArguments = arguments.Skip(1).ToArray();

            string result = string.Empty;

            switch (command)
            {
                case "Reactor Command":
                    result = this.reactorManager.ReactorCommand(commandArguments);
                    break;
                case "Module Command":
                    result = this.reactorManager.ModuleCommand(commandArguments);
                    break;
                case "Report Command":
                    result = this.reactorManager.ReportCommand(commandArguments);
                    break;
                case "Exit Command":
                    result = this.reactorManager.ExitCommand(commandArguments);
                    break;
            }

            return result;
        }
    }
}