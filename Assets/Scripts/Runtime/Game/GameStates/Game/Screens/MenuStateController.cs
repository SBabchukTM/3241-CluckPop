using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core.GameStateMachine;
using Runtime.Game.GameStates.Game.Controllers;
using Runtime.Game.Services.UI;
using Runtime.Game.Services.UserData.Data;
using Runtime.Game.UI.Screen;
using ILogger = Runtime.Core.Infrastructure.ILogger;

namespace Runtime.Game.GameStates.Game.Screens
{
    public class MenuStateController : StateController
    {
        private readonly IGameUiService _gameUiService;
        private readonly SettingsPopupController _settingsPopupController;
        private readonly ProgramSelectScreenStateController _programSelectScreenStateController;
        private readonly ExercisesScreenStateController _exercisesScreenStateController;

        private MenuScreen _screen;

        private ProgramType _lastType = ProgramType.Upper;
        
        public MenuStateController(ILogger logger, IGameUiService gameUiService, SettingsPopupController settingsPopupController,
            ProgramSelectScreenStateController programSelectScreenStateController, ExercisesScreenStateController exercisesScreenStateController) : base(logger)
        {
            _gameUiService = gameUiService;
            _settingsPopupController = settingsPopupController;
            _programSelectScreenStateController = programSelectScreenStateController;
            _exercisesScreenStateController = exercisesScreenStateController;
        }

        public override UniTask Enter(CancellationToken cancellationToken)
        {
            CreateScreen();
            SubscribeToEvents();
            
            return UniTask.CompletedTask;
        }

        public override async UniTask ExitState()
        {
            await _gameUiService.HideScreen(ConstScreens.MenuScreen);
        }

        private void CreateScreen()
        {
            _screen = _gameUiService.GetScreen<MenuScreen>(ConstScreens.MenuScreen);
            _screen.Initialize();
            _screen.ShowAsync().Forget();
            _screen.SetStartingCanvas(_lastType);
        }

        private void SubscribeToEvents()
        {
            _screen.OnProfilePressed += async () => await EnterState<ProfileScreenStateController>();
            _screen.OnAchievementsPressed += async () => await EnterState<AchievementsScreenStateController>();
            _screen.OnCollectionPressed += async () => await EnterState<CollectionScreenStateController>();
            _screen.OnShopPressed += async () => await EnterState<ShopScreenStateController>();
            _screen.OnSettingsPressed += () => _settingsPopupController.Run(CancellationToken.None).Forget();

            _screen.OnProgramPressed += async (programType) =>
            {
                _programSelectScreenStateController.SetProgramType(programType);
                await EnterState<ProgramSelectScreenStateController>();
            };
            
            _screen.OnExercisesPressed += async (programType) =>
            {
                _exercisesScreenStateController.SetProgramType(programType);
                await EnterState<ExercisesScreenStateController>();
            };

            _screen.OnPageChanged += (page) => _lastType = page;
        }
    }
}