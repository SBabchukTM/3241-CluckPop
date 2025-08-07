using Runtime.Core.Compressor;
using Runtime.Core.Infrastructure;
using Runtime.Game.Services.Path;

namespace Runtime.Game.Services.UserData
{
    public class SavedDataRetrieveService
    {
        private readonly IPersistentDataProvider _persistentDataProvider;
        private readonly BaseCompressor _compressor;

        private Data.UserData _userData;

        public SavedDataRetrieveService(IPersistentDataProvider persistentDataProvider, BaseCompressor compressor)
        {
            _persistentDataProvider = persistentDataProvider;
            _compressor = compressor;
        }

        public void Initialize()
        {
#if DEV
            _userData = _persistentDataProvider.Load<Data.UserData>(ConstDataPath.UserDataPath, ConstDataPath.UserDataFileName) ?? new Data.UserData();
#else
            _userData = _persistentDataProvider.Load<Data.UserData>(ConstDataPath.UserDataPath, ConstDataPath.UserDataFileName, null, _compressor) ?? new Data.UserData();
#endif
        }

        public Data.UserData GetUserData()
        {
            return _userData;
        }

        public void SaveUserData()
        {
            if (_userData == null)
                return;

#if DEV
            _persistentDataProvider.Save(_userData, ConstDataPath.UserDataPath, ConstDataPath.UserDataFileName);
#else
            _persistentDataProvider.Save(_userData, ConstDataPath.UserDataPath, ConstDataPath.UserDataFileName, null, _compressor);
#endif
        }
    }
}