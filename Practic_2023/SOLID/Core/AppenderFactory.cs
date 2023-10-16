using SOLID.Appenders;
using SOLID.Core.Factories;
using SOLID.Enumerations;
using SOLID.Layouts;
using SOLID.Loggers;

namespace SOLID.Core
{
	public class AppenderFactory : IAppenderFactory
	{
		public AppenderFactory()
		{
		}

        public IAppender CreatAppender(string type, ILayout layout, ReportLevel reportLevel)
        {
            IAppender appender;

            switch (type)
            {
                case nameof(ConsoleAppender):
                    appender = new ConsoleAppender(layout)
                    {
                        ReportLevel = reportLevel
                    };
            break;
                case nameof(FileAppender):
                    appender = new FileAppender(layout, new LogFile())
                    {
                        ReportLevel = reportLevel
                    };
                    break;
                        default:
                    throw new InvalidDataException();
            }

            return appender;
        }
    }
}

