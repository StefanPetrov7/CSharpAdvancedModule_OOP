using System;
using System.Collections.Generic;
using ExLogger.Common;
using ExLogger.Core;
using ExLogger.Core.Contracts;
using ExLogger.Factories;
using ExLogger.Models;
using ExLogger.Models.Contracts;
using ExLogger.Models.Enumerations;
using ExLogger.Models.Files;
using ExLogger.Models.IOManagment;
using ExLogger.Models.IOManagment.Contracts;
using ExLogger.Models.PathManagment;

namespace ExLogger
{
    public class StartUp
    {

        static void Main(string[] args)
        {
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();
            int n = int.Parse(Console.ReadLine());   
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IPathManager pathManager = new PathManager("logs","logs.txt");
            IFile file = new LogFile(pathManager);
            ILogger logger = SetUpLogger(n, reader, writer, file, layoutFactory, appenderFactory);
            IEngine engine = new Engine(logger, reader, writer);
            engine.Run();
        }

        private static ILogger SetUpLogger(int appendersCount, IReader reader, IWriter writer, IFile file
            , LayoutFactory layoutFactory, AppenderFactory appenderFactory)
        {

            ICollection<IAppender> appenders = new HashSet<IAppender>();

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appArg = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string appenderType = appArg[0];
                string layoutType = appArg[1];

                bool hasError = false;
                Level level = ParseLevel(appArg, writer, ref hasError);

                if (hasError)
                {
                    continue;
                }

                try
                {
                    ILayout layout = layoutFactory.CreateLayout(layoutType);
                    IAppender appender = appenderFactory.CreaterAppender(appenderType, layout, level, file);
                    appenders.Add(appender);
                }
                catch (InvalidOperationException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            ILogger logger = new Logger(appenders);
            return logger;
        }

        private static Level ParseLevel(string[] levelString, IWriter writer, ref bool hasError)
        {
            Level appenderLevel = Level.INFO;

            if (levelString.Length == 3)
            {

                bool isEnumValid = Enum.TryParse(typeof(Level), levelString[2], true, out object enumParsed);

                if (!isEnumValid)
                {
                    writer.WriteLine(GlobalConstants.InvalidLevelType);
                    hasError = true;
                }

                appenderLevel = (Level)enumParsed;
            }

            return appenderLevel;
        }
    }
}
