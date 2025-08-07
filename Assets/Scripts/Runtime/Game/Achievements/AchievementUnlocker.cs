using Runtime.Game.Services.UserData;
using Runtime.Game.Services.UserData.Data;

namespace Runtime.Game.Achievements
{
    public class AchievementUnlocker
    {
        private readonly SavedDataRetrieveService _savedDataRetrieveService;

        public AchievementUnlocker(SavedDataRetrieveService savedDataRetrieveService)
        {
            _savedDataRetrieveService = savedDataRetrieveService;
        }

        public void OnProgramStarted()
        {
            GetData().StartProgram.IncreaseProgress(1);
            GetData().StartTwoProgram.IncreaseProgress(1);
            GetData().StartThreeProgram.IncreaseProgress(1);
        }

        public void OnExerciseDone()
        {
            GetData().FirstExercise.IncreaseProgress(1);
            GetData().FourExercises.IncreaseProgress(1);
            GetData().TenExercises.IncreaseProgress(1);
            GetData().TwentyExercises.IncreaseProgress(1);
            GetData().FiftyExercises.IncreaseProgress(1);
        }

        public void OnTrainingDayDone(ProgramType programType)
        {
            GetData().FirstTrainDay.IncreaseProgress(1);

            switch (programType)
            {
                case ProgramType.Upper:
                    GetData().UpperThreeDaysTrainingProgram.IncreaseProgress(1);
                    GetData().UpperFinishTrainingProgram.IncreaseProgress(1);
                    break;
                case ProgramType.Lower:
                    GetData().LowerThreeDaysTrainingProgram.IncreaseProgress(1);
                    GetData().LowerFinishTrainingProgram.IncreaseProgress(1);
                    break;
                case ProgramType.Core:
                    GetData().CoreThreeDaysTrainingProgram.IncreaseProgress(1);
                    GetData().CoreFinishTrainingProgram.IncreaseProgress(1);
                    break;
            }
        }

        public void OnProgramUnlocked()
        {
            GetData().UnlockSecondProgram.IncreaseProgress(1);
            GetData().UnlockThirdProgram.IncreaseProgress(1);
        }
        
        public void OnBackgroundPurchased()
        {
            GetData().ObtainTwoBackgrounds.IncreaseProgress(1);
            GetData().ObtainThreeBackgrounds.IncreaseProgress(1);
            GetData().ObtainAllBgs.IncreaseProgress(1);
        }
        
        private UserAchievementsData GetData() => _savedDataRetrieveService.GetUserData().UserAchievementsData;
    }
}