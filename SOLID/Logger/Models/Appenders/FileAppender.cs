using System;
using ExLogger.Models.Contracts;
using ExLogger.Models.Enumerations;
using ExLogger.Models.IOManagment;
using ExLogger.Models.IOManagment.Contracts;

namespace ExLogger.Models.Appenders
{
    public class FileAppender : Appender
    {

        private readonly IWriter writer;

        public FileAppender(ILayout layout, Level level, IFile file) : base(layout, level)
        {
            this.File = file;
            this.writer = new FileWriter(this.File.Path);
        }

        public IFile File { get; }

        public override void Append(IError error)
        {
            string formatedMessage = this.File.Write(this.Layout, error);

            this.writer.WriteLine(formatedMessage);
            this.messagesAppended++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size{this.File.Size }";
        }
    }
}
