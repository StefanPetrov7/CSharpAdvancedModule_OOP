using System;
using Logger_Exercise.Appenders;
using Logger_Exercise.Appenders.Contracts;
using Logger_Exercise.Enums;
using Logger_Exercise.Layouts.Contracts;
using Logger_Exercise.Loggers;
using Logger_Exercise.Loggers.Contracts;

namespace Logger_Exercise.Core.Factories
{
    public class AppenderFactory : IAppenderFactory
    {

        public IAppender CreateAppender(ILayout layout, string type, ReportLevel level)
        {
            IAppender appender;

            switch (type)
            {
                case nameof(ConsoleAppender):
                    appender = new ConsoleAppender(layout)
                    {
                        ReportLevel = level // => Initializing public prop directly from the here.
                    };
                    break;
                case nameof(FileAppender):
                    appender = new FileAppender(layout, new LogFile())
                    {
                        ReportLevel = level
                    };
                    break;
                default:
                    throw new ArgumentException("Type is invalid Appender");
            }

            return appender;

        }
    }
}
