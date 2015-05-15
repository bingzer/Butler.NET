namespace Bingzer.Butler.Serials
{
    public interface IMarshall
    {
        /// <summary>
        /// Serialize this object to a format
        /// </summary>
        /// <param name="format">format where serialization will be in</param>
        /// <exception cref="MarshallException">For any error that occurs</exception>
        void Serialize(IFormat format);

        /// <summary>
        /// Deserialize this object from a format
        /// </summary>
        /// <param name="format">format where serialization data resides</param>
        /// <exception cref="MarshallException">For any error that occurs</exception>
        void Deserialize(IFormat format);
    }
}
