using System.Collections.Generic;
using Runtime.Core.UI;
using Runtime.Game.UI.Screen;
using UnityEngine;

namespace Runtime.Game.Services.UI
{
    public sealed class UiServiceViewContainer : MonoBehaviour
    {
        [SerializeField] private ScreenFade _screenFade;
        [SerializeField] private List<UiScreen> _screensPrefab;
        [SerializeField] private List<MyPopup> _popupsPrefab;
        [SerializeField] private Transform _screenParent;

        public ScreenFade ScreenFade => _screenFade;
        public List<UiScreen> ScreensPrefab => _screensPrefab;
        public List<MyPopup> PopupsPrefab => _popupsPrefab;
        public Transform ScreenParent => _screenParent;
    }
}