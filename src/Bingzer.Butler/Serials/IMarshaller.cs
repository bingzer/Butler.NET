using System;
using System.IO;

namespace Bingzer.Butler.Serials
{
    /// <summary>
    /// Used to read/write a IMarshall
    /// </summary>
    public interface IMarshaller : IDisposable
    {
        /// <summary>
        /// Reads from input
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="marshall"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        T Read<T>(T marshall, Stream input) where  T : IMarshall;

        /// <summary>
        /// Write to output
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="marshall"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        T Write<T>(T marshall, Stream output) where T : IMarshall;
    }
}
