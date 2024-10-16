using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Zenject;

namespace com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine
{
    public abstract class BaseStateMachine : IGameStateMachine
    {
        protected Dictionary<Type, IRunnableState> states;
        
        public bool IsInitialized { get; private set; }
        public IRunnableState ActiveState { get; private set; }
        
        public event Action<TransitionPayload> OnTransitionStarted;
        public event Action<Type> OnStateExited;
        public event Action<ExitPayload> OnStateMachineExited;
        private DiContainer container;
        [Inject]
        protected BaseStateMachine(DiContainer container)
        {
          
            this.container = container;
        }
        
        public void StartStateMachine(TransitionPayload payload)
        {
            if (IsInitialized)
                return;
            
            IsInitialized = true;
            
            Enter(payload);
        }

        private async UniTaskVoid Enter(TransitionPayload payload)
        {
            if (ActiveState != null)
                OnStateExited?.Invoke(ActiveState.GetType());

            if (IsExitPayloadReceived(payload))
            {
                OnStateMachineExited?.Invoke((ExitPayload)payload.statePayload);
                return;
            }

            var state = GetState(payload.destinationState);
            ActiveState = state;
            
            OnTransitionStarted?.Invoke(payload);
            var transitionPayload = await state.RunState(payload.statePayload);
            Enter(transitionPayload).Forget();
        }

        private bool IsExitPayloadReceived(TransitionPayload payload) =>
            payload != null && payload.statePayload is ExitPayload;

        protected IRunnableState GetState(Type stateType)
        {
            return (IRunnableState) ProjectContext.Instance.Container.Resolve(stateType);
        }
    }
}