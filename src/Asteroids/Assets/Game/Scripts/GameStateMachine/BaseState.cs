using System;
using Cysharp.Threading.Tasks;

namespace com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine
{
    public abstract class BaseState<TPayload> : IState<TPayload> where TPayload : class, IPayload
    {
        protected TPayload payload;
        public abstract UniTask<TransitionPayload> Run(TPayload payload);

        public virtual async UniTask<TransitionPayload> RunState(IPayload inputPayload)
        {
            if (inputPayload == null)
            {
                inputPayload = Activator.CreateInstance<TPayload>();
                inputPayload.IsNull = true;
            }

            payload = inputPayload as TPayload;

            if (payload == null)
                throw new StateMachineException(
                    $"Received payload \"{inputPayload.GetType().Name}\" instead of \"{typeof(TPayload).Name}\"");

            var transition = await Run(payload);

            return transition;
        }
    }
}