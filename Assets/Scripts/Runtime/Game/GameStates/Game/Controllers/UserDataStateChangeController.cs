using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core.Controllers;
using Runtime.Game.Services.ApplicationState;
using Runtime.Game.Services.UserData;

namespace Runtime.Game.GameStates.Game.Controllers
{
    public class UserDataStateChangeController : BaseController
    {
        private readonly ApplicationStateService _applicationStateService;
        private readonly SavedDataRetrieveService _savedDataRetrieveService;

        public UserDataStateChangeController(ApplicationStateService applicationStateService,
            SavedDataRetrieveService savedDataRetrieveService)
        {
            _applicationStateService = applicationStateService;
            _savedDataRetrieveService = savedDataRetrieveService;
        }

        public override UniTask Run(CancellationToken cancellationToken)
        {
            base.Run(cancellationToken);

            _applicationStateService.Initialize();

            _applicationStateService.ApplicationQuitEvent += OnQuitApplicationHandler;
            _applicationStateService.ApplicationPauseEvent += OnPauseApplicationHandler;

            return UniTask.CompletedTask;
        }

        private void OnQuitApplicationHandler()
        {
            _savedDataRetrieveService.SaveUserData();
        }

        private void OnPauseApplicationHandler(bool isPause)
        {
            if (isPause)
                _savedDataRetrieveService.SaveUserData();
        }
    }
}