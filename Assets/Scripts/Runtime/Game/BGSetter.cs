using Runtime.Game.Services;
using Runtime.Game.Shop;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Runtime.Game
{
    public class BGSetter : MonoBehaviour
    {
        [SerializeField] private Image _image;
    
        [Inject]
        private ConfigsProvider _configsProvider;
    
        [Inject]
        private BackgroundsService _backgroundsService;

        private void Awake()
        {
            _image.sprite = _configsProvider.Get<BackgroundsConfig>().ShopItems[_backgroundsService.GetSelectedId()]
                .BackgroundSprite;
        }
    }
}
