using Runtime.Core.Compressor;

namespace Runtime.Core.Infrastructure
{
    public interface IPersistentDataProvider
    {
        T Load<T>(string path, string fileName, ISerializationProvider serializationProvider = null, BaseCompressor compressor = null) where T : class;

        bool Save<T>(T data, string path, string fileName, ISerializationProvider serializationProvider = null, BaseCompressor compressor = null) where T : class;
    }
}