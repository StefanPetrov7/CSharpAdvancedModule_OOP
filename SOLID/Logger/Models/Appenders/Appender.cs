using System;
using ExLogger.Models.Contracts;
using ExLogger.Models.Enumerations;

namespace ExLogger.Models.Appenders
{
    public abstract class Appender : IAppender
    {
        protected int messagesAppended;

        protected Appender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; }

        public Level Level { get; }

        public abstract void Append(IError error);


        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: " +
                $"{this.Layout.GetType().Name}, Report level: " +
                $"{this.Level.ToString()}, Messages appended: " +
                $"{this.messagesAppended};";
        }
    }
}
