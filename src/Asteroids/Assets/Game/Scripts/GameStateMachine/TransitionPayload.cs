using System;
using Cysharp.Threading.Tasks;

namespace com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine
{
    public class TransitionPayload
    {
        public Type destinationState;
        public IPayload statePayload;

        private TransitionPayload(Type state, IPayload payload)
        {
            destinationState = state;
            statePayload = payload;
        }

        public static TransitionPayload Create<TState, TPayload>(TPayload statePayload)
            where TState : class, IRunnableState
            where TPayload : class, IPayload =>
            new(typeof(TState), statePayload);

        public static TransitionPayload CreateExitPayload<TPayload>(TPayload exitPayload)
            where TPayload : class, IPayload
        {
            ExitPayload payload = new ExitPayload(exitPayload, exitPayload == null);
            return new TransitionPayload(typeof(IRunnableState), payload);
        }
        
    }
}