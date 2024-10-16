using com.asteroids.scripts.Lobby.Game.Scripts.Lobby;
using com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class MainLobbyState :  BaseState<EmptyPayload>
{
    
    private StateExitTypeEnum exitType = StateExitTypeEnum.None;
    
    public override async UniTask<TransitionPayload> Run(EmptyPayload payload)
    {
        exitType = StateExitTypeEnum.None;
        await UniTask.WaitUntil(() => exitType != StateExitTypeEnum.None);

        switch (exitType)
        {
            case StateExitTypeEnum.ToGame:
                return await TransitionToMiniGame();
        }
        
        throw new StateMachineException($"Unknown exit type {exitType} for {nameof(MainLobbyState)}");
    }
    
    public void SetState(StateExitTypeEnum exitType)
    {
        this.exitType = exitType;
    }
    
    private async UniTask<TransitionPayload> TransitionToMiniGame()
    {
        await LoadScene(SceneName.GameplaySceneName);
        return TransitionPayload.Create<GameplayState,EmptyPayload>(null);
    }
    
    private async UniTask LoadScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name == sceneName)
            return;

        await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}