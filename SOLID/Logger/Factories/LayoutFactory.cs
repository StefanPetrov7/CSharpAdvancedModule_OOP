using System;
using System.Reflection;
using System.Linq;
using ExLogger.Models.Contracts;
using ExLogger.Common;

namespace ExLogger.Factories
{
    public class LayoutFactory
    {

        public ILayout CreateLayout(string layoutTypeStr)
        {
            Assembly assembly = Assembly.GetExecutingAssembly(); //=> getting the current assembly.

            Type layoutType = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name.Equals(layoutTypeStr, StringComparison.InvariantCultureIgnoreCase));

            if (layoutType == null)
            {
                throw new InvalidOperationException(GlobalConstants.InvalidLayoutType);
            }

            object[] argCtor = new object[] { };
            ILayout layout = (ILayout)Activator.CreateInstance(layoutType, argCtor);
            return layout;
        }
    }
}
