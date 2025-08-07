using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Runtime.Core.GameStateMachine;
using Runtime.Core.Infrastructure;
using Runtime.Game.GameStates.Game;
using Runtime.Game.Services;
using Runtime.Game.Services.UI;
using Runtime.Game.Services.UserData;
using UnityEngine;
using ILogger = Runtime.Core.Infrastructure.ILogger;

namespace Runtime.Game.GameStates
{
    public class BootstrapState : StateController
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IGameUiService _gameUiService;
        private readonly ConfigsProvider _configsProvider;
        private readonly PrefabsProvider _prefabsProvider;
        private readonly SavedDataRetrieveService _savedDataRetrieveService;
        private readonly AudioLoader _audioLoader;

        public BootstrapState(IAssetProvider assetProvider,
            IGameUiService gameUiService,
            ILogger logger,
            ConfigsProvider configsProvider,
            PrefabsProvider prefabsProvider,
            SavedDataRetrieveService savedDataRetrieveService,
            AudioLoader audioLoader) : base(logger)
        {
            _assetProvider = assetProvider;
            _gameUiService = gameUiService;
            _configsProvider = configsProvider;
            _prefabsProvider = prefabsProvider;
            _savedDataRetrieveService = savedDataRetrieveService;
            _audioLoader = audioLoader;
        }

        public override async UniTask Enter(CancellationToken cancellationToken)
        {
            Input.multiTouchEnabled = false;

            await Load1();
            await Losd2();
            _gameUiService.ShowScreen(ConstScreens.SplashScreen, cancellationToken).Forget();
            await _audioLoader.Run(CancellationToken.None);

            EnterState<GameState>().Forget();
        }

        private async Task Losd2()
        {
            await _configsProvider.Initialize();
            await _prefabsProvider.Initialize();
        }

        private async Task Load1()
        {
            _savedDataRetrieveService.Initialize();
            await _assetProvider.Initialize();
            await _gameUiService.Initialize();
        }

        public override async UniTask ExitState()
        {
            await _gameUiService.HideScreen(ConstScreens.SplashScreen);
        }
    }
}