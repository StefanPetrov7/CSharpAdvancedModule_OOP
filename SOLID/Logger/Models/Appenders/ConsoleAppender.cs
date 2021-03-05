using System;
using ExLogger.Common;
using ExLogger.Models.Contracts;
using ExLogger.Models.Enumerations;
using ExLogger.Models.IOManagment;
using ExLogger.Models.IOManagment.Contracts;

namespace ExLogger.Models.Appenders
{
    public class ConsoleAppender : Appender
    {
        private readonly IWriter writer;

        public ConsoleAppender(ILayout layout, Level level) : base(layout, level)
        {
            this.writer = new ConsoleWriter();
        }


        public override void Append(IError error)
        {
            string format = this.Layout.Format;
            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formatedString = string.Format
                (format, dateTime.ToString(GlobalConstants.DateTimeFormat), level.ToString(), message);

            this.writer.WriteLine(formatedString);
            this.messagesAppended++;
        }
    }
}
