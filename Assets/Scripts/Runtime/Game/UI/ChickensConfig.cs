using System;
using System.Collections.Generic;
using Runtime.Core.Infrastructure;
using UnityEngine;

namespace Runtime.Game.UI
{
    [CreateAssetMenu(fileName = "ChickensConfig", menuName = "Configs/ChickensConfig")]
    public class ChickensConfig : BaseSettings
    {
        public List<ChickenGrowConfig> ChickenGrowConfigs = new List<ChickenGrowConfig>();
    }

    [Serializable]
    public class ChickenGrowConfig
    {
        public List<Sprite> Sprites;
    }
}