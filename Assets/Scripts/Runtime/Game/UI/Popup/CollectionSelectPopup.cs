using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Runtime.Game.UI.Popup
{
    public class CollectionSelectPopup : MyPopup
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private RectTransform _content;
        [SerializeField] private GameObject _errorGo;
        
        [Inject]
        private CollectionSelectFactory _factory;

        public event Action<int, int> OnSelected;

        public override UniTask Show(BasePopupData data, CancellationToken cancellationToken = default)
        {
            _closeButton.onClick.AddListener(DestroyPopup);

            var list = _factory.GetCollectionSelectDisplays();
            _errorGo.SetActive(list.Count == 0);
            foreach (var item in list)
            {
                item.transform.SetParent(_content, false);
                item.OnSelected += (a,b) =>
                {
                    OnSelected?.Invoke(a, b);
                    DestroyPopup();
                };
            }
            
            return base.Show(data, cancellationToken);
        }
    }
}