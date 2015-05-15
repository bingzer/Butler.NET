using System.Text;

namespace Bingzer.Butler.Serials
{
    public class XmlFormat : FormatBase
    {
        public override IFormat NewFormat()
        {
            return new XmlFormat();
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Tag)) return "";

            var builder = new StringBuilder();
            builder.Append("<").Append(Tag).Append(BuildAttributes());
            
            if (Content.Length > 0)
                builder.Append(">").Append(Content).Append("</").Append(Tag).Append(">");
            else if (ChildList.Count > 0)
            {
                builder.Append(">");
                ChildList.ForEach(child => builder.Append(child));
                builder.Append("</").Append(Tag).Append(">");
            }
            else
                builder.Append("/>");

            return builder.ToString();
        }

        private string BuildAttributes()
        {
            var builder = new StringBuilder();
            if (Keys.Count > 0)
                builder.Append(" ");
            foreach (var key in Keys)
            {
                builder.Append(key).Append("=\"").Append(this[key]).Append("\"");
                builder.Append(" ");
            }
            if (builder.Length > 0)
                builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }
    }
}
