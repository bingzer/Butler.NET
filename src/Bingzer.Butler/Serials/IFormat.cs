using System.Collections.Generic;

namespace Bingzer.Butler.Serials
{
    /// <summary>
    /// Base format for Marshalling an object
    /// </summary>
    public interface IFormat 
    {
        /// <summary>
        /// Tag
        /// </summary>
        string Tag { get; set; }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        object this[string attributeName] { get; set; }

        /// <summary>
        /// Append any to content
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        IFormat Append(object any);

        /// <summary>
        /// Append any to content
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        IFormat Append(string any);

        /// <summary>
        /// Append to content
        /// </summary>
        /// <param name="str"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        IFormat Append(char[] str, int offset, int len);

        /// <summary>
        /// Append to content
        /// </summary>
        /// <param name="format"></param>
        /// <param name="any"></param>
        /// <returns></returns>
        IFormat AppendFormat(string format, params object[] any);

        /// <summary>
        /// Get content
        /// </summary>
        /// <returns></returns>
        string GetContent();

        /// <summary>
        /// Creates a new format
        /// </summary>
        /// <returns></returns>
        IFormat NewFormat();

        /// <summary>
        /// Creates a new format with specified tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        IFormat NewFormat(string tag);

        /// <summary>
        /// Adds format to the child
        /// </summary>
        /// <param name="child"></param>
        void AddChild(IFormat child);

        /// <summary>
        /// Clear the children
        /// </summary>
        void ClearChildren();

        /// <summary>
        /// The children
        /// </summary>
        IEnumerable<IFormat> Children { get; }

        /// <summary>
        /// To String representation
        /// </summary>
        /// <returns></returns>
        string ToString();
    }
}
