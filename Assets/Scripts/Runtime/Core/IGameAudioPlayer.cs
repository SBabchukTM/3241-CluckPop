using UnityEngine;

namespace Runtime.Core
{
    public interface IGameAudioPlayer
    {
        void PlayMusic(AudioClip clip);
        void PlaySound(string clipId);
        void SetVolume(GameAudioType gameAudioType, float volume);
    }
}