using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game
{
    public class ChickenColectionDisplay : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void SetImage(Sprite sprite, bool locked)
        {
            _image.sprite = sprite;
            if(locked)
                _image.color = Color.black;
        }
    }
}
