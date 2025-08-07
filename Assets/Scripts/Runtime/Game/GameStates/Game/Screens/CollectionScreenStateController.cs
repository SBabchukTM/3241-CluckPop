using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core.GameStateMachine;
using Runtime.Game.Services.UI;
using Runtime.Game.UI.Screen;
using ILogger = Runtime.Core.Infrastructure.ILogger;

namespace Runtime.Game.GameStates.Game.Screens
{
    public class CollectionScreenStateController : StateController
    {
        private readonly IGameUiService _gameUiService;
        
        private CollectionScreen _screen;
        
        public CollectionScreenStateController(ILogger logger, IGameUiService gameUiService) : base(logger)
        {
            _gameUiService = gameUiService;
        }
        
        public override UniTask Enter(CancellationToken cancellationToken)
        {
            CreateScreen();
            SubscribeToEvents();
            
            return UniTask.CompletedTask;
        }
        
        public override async UniTask ExitState()
        {
            await _gameUiService.HideScreen(ConstScreens.CollectionScreen);
        }
        
        private void CreateScreen()
        {
            _screen = _gameUiService.GetScreen<CollectionScreen>(ConstScreens.CollectionScreen);
            _screen.Initialize();
            _screen.ShowAsync().Forget();
        }
        
        private void SubscribeToEvents()
        {
            _screen.OnBackPressed += async () => await EnterState<MenuStateController>();
        }    
    }
}