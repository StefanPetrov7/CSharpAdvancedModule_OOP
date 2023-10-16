namespace SOLID.Loggers
{
    public class LogFile : ILogFile
    {
        private const string FILE_PATH = "../../../log.txt";

        public LogFile()
        {
        }

        public int Size => File.ReadAllText(FILE_PATH).Where(x => char.IsLetter(x)).Sum(x => x);

        public void Write(string content)
        {
            File.AppendAllText(FILE_PATH, content);
        }
    }
}

