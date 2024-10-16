using asteroids.scripts;
using com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay.PlayerInputSystem;
using UnityEngine;

namespace com.asteroids.scripts.Gameplay
{
    public class AIFireComponent : FireComponent
    {
        private IEnemySettings settings;
        private float fireInterval;
        private float timeToFire;
        
        public AIFireComponent(IEnemySettings settings, Transform firePoint, Transform playerPosition, GameObject bulletPrefab, int bulletCount, float bulletSpeed) : base(firePoint, playerPosition, bulletPrefab, bulletCount, bulletSpeed)
        {
            this.settings = settings;
        }

        public override void Start()
        {
            fireInterval = Random.Range(settings.MinFireDelay, settings.MaxFireDelay);
            timeToFire = fireInterval;
        }

        public override void Update()
        {
            timeToFire-= Time.deltaTime;
            if (timeToFire <= 0)
            {
                timeToFire = fireInterval;
                Fire();
            }
        }
    }
}