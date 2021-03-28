using Logger_Exercise.Appenders.Contracts;
using Logger_Exercise.Enums;
using Logger_Exercise.Layouts.Contracts;

namespace Logger_Exercise.Core.Factories
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(ILayout layout, string type, ReportLevel level);
    }
}
