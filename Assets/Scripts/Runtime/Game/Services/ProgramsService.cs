using System;
using System.Collections.Generic;
using Runtime.Game.Achievements;
using Runtime.Game.GameStates.Game;
using Runtime.Game.Services.UserData;
using Runtime.Game.Services.UserData.Data;
using UnityEngine;

namespace Runtime.Game.Services
{
    public class ProgramsService
    {
       private readonly SavedDataRetrieveService _savedDataRetrieveService;
       private readonly ConfigsProvider _configsProvider;
       private readonly EggSelector _eggSelector;
       private readonly AchievementUnlocker _achievementUnlocker;

       public ProgramsService(SavedDataRetrieveService savedDataRetrieveService, 
           ConfigsProvider configsProvider, EggSelector eggSelector,
           AchievementUnlocker achievementUnlocker)
       {
           _savedDataRetrieveService = savedDataRetrieveService;
           _configsProvider = configsProvider;
           _eggSelector = eggSelector;
           _achievementUnlocker = achievementUnlocker;
       }

       public List<ExerciseExplanation> GetExercises(ProgramType programType)
       {
           var config = _configsProvider.Get<ExerciseDatabaseConfig>();

           switch (programType)
           {
               case ProgramType.Upper:
                   return config.UpperExercises;
               case ProgramType.Lower:
                   return config.LowerExercises;
               case ProgramType.Core:
                   return config.CoreExercises;
           }

           return null;
       }
       
       public List<ExerciseDayData> GetExercisesForProgram(ProgramType programType)
       {
           var config = _configsProvider.Get<ExercisesConfig>();
           var difficultyType = GetSelectedDifficulty(programType);
           
           switch (programType)
           {
               case ProgramType.Upper:
                   switch (difficultyType)
                   {
                       case DifficultyType.Easy:
                           return config.EasyUpperConfig.ExercisesPerDay;
                       case DifficultyType.Normal:
                           return config.NormalUpperConfig.ExercisesPerDay;
                       case DifficultyType.Hard:
                           return config.HardUpperConfig.ExercisesPerDay;
                   }
                   break;
               case ProgramType.Core:
                   switch (difficultyType)
                   {
                       case DifficultyType.Easy:
                           return config.EasyCoreConfig.ExercisesPerDay;
                       case DifficultyType.Normal:
                           return config.NormalCoreConfig.ExercisesPerDay;
                       case DifficultyType.Hard:
                           return config.HardCoreConfig.ExercisesPerDay;
                   }
                   break;
               case ProgramType.Lower:
                   switch (difficultyType)
                   {
                       case DifficultyType.Easy:
                           return config.EasyLowerConfig.ExercisesPerDay;
                       case DifficultyType.Normal:
                           return config.NormalLowerConfig.ExercisesPerDay;
                       case DifficultyType.Hard:
                           return config.HardLowerConfig.ExercisesPerDay;
                   }
                   break;
           }

           return null;
       }

       public void RecordExerciseCleared(ProgramType programType, int exerciseIndex)
       {
           _achievementUnlocker.OnExerciseDone();
           
           var data = GetActiveProgramData(programType);
           if (exerciseIndex == 0)
               data.FirstExerciseCleared = true;
           if(exerciseIndex == 1)
               data.SecondExerciseCleared = true;

           if (data.FirstExerciseCleared && data.SecondExerciseCleared)
           {
               data.FirstExerciseCleared = false;
               data.SecondExerciseCleared = false;
               data.SetClearDate = DateTime.Now.ToString();
               data.DaysTrained++;
               _achievementUnlocker.OnTrainingDayDone(programType);
           }
       }

       public DifficultyType GetSelectedDifficulty(ProgramType programType)
       {
           var data = _savedDataRetrieveService.GetUserData().UserProgramsData;
           switch (programType)
           {
               case ProgramType.Upper:
                   return data.UpperProgramData.DifficultyType;
               case ProgramType.Core:
                   return data.CoreProgramData.DifficultyType;
               case ProgramType.Lower:
                   return data.LowerProgramData.DifficultyType;
           }
           
           return DifficultyType.Easy;
       }
       
