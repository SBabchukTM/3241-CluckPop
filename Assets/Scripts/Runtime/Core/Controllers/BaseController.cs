using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.Assertions;

namespace Runtime.Core.Controllers
{
    public abstract class BaseController
    {
        protected ControllerState CurrentState = ControllerState.Pending;
        
        public virtual UniTask Run(CancellationToken cancellationToken)
        {
            Assert.IsFalse(CurrentState == ControllerState.Run, $"{this.GetType().Name}: try run already running controller");

            CurrentState = ControllerState.Run;
            return UniTask.CompletedTask;
        }
    }
}