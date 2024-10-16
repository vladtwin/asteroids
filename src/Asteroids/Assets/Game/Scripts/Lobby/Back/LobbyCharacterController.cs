using System.Collections.Generic;
using com.asteroids.scripts.Gameplay;
using UnityEngine;
using Zenject;

namespace asteroids.scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class LobbyCharacterController : EntityBase
    {
        public Transform bulletSpawnPoint;
        public BulletComponent BulletPrefab;
        private IEnemySettings settings;
        
        [Inject]
        public void Construct()
        {
            settings = new EnemySettingsMoc(0, 5, 0, 0, 1, 3, BulletPrefab.gameObject, 10, 15);
            var fireComponent = new AIFireComponent(this.settings, bulletSpawnPoint, transform,
                settings.BulletPrefab, settings.BulletsCount,  settings.BulletSpeed);
            
            CharacterComponents = new List<ICharacterComponent>();
            CharacterComponents.Add(new LobbyMovementComponent(transform,settings.MaxSpeed));
            CharacterComponents.Add(fireComponent);
        }
        
    }
}