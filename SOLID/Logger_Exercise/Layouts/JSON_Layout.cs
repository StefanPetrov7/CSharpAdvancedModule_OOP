using System;
using System.Text;
using Logger_Exercise.Layouts.Contracts;

namespace Logger_Exercise.Layouts
{
    public class JSON_Layout : ILayout
    {
        public JSON_Layout()
        { }

        public string Template
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("log: {{");
                sb.AppendLine("    date: {0},");
                sb.AppendLine("    level: {1},");
                sb.AppendLine("    message: {2}");
                sb.AppendLine("}},");
                return sb.ToString().TrimEnd();
            }
        }
    }
}
