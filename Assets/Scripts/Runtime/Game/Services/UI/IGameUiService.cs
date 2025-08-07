using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core.UI;
using Runtime.Game.UI.Screen;

namespace Runtime.Game.Services.UI
{
    public interface IGameUiService
    {
        UniTask Initialize();
        T GetScreen<T>(string id) where T : UiScreen;
        UniTask ShowScreen(string id, CancellationToken cancellationToken = default);
        UniTask HideScreen(string id, CancellationToken cancellationToken = default);
        UniTask<MyPopup> ShowPopup(string id, BasePopupData data = null, CancellationToken cancellationToken = default);
        T GetPopup<T>(string id) where T : MyPopup;
    }
}