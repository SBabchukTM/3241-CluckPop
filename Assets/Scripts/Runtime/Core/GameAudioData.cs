using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Core
{
    [Serializable]
    public class GameAudioData
    {
        public string Id;
        [FormerlySerializedAs("AudioType")] public GameAudioType _gameAudioType;
        public AudioClip Clip;
    }
}