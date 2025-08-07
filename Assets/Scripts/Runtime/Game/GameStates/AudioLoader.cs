using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core;
using Runtime.Core.Controllers;
using Runtime.Game.Services;
using Runtime.Game.Services.UserData;
using UnityEngine;

namespace Runtime.Game.GameStates
{
    public class AudioLoader : BaseController
    {
        private readonly IGameAudioPlayer _gameAudioPlayer;
        private readonly ConfigsProvider _configsProvider;
        private readonly SavedDataRetrieveService _savedDataRetrieveService;

        private CancellationTokenSource _cancellationTokenSource;

        public AudioLoader(IGameAudioPlayer gameAudioPlayer, ConfigsProvider configsProvider, SavedDataRetrieveService savedDataRetrieveService)
        {
            _gameAudioPlayer = gameAudioPlayer;
            _configsProvider = configsProvider;
            _savedDataRetrieveService = savedDataRetrieveService;
        }

        public override UniTask Run(CancellationToken cancellationToken)
        {
            base.Run(cancellationToken);

            _cancellationTokenSource = new CancellationTokenSource();
            var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _cancellationTokenSource.Token);

            SetVolume();
            PlayMusic(linkedTokenSource.Token).Forget();
            return UniTask.CompletedTask;
        }
        
        private async UniTask PlayMusic(CancellationToken cancellationToken)
        {
            var audioSettings = _configsProvider.Get<GameAudioConfigfile>();
            var allMusicAudioData = audioSettings.Audio.FindAll(x => x._gameAudioType == GameAudioType.Music);
            var allMusicClips = new List<AudioClip>(allMusicAudioData.Count);

            foreach (var audioData in allMusicAudioData)
                allMusicClips.Add(audioData.Clip);

            var clipsCount = allMusicClips.Count;

            var clipIndex = 0;
            while (!cancellationToken.IsCancellationRequested)
            {
                var clipDuration = (int)allMusicClips[clipIndex].length * 1000 + 1000;
                _gameAudioPlayer.PlayMusic(allMusicClips[clipIndex]);
                await UniTask.Delay(clipDuration, cancellationToken: cancellationToken);
                clipIndex++;
                if (clipIndex >= clipsCount)
                    clipIndex = 0;
            }
        }

        private void SetVolume()
        {
            var isSoundVolume = _savedDataRetrieveService.GetUserData().SettingsData.SoundVolume;
            _gameAudioPlayer.SetVolume(GameAudioType.Sound, isSoundVolume);

            var isMusicVolume = _savedDataRetrieveService.GetUserData().SettingsData.MusicVolume;
            _gameAudioPlayer.SetVolume(GameAudioType.Music, isMusicVolume);
        }
    }
}