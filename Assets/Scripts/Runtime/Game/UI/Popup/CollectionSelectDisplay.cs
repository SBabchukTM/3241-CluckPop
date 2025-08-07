using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game.UI.Popup
{
    public class CollectionSelectDisplay : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;

        public event Action<int, int> OnSelected;
    
        public void Initialize(Sprite sprite, int chickenId, int growPhase)
        {
            _image.sprite = sprite;
            _button.onClick.AddListener(() => OnSelected?.Invoke(chickenId, growPhase)); 
        }
    }
}
