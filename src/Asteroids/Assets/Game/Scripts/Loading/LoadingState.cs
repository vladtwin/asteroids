using com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine;
using Cysharp.Threading.Tasks;

public class LoadingState :  BaseState<EmptyPayload>
{
    public override async UniTask<TransitionPayload> Run(EmptyPayload payload)
    {
        //waiting for some critical service initialization
        return TransitionPayload.Create<MainLobbyState, EmptyPayload>(null);
    }

    
}