using System.Threading.Tasks;
using UnityEngine;

namespace com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay
{
    public interface IPlayerController
    {
        void SetSpawnPosition(Vector3 spawnPointPosition);
        Task WaitForEnemyKill();
    }
}