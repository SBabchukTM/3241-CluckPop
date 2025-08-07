using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core.GameStateMachine;
using Runtime.Game.Services.UI;
using Runtime.Game.Services.UserData;
using Runtime.Game.UI.Popup;
using Runtime.Game.UI.Screen;
using ILogger = Runtime.Core.Infrastructure.ILogger;

namespace Runtime.Game.GameStates.Game.Screens
{
    public class ProfileScreenStateController : StateController
    {
        private readonly IGameUiService _gameUiService;
        private readonly SavedDataRetrieveService _savedDataRetrieveService;
        private readonly ChickenCollectionProvider _chickenCollectionProvider;
        
        private ProfileScreen _screen;
        
        public ProfileScreenStateController(ILogger logger, IGameUiService gameUiService,
            SavedDataRetrieveService savedDataRetrieveService, ChickenCollectionProvider chickenCollectionProvider) : base(logger)
        {
            _gameUiService = gameUiService;
            _savedDataRetrieveService = savedDataRetrieveService;
            _chickenCollectionProvider = chickenCollectionProvider;
        }
        
        public override UniTask Enter(CancellationToken cancellationToken)
        {
            CreateScreen();
            SubscribeToEvents();
            
            return UniTask.CompletedTask;
        }
        
        public override async UniTask ExitState()
        {
            await _gameUiService.HideScreen(ConstScreens.ProfileScreen);
        }
        
        private void CreateScreen()
        {
            _screen = _gameUiService.GetScreen<ProfileScreen>(ConstScreens.ProfileScreen);
            _screen.Initialize();
            _screen.ShowAsync().Forget();
            _screen.SetDisplay(_chickenCollectionProvider.GetSprite(
                _savedDataRetrieveService.GetUserData().DisplayData.ChickenId,
                _savedDataRetrieveService.GetUserData().DisplayData.GrowPhase));
        }
        
        private void SubscribeToEvents()
        {
            _screen.OnBackPressed += async () => await EnterState<MenuStateController>();
            _screen.OnDisplayPressed += ScreenOnOnDisplayPressed;
        }

        private async void ScreenOnOnDisplayPressed()
        {
            var popup = await _gameUiService.ShowPopup(ConstPopups.CollectionSelectPopup) as CollectionSelectPopup;
            popup.OnSelected += UpdateSelectedDisplay;
        }

        private void UpdateSelectedDisplay(int chicken, int growPhase)
        {
            _savedDataRetrieveService.GetUserData().DisplayData.ChickenId = chicken;
            _savedDataRetrieveService.GetUserData().DisplayData.GrowPhase = growPhase;
            
            _screen.SetDisplay(_chickenCollectionProvider.GetSprite(
                _savedDataRetrieveService.GetUserData().DisplayData.ChickenId,
                _savedDataRetrieveService.GetUserData().DisplayData.GrowPhase));
        }
    }
}