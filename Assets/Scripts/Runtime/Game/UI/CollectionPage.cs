using DG.Tweening;
using UnityEngine;

namespace Runtime.Game.UI
{
    public class CollectionPage : MonoBehaviour
    {
        private const float AnimTime = 0.25f;
    
        [SerializeField] private CanvasGroup _canvasGroup;

        private Sequence _sequence;
    
        public void Show()
        {
            Animate(true);
        }

        public void Hide()
        {
            Animate(false);
        }

        private void Animate(bool enable)
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
        
            _canvasGroup.interactable = enable;
            _canvasGroup.blocksRaycasts = enable;
            _canvasGroup.DOFade(enable ? 1 : 0, AnimTime);
            _sequence.SetLink(gameObject);
        }
    }
}
