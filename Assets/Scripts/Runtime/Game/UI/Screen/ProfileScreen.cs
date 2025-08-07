using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game.UI.Screen
{
    public class ProfileScreen : UiScreen
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _displayButton;
        [SerializeField] private Image _image;
        
        public event Action OnBackPressed;
        
        public event Action OnDisplayPressed;
        
        public void Initialize()
        {
            SubscribeEvents();
        }
        
        private void SubscribeEvents()
        {
            _backButton.onClick.AddListener(() => OnBackPressed?.Invoke());
            _displayButton.onClick.AddListener(() => OnDisplayPressed?.Invoke());
        }

        public void SetDisplay(Sprite displaySprite)
        {
            if (!displaySprite)
            {
                _image.gameObject.SetActive(false);
                return;
            }
            
            _image.sprite = displaySprite;
            _image.gameObject.SetActive(true);
        }
    }
}