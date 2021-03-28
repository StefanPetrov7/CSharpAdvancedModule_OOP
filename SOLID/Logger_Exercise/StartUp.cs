using System;
using System.Collections.Generic;
using System.Linq;
using Logger_Exercise.Appenders;
using Logger_Exercise.Appenders.Contracts;
using Logger_Exercise.Core.Factories;
using Logger_Exercise.Enums;
using Logger_Exercise.Layouts;
using Logger_Exercise.Layouts.Contracts;
using Logger_Exercise.Loggers;
using Logger_Exercise.Loggers.Contracts;

namespace Logger_Exercise
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IAppender> appenders = ReadAppenders(n);
            ILogger logger = new Logger(appenders.ToArray());

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] info = input.Split("|", StringSplitOptions.RemoveEmptyEntries);
                ReportLevel level = Enum.Parse<ReportLevel>(info[0], true);
                string date = info[1];
                string msg = info[2];

                switch (level)
                {
                    case ReportLevel.Info:
                        logger.Info(date, msg);
                        break;
                    case ReportLevel.Warning:
                        logger.Warning(date, msg);
                        break;
                    case ReportLevel.Error:
                        logger.Error(date, msg);
                        break;
                    case ReportLevel.Critical:
                        logger.Critical(date, msg);
                        break;
                    case ReportLevel.Fatal:
                        logger.Fatal(date, msg);
                        break;
                }
            }

            Console.WriteLine(logger);
        }

        private static List<IAppender> ReadAppenders(int n)
        {
            List<IAppender> appenders = new List<IAppender>();
            IAppenderFactory appenderFoctory = new AppenderFactory();
            Dictionary<string, ILayout> layoutTypes = new Dictionary<string, ILayout>()
            {
                { nameof(SimpleLayout), new SimpleLayout()},
                { nameof(XML_Layout), new XML_Layout()},
                { nameof(JSON_Layout), new JSON_Layout()}
            };

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split().ToArray();
                string appenderType = info[0];
                string layoutType = info[1];
                ReportLevel level = info.Length == 3 ? Enum.Parse<ReportLevel>(info[2], true) : ReportLevel.Info;
                IAppender appender = appenderFoctory.CreateAppender(layoutTypes[layoutType], appenderType, level);
                appenders.Add(appender);
            }
            return appenders;
        }
    }
}
