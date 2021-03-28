using System;
using Logger_Exercise.Enums;
using Logger_Exercise.Layouts.Contracts;
using Logger_Exercise.Loggers.Contracts;

namespace Logger_Exercise.Appenders
{
    public class FileAppender : Appender  // Generating msg and appending it to a log file => output.txt.
    {
        private readonly ILogFile logfile;

        public FileAppender(ILayout layout, ILogFile logfile) : base(layout)
        {
            this.logfile = logfile;
        }

        public override void Append(string date, ReportLevel level, string msg)
        {
            if (this.CanAppend(level))
            {
                string content = string.Format(this.layout.Template, date, level, msg) + Environment.NewLine;
                this.MessagesCount += 1;
                logfile.Write(content);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"File size: {this.logfile.Size}";
        }
    }
}
