using System;

namespace Runtime.Game.Services.UserData.Data
{
    [Serializable]
    public class UserProgramsData
    {
        public ActiveProgramData UpperProgramData = new ActiveProgramData();
        public ActiveProgramData CoreProgramData = new ActiveProgramData();
        public ActiveProgramData LowerProgramData = new ActiveProgramData();
    }
}