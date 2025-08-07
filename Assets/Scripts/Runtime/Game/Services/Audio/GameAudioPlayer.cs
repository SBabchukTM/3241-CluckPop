using System.Collections.Generic;
using Hellmade.Sound;
using Runtime.Core;
using UnityEngine;

namespace Runtime.Game.Services.Audio
{
    public class GameAudioPlayer : IGameAudioPlayer
    {
        private readonly ConfigsProvider _configsProvider;

        public GameAudioPlayer(ConfigsProvider configsProvider)
        {
            _configsProvider = configsProvider;
        }

        public void PlayMusic(string clipId)
        {
            var audioSettings = _configsProvider.Get<GameAudioConfigfile>();
            var clip = audioSettings.GetClip(clipId);
            if (clip)
                EazySoundManager.PlayMusic(clip);
        }

        public void PlayMusic(AudioClip clip)
        {
            EazySoundManager.PlayMusic(clip);
        }

        public void PlaySound(string clipId)
        {
            var audioSettings = _configsProvider.Get<GameAudioConfigfile>();
            var clip = audioSettings.GetClip(clipId);
            if (clip)
                EazySoundManager.PlaySound(clip);
        }

        public void PlaySound(string clipId, bool loop)
        {
            var audioSettings = _configsProvider.Get<GameAudioConfigfile>();
            var clip = audioSettings.GetClip(clipId);
            if (clip)
                EazySoundManager.PlaySound(clip, loop);
        }

        public void PauseAll()
        {
            EazySoundManager.PauseAll();
        }

        public void ResumeAll()
        {
            EazySoundManager.ResumeAll();
        }

        public void ResumeSounds()
        {
            EazySoundManager.ResumeAllSounds();
        }

        public bool IsPlaying(string clipId)
        {
            var audioSettings = _configsProvider.Get<GameAudioConfigfile>();
            var clip = audioSettings.GetClip(clipId);
            return EazySoundManager.IsPlaying(clip);
        }

        public void StopMusic()
        {
            EazySoundManager.StopAllMusic();
        }

        public void StopAllSounds()
        {
            EazySoundManager.StopAllSounds();
        }

        public void StopAll()
        {
            EazySoundManager.StopAll();
        }

        public void SetVolume(GameAudioType gameAudioType, float volume)
        {
            switch (gameAudioType)
            {
                case GameAudioType.Music:
                    EazySoundManager.GlobalMusicVolume = volume;
                    break;
                case GameAudioType.Sound:
                    EazySoundManager.GlobalSoundsVolume = volume;
                    break;
                default:
                    throw new KeyNotFoundException($"{nameof(GameAudioPlayer)}: {gameAudioType} handler not found");
            }
        }
    }
}