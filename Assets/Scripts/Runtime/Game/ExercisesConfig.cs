using System;
using System.Collections.Generic;
using Runtime.Core.Infrastructure;
using UnityEngine;

namespace Runtime.Game
{
    [CreateAssetMenu(fileName = "ExercisesConfig", menuName = "Configs/ExercisesConfig")]
    public class ExercisesConfig : BaseSettings
    {
        public ProgramConfig EasyUpperConfig;
        public ProgramConfig EasyCoreConfig;
        public ProgramConfig EasyLowerConfig;
    
        public ProgramConfig NormalUpperConfig;
        public ProgramConfig NormalCoreConfig;
        public ProgramConfig NormalLowerConfig;
    
        public ProgramConfig HardUpperConfig;
        public ProgramConfig HardCoreConfig;
        public ProgramConfig HardLowerConfig;
    }

    [Serializable]
    public class ExerciseData
    {
        public string Name;
        public int Reps;
        public string Hint;
    }

    [Serializable]
    public class ProgramConfig
    {
        public List<ExerciseDayData> ExercisesPerDay;
    }
}