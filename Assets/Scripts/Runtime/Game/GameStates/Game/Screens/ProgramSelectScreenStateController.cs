using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core.GameStateMachine;
using Runtime.Game.Services;
using Runtime.Game.Services.UI;
using Runtime.Game.Services.UserData.Data;
using Runtime.Game.UI.Screen;
using ILogger = Runtime.Core.Infrastructure.ILogger;

namespace Runtime.Game.GameStates.Game.Screens
{
    public class ProgramSelectScreenStateController : StateController
    {
        private readonly IGameUiService _gameUiService;
        private readonly ProgramsService _programsService;
        
        private ProgramSelectScreen _screen;
        
        private ProgramType _programType;
        
        public ProgramSelectScreenStateController(ILogger logger, IGameUiService gameUiService, ProgramsService programsService) : base(logger)
        {
            _gameUiService = gameUiService;
            _programsService = programsService;
        }
        
        public override UniTask Enter(CancellationToken cancellationToken)
        {
            CreateScreen();
            SubscribeToEvents();
            
            return UniTask.CompletedTask;
        }
        
        public override async UniTask ExitState()
        {
            await _gameUiService.HideScreen(ConstScreens.ProgramSelectScreen);
        }
        
        public void SetProgramType(ProgramType programType) => _programType = programType;
        
        private void CreateScreen()
        {
            _screen = _gameUiService.GetScreen<ProgramSelectScreen>(ConstScreens.ProgramSelectScreen);
            _screen.Initialize();
            _screen.ShowAsync().Forget();
        }
        
        private void SubscribeToEvents()
        {
            _screen.OnBackPressed += async () => await EnterState<MenuStateController>();
            
            _screen.OnDifficultySelected += async (difficultyType) =>
            {
                _programsService.StartProgram(_programType, difficultyType);
                await EnterState<MenuStateController>();
            };
        }    
    }
}