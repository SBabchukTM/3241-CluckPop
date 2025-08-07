using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core.GameStateMachine;
using Runtime.Game.Achievements;
using Runtime.Game.Services;
using Runtime.Game.Services.UI;
using Runtime.Game.Services.UserData;
using Runtime.Game.Shop;
using Runtime.Game.UI.Screen;
using ILogger = Runtime.Core.Infrastructure.ILogger;

namespace Runtime.Game.GameStates.Game.Screens
{
    public class ShopScreenStateController : StateController
    {
        private readonly IGameUiService _gameUiService;
        private readonly ConfigsProvider _configsProvider;
        private readonly BackgroundsService _backgroundsService;
        private readonly UserBalanceService _userBalanceService;
        private readonly AchievementUnlocker _achievementUnlocker;
        
        private ShopScreen _screen;
        
        private List<ShopItemDisplay> _shopItems;
        
        public ShopScreenStateController(ILogger logger, IGameUiService gameUiService, 
            ConfigsProvider configsProvider, BackgroundsService backgroundsService,
            UserBalanceService userBalanceService, AchievementUnlocker achievementUnlocker) : base(logger)
        {
            _gameUiService = gameUiService;
            _configsProvider = configsProvider;
            _backgroundsService = backgroundsService;
            _userBalanceService = userBalanceService;
            _achievementUnlocker = achievementUnlocker;
        }
        
        public override UniTask Enter(CancellationToken cancellationToken)
        {
            CreateScreen();
            SubscribeToEvents();
            
            return UniTask.CompletedTask;
        }
        
        public override async UniTask ExitState()
        {
            await _gameUiService.HideScreen(ConstScreens.ShopScreen);
        }
        
        private void CreateScreen()
        {
            _screen = _gameUiService.GetScreen<ShopScreen>(ConstScreens.ShopScreen);
            _screen.Initialize();
            _screen.ShowAsync().Forget();

            _shopItems = _screen.GetItems();

            var config = _configsProvider.Get<BackgroundsConfig>();
            for (int i = 0; i < _shopItems.Count; i++)
            {
                _shopItems[i].Initialize(config.ShopItems[i]);
            }
            
            UpdateItems();
        }
        
        private void SubscribeToEvents()
        {
            _screen.OnBackPressed += async () => await EnterState<MenuStateController>();
            _screen.OnActionPressed += ProcessAction;
        }

        private void ProcessAction()
        {
            var closest = _screen.GetClosest;
            
            if(closest.IsSelected)
                return;

            if (!closest.IsLocked)
            {
                _backgroundsService.SetSelectedId(_shopItems.IndexOf(closest));
                UpdateItems();
                return;
            }
            
            
            int price = closest.Price;
            if (_userBalanceService.GetUserBalance() < price)
            {
                _screen.ShowError();
                return;
            }
            
            _userBalanceService.AddBalance(-price);
            _backgroundsService.AddPurchasedId(_shopItems.IndexOf(closest));
            _backgroundsService.SetSelectedId(_shopItems.IndexOf(closest));
            _achievementUnlocker.OnBackgroundPurchased();
            UpdateItems();
        }

        private void UpdateItems()
        {
            for (int i = 0; i < _shopItems.Count; i++)
            {
                var display = _shopItems[i];
                
                if(IsLocked(i))
                    display.SetLocked();
                else
                    display.SetUnlocked(IsSelected(i));
            }
        }
        
        private bool IsLocked(int i) => !_backgroundsService.IsPurchased(i);
        private bool IsSelected(int i) => _backgroundsService.GetSelectedId() == i;
    }
}