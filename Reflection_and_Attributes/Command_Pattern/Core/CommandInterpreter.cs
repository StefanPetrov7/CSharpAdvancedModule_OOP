using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";

        public string Read(string args)
        {
            string[] tookens = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = tookens[0] + COMMAND_POSTFIX;
            string[] commandArgs = tookens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(x => x.Name.ToLower() == commandName.ToLower());

            if (commandType==null)
            {
                throw new ArgumentException("Ivalid Type!");
            }

            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType, new object[] { });
            return commandInstance.Execute(commandArgs);
        }
    }
}