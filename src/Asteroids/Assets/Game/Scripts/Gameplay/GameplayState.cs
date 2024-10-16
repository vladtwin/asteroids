using System.Threading.Tasks;
using com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay;
using com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameplayState : BaseState<EmptyPayload>, IGameplayState
{
    private IGameLogic gameLogic;
    private IGameplayUI GameplayUI;

    public void Configure(IGameLogic gameLogic, IGameplayUI GameplayUI)
    {
        this.gameLogic = gameLogic;
        this.GameplayUI = GameplayUI;
    }

    public override async UniTask<TransitionPayload> Run(EmptyPayload payload)
    {
        var gameFinish = await gameLogic.RunGameplay();

        var gameState = await GameplayUI.WaitForPlayerAction(gameFinish);

        switch (gameState)
        {
            case GameFinishPlayerAction.Finish:
                await LoadScene(SceneName.MainSceneName);
                return TransitionPayload.Create<MainLobbyState, EmptyPayload>(null);
                break;
            case GameFinishPlayerAction.Retry:
                await LoadScene(SceneName.GameplaySceneName);
                return TransitionPayload.Create<GameplayState, EmptyPayload>(null);
                break;
            default:
                throw new StateMachineException($"Unknown game state {gameState}");
        }
    }

    private async UniTask LoadScene(string sceneName)
    {
        await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}