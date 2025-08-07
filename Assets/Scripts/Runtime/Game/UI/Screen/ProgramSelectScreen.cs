using System;
using Runtime.Game.Services.UserData.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game.UI.Screen
{
    public class ProgramSelectScreen : UiScreen
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _easyButton;
        [SerializeField] private Button _normalButton;
        [SerializeField] private Button _hardButton;
        
        public event Action<DifficultyType> OnDifficultySelected;
        
        public event Action OnBackPressed;
        
        public void Initialize()
        {
            SubscribeEvents();
        }
        
        private void SubscribeEvents()
        {
            _backButton.onClick.AddListener(() => OnBackPressed?.Invoke());
            _easyButton.onClick.AddListener(() => OnDifficultySelected?.Invoke(DifficultyType.Easy));
            _normalButton.onClick.AddListener(() => OnDifficultySelected?.Invoke(DifficultyType.Normal));
            _hardButton.onClick.AddListener(() => OnDifficultySelected?.Invoke(DifficultyType.Hard));
        }
    }
}