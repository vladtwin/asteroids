using System.Threading.Tasks;

namespace com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay
{
    public interface IGameplayUI
    {
        Task<GameFinishPlayerAction> WaitForPlayerAction(GameFinishType gameFinish);
    }
}