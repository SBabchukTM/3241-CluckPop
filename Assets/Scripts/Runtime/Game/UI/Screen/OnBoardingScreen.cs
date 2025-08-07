using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game.UI.Screen
{
    public class OnBoardingScreen : UiScreen
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private PageScroller _pageScroller;
        [SerializeField] private GameObject _circles;
        

        public event Action OnOnboardingEnded;
        
        public void Initialize()
        {
            SubscribeEvents();
        }
        
        private void SubscribeEvents()
        {
            _pageScroller.OnPageChanged += index =>
            {
                if (index == _pageScroller.PagesCount - 1)
                {
                    _startButton.gameObject.SetActive(true);
                    _circles.SetActive(false);
                    _startButton.onClick.AddListener(() =>
                    {
                        OnOnboardingEnded?.Invoke();
                    });
                }
            };
        }
    }
}