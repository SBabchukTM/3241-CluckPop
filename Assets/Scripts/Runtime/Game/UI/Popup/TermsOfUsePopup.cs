using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game.UI.Popup
{
    public class TermsOfUsePopup : MyPopup
    {
        [SerializeField] private Button _closeButton;

        public override UniTask Show(BasePopupData data, CancellationToken cancellationToken = default)
        {
            _closeButton.onClick.AddListener(DestroyPopup);
            return base.Show(data, cancellationToken);
        }
    }
}