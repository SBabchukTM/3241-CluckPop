using System;
using System.Collections.Generic;
using DG.Tweening;
using Runtime.Game.Achievements;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game.UI.Screen
{
    public class AchievementsScreen : UiScreen
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private RectTransform _content;
        [SerializeField] private CanvasGroup _rewardCanvas;
        
        private Sequence _rewardSequence;
        
        public event Action OnBackPressed;
        
        public void Initialize(List<AchievementDisplay> achievements)
        {
            SubscribeEvents();

            foreach (var achievement in achievements) 
                achievement.transform.SetParent(_content, false);
        }
        
        public void DisplayReward()
        {
            _rewardSequence?.Kill();
            _rewardSequence = DOTween.Sequence();

            _rewardCanvas.alpha = 0;
            
            _rewardSequence.Append(_rewardCanvas.DOFade(1, 0.15f));
            _rewardSequence.AppendInterval(0.34f);
            _rewardSequence.Append(_rewardCanvas.DOFade(0, 0.15f));
        }
        
        private void SubscribeEvents()
        {
            _backButton.onClick.AddListener(() => OnBackPressed?.Invoke());
        }
    }
}