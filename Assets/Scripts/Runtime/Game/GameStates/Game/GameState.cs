using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core.GameStateMachine;
using Runtime.Game.GameStates.Game.Controllers;
using Runtime.Game.GameStates.Game.Screens;
using Runtime.Game.Services.UserData;
using ILogger = Runtime.Core.Infrastructure.ILogger;

namespace Runtime.Game.GameStates.Game
{
    public class GameState : StateController
    {
        private readonly StateMachine _stateMachine;

        private readonly AchievementsScreenStateController _achievementsScreenController;
        private readonly CollectionScreenStateController _collectionScreenController;
        private readonly MenuStateController _menuStateController;
        private readonly OnBoardingScreenStateController _onBoardingScreenController;
        private readonly ProfileScreenStateController _profileScreenController;
        private readonly ShopScreenStateController _shopScreenStateController;
        private readonly ExercisesScreenStateController _exercisesScreenController;
        private readonly ProgramSelectScreenStateController _programSelectScreenController;
        private readonly UserDataStateChangeController _userDataStateChangeController;
        private readonly SavedDataRetrieveService _savedDataRetrieveService;

        public GameState(ILogger logger,
            AchievementsScreenStateController achievementsScreenController,
            CollectionScreenStateController collectionScreenController,
            MenuStateController menuStateController,
            OnBoardingScreenStateController onBoardingScreenController,
            ProfileScreenStateController profileScreenController,
            ShopScreenStateController shopScreenStateController,
            ExercisesScreenStateController exercisesScreenController,
            ProgramSelectScreenStateController programSelectScreenController,
            StateMachine stateMachine,
            UserDataStateChangeController userDataStateChangeController,
            SavedDataRetrieveService savedDataRetrieveService) : base(logger)
        {
            _stateMachine = stateMachine;
            _achievementsScreenController = achievementsScreenController;
            _collectionScreenController = collectionScreenController;
            _menuStateController = menuStateController;
            _onBoardingScreenController = onBoardingScreenController;
            _profileScreenController = profileScreenController;
            _shopScreenStateController = shopScreenStateController;
            _exercisesScreenController = exercisesScreenController;
            _programSelectScreenController = programSelectScreenController;
            _userDataStateChangeController = userDataStateChangeController;
            _savedDataRetrieveService = savedDataRetrieveService;
        }

        public override async UniTask Enter(CancellationToken cancellationToken)
        {
            await _userDataStateChangeController.Run(default);

            _stateMachine.SetStates(_achievementsScreenController, 
                _collectionScreenController, _menuStateController, _onBoardingScreenController, 
                _profileScreenController, _shopScreenStateController,
                _exercisesScreenController, _programSelectScreenController);
            
            if(_savedDataRetrieveService.GetUserData().TutorialData.PassedTutorial)
                _stateMachine.GoTo<MenuStateController>().Forget();
            else
                _stateMachine.GoTo<OnBoardingScreenStateController>().Forget();
        }
    }
}