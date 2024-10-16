using Cysharp.Threading.Tasks;

namespace com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay
{
    public interface IGameLogic
    {
        UniTask<GameFinishType> RunGameplay();
    }
}