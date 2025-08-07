using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game.UI.Screen
{
    public class ShopScreen : UiScreen
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _actionButton;
        [SerializeField] private TextMeshProUGUI _actionText;

        [SerializeField] private RectTransform _pivotPoint;
        [SerializeField] private TextMeshProUGUI _errorText;

        [SerializeField] private List<ShopItemDisplay> _shopItems = new List<ShopItemDisplay>();
        [SerializeField] private PageScroller _pageScroller;
        
        private Sequence _sequence;
        
        public event Action OnBackPressed;
        public event Action OnActionPressed;
        
        private ShopItemDisplay _closestItem;

        public ShopItemDisplay GetClosest => _closestItem;
        
        public List<ShopItemDisplay> GetItems () =>_shopItems;

        private void Start()
        {
            _closestItem = _shopItems[0];
            _pageScroller.OnPageChanged += UpdateClosest;
        }

        private void Update()
        {
            UpdateActionText();
        }

        public void Initialize()
        {
            SubscribeEvents();
        }

        private void UpdateClosest(int obj)
        {
            _closestItem = _shopItems[obj];
        }

        public void ShowError()
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();

            _sequence.Append(_errorText.DOFade(1, 0.2f));
            _sequence.AppendInterval(0.5f);
            _sequence.Append(_errorText.DOFade(0, 0.2f));
            _sequence.SetLink(gameObject);
        }
        
        private void UpdateActionText()
        {
            if(_closestItem.IsLocked)
                _actionText.text = "BUY";
            else
            if(!_closestItem.IsSelected)
                _actionText.text = "SELECT";
            else
                _actionText.text = "USED";
        }

        private void SubscribeEvents()
        {
            _backButton.onClick.AddListener(() => OnBackPressed?.Invoke());
            _actionButton.onClick.AddListener(() => OnActionPressed?.Invoke());
        }
    }
}