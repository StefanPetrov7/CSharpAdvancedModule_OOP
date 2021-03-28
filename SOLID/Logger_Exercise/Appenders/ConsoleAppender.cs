using System;
using Logger_Exercise.Enums;
using Logger_Exercise.Layouts.Contracts;

namespace Logger_Exercise.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        { }

        public override void Append(string date, ReportLevel level, string msg)
        {
            if (this.CanAppend(level))
            {
                string content = string.Format(layout.Template, date, level, msg);
                this.MessagesCount += 1;
                Console.WriteLine(content);
            }
        }
    }
}
