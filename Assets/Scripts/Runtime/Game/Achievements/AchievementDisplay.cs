using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game.Achievements
{
    public class AchievementDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private Slider _slider;
        [SerializeField] private Button _claimButton;
    
        public event Action OnClaimed;
    
        public void Initialize(AchievementData achievementData)
        {
            float progress = achievementData.Progress / achievementData.Target;
        
            _nameText.text = achievementData.Name;
            _slider.value = progress;

            bool claimed = achievementData.Claimed;
            if (progress >= 1 && !claimed)
            {
                _claimButton.gameObject.SetActive(true);
                _claimButton.onClick.AddListener(() =>
                {
                    achievementData.Claimed = true;
                    _claimButton.gameObject.SetActive(false);
                    OnClaimed?.Invoke();
                });
            }
        }
    }
}
