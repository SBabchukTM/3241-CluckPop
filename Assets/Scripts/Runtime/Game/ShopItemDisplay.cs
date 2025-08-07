using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game
{
    public class ShopItemDisplay : MonoBehaviour
    {
        [SerializeField] private Color _lockedColor;
    
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private GameObject _priceGO;

        private bool _isLocked;
        private bool _isSelected;
        private int _price;
    
        public bool IsLocked => _isLocked;
        public bool IsSelected => _isSelected;
        public int Price => _price;
    
        public void Initialize(ShopItem shopItem)
        {
            _image.sprite = shopItem.BackgroundSprite;
            _priceText.text = shopItem.Price.ToString();
            _price = shopItem.Price;
        }

        public void SetLocked()
        {
            _image.color = _lockedColor;
            _priceGO.SetActive(true);
            _isLocked = true;
            _isSelected = false;
        }

        public void SetUnlocked(bool isSelected)
        {
            _image.color = Color.white;
            _priceGO.SetActive(false);
        
            _isLocked = false;
            _isSelected = isSelected;
        }
    }
}
