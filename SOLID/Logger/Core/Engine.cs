using System;
using System.Globalization;
using System.Linq;
using ExLogger.Common;
using ExLogger.Core.Contracts;
using ExLogger.Factories;
using ExLogger.Models.Contracts;
using ExLogger.Models.Enumerations;
using ExLogger.Models.Errors;
using ExLogger.Models.IOManagment.Contracts;

namespace ExLogger.Core
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IReader reader;
        private readonly IWriter writer;
       
        public Engine(ILogger logger, IReader reader, IWriter writer) 
        {
            this.logger = logger;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string cmd;

            while ((cmd = this.reader.ReadLine()) != "END")
            {
                string[] args = cmd.Split("|").ToArray();
                string levelStr = args[0];
                string dateTimeStr = args[1];
                string message = args[2];

                bool isLevelValid = Enum.TryParse(typeof(Level), levelStr, true, out object levelObj);

                if (!isLevelValid)
                {
                    writer.WriteLine(GlobalConstants.InvalidLevelType);
                    continue;
                }

                Level level = (Level)levelObj;

                bool isDateTimeValid = DateTime
                    .TryParseExact(dateTimeStr, GlobalConstants.DateTimeFormat,
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);

                if (!isDateTimeValid)
                {
                    writer.WriteLine(GlobalConstants.InvalidDateTime);
                    continue;
                }

                IError error = new Error(dateTime, message, level);
                this.logger.Log(error);
            }

           this.writer.WriteLine(this.logger.ToString()); 
        }
    }
}
