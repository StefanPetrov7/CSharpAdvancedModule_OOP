using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandPattern.Models
{
    public class HelloCommand : Core.Contracts.ICommand
    {
        public string Execute(string[] args)
        {
            if (args == null) throw new ArgumentNullException(nameof(args));
            if (args.Length != 1) throw new InvalidOperationException("Hello command requires single argument");
            return $"Hello, {args[0]}";
        }
    }
}
