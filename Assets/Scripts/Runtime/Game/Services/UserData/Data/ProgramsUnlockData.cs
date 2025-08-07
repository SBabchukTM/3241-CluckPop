using System;

namespace Runtime.Game.Services.UserData.Data
{
    [Serializable]
    public class ProgramsUnlockData
    {
        public bool UnlockedUpperProgram;
        public bool UnlockedCoreProgram;
        public bool UnlockedLowerProgram;
    }
}