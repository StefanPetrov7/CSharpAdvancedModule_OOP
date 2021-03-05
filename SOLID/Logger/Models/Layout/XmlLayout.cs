using System;
using System.Text;
using ExLogger.Models.Contracts;

namespace ExLogger.Models.Layout
{
    public class XmlLayout : ILayout
    {
        public string Format => this.GetFormat();

        private string GetFormat()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine("<log>")
                  .AppendLine("\t<date>{0}</date>")
                  .AppendLine("\t<level>{1}</level>")
                  .AppendLine("\t<messaeg>{2}</message>")
                .AppendLine("<log>");
            return sb.ToString();
        }
    }
}
