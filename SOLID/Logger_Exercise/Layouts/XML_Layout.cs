using System;
using System.Text;
using Logger_Exercise.Layouts.Contracts;

namespace Logger_Exercise.Layouts
{
    public class XML_Layout : ILayout
    {
        public XML_Layout()
        { }

        public string Template
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<log>");
                sb.AppendLine(" <date>{0}</date>");
                sb.AppendLine(" <level>{1}</level>");
                sb.AppendLine(" <message>{2}</message>");
                sb.AppendLine("</log>");
                return sb.ToString().TrimEnd();
            }
        }
    }
}
