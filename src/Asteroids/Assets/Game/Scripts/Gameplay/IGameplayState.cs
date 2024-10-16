using com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay;

public interface IGameplayState
{
    void Configure(IGameLogic gameLogic, IGameplayUI GameplayUI);
}