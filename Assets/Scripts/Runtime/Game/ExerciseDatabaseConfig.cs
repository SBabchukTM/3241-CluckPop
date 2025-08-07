using System;
using System.Collections.Generic;
using Runtime.Core.Infrastructure;
using UnityEngine;

namespace Runtime.Game
{
    [CreateAssetMenu(fileName = "ExerciseDatabaseConfig", menuName = "Configs/ExerciseDatabaseConfig")]
    public class ExerciseDatabaseConfig : BaseSettings
    {
        public List<ExerciseExplanation> UpperExercises;
        public List<ExerciseExplanation> CoreExercises;
        public List<ExerciseExplanation> LowerExercises;
    }

    [Serializable]
    public class ExerciseExplanation
    {
        public string ExerciseName;
        public string ExerciseDescription;
    }
}