using System;
using Runtime.Game.Achievements;
using Runtime.Game.Shop;

namespace Runtime.Game.Services.UserData.Data
{
    [Serializable]
    public class UserData
    {
        public SettingsData SettingsData = new SettingsData();
        public TutorialData TutorialData = new TutorialData();
        public ProgramsUnlockData ProgramsUnlockData = new ProgramsUnlockData();
        public UserBalanceData UserBalanceData = new UserBalanceData();
        public UserProgramsData UserProgramsData = new UserProgramsData();
        public UserAchievementsData UserAchievementsData = new UserAchievementsData();
        public BackgroundsData BackgroundsData = new BackgroundsData();
        public DisplayData DisplayData = new DisplayData();
    }
}