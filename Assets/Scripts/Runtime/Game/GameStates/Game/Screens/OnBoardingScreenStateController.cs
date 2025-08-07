using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core.GameStateMachine;
using Runtime.Game.Services.UI;
using Runtime.Game.Services.UserData;
using Runtime.Game.UI.Screen;
using ILogger = Runtime.Core.Infrastructure.ILogger;

namespace Runtime.Game.GameStates.Game.Screens
{
    public class OnBoardingScreenStateController : StateController
    {
        private readonly IGameUiService _gameUiService;
        private readonly SavedDataRetrieveService _savedDataRetrieveService;
        
        private OnBoardingScreen _screen;
        
        public OnBoardingScreenStateController(ILogger logger, IGameUiService gameUiService,
            SavedDataRetrieveService savedDataRetrieveService) : base(logger)
        {
            _gameUiService = gameUiService;
            _savedDataRetrieveService = savedDataRetrieveService;
        }
        
        public override UniTask Enter(CancellationToken cancellationToken)
        {
            CreateScreen();
            SubscribeToEvents();
            
            return UniTask.CompletedTask;
        }
        
        public override async UniTask ExitState()
        {
            await _gameUiService.HideScreen(ConstScreens.OnBoardingScreen);
        }
        
        private void CreateScreen()
        {
            _screen = _gameUiService.GetScreen<OnBoardingScreen>(ConstScreens.OnBoardingScreen);
            _screen.Initialize();
            _screen.ShowAsync().Forget();
        }
        
        private void SubscribeToEvents()
        {
            _screen.OnOnboardingEnded += async () =>
            {
                _savedDataRetrieveService.GetUserData().TutorialData.PassedTutorial = true;
                await EnterState<MenuStateController>();
            };
        }    
    }
}