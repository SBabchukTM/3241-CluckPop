using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core.UI;
using Runtime.Game.Services.Audio;
using Runtime.Game.Services.UserData.Data;
using Runtime.Game.UI.Popup.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game.UI.Popup
{
    public class SettingsPopup : MyPopup
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Slider _soundSlider;
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Button _ppButton;
        [SerializeField] private Button _touButton;
        
        public event Action<float> SoundVolumeChangeEvent;
        public event Action<float> MusicVolumeChangeEvent;
        public event Action OnPPPressed;
        public event Action OnToUressed;
        

        public override UniTask Show(BasePopupData data, CancellationToken cancellationToken = default)
        {
            SettingsPopupData settingsPopupData = data as SettingsPopupData;

            var isSoundVolume = settingsPopupData.SoundVolume;
            _soundSlider.value = isSoundVolume;
            
            var isMusicVolume = settingsPopupData.MusicVolume;
            _musicSlider.value = isMusicVolume;

            _closeButton.onClick.AddListener(DestroyPopup);

            _soundSlider.onValueChanged.AddListener(OnSoundVolumeToggleValueChanged);
            _musicSlider.onValueChanged.AddListener(OnMusicVolumeToggleValueChanged);
            
            _ppButton.onClick.AddListener(() => OnPPPressed?.Invoke());
            _touButton.onClick.AddListener(() => OnToUressed?.Invoke());

            GameAudioPlayer.PlaySound(ConstAudio.OpenPopupSound);

            return base.Show(data, cancellationToken);
        }

        public override void DestroyPopup()
        {
            GameAudioPlayer.PlaySound(ConstAudio.PressButtonSound);
            Destroy(gameObject);
        }

        private void OnSoundVolumeToggleValueChanged(float value)
        {
            SoundVolumeChangeEvent?.Invoke(value);
        }

        private void OnMusicVolumeToggleValueChanged(float value)
        {
            MusicVolumeChangeEvent?.Invoke(value);
        }
    }
}