using System;

namespace com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine
{
    public interface IGameStateMachine
    {
        bool IsInitialized { get; }
        IRunnableState ActiveState { get;}
        
        event Action<TransitionPayload> OnTransitionStarted;
        event Action<Type> OnStateExited;
        event Action<ExitPayload> OnStateMachineExited;
        
        void StartStateMachine(TransitionPayload payload); 
    }
}
