using System.Collections.Generic;
using System.Text;

namespace Bingzer.Butler.Serials
{
    public abstract class FormatBase : SortedDictionary<string, object>, IFormat
    {
        protected readonly List<IFormat> ChildList;
        protected readonly StringBuilder Content;
        public IEnumerable<IFormat> Children { get { return ChildList; } }

        public new object this[string key]
        {
            get
            {
                if (!ContainsKey(key))
                    base[key] = null;
                return base[key];
            }
            set { base[key] = value; }
        }

        public string Tag { get; set; }

        protected FormatBase()
        {
            Tag = "";
            ChildList = new List<IFormat>();
            Content = new StringBuilder();
        }

        public IFormat Append(object any)
        {
            Content.Append(any);
            return this;
        }

        public IFormat Append(string any)
        {
            Content.Append(any);
            return this;
        }

        public IFormat Append(char[] str, int offset, int len)
        {
            Content.Append(str, offset, len);
            return this;
        }

        public IFormat AppendFormat(string format, params object[] any)
        {
            Content.AppendFormat(format, any);
            return this;
        }

        public string GetContent()
        {
            return Content.ToString();
        }

        public IFormat NewFormat(string tag)
        {
            var format = NewFormat();
            format.Tag = tag;
            return format;
        }

        public void AddChild(IFormat child)
        {
            ChildList.Add(child);
        }

        public void ClearChildren()
        {
            Content.Clear();
        }

        public abstract IFormat NewFormat();

    }
}
