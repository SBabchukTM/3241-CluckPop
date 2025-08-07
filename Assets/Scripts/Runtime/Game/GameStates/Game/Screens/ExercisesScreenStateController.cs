using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core.GameStateMachine;
using Runtime.Game.Services;
using Runtime.Game.Services.UI;
using Runtime.Game.Services.UserData;
using Runtime.Game.Services.UserData.Data;
using Runtime.Game.UI.Screen;
using ILogger = Runtime.Core.Infrastructure.ILogger;

namespace Runtime.Game.GameStates.Game.Screens
{
    public class ExercisesScreenStateController : StateController
    {
        private readonly IGameUiService _gameUiService;
        private readonly ProgramsService _programsService;
        private readonly UserBalanceService _userBalanceService;
        
        private ExercisesScreen _screen;
        
        private ProgramType _programType;
        
        public ExercisesScreenStateController(ILogger logger, IGameUiService gameUiService, ProgramsService programsService,
            UserBalanceService userBalanceService) : base(logger)
        {
            _gameUiService = gameUiService;
            _programsService = programsService;
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
            await _gameUiService.HideScreen(ConstScreens.ExercisesScreen);
        }
        
        public void SetProgramType(ProgramType programType) => _programType = programType;
        
        private void CreateScreen()
        {
            _screen = _gameUiService.GetScreen<ExercisesScreen>(ConstScreens.ExercisesScreen);
            _screen.Initialize(CreateExercisesDisplayData());
            _screen.ShowAsync().Forget();
            
            _screen.SetDifficulty(_programsService.GetSelectedDifficulty(_programType));
        }
        
        private void SubscribeToEvents()
        {
            _screen.OnBackPressed += async () => await EnterState<MenuStateController>();
            _screen.OnExercise1Pressed += () =>
            {
                RecordExercise(0);
            };
            _screen.OnExercise2Pressed += () =>
            {
                RecordExercise(1);
            };
        }

        private void RecordExercise(int id)
        {
            _screen.DisplayReward();
            _programsService.RecordExerciseCleared(_programType, id);
            _userBalanceService.AddBalance(+25);
        }

        private List<ExerciseDisplayData> CreateExercisesDisplayData()
        {
            var exercises = _programsService.GetExercisesForProgram(_programType);
            int daysTrained = _programsService.GetDaysTrained(_programType);
            var programData = _programsService.GetActiveProgramData(_programType);

            bool clearedToday = false;

            if (programData.SetClearDate != String.Empty)
            {
                var now = DateTime.Now;
                var lastClearTime = Convert.ToDateTime(programData.SetClearDate);
                clearedToday = lastClearTime.Date == now.Date;
            }
            
            List<ExerciseDisplayData> result = new(7);
            for (int i = 0; i < exercises.Count; i++)
            {
                bool cleared = daysTrained > i;
                result.Add(new()
                {
                    ExerciseDayData = exercises[i],
                    Cleared = cleared,
                    Exercise1Completed = programData.FirstExerciseCleared,
                    Exercise2Completed = programData.SecondExerciseCleared,
                    Locked = i > daysTrained || clearedToday,
                    CompleteMessage = clearedToday && (i + 1) == daysTrained ? "COMPLETED!\nCOME BACK TOMORROW!" : "COMPLETED!"
                });
            }

            return result;
        }
    }
}