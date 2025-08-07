using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Runtime.Core.GameStateMachine
{
    public class StateMachine
    {
        private Dictionary<Type, StateController> _states;
        private StateController _activeState;

        public void SetStates(params StateController[] stateControllers)
        {
            Init(stateControllers);
            Add(stateControllers);
        }

        private void Add(StateController[] stateControllers)
        {
            foreach (var executiveStateController in stateControllers)
            {
                _states.Add(executiveStateController.GetType(), executiveStateController);
                executiveStateController.SetMachine(this);
            }
        }

        private void Init(StateController[] stateControllers)
        {
            _states = new Dictionary<Type, StateController>(stateControllers.Length);
        }

        public async UniTask GoTo<TState>(CancellationToken cancellationToken = default) where TState : StateController
        {
            StateController state = await ChangeState<TState>();
            await state.Enter(cancellationToken);
        }

        private async UniTask<TState> ChangeState<TState>() where TState : StateController
        {
            if (_activeState != null)
                await _activeState.ExitState();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class
        {
            return _states[typeof(TState)] as TState;
        }
    }
}