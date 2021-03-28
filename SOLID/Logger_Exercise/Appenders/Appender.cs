using System;
using Logger_Exercise.Appenders.Contracts;
using Logger_Exercise.Enums;
using Logger_Exercise.Layouts.Contracts;

namespace Logger_Exercise.Appenders
{
    public abstract class Appender : IAppender
    {
        protected readonly ILayout layout;  // => Gives the template. 

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string date, ReportLevel level, string msg);

        protected int MessagesCount { get; set; }

        protected bool CanAppend(ReportLevel level)
        {
            return this.ReportLevel <= level;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, " +
                $"Report level: {this.ReportLevel}, Messages appended: {this.MessagesCount}";
        }
    }
}
