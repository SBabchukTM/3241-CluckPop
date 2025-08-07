using System.Collections.Generic;
using Runtime.Core.Infrastructure;
using UnityEngine;

namespace Runtime.Core
{
    [CreateAssetMenu(fileName = "AudioConfig", menuName = "Config/AudioConfig")]
    public sealed class GameAudioConfigfile : BaseSettings
    {
        public List<GameAudioData> Audio;
    }
}