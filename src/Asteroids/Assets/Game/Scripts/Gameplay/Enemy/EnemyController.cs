using System.Collections.Generic;
using com.asteroids.scripts.Gameplay;
using UnityEngine;
using Zenject;

namespace asteroids.scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyController : EntityBase
    {
        public Transform bulletSpawnPoint;

        private IEnemySettings settings;
        private Rigidbody2D rigidbody2D;
        
        [Inject]
        public void Construct(IEnemySettings settings)
        {
            this.settings = settings;

            var fireComponent = new AIFireComponent(this.settings, bulletSpawnPoint, transform,
                settings.BulletPrefab, settings.BulletsCount, settings.BulletSpeed);
            
            rigidbody2D = GetComponent<Rigidbody2D>();
            CharacterComponents = new List<ICharacterComponent>();
            CharacterComponents.Add(new EnemyMovementComponent(transform, settings, rigidbody2D));
            CharacterComponents.Add(fireComponent);
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                var player = collision.GetComponent<IHittable>();
                player?.Hit(gameObject);
                Death();
            }

        }
    }
}