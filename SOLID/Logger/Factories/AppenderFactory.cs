using System;
using ExLogger.Common;
using ExLogger.Models.Appenders;
using ExLogger.Models.Contracts;
using ExLogger.Models.Enumerations;

namespace ExLogger.Factories
{
    public class AppenderFactory
    {
        public IAppender CreaterAppender(string appenderType, ILayout layout, Level level, IFile file = null)
        {
            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender" && file != null)
            {
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidOperationException(GlobalConstants.InvalidAppender);
            }

            return appender;
        }
    }
}
