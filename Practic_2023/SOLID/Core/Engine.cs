using SOLID.Appenders;
using SOLID.Core.Factories;
using SOLID.Enumerations;
using SOLID.IO;
using SOLID.Layouts;
using SOLID.Loggers;

namespace SOLID.Core
{
    public class Engine : IEngine
    {
        private readonly IAppenderFactory appenderFactory;
        private readonly ILayoutFactory layoutFactory;
        private IReader reader;
        private IWriter writer;

        public Engine(IAppenderFactory appenderFactory, ILayoutFactory layoutFactory, IReader reader, IWriter writer)
        {
            this.appenderFactory = appenderFactory;
            this.layoutFactory = layoutFactory;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int n = int.Parse(reader.Read());
            IAppender[] appenders = CreateAppenders(n);
            ILogger logger = new Logger(appenders);

            string input;

            while ((input = reader.Read()) != "END")
            {
                string[] parts = input.Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();
                ReportLevel reportLevel = Enum.Parse<ReportLevel>(parts[0], true);
                string date = parts[1];
                string message = parts[2];

                switch (reportLevel)
                {
                    case ReportLevel.Info:
                        logger.Info(date, message);
                        break;
                    case ReportLevel.Warning:
                        logger.Warning(date, message);
                        break;
                    case ReportLevel.Error:
                        logger.Error(date, message);
                        break;
                    case ReportLevel.Critical:
                        logger.Critical(date, message);
                        break;
                    case ReportLevel.Fatal:
                        logger.Fatal(date, message);
                        break;
                }
            }

            writer.WriteLine(logger.ToString());

        }

        private IAppender[] CreateAppenders(int n)
        {
            IAppender[] appenders = new IAppender[n];

            for (int i = 0; i < n; i++)
            {
                string[] appenderParts = reader.Read().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string type = appenderParts[0];
                string layoutType = appenderParts[1];
                ReportLevel reportLevel = appenderParts.Length == 3 ? Enum.Parse<ReportLevel>(appenderParts[2], true) : ReportLevel.Info;
                ILayout layout = this.layoutFactory.CreateLayout(layoutType);
                IAppender appender = this.appenderFactory.CreatAppender(type, layout, reportLevel);
                appenders[i] = appender;
            }
            return appenders;
        }
    }
}

