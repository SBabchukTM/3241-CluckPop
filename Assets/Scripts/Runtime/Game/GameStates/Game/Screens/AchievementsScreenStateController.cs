using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core.GameStateMachine;
using Runtime.Game.Achievements;
using Runtime.Game.Services.UI;
using Runtime.Game.Services.UserData;
using Runtime.Game.Services.UserData.Data;
using Runtime.Game.UI.Screen;
using ILogger = Runtime.Core.Infrastructure.ILogger;

namespace Runtime.Game.GameStates.Game.Screens
{
    public class AchievementsScreenStateController : StateController
    {
        private readonly IGameUiService _gameUiService;
        private readonly AchievementsFactory _achievementsFactory;
        private readonly UserBalanceService _userBalanceService;
        
        private AchievementsScreen _screen;
        
        public AchievementsScreenStateController(ILogger logger, IGameUiService gameUiService, 
            AchievementsFactory achievementsFactory, UserBalanceService userBalanceService) : base(logger)
        {
            _gameUiService = gameUiService;
            _achievementsFactory = achievementsFactory;
            _userBalanceService = userBalanceService;
        }
        
        public override UniTask Enter(CancellationToken cancellationToken)
        {
            CreateScreen();
            SubscribeToEvents();
            
            return UniTask.CompletedTask;
        }
        
        public override async UniTask ExitState()
        {
            await _gameUiService.HideScreen(ConstScreens.AchievementsScreen);
        }
        
        private void CreateScreen()
        {
            var achievements = _achievementsFactory.GetAchievementDisplays();
            
            _screen = _gameUiService.GetScreen<AchievementsScreen>(ConstScreens.AchievementsScreen);
            _screen.Initialize(achievements);
            _screen.ShowAsync().Forget();

            foreach (var achievement in achievements) 
                achievement.OnClaimed += () =>
                {
                    _screen.DisplayReward();
                    _userBalanceService.AddBalance(+25);
                };
        }
        
        private void SubscribeToEvents()
        {
            _screen.OnBackPressed += async () => await EnterState<MenuStateController>();
        }    
    }
}