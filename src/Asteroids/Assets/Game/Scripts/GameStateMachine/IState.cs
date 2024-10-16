using Cysharp.Threading.Tasks;

namespace com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine
{
    public interface IState<TPayload>: IRunnableState 
        where TPayload : class, IPayload
    {
        UniTask<TransitionPayload> Run(TPayload payload);
    }
}