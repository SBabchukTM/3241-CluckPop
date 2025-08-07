using System;

namespace Runtime.Game.Services.UserData.Data
{
    [Serializable]
    public class ActiveProgramData
    {
        public DifficultyType DifficultyType;
        public int DaysTrained;
        public bool FirstExerciseCleared;
        public bool SecondExerciseCleared;
        public bool IsActive;
        public string SetClearDate = string.Empty;
        public int ChickenId = 0;
    }
}