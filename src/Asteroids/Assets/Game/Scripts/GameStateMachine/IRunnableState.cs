using Cysharp.Threading.Tasks;

namespace com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine
{
    public interface IRunnableState
    {
        UniTask<TransitionPayload> RunState(IPayload inputPayload);
    }
}