using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Runtime.Core.UI
{
    public class MyPopup : MonoBehaviour
    {
        private const string OpenPopupSound = "OpenPopup";
        private const string ClosePopupSound = "ClosePopupSound";
        
        [SerializeField] protected string _id;

        protected IGameAudioPlayer GameAudioPlayer;

        public event Action DestroyPopupEvent;

        public string Id => _id;

        [Inject]
        public void Construct(IGameAudioPlayer gameAudioPlayer)
        {
            GameAudioPlayer = gameAudioPlayer;
        }

        public virtual UniTask Show(BasePopupData data, CancellationToken cancellationToken = default)
        {
            TryPlaySound(OpenPopupSound);
            return UniTask.CompletedTask;
        }

        public virtual void DestroyPopup()
        {
            DestroyPopupEvent?.Invoke();
            TryPlaySound(ClosePopupSound);
            Destroy(gameObject);
        }
        
        protected void TryPlaySound(string soundName)
        {
            GameAudioPlayer.PlaySound(soundName);
        }
    }
}