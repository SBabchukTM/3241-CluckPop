using System;
using UnityEngine;

namespace Runtime.Game.Achievements
{
    [Serializable]
    public class AchievementData
    {
        public string Name;
        public float Progress;
        public float Target;
        public bool Claimed;
        public int Reward;

        public void IncreaseProgress(int increase)
        {
            Progress += increase;
            Progress = Mathf.Clamp(Progress, 0, Target);
        }
    }
}
