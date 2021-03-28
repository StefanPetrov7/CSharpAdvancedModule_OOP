using System;
using System.Linq;
using System.Text;
using Logger_Exercise.Appenders.Contracts;
using Logger_Exercise.Enums;
using Logger_Exercise.Loggers.Contracts;

namespace Logger_Exercise.Loggers
{
    public class Logger : ILogger
    {
        private readonly IAppender[] appenders; // With readonly we can initialize it only thru the ctor.

        public Logger(params IAppender[] appenders) // This is how we can add multiple IAppenders upon initialization.
        {
            this.appenders = appenders;
        }

        public void Info(string date, string msg)
        {
            AppendAppenders(date, ReportLevel.Info, msg);
        }

        public void Warning(string date, string msg)
        {
            AppendAppenders(date, ReportLevel.Warning, msg);
        }

        public void Error(string date, string msg)
        {
            AppendAppenders(date, ReportLevel.Error, msg);
        }

        public void Critical(string date, string msg)
        {
            AppendAppenders(date, ReportLevel.Critical, msg);
        }

        public void Fatal(string date, string msg)
        {
            AppendAppenders(date, ReportLevel.Fatal, msg);
        }

        private void AppendAppenders(string date, ReportLevel level, string msg)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(date, level, msg);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var appender in this.appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
