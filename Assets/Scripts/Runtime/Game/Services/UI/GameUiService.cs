using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core.Factory;
using Runtime.Core.Infrastructure;
using Runtime.Core.UI;
using Runtime.Game.UI.Screen;
using UnityEngine;
using Zenject;

namespace Runtime.Game.Services.UI
{
    public sealed class GameUiService : IGameUiService
    {
        private readonly Dictionary<string, UiScreen> _shownScreens = new Dictionary<string, UiScreen>();
        
        private IAssetProvider _assetProvider;
        private Dictionary<string, GameObject> _screenPrototypes;
        private Dictionary<string, GameObject> _popupPrototypes;
        private GameObjectFactory _factory;
        private UiServiceViewContainer _uiServiceViewContainer;

        public Dictionary<string, UiScreen> ShownScreens => _shownScreens;

        [Inject] 
        private void Construct(GameObjectFactory factory, IAssetProvider assetProvider)
        {
            _factory = factory;
            _assetProvider = assetProvider;
        }

        public async UniTask Initialize()
        {
            GameObject container = await _assetProvider.Instantiate(ConstScreens.UiServiceViewContainer);
            _uiServiceViewContainer = container.GetComponent<UiServiceViewContainer>();

            Add1();

            Add2();
        }

        private void Add2()
        {
            _popupPrototypes = new Dictionary<string, GameObject>(_uiServiceViewContainer.PopupsPrefab.Count);
            foreach (var popup in _uiServiceViewContainer.PopupsPrefab)
            {
                if (!_popupPrototypes.ContainsKey(popup.Id))
                {
                    _popupPrototypes.Add(popup.Id, popup.gameObject);
                }
            }
        }

        private void Add1()
        {
            _screenPrototypes = new Dictionary<string, GameObject>(_uiServiceViewContainer.ScreensPrefab.Count);
            foreach (var screen in _uiServiceViewContainer.ScreensPrefab)
            {
                if (!_screenPrototypes.ContainsKey(screen.Id))
                {
                    _screenPrototypes.Add(screen.Id, screen.gameObject);
                }
            }
        }

        public async UniTask ShowScreen(string id, CancellationToken cancellationToken = default)
        {
            if (TryGetShownScreen(id, out UiScreen screen))
            {
                await screen.ShowAsync(cancellationToken);
            }
            else
            {
                screen = CreateScreen(id);
                _shownScreens.Add(id, screen);
                await screen.ShowAsync(cancellationToken);
            }
        }

        public T GetScreen<T>(string id) where T : UiScreen
        {
            if (!TryGetShownScreen(id, out UiScreen screen))
            {
                screen = CreateScreen(id);
                _shownScreens.Add(id, screen);
                screen.HideImmediately();
            }

            return screen as T;
        }

        public async UniTask HideScreen(string id, CancellationToken cancellationToken = default)
        {
            if (TryGetShownScreen(id, out UiScreen screen))
            {
                await screen.HideAsync(cancellationToken);
                _shownScreens.Remove(id);
            }
        }
        
        public async UniTask<MyPopup> ShowPopup(string id, BasePopupData data = null, CancellationToken cancellationToken = default)
        {
            if (_popupPrototypes.TryGetValue(id, out GameObject prototype))
            {
                var popup = _factory.Create<MyPopup>(prototype, _uiServiceViewContainer.ScreenParent);
                await popup.Show(data, cancellationToken);
                return popup;
            }

            throw new ArgumentException($"Prototype for '{id}' is not registered.");
        }

        public T GetPopup<T>(string id) where T : MyPopup
        {
            if (_popupPrototypes.TryGetValue(id, out GameObject prototype))
            {
                var popup = _factory.Create<T>(prototype, _uiServiceViewContainer.ScreenParent);
                return popup;
            }

            throw new ArgumentException($"Prototype for '{id}' is not registered.");
        }

        private bool TryGetShownScreen(string id, out UiScreen screen)
        {
            if (_shownScreens.TryGetValue(id, out screen))
                return true;

            return false;
        }

        private UiScreen CreateScreen(string id)
        {
            if (_screenPrototypes.TryGetValue(id, out GameObject prototype))
                return _factory.Create<UiScreen>(prototype, _uiServiceViewContainer.ScreenParent);

            throw new ArgumentException($"Prototype for '{id}' is not registered.");
        }
    }
}