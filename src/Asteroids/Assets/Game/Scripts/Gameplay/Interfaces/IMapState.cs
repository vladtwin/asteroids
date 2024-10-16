using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay
{
    public interface IMapState
    {
        void Run(CancellationTokenSource gameFinishedToken);
        int LifeCount { get; }
        int KilledCount { get; }
        void SpawnEnemy();
        UniTask WaitForKillAllEnemy();
        UniTask WaitForKill();
    }
}