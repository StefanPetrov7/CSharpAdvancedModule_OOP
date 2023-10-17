using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";

        public string Read(string args)
        {
            string[] tokens = args.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string commandName = tokens[0];
            string[] commandArgs = tokens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(x => x.Name.ToLower() == commandName.ToLower());

            if (commandType == null)
            {
                throw new ArgumentException("Invalid Type");
            }

            ICommand commandInstance = ((ICommand)Activator.CreateInstance(commandType, new object[] { }));
            return commandInstance.Execute(commandArgs);
        }
    }
}

