using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.Core.Infrastructure;

namespace Runtime.Core.GameStateMachine
{
    public abstract class StateController
    {
        private StateMachine _stateMachine;

        protected readonly ILogger Logger;

        protected StateController(ILogger logger)
        {
            Logger = logger;
        }

        public void SetMachine(StateMachine stateMachine) => _stateMachine = stateMachine;

        public abstract UniTask Enter(CancellationToken cancellationToken = default);

        public virtual UniTask ExitState() => UniTask.CompletedTask;

        protected async UniTask EnterState<T>(CancellationToken cancellationToken = default) where T : StateController => await _stateMachine.GoTo<T>(cancellationToken);
    }
}