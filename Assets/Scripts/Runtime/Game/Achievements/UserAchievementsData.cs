using System;
using UnityEngine.Serialization;

namespace Runtime.Game.Achievements
{
    [Serializable]
    public class UserAchievementsData
    {
        public AchievementData StartProgram = new()
        {
            Name = "START A PROGRAM",
            Target = 1,
            Reward = 25,
        };
        
        public AchievementData StartTwoProgram = new()
        {
            Name = "START TWO PROGRAMS",
            Target = 2,
            Reward = 25,
        };
        
        public AchievementData StartThreeProgram = new()
        {
            Name = "START THREE PROGRAMS",
            Target = 3,
            Reward = 25,
        };
        
        public AchievementData FirstExercise = new()
        {
            Name = "FINISH YOUR FIRST EXERCISE",
            Target = 1,
            Reward = 25,
        };
        
        public AchievementData FirstTrainDay = new()
        {
            Name = "FINISH WHOLE DAY FOR OF ANY PROGRAM",
            Target = 1,
            Reward = 25,
        };

        public AchievementData UnlockSecondProgram = new()
        {
            Name = "UNLOCK TWO PROGRAMS",
            Target = 2,
            Reward = 25,
        };
        
        public AchievementData UnlockThirdProgram = new()
        {
            Name = "UNLOCK THREE PROGRAMS",
            Target = 3,
            Reward = 25,
        };
        
        public AchievementData UpperThreeDaysTrainingProgram = new()
        {
            Name = "TRAIN FOR THREE DAYS IN THE UPPER PROGRAM",
            Target = 3,
            Reward = 25,
        };
        
        public AchievementData UpperFinishTrainingProgram = new()
        {
            Name = "FINISH THE UPPER PROGRAM",
            Target = 7,
            Reward = 25,
        };
        
        public AchievementData CoreThreeDaysTrainingProgram = new()
        {
            Name = "TRAIN FOR THREE DAYS IN THE CORE PROGRAM",
            Target = 3,
            Reward = 25,
        };
        
        public AchievementData CoreFinishTrainingProgram = new()
        {
            Name = "FINISH THE CORE PROGRAM",
            Target = 7,
            Reward = 25,
        };
        
        public AchievementData LowerThreeDaysTrainingProgram = new()
        {
            Name = "TRAIN FOR THREE DAYS IN THE LOWER PROGRAM",
            Target = 3,
            Reward = 25,
        };
        
        public AchievementData LowerFinishTrainingProgram = new()
        {
            Name = "FINISH THE LOWER PROGRAM",
            Target = 7,
            Reward = 25,
        };
        
        public AchievementData FourExercises = new()
        {
            Name = "PERFORM ANY FOUR EXERCISES",
            Target = 4,
            Reward = 25,
        };
                
        public AchievementData TenExercises = new()
        {
            Name = "PERFORM ANY TEN EXERCISES",
            Target = 10,
            Reward = 25,
        };
        
        public AchievementData TwentyExercises = new()
        {
            Name = "PERFORM ANY TWENTY EXERCISES",
            Target = 20,
            Reward = 25,
        };
        
        public AchievementData FiftyExercises = new()
        {
            Name = "PERFORM ANY FIFTY EXERCISES",
            Target = 50,
            Reward = 25,
        };
        
        public AchievementData ObtainTwoBackgrounds = new()
        {
            Name = "OBTAIN TWO BACKGROUNDS",
            Progress = 1,
            Target = 2,
            Reward = 25,
        };
        
        public AchievementData ObtainThreeBackgrounds = new()
        {
            Name = "OBTAIN THREE BACKGROUNDS",
            Progress = 1,
            Target = 3,
            Reward = 25,
        };
        
        public AchievementData ObtainAllBgs = new()
        {
            Name = "OBTAIN ALL BACKGROUNDS",
            Progress = 1,
            Target = 5,
            Reward = 25,
        };
    }
}