using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Bingzer.Butler.Serials
{
    /// <summary>
    /// XML Marshaller
    /// </summary>
    public abstract class XmlMarshaller : IMarshaller
    {
        protected IMarshall Marshall;

        public T Read<T>(T marshall, Stream input) where T : IMarshall
        {
            Marshall = marshall;
            var reader = XmlReader.Create(input);
            var elementStack = new Stack<Element?>();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        var element = new Element(reader.LocalName);
                        ReadAttributes(element.Attributes, reader);
                        elementStack.Push(element);
                        StartElement(element.Name, element.Attributes);
                        break;
                    //                    case XmlNodeType.EndElement:
                    //                        EndElement(elementStack.Pop().Name);
                    //                        break;
                    //                    case XmlNodeType.Attribute:
                    //                        var dictionary = ReadAttributes(reader);
                    //                        StartElement(currentElement, dictionary);
                    //                        break;
                    case XmlNodeType.Text:
                        ReadTextChunk(reader);
                        break;
                }
            }

            while (elementStack.Count > 0)
            {
                EndElement(elementStack.Pop().Value.Name);
            }

            return marshall;
        }

        public T Write<T>(T marshall, Stream output) where T : IMarshall
        {
            var format = new XmlFormat();
            marshall.Serialize(format);

            using (var writer = new StreamWriter(output) { AutoFlush = true })
            {
                writer.Write(format.ToString());
            }
            return marshall;
        }

        protected abstract void StartElement(string element, IDictionary<string, string> attributes);
        protected abstract void Text(char[] ch, int start, int length);
        protected abstract void EndElement(string element);
        protected void AddAttributesToFormat(IFormat format, IDictionary<string, string> attributes)
        {
            foreach (var attribute in attributes)
            {
                format[attribute.Key] = attribute.Value;
            }
        }

        private static void ReadAttributes(IDictionary<string, string> dictionary, XmlReader reader)
        {
            while (reader.MoveToNextAttribute())
            {
                dictionary.Add(reader.Name, reader.Value);
            }
        }

        private void ReadTextChunk(XmlReader reader)
        {
            if (!reader.CanReadValueChunk)
            {
                var value = reader.Value;
                Text(value.ToCharArray(), 0, value.Length);
            }

            // read per chunk
            const int size = 1024;
            var buffer = new char[size];
            var read = 0;
            while ((read = reader.ReadValueChunk(buffer, 0, buffer.Length)) != 0)
            {
                Text(buffer, 0, read);
            }
        }

        public virtual void Dispose()
        {
            Marshall = null;
        }
    }

    struct Element
    {
        private readonly string _name;
        private readonly IDictionary<string, string> _attributes;

        public string Name { get { return _name; } }
        public IDictionary<string, string> Attributes { get { return _attributes; } }

        public Element(string name)
        {
            _name = name;
            _attributes = new Dictionary<string, string>();
        }
    }
}
