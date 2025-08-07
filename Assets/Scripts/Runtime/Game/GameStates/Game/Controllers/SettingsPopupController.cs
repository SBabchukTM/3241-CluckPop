using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core;
using Runtime.Core.Controllers;
using Runtime.Game.Services.UI;
using Runtime.Game.Services.UserData;
using Runtime.Game.Services.UserData.Data;
using Runtime.Game.UI.Popup;
using Runtime.Game.UI.Popup.Data;

namespace Runtime.Game.GameStates.Game.Controllers
{
    public sealed class SettingsPopupController : BaseController
    {
        private readonly IGameUiService _gameUiService;
        private readonly SavedDataRetrieveService _savedDataRetrieveService;
        private readonly IGameAudioPlayer _gameAudioPlayer;

        public SettingsPopupController(IGameUiService gameUiService, SavedDataRetrieveService savedDataRetrieveService, IGameAudioPlayer gameAudioPlayer)
        {
            _gameUiService = gameUiService;
            _savedDataRetrieveService = savedDataRetrieveService;
            _gameAudioPlayer = gameAudioPlayer;
        }

        public override UniTask Run(CancellationToken cancellationToken)
        {
            base.Run(cancellationToken);

            SettingsPopup settingsPopup = _gameUiService.GetPopup<SettingsPopup>(ConstPopups.SettingsPopup);

            Sub(settingsPopup);

            var userData = _savedDataRetrieveService.GetUserData();

            var isSoundVolume = userData.SettingsData.SoundVolume;
            var isMusicVolume = userData.SettingsData.MusicVolume;

            settingsPopup.Show(new SettingsPopupData(isSoundVolume, isMusicVolume), cancellationToken).Forget();
            CurrentState = ControllerState.Complete;
            return UniTask.CompletedTask;
        }

        private void Sub(SettingsPopup settingsPopup)
        {
            settingsPopup.SoundVolumeChangeEvent += Sound;
            settingsPopup.MusicVolumeChangeEvent += Music;
            settingsPopup.OnToUressed += async () => await _gameUiService.ShowPopup(ConstPopups.TermsOfUsePopup);
            settingsPopup.OnPPPressed += async () => await _gameUiService.ShowPopup(ConstPopups.PrivacyPolicyPopup);
        }


        private void Sound(float state)
        {
            _gameAudioPlayer.SetVolume(GameAudioType.Sound, state);
            var userData = _savedDataRetrieveService.GetUserData();
            userData.SettingsData.SoundVolume = state;
        }

        private void Music(float state)
        {
            _gameAudioPlayer.SetVolume(GameAudioType.Music, state);
            var userData = _savedDataRetrieveService.GetUserData();
            userData.SettingsData.MusicVolume = state;
        }
    }
}