using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string commandTypeNameSuffix = "Command";
        public string Read(string args)
        {
            if (string.IsNullOrWhiteSpace(args))
                throw new ArgumentNullException(nameof(args));

            string[] tokens = args.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string commandType = tokens[0];
            Assembly assembly = Assembly.GetCallingAssembly();

            Type command = FindCommandType(assembly, commandType);

            if (command == null)
                throw new InvalidOperationException("Command type was incorrect");

            ICommand commandInstance = Activator.CreateInstance(command) as ICommand;
            string result = commandInstance.Execute(tokens[1..]);
            return result;
        }

        private static Type FindCommandType(Assembly assembly, string commandType)
        {
            string expectedCommandName = commandType + commandTypeNameSuffix;
            Type[] types = assembly.GetTypes();
            Type commandInterfaceType = typeof(ICommand);

            foreach (var type in types.Where(x => x.IsClass && !x.IsAbstract))
            {
                bool isCommand = type.IsAssignableTo(commandInterfaceType);

                if (isCommand && type.Name == expectedCommandName)
                    return type;
            }

            return null;
        }
    }
}
