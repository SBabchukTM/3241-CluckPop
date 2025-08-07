using Runtime.Core;
using Runtime.Core.Compressor;
using Runtime.Core.Factory;
using Runtime.Core.Infrastructure;
using Runtime.Game.Services.ApplicationState;
using Runtime.Game.Services.Audio;
using Runtime.Game.Services.UI;
using Runtime.Game.Services.UserData;
using UnityEngine;
using Zenject;
using ILogger = Runtime.Core.Infrastructure.ILogger;

namespace Runtime.Game.Services
{
    [CreateAssetMenu(fileName = "ServicesInstaller", menuName = "Installers/ServicesInstaller")]
    public class ServicesInstaller : ScriptableObjectInstaller<ServicesInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameUiService>().To<GameUiService>().AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IPersistentDataProvider>().To<PersistantDataProvider>().AsSingle();
            Container.Bind<ConfigsProvider>().AsSingle();
            Container.Bind<PrefabsProvider>().AsSingle();
            Container.Bind<ILogger>().To<MyLogger>().AsSingle();
            Container.Bind<IFileStorageService>().To<PersistentFileStorageService>().AsSingle();
            Container.Bind<ISerializationProvider>().To<JsonSerializationProvider>().AsSingle();
            Container.Bind<IGameAudioPlayer>().To<GameAudioPlayer>().AsSingle();
            Container.Bind<BaseCompressor>().To<ZipCompressor>().AsSingle();
            Container.Bind<GameObjectFactory>().AsSingle();
            Container.Bind<ApplicationStateService>().AsSingle();
            Container.Bind<SavedDataRetrieveService>().AsSingle();
        }
    }
}