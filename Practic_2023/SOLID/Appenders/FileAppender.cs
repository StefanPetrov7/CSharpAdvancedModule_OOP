using SOLID.Enumerations;
using SOLID.Layouts;
using SOLID.Loggers;

namespace SOLID.Appenders
{
    public class FileAppender : Appender
    {
        private ILogFile logfile;

        public FileAppender(ILayout layout, ILogFile logfile) : base(layout)
        {
            this.logfile = logfile;
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (this.CanAppend(reportLevel))
            {
                this.MessagesCount += 1;
                string content = string.Format(this.layout.Template, date, reportLevel, message) + Environment.NewLine;
                this.logfile.Write(content);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.logfile.Size}";
        }
    }
}

