using System;
using DG.Tweening;
using Runtime.Core.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game.UI.Popup
{
    public class PurchaseProgramPopup : MyPopup
    {
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private GameObject _priceGO;
        [SerializeField] private GameObject _freeGO;
        [SerializeField] private TextMeshProUGUI _errorText;
        
        private Sequence _sequence;
        
        public event Action OnPurchased;
        
        public void SetData(int price, string description)
        {
            _closeButton.onClick.AddListener(DestroyPopup);
            _buyButton.onClick.AddListener(() =>
            {
                OnPurchased?.Invoke();
            });
            
            _text.text = $"BUY {description}\nPROGRAM";

            if (price > 0)
            {
                _priceText.text = price.ToString();
                _priceGO.SetActive(true);
            }
            else
            {
                _freeGO.SetActive(true);
            }
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
    }
}