       public bool IsProgramActive(ProgramType programType)
       {
           var data = _savedDataRetrieveService.GetUserData().UserProgramsData;
           switch (programType)
           {
               case ProgramType.Upper:
                   return data.UpperProgramData.IsActive;
               case ProgramType.Core:
                   return data.CoreProgramData.IsActive;
               case ProgramType.Lower:
                   return data.LowerProgramData.IsActive;
           }
           
           return false;
       }

       public Sprite GetChickenSprite(ProgramType programType)
       {
           var data = GetActiveProgramData(programType);
           return _eggSelector.GetChickenSprite(data.ChickenId, data.DaysTrained);
       }
       
       public int GetDaysTrained(ProgramType programType)
       {
           var activeProgram = GetActiveProgramData(programType);
           return activeProgram.DaysTrained;
       }

       public ActiveProgramData GetActiveProgramData(ProgramType programType)
       {
           var data = _savedDataRetrieveService.GetUserData().UserProgramsData;
           switch (programType)
           {
               case ProgramType.Upper:
                   return data.UpperProgramData;
               case ProgramType.Core:
                   return data.CoreProgramData;
               case ProgramType.Lower:
                   return data.LowerProgramData;
           }

           return null;
       }

       public int GetProgramPrice()
       {
           int unlockedPrograms = 0;
           
           if(GetUnlockData().UnlockedCoreProgram)
               unlockedPrograms++;
           
           if(GetUnlockData().UnlockedLowerProgram)
               unlockedPrograms++;
           
           if(GetUnlockData().UnlockedUpperProgram)
               unlockedPrograms++;

           switch (unlockedPrograms)
           {
               case 0:
                   return 0;
               case 1:
                   return 50;
               case 2:
                   return 300;
           }
           
           return 0;
       }

       public void UnlockProgram(ProgramType programType)
       {
           _achievementUnlocker.OnProgramUnlocked();
           switch (programType)
           {
               case ProgramType.Core:
                   GetUnlockData().UnlockedCoreProgram = true;
                   break;
               case ProgramType.Lower:
                   GetUnlockData().UnlockedLowerProgram = true;
                   break;
               case ProgramType.Upper:
                   GetUnlockData().UnlockedUpperProgram = true;
                   break;
           }
       }

       public void StartProgram(ProgramType programType, DifficultyType difficultyType)
       {
           _achievementUnlocker.OnProgramStarted();
           var data = _savedDataRetrieveService.GetUserData().UserProgramsData;
           switch (programType)
           {
               case ProgramType.Upper:
                   data.UpperProgramData.IsActive = true;
                   data.UpperProgramData.DifficultyType = difficultyType;
                   data.UpperProgramData.ChickenId = _eggSelector.SelectUniqueEggIndex();
                   break;
               case ProgramType.Core:
                   data.CoreProgramData.IsActive = true;
                   data.CoreProgramData.DifficultyType = difficultyType;
                   data.CoreProgramData.ChickenId = _eggSelector.SelectUniqueEggIndex();
                   break;
               case ProgramType.Lower:
                   data.LowerProgramData.IsActive = true;
                   data.LowerProgramData.DifficultyType = difficultyType;
                   data.LowerProgramData.ChickenId = _eggSelector.SelectUniqueEggIndex();
                   break;
           }
       }
       
       public bool IsLockedProgram(ProgramType type)
       {
           switch (type)
           {
               case ProgramType.Core:
                   return !GetUnlockData().UnlockedCoreProgram;
               case ProgramType.Lower:
                   return !GetUnlockData().UnlockedLowerProgram;
               case ProgramType.Upper:
                   return !GetUnlockData().UnlockedUpperProgram;
           }

           return true;
       }

       private ProgramsUnlockData GetUnlockData() => _savedDataRetrieveService.GetUserData().ProgramsUnlockData;
    }
}