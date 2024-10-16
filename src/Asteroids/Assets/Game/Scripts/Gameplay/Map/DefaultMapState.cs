using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using ModestTree;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay
{
    public class DefaultMapState : MonoBehaviour, IMapState
    {
        public int LifeCount { get; private set; }
        public int KilledCount { get; private set; }

        public GameObject EnemyPrefab;
        public EntityBase Player;
        public List<GameObject> SpawnPlaces;

        private ObjectPool<EntityBase> entityPool;
        private DiContainer container;
        private CancellationTokenSource gameFinishedToken;

        [Inject]
        public void Construct(DiContainer container)
        {
            this.container = container;
        }
        
        public void Run(CancellationTokenSource gameFinishedToken)
        {
            this.gameFinishedToken = gameFinishedToken;
          
            
            entityPool = new ObjectPool<EntityBase>(
                () =>
                {
                   var entity = container.InstantiatePrefab(EnemyPrefab).GetComponent<EntityBase>();
                   return entity;
                },
                entity =>
                {
                    entity.gameObject.SetActive(true);
                }, entity =>
                {
                    entity.gameObject.SetActive(false);
                },
                null);
            LifeCount = 3;
            Player.OnDeath += () =>
            {
                LifeCount--;
                if (LifeCount <= 0)
                    FinishGame();
            };

            Player.OnKill += () =>
            {
                KilledCount++;
            };

            MovePlayerToSpawnLocation();
        }

        private void FinishGame()
        {
            gameFinishedToken.Cancel();
            GameObject.Destroy(Player.gameObject);
        }
        
        public void SpawnEnemy()
        {
            var position = FindRandomSpawnLocation();
            var enemy = entityPool.Get();
            enemy.SetPool(entityPool);
            enemy.transform.position = position;
        }

        public void MovePlayerToSpawnLocation()
        {
            var position = FindRandomSpawnLocation();
            Player.transform.position = position;
            Player.transform.rotation = Quaternion.identity;
        }

        public  async UniTask WaitForKillAllEnemy()
        {
           await UniTask.WaitUntil(()=>entityPool.CountActive == 0, PlayerLoopTiming.Update,cancellationToken: gameFinishedToken.Token);
        }

        public async UniTask WaitForKill()
        {
            await UniTask.WaitWhile(()=>KilledCount == 0, cancellationToken:gameFinishedToken.Token);
        }

        private Vector2 FindRandomSpawnLocation()
        {
            const int tryFindSpawnPoint = 20;
            for (int i = 0; i < tryFindSpawnPoint; i++)
            {
                var randomSpawnPlace = SpawnPlaces[Random.Range(0, SpawnPlaces.Count)];
           
                var randomX = Random.Range(-randomSpawnPlace.transform.localScale.x,
                    randomSpawnPlace.transform.localScale.x) / 2f;
                var randomY = Random.Range(-randomSpawnPlace.transform.localScale.y,
                    randomSpawnPlace.transform.localScale.y) / 2f;

                var worldX = randomX + randomSpawnPlace.transform.position.x;
                var worldY = randomY + randomSpawnPlace.transform.position.y;
                var vector = new Vector2(worldX, worldY);
                if (IsFreeSpace(vector))
                    return new Vector2(worldX, worldY);
            }

            return Vector2.zero;
        }

        private bool IsFreeSpace(Vector2 vector) =>
            !Physics2D.BoxCast(vector, new Vector2(2, 2), 0, Vector2.zero);
    }
}