using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay
{
    public class MainGameLogic : IGameLogic
    {
        public IMapState MapState;

        public Transform SpawnPoint;

        private int timeToEnemySpawn = 3000;
        private int timeToFirstSpawn = 2000;
        private int enemyCountToSpawn = 25;
        private int firstTimeEnemySpawnCount = 5;
        private CancellationTokenSource gameFinishToken;

        [Inject]
        public MainGameLogic(IMapState mapState)
        {
            MapState = mapState;
        }
        
        public async UniTask<GameFinishType> RunGameplay()
        {
            try
            {
                gameFinishToken = new CancellationTokenSource();
                MapState.Run(gameFinishToken);

                await UniTask.Delay(timeToFirstSpawn);

                for (var i = 0; i < firstTimeEnemySpawnCount; i++)
                {
                    MapState.SpawnEnemy();
                    enemyCountToSpawn--;
                }

                await MapState.WaitForKill();

                for (var i = 0; i < enemyCountToSpawn; i++)
                {
                    timeToEnemySpawn -= 100;
                    if (timeToFirstSpawn <= 0)
                        continue;

                    await UniTask.Delay(timeToEnemySpawn, cancellationToken: gameFinishToken.Token);

                    if (gameFinishToken.IsCancellationRequested)
                        return new GameFinishType() { EnemyKilled = MapState.KilledCount, IsWin = false };

                    MapState.SpawnEnemy();
                }

                await MapState.WaitForKillAllEnemy();
                return new GameFinishType() { EnemyKilled = MapState.KilledCount, IsWin = true };

            }
            catch (Exception ex)
            {
                return new GameFinishType() { EnemyKilled = MapState.KilledCount, IsWin = false };
            }
        }
    }
}