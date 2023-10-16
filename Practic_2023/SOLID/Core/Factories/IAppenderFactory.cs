using SOLID.Appenders;
using SOLID.Enumerations;
using SOLID.Layouts;

namespace SOLID.Core.Factories
{
	public interface IAppenderFactory
	{
		IAppender CreatAppender(string type, ILayout layout, ReportLevel reportType);
	}
}

