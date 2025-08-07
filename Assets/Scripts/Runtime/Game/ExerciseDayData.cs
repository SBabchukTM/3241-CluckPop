using UnityEngine;

namespace Runtime.Game
{
    [CreateAssetMenu(fileName = "ExerciseDayData", menuName = "Configs/ExerciseDayData")]
    public class ExerciseDayData : ScriptableObject
    {
        public ExerciseData ExerciseOne;
        public ExerciseData ExerciseTwo;
    }
